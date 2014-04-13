using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using ImageProcessingServices.Infrastructure;
using ImageProcessingServices.Models;
using System.Drawing;
using ImageProcessingServices.Infrastructure.NeuroneNetwork;

namespace ImageProcessingServices.Controllers
{
    public class AnalyzeController : ApiController
    {
        private readonly string IMAGES_LOCATION = "Images";

        public string Get()
        {
            return "Services up and running";
        }

        public AnalyzeResultModel Post(AnalyzeModel obj)
        {
            if(obj.ImageBase64 != null)
            {
                string imagePath = "http://localhost/api/Images/" + obj.ImageName + "-analyzed.jpg";

                Bitmap leafImage = MyHelpers.Base64StringToBitmap(obj.ImageBase64);
                var pathBMP = Path.Combine(HttpContext.Current.Server.MapPath(IMAGES_LOCATION), obj.ImageName) + ".bmp";
                var pathJPG = Path.Combine(HttpContext.Current.Server.MapPath(IMAGES_LOCATION), obj.ImageName) + ".jpg";
                var pathContour = Path.Combine(HttpContext.Current.Server.MapPath(IMAGES_LOCATION), obj.ImageName) + "-analyzed.jpg";

                using (Bitmap tempImage = new Bitmap(leafImage))
                {
                    tempImage.Save(pathBMP, System.Drawing.Imaging.ImageFormat.Jpeg);
                }   

                using (Bitmap tempImage = new Bitmap(leafImage))
                {
                    tempImage.Save(pathJPG, System.Drawing.Imaging.ImageFormat.Bmp);
                }

                using (Bitmap tempImage = new Bitmap(leafImage))
                {
                    tempImage.Save(pathContour, System.Drawing.Imaging.ImageFormat.Jpeg);
                } 

                MyHelpers.ResizeImage(pathJPG, pathJPG, 411, 600, true);

                ImageAnalyzer analyzedImage = new ImageAnalyzer();
                analyzedImage.CreateImageContours(pathJPG);
                double ozonePercentage = analyzedImage.GetOzonePercentage();

                string plantDisease = analyzedImage.PlantDisease();


                NeuroneEnter neuroneNetwork = new NeuroneEnter();
                Bitmap bmp = new Bitmap(pathBMP);
                string plantName = neuroneNetwork.Recognize(bmp);

                AnalyzeResultModel result = new AnalyzeResultModel(imagePath, plantDisease, plantName, ozonePercentage);

                return result;
            }

            return new AnalyzeResultModel();
        }
    }
}
