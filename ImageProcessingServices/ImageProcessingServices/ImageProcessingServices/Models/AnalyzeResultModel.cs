using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImageProcessingServices.Models
{
    public class AnalyzeResultModel
    {
        public string ImageUrl { get; set; }
        public string DiseaseName { get; set; }
        public string PlantName { get; set; }
        public double OzoneAffected { get; set; }

        public AnalyzeResultModel() 
        {
            this.ImageUrl = "";
            this.DiseaseName = "";
            this.PlantName = "";
            this.OzoneAffected = 0d;
        }

        public AnalyzeResultModel(string imageUrl, string diseaseName, string plantName, double ozoneAffected)
        {
            this.ImageUrl = imageUrl;
            this.DiseaseName = diseaseName;
            this.PlantName = plantName;
            this.OzoneAffected = ozoneAffected;
        }
    }
}