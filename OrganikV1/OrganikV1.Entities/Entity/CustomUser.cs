using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrganikV1.Entities.Entity
{
    public class CustomUser : IdentityUser
    {
        [Required]
        [MaxLength(30, ErrorMessage = "Adınız En fazla 30 Karakter içerebilir"), MinLength(3)]
        public string name { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "Soyadınız En fazla 30 Karakter içerebilir"), MinLength(3)]
        public string lastname { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? createdDate { get; set; }


        public bool activated { get; set; }

        [DataType(DataType.ImageUrl)]
        public string userPhoto { get; set; }


        [DataType(DataType.Url)]
        public string website { get; set; }


        [DataType(DataType.Url)]
        public string facebook { get; set; }

        [DataType(DataType.Url)]
        public string twitter { get; set; }

        [DataType(DataType.Url)]
        public string instagram { get; set; }

        public string Content { get; set; }

        public int Gender { get; set; }

        public long Age { get; set; }

        public string Adress { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
