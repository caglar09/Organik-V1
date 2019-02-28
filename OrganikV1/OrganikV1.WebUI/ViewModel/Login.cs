using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OrganikV1.WebUI.ViewModel
{
    public class Login
    {
        [Required] public string email { get; set; }
        [Required] public string password { get; set; }
    }
}
