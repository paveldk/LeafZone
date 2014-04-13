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

        private Image<Bgr, Byte> ImageMarkedContour { get; set; }

        private Image<Gray, Byte> GrayscaleImage { get; set; }

        public Contour<Point> Contours { get; set; }

        public int trackBarThresholdValue { get; set; }
        public int trackBarThresholdLinkingValue { get; set; }

        public string ImageAnalyzedPath { get; set; }

        private Image<Gray, Byte> ImagePlantDisease { get; set; }
        public Contour<Point> DiseaseContours { get; set; }
        public int DiseaseCount { get; set; }

        private Image<Gray, Byte> ImageOzone { get; set; }
        public Contour<Point> OzoneContours { get; set; }
        public int OzoneArea { get; set; }

        public ImageAnalyzer()
        {

        }

        private void SetInitialTruesholdValues()
        {
            Gray averageIntensity = this.GrayscaleImage.GetAverage();

            this.trackBarThresholdValue = (int)(averageIntensity.Intensity * .66);
            this.trackBarThresholdLinkingValue = (int)(averageIntensity.Intensity * 1.33);
        }

        public double GetOzonePercentage()
        {
            int imageArea = (int)(this.ImageOzone.Height * this.ImageOzone.Width);
            return 100 * this.OzoneArea / imageArea;
        }

        private void CountOzoneArea()
        {
            if (this.OzoneContours == null)
            {
                return;
            }

            this.OzoneArea += (int)this.OzoneContours.Area;

            this.OzoneContours = this.OzoneContours.HNext;
            this.CountOzoneArea();
        }

        private void CountPlantDiseaseArea()
        {
            if (this.DiseaseContours == null)
            {
                return;
            }

            this.DiseaseCount += (int)this.DiseaseContours.Area;

            this.DiseaseContours = this.DiseaseContours.HNext;
            this.CountPlantDiseaseArea();
        }

        public string PlantDisease()
        {
            if(this.DiseaseCount < 10000 && this.DiseaseCount > 500)
            {
                return "Pseudomonas syringae";
            }
                
            return "Unknown";
        }

        private void initialTransformations()
        {
            this.GrayscaleImage.Erode(1);
        }

        public void CreateImageContours(string path)
        {
            this.ImageOriginal = new Image<Bgr, byte>(path);

            this.ImageAnalyzedPath = path.Remove(path.Length - 4, 4) + "-analyzed.jpg";

            this.GrayscaleImage = this.ImageOriginal.Convert<Gray, Byte>();

            this.GrayscaleImage.Erode(1);

            this.SetInitialTruesholdValues();

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
            this.ImageOzone = this.Image.InRange(new Bgr(90, 113, 115), new Bgr(113, 162, 250));
            this.ImagePlantDisease = this.Image.InRange(new Bgr(41, 25, 0), new Bgr(255, 140, 255));

            CvInvoke.cvAddWeighted(this.Image, 1, this.ImageMarked, 0.6, 0, this.Image);
            CvInvoke.cvAddWeighted(this.Image, 1, this.ImageMarkedContour, 0.7, 0, this.Image);

            this.OzoneContours = this.ImageOzone.FindContours(Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE, Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_EXTERNAL);
            this.DiseaseContours = this.ImagePlantDisease.FindContours(Emgu.CV.CvEnum.CHAIN_APPROX_METHOD.CV_CHAIN_APPROX_SIMPLE, Emgu.CV.CvEnum.RETR_TYPE.CV_RETR_EXTERNAL);
            this.CountOzoneArea();
            this.CountPlantDiseaseArea();

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
                this.ImageMarked.Draw(this.Contours, new Bgr(100, 100, 255), 10);

                this.ImageMarkedContour = new Image<Bgr, Byte>(this.ImageMarked.Bitmap);
                this.ImageMarkedContour.Draw(this.Contours, new Bgr(0, 0, 255), -1);
                this.Contours = this.Contours.HNext;
            }
            else
            {
                this.Contours = this.Contours.HNext;
                this.DrawSolidContour();
            }
        }
    }
}