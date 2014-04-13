using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;

namespace ImageProcessingServices.Infrastructure.NeuroneNetwork
{
    class NeuroneEnter
    {
        //Neural Network Object With Output Type String
        private NeuralNetwork<string> neuralNetwork = null;

        //Data Members Required For Neural Network
        private Dictionary<string, double[]> TrainingSet = null;
        private int av_ImageHeight = 0;
        private int av_ImageWidth = 0;
        private int NumOfPatterns = 0;

        //For Asynchronized Programming Instead of Handling Threads
        private delegate bool TrainingCallBack();
        private AsyncCallback asyCallBack = null;
        private IAsyncResult res = null;
        private ManualResetEvent ManualReset = null;

        private DateTime DTStart;

        public NeuroneEnter()
        {
            try
            {
                string[] Images = Directory.GetFiles(@"C:\work\LeafZone\ImageProcessingServices\ImageProcessingServices\ImageProcessingServices\Infrastructure\NeuroneNetwork\source", "*.bmp");
                NumOfPatterns = Images.Length;

                av_ImageHeight = 0;
                av_ImageWidth = 0;

                foreach (string s in Images)
                {
                    Bitmap Temp = new Bitmap(s);
                    av_ImageHeight += Temp.Height;
                    av_ImageWidth += Temp.Width;
                    Temp.Dispose();
                }
                av_ImageHeight /= NumOfPatterns;
                av_ImageWidth /= NumOfPatterns;
            }
            catch (Exception ex)
            {

            }

            GenerateTrainingSet();
            CreateNeuralNetwork();

            neuralNetwork.Train();

        }

        private void CreateNeuralNetwork()
        {
            neuralNetwork = new NeuralNetwork<string>
                (new BP1Layer<string>(av_ImageHeight * av_ImageWidth, NumOfPatterns), TrainingSet);

            neuralNetwork.IterationChanged +=
                new NeuralNetwork<string>.IterationChangedCallBack(neuralNetwork_IterationChanged);

            neuralNetwork.MaximumError = Double.Parse("1.2");
        }

        private void GenerateTrainingSet()
        {
            string[] Patterns = Directory.GetFiles(@"C:\work\LeafZone\ImageProcessingServices\ImageProcessingServices\ImageProcessingServices\Infrastructure\NeuroneNetwork\source", "*.bmp");

            TrainingSet = new Dictionary<string, double[]>(Patterns.Length);
            foreach (string s in Patterns)
            {
                Bitmap Temp = new Bitmap(s);
                TrainingSet.Add(Path.GetFileNameWithoutExtension(s),
                    ImageProcessing.ToMatrix(Temp, av_ImageHeight, av_ImageWidth));
                Temp.Dispose();
            }
        }

        public string Recognize(Bitmap ImageToRec)
        {
            string MatchedHigh = "?", MatchedLow = "?";
            double OutputValueHight = 0, OutputValueLow = 0;

            double[] input = ImageProcessing.ToMatrix(ImageToRec,
                av_ImageHeight, av_ImageWidth);

            neuralNetwork.Recognize(input, ref MatchedHigh, ref OutputValueHight,
                ref MatchedLow, ref OutputValueLow);

            return ShowRecognitionResults(MatchedHigh, MatchedLow, OutputValueHight, OutputValueLow);

        }

        private string ShowRecognitionResults(string MatchedHigh, string MatchedLow, double OutputValueHight, double OutputValueLow)
        {

            return MatchedHigh;

            //pictureBoxInput.Image = new Bitmap(drawingPanel1.ImageOnPanel,
            //    pictureBoxInput.Width, pictureBoxInput.Height);

            //if (MatchedHigh != "?")
            //    pictureBoxMatchedHigh.Image = new Bitmap(new Bitmap(textBoxTrainingBrowse.Text + "\\" + MatchedHigh + ".bmp"),
            //        pictureBoxMatchedHigh.Width, pictureBoxMatchedHigh.Height);

            //if (MatchedLow != "?")
            //    pictureBoxMatchedLow.Image = new Bitmap(new Bitmap(textBoxTrainingBrowse.Text + "\\" + MatchedLow + ".bmp"),
            //        pictureBoxMatchedLow.Width, pictureBoxMatchedLow.Height);
        }

        void neuralNetwork_IterationChanged(object o, NeuralEventArgs args)
        {

        }
    }
}