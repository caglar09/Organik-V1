using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrganikV1.WebUI.ViewModel
{
    public class NewUser
    {
        //[Key]
        //public string userId { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "Adınız En fazla 30 Karakter içerebilir"), MinLength(3)]
        public string name { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "Soyadınız En fazla 30 Karakter içerebilir"), MinLength(3)]
        public string lastname { get; set; }

        //[DataType(DataType.DateTime)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public DateTime? createdDate { get; set; }


        //public bool activated { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }


        //[DataType(DataType.ImageUrl)]
        //public string userPhoto { get; set; }

        [Required]
        [MaxLength(16, ErrorMessage = "Şifreniz en az 6 ile en fazla 16 karakter uzunluğunda olmalıdır. "), MinLength(6)]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Required]
        [MaxLength(16, ErrorMessage = "Şifreniz en az 6 ile en fazla 16 karakter uzunluğunda olmalıdır. "), MinLength(6)]
        [DataType(DataType.Password)]
        public string passwordConfirm { get; set; }
        //[Required]
        //[DataType(DataType.PhoneNumber)]
        //public string phoneNumber { get; set; }

        //[DataType(DataType.Url)]
        //public string website { get; set; }
    }
}
