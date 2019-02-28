using Microsoft.AspNetCore.Http;
using OrganikV1.Entities;
using System;
using System.Collections.Generic;

namespace OrganikV1.WebUI.Models
{
    public class ProductViewModel
    {
        public int productId { get; set; }

        public string userId { get; set; }

        public int catId { get; set; }

        public string title { get; set; }

        public int price { get; set; }

        public string content { get; set; }

        public IFormFile productPhoto { get; set; }


        public int stockCount { get; set; }

        public bool stockStatus { get; set; }

        public bool status { get; set; }

        public string seoTitle { get; set; }

        public string priceType { get; set; }

        public string cinsispecies { get; set; }

        public string province { get; set; }

        public bool isDeleted { get; set; }



        public virtual ICollection<ProductPhoto> ProductPhotos { get; set; }

        public virtual Categories Categories { get; set; }
    }
}
