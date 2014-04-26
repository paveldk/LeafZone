using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;

namespace ImageProcessingServices.Infrastructure.NeuroneNetwork
{
    /// <summary>
    /// Class for handling Neural Net. We are using back propagation over 1-(Perceptron), 2- or 3-layer neural net. 
    /// Currently training and recognition is sync operation. In the future it will be refactored to be async operation.
    /// </summary>
    public class NeuroneEnter
    {

        #region Members
        //Neural Network Object With Output Type String
        private NeuralNetwork<string> neuralNetwork = null;

        //Data Members Required For Neural Network
        private Dictionary<string, double[]> TrainingSet = null;
        private int averageImageHeight = 0;
        private int averageImageWidth = 0;
        private int numOfPatterns = 0;
        string[] patterns;
        #endregion

        #region Constructor
        public NeuroneEnter() : this(@"C:\work\LeafZone\ImageProcessingServices\ImageProcessingServices\ImageProcessingServices\Infrastructure\NeuroneNetwork\source")
        {
        }
        public NeuroneEnter(string patternDirectory)
        {
            patterns = InitializePatterns(patternDirectory);
            GenerateTrainingSet();
            CreateNeuralNetwork();
            neuralNetwork.Train();
        }
        #endregion

        #region Methods

        /// <summary>
        /// Initializes the pattern images from a given folder
        /// </summary>
        /// <param name="folderPath">Path to the folder containing the images</param>
        /// <returns>Array with the names of the images</returns>
        private string[] InitializePatterns(string folderPath)
        {
            return Directory.GetFiles(folderPath, "*.bmp");
        }

        /// <summary>
        /// Finds the average height and width of the patterns(images)
        /// </summary>
        private void FindAverageDimensions()
        {
            try
            {
                numOfPatterns = patterns.Length;

                averageImageHeight = 0;
                averageImageWidth = 0;

                foreach (string imagePath in patterns)
                {
                    using (Bitmap image = new Bitmap(imagePath))
                    {
                        averageImageHeight += image.Height;
                        averageImageWidth += image.Width;
                    }
                }

                averageImageHeight /= numOfPatterns;
                averageImageWidth /= numOfPatterns;
            }
            catch (Exception)
            {
                //should be handles somehow in the future
            }

        }

        /// <summary>
        /// Creates the Neural Network with the rescaled images. The number of patterns is the number of the files in the given directory.
        /// </summary>
        private void CreateNeuralNetwork()
        {
            neuralNetwork = new NeuralNetwork<string>
                (new BP1Layer<string>(averageImageHeight * averageImageWidth, numOfPatterns), TrainingSet);

            neuralNetwork.MaximumError = Double.Parse("1.2");
        }

        /// <summary>
        /// Generates the training set for the Neural Network. All images need to be scaled to the same height and width prior to the learning!
        /// Otherwise the feature matrix will map random pixels to a specific feature for the differnet images.
        /// </summary>
        private void GenerateTrainingSet()
        {
            TrainingSet = new Dictionary<string, double[]>(patterns.Length);
            foreach (string pattern in patterns)
            {
                using (Bitmap patternImage = new Bitmap(pattern))
                {
                    Bitmap scaledPatternImage = ImageProcessing.ScaleImage(patternImage, averageImageHeight, averageImageWidth);
                    TrainingSet.Add(Path.GetFileNameWithoutExtension(pattern),
                    ImageProcessing.ToMatrix(scaledPatternImage, averageImageHeight, averageImageWidth));
                }
            }
        }

        /// <summary>
        /// Recognizes the given image. Returns the image with the highest probability only.
        /// </summary>
        /// <param name="imageToRecognize">The bmp image to be recognized.</param>
        /// <returns></returns>
        public string Recognize(Bitmap imageToRecognize)
        {
            //in the future the functionality can be extended to a set of matched probabilities.
            string matchedHigh = "?", matechedLow = "?";
            double outputValueHigh = 0, outputValueLow = 0;

            double[] input = ImageProcessing.ToMatrix(imageToRecognize,
                averageImageHeight, averageImageWidth);

            neuralNetwork.Recognize(input, ref matchedHigh, ref outputValueHigh,
                ref matechedLow, ref outputValueLow);

            return matchedHigh;

        }
        #endregion
    }
}