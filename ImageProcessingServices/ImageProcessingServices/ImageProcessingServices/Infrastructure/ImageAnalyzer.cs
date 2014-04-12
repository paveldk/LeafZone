using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.CV.CvEnum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;

namespace ImageProcessingServices.Infrastructure
{
    public  class ImageAnalyzer
    {
        private Image<Bgr, Byte> ImageOriginal { get; set; }

        private Image<Bgr, Byte> Image { get; set; }

        private Image<Bgr, Byte> ImageMarked { get; set; }

        private Image<Gray, Byte> GrayscaleImage { get; set; }

        public Contour<Point> Contours { get; set; }

        public int trackBarThresholdValue { get; set; }
        public int trackBarThresholdLinkingValue { get; set; }

        public string ImageAnalyzedPath { get; set; }

        public ImageAnalyzer()
        {

        }

        private void SetInitialScrollbarValues()
        {
            Gray averageIntensity = this.GrayscaleImage.GetAverage();

            this.trackBarThresholdValue = (int)(averageIntensity.Intensity * .66);
            this.trackBarThresholdLinkingValue = (int)(averageIntensity.Intensity * 1.33);
        }

        private void initialTransformations()
        {
            this.GrayscaleImage.Erode(1);
        }

        public void CreateImageContours(string path)
        {
            this.ImageOriginal = new Image<Bgr, byte>("C:\\Users\\paveldk\\Downloads\\lrecog1_0-cfg\\1.jpg");

            this.ImageAnalyzedPath = path.Remove(path.Length - 4, 4) + "-analyzed.bmp";

            this.GrayscaleImage = this.ImageOriginal.Convert<Gray, Byte>();

            this.GrayscaleImage.Erode(1);

            this.SetInitialScrollbarValues();

            this.PerformEdgeDetection();
        }

        public Image<Gray, Byte> GetContoursHard()
        {
            Image<Gray, Byte> cannyEdges = this.GrayscaleImage.Canny(this.trackBarThresholdValue, this.trackBarThresholdLinkingValue);

            StructuringElementEx element = new StructuringElementEx(3, 3, 1, 1, Emgu.CV.CvEnum.CV_ELEMENT_SHAPE.CV_SHAPE_CROSS);

            CvInvoke.cvMorphologyEx(cannyEdges, cannyEdges, IntPtr.Zero, element, CV_MORPH_OP.CV_MOP_GRADIENT, 1);

            this.Contours = cannyEdges.FindContours(Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE, Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_EXTERNAL);

            return cannyEdges;
        }

        public Image<Gray, Byte> GetContours()
        {
            Image<Gray, Byte> cannyEdges = this.GrayscaleImage.Canny(this.trackBarThresholdValue, this.trackBarThresholdLinkingValue);

            this.Contours = cannyEdges.FindContours(Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE, Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_EXTERNAL);

            return cannyEdges;
        }

        public void SetSolidContours()
        {
            this.ImageMarked = this.GrayscaleImage.Convert<Bgr, Byte>();

            this.DrawSolidContour();

            this.GrayscaleImage = this.ImageMarked.Convert<Gray, Byte>();
        }

        private void PerformEdgeDetection()
        {
            this.GrayscaleImage = this.GetContoursHard();

            this.SetSolidContours();

            this.Image = this.ImageOriginal.Copy();
            CvInvoke.cvAddWeighted(this.Image, 1, this.ImageMarked, 0.3, 0, this.Image);

            this.Image.Save(this.ImageAnalyzedPath);
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