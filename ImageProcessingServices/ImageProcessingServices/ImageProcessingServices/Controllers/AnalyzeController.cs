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
                string imagePath = "http://leafzoneservices.keydown.org/api/Images/" + obj.ImageName + "-analyzed.bmp";

                string converted = obj.ImageBase64.Remove(0, 23);

                Bitmap leafImage = MyHelpers.Base64StringToBitmap(converted);
                var path = Path.Combine(HttpContext.Current.Server.MapPath(IMAGES_LOCATION), obj.ImageName) + ".bmp";

                using (Bitmap tempImage = new Bitmap(leafImage))
                {
                    tempImage.Save(path, System.Drawing.Imaging.ImageFormat.Bmp);
                }   

                MyHelpers.ResizeImage(path, path, 800, 600, true);

                ImageAnalyzer analyzedImage = new ImageAnalyzer();
                analyzedImage.CreateImageContours(path);

                AnalyzeResultModel result = new AnalyzeResultModel(imagePath, "Unknown", "Unknown", 75d);

                return result;
            }

            return new AnalyzeResultModel();
        }
    }
}
