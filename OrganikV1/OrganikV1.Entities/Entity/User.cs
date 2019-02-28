using OrganikV1.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrganikV1.Entities
{
    public class User : IEntity
    {

        public string UserName { get; set; }


        [Key]
        public string userId { get; set; }

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

        [Required]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }


        [DataType(DataType.ImageUrl)]
        public string userPhoto { get; set; }



        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Url)]
        public string website { get; set; }



        [DataType(DataType.Url)]
        public string facebook { get; set; }

        [DataType(DataType.Url)]
        public string twitter { get; set; }

        [DataType(DataType.Url)]
        public string instagram { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
