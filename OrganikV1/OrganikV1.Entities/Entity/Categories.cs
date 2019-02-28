using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

using OrganikV1.Core;

namespace OrganikV1.Entities
{
   public class Categories:IEntity
    {
        [Key]public int catId { get; set; }

        public int altCatId { get; set; }

        [Required] public string catName { get; set; }
        public int count { get; set; }
        [Required] public Boolean isDeleted { get; set; }
        [Required]  public string seoTitle { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
