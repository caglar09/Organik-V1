using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using OrganikV1.Business.Abstract;
using OrganikV1.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrganikV1.WebUI.ViewComponents
{
    public class UserDetailMenu:ViewComponent
    {
        private readonly IUserService _userService;
        public UserDetailMenu(IUserService userService)
        {
            _userService = userService;
        }

        public ViewViewComponentResult Invoke()
        {
            

            return View();

        }

    }
}
