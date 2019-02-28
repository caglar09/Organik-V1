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
    public class UserMenuViewComponent: ViewComponent
    {

        private readonly IUserService _userService;
        public UserMenuViewComponent(IUserService userService)
        {
            _userService = userService;
        }

        public ViewViewComponentResult Invoke()
        {
            CustomUser userModel = new CustomUser();

            string username = User.Identity.Name;
            Task<CustomUser> user = _userService.UserInfo(null, username);

            userModel = user.Result;

            return View(userModel);

        }

    }
}
