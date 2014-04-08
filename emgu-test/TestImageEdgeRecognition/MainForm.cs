using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV.CvEnum;

namespace TestImageEdgeRecognition
{
    public partial class MainForm : Form
    {
        private Image<Bgr, Byte> ImageOriginal { get; set; }

        private Image<Bgr, Byte> Image { get; set; }

        private Image<Gray, Byte> GrayscaleImage { get; set; }

        public Contour<Point> Contours { get; set; }

        public MainForm()
        {
            this.InitializeComponent();
        }

        private void loadImageButton_Click(object sender, EventArgs e)
        {
            DialogResult result = this.openFileDialog1.ShowDialog();
            if (result == DialogResult.OK || result == DialogResult.Yes)
            {
                this.fileNameTextBox.Text = this.openFileDialog1.FileName;

                this.ImageOriginal = new Image<Bgr, byte>(this.fileNameTextBox.Text);


              //  this.ImageOriginal.SmoothBlur();
                //this.ImageOriginal._EqualizeHist();
                //this.ImageOriginal._GammaCorrect(1.8d);
                this.ImageOriginal.Erode(1);
                //this.ImageOriginal.Dilate(1);

                this.GrayscaleImage = this.ImageOriginal.Convert<Gray, Byte>();

                Gray averageIntensity = this.GrayscaleImage.GetAverage();

                this.trackBarThreshold.Value = (int)(averageIntensity.Intensity * .66);
                this.trackBarThresholdLinking.Value = (int)(averageIntensity.Intensity * 1.33);

                this.textBox1.Text = "";
                this.UpdateTackBarValues();
                this.PerformEdgeDetection();
            }
        }

        private void UpdateTackBarValues()
        {
            this.labelThresholdValue.Text = this.trackBarThreshold.Value.ToString();
            this.labelThresholdLinkingValue.Text = this.trackBarThresholdLinking.Value.ToString();
        }

        public void PerformEdgeDetection()
        {
            Image<Gray, Byte> cannyEdges = this.GrayscaleImage.Canny(this.trackBarThreshold.Value, this.trackBarThresholdLinking.Value);

            StructuringElementEx element = new StructuringElementEx(3, 3, 1, 1, Emgu.CV.CvEnum.CV_ELEMENT_SHAPE.CV_SHAPE_CROSS);

            CvInvoke.cvMorphologyEx(cannyEdges, cannyEdges, IntPtr.Zero, element, CV_MORPH_OP.CV_MOP_GRADIENT, 1);

            this.Image = this.ImageOriginal.Copy();
            this.imageBoxOriginal.Image = this.Image;
            //this.imageBoxEdges.Image = cannyEdges;

            this.Contours = cannyEdges.FindContours(Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE, Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_EXTERNAL);

            //make sure all contours are on
            //var ContoursCount = this.CountContour();
            //for (int i = 0; i < ContoursCount; i++)
            //{
            //    this.DrawContour();
            //}

            //this.Image.Erode(1);
            //Image<Gray, Byte> resultImageWithContour = this.Image.Convert<Gray, Byte>();
            //Image<Gray, Byte> resultContour = resultImageWithContour.Canny(this.trackBarThreshold.Value, this.trackBarThresholdLinking.Value);

            //this.Contours = resultContour.FindContours(Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE, Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_EXTERNAL);
            //this.imageBoxEdges.Image = resultContour;
        }

        private void trackBarThreshold_Scroll(object sender, EventArgs e)
        {
            this.UpdateTackBarValues();
            //this.PerformEdgeDetection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.Contours == null)
            {
                return;
            }

            this.Image.Draw(this.Contours, new Bgr(Color.Red), -1);
            this.textBox1.Text += "Area: " + this.Contours.Area + " Perimeter: " + this.Contours.Perimeter + Environment.NewLine;
            this.imageBoxOriginal.Refresh();
            this.Contours = this.Contours.HNext;
        }

        private int CountContour()
        {
            int counter = 0;
            while (this.Contours != null)
            {
                //next contour
                this.Contours = this.Contours.HNext;
                counter++;
            }
            for (int i = 0; i < counter; i++)
            {
                this.Contours = this.Contours.HPrev;
            }

            return counter;
        }

        private void DrawContour()
        {
            this.Image.Draw(this.Contours, new Bgr(Color.Red), -1);
            this.textBox1.Text += "Area: " + this.Contours.Area + " Perimeter: " + this.Contours.Perimeter + Environment.NewLine;
            this.imageBoxOriginal.Refresh();
            this.Contours = this.Contours.HNext;
        }
    }
}