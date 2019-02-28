using OrganikV1.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace OrganikV1.Entities
{
    public class Products : IEntity
    {

        [Key] public int productId { get; set; }

        public string userId { get; set; }

        public int catId { get; set; }

        [Required] public string title { get; set; }

        [Required] public int price { get; set; }

        [Required] [DataType(DataType.MultilineText)] public string content { get; set; }

        [DataType(DataType.ImageUrl)] public string productPhoto { get; set; }

        [DataType(DataType.DateTime)] public DateTime createdDate { get; set; }

        public int stockCount { get; set; }

        public bool stockStatus { get; set; }

        public bool status { get; set; }

        [Required] public string seoTitle { get; set; }

        public string priceType { get; set; }

        public string cinsispecies { get; set; }

        public string province { get; set; }

        [Required] public bool isDeleted { get; set; }



        public virtual ICollection<ProductPhoto> ProductPhotos { get; set; }

        public virtual Categories Categories { get; set; }

    }
}
