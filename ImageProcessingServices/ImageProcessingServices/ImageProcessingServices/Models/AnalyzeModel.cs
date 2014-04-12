using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImageProcessingServices.Models
{
    public class AnalyzeModel
    {
        public string ImageName { get; set; }
        public string ImageBase64 { get; set; }
        
        public AnalyzeModel() 
        {

        }
    }
}