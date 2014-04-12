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

        public AnalyzeResultModel Post(AnalyzeModel obj)
        {
            if(obj.ImageBase64 != null)
            {
                string converted = obj.ImageBase64.Remove(0, 22);

                Bitmap leafImage = MyHelpers.Base64StringToBitmap(converted);
                var path = Path.Combine(HttpContext.Current.Server.MapPath(IMAGES_LOCATION), obj.ImageName);

                path = path + ".bmp";
                leafImage.Save(path, System.Drawing.Imaging.ImageFormat.Bmp);

                MyHelpers.ResizeImage(path, path, 900, 580, true);

                string imagePath = "http://leafzoneservices.keydown.org/api/Images/" + obj.ImageName + ".bmp";

                AnalyzeResultModel result = new AnalyzeResultModel(imagePath, "Unknown", "Unknown", 75d);

                return result;
            }

            return new AnalyzeResultModel();
        }

        public string Get()
        {
            return Path.Combine(HttpContext.Current.Server.MapPath(IMAGES_LOCATION), "penko.jpg");
        }
    }
}
