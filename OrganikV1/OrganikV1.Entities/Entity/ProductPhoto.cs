using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using OrganikV1.Core;

namespace OrganikV1.Entities
{
    public class ProductPhoto : IEntity
    {
        [Key] public int photoId { get; set; }

        public int productId { get; set; }

        [DataType(DataType.ImageUrl), Required]
        public string path { get; set; }

        public  Products Products { get; set; }
    }
}
