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

        private Image<Bgr, Byte> ImageMarked { get; set; }

        private Image<Gray, Byte> GrayscaleImage { get; set; }

        public Contour<Point> Contours { get; set; }

        public MainForm()
        {
            this.InitializeComponent();
        }

        private void SetInitialScrollbarValues()
        {
            Gray averageIntensity = this.GrayscaleImage.GetAverage();

            this.trackBarThreshold.Value = (int)(averageIntensity.Intensity * .66);
            this.trackBarThresholdLinking.Value = (int)(averageIntensity.Intensity * 1.33);
        }

        private void initialTransformations()
        {
            this.GrayscaleImage.Erode(1);
        }

        private void loadImageButton_Click(object sender, EventArgs e)
        {
            DialogResult result = this.openFileDialog1.ShowDialog();
            if (result == DialogResult.OK || result == DialogResult.Yes)
            {
                this.fileNameTextBox.Text = this.openFileDialog1.FileName;

                this.ImageOriginal = new Image<Bgr, byte>(this.fileNameTextBox.Text);

                this.GrayscaleImage = this.ImageOriginal.Convert<Gray, Byte>();

                this.GrayscaleImage.Erode(1);

                this.SetInitialScrollbarValues();

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

        public Image<Gray, Byte> GetContoursHard()
        {
            Image<Gray, Byte> cannyEdges = this.GrayscaleImage.Canny(this.trackBarThreshold.Value, this.trackBarThresholdLinking.Value);

            StructuringElementEx element = new StructuringElementEx(3, 3, 1, 1, Emgu.CV.CvEnum.CV_ELEMENT_SHAPE.CV_SHAPE_CROSS);

            CvInvoke.cvMorphologyEx(cannyEdges, cannyEdges, IntPtr.Zero, element, CV_MORPH_OP.CV_MOP_GRADIENT, 1);

            this.Contours = cannyEdges.FindContours(Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE, Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_EXTERNAL);

            return cannyEdges;
        }

        public Image<Gray, Byte> GetContours()
        {
            Image<Gray, Byte> cannyEdges = this.GrayscaleImage.Canny(this.trackBarThreshold.Value, this.trackBarThresholdLinking.Value);

            this.Contours = cannyEdges.FindContours(Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE, Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_EXTERNAL);

            return cannyEdges;
        }

        public void SetSolidContours()
        {
            this.ImageMarked = this.GrayscaleImage.Convert<Bgr, Byte>();

            this.DrawSolidContour();

            this.GrayscaleImage = this.ImageMarked.Convert<Gray, Byte>();
        }

        public void PerformEdgeDetection()
        {
            this.GrayscaleImage = this.GetContoursHard();

            this.SetSolidContours();

            this.imageBoxEdges.Image = this.GrayscaleImage;

            this.Image = this.ImageOriginal.Copy();
            CvInvoke.cvAddWeighted(this.Image, 1, this.ImageMarked, 0.5, 0, this.Image);

            this.imageBoxOriginal.Image = this.Image;
        }

        private void trackBarThreshold_Scroll(object sender, EventArgs e)
        {
            this.UpdateTackBarValues();
            this.PerformEdgeDetection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DrawContour();
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

        private void DrawSolidContour()
        {
            if (this.Contours == null)
            {
                return;
            }

            if (this.Contours.Perimeter > 1000d)
            {
                this.ImageMarked.Draw(this.Contours, new Bgr(0, 0, 255), -1);
                this.Contours = this.Contours.HNext;
            }
            else
            {
                this.Contours = this.Contours.HNext;
                this.DrawSolidContour();
            }
        }

        private void DrawContour()
        {
            if (this.Contours == null)
            {
                return;
            }

            if(this.Contours.Perimeter > 1000d)
            {
                this.Image.Draw(this.Contours, new Bgr(0, 0, 255), -1);
                this.textBox1.Text += "Area: " + this.Contours.Area + " Perimeter: " + this.Contours.Perimeter + Environment.NewLine;
                this.imageBoxOriginal.Refresh();
                this.Contours = this.Contours.HNext;
            } 
            else
            {
                this.Contours = this.Contours.HNext;
                this.DrawContour();
            }

        }
    }
}