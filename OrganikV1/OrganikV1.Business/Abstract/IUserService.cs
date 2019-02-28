using OrganikV1.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using OrganikV1.Entities.Entity;
using OrganikV1.Common;

namespace OrganikV1.Business.Abstract
{
    public interface IUserService
    {
        //bool UserInfo(string userId);
        Task<CustomUser> UserInfo(string userId , string username);
        //CustomUser GetUser(string email);
        bool CheckEmailControl(string email);

        bool CheckUserControl(string username);

        ServiceResponseLoginRegister Login(CustomUser user, string password,bool isPersistent, bool lockoutOnFailure);

        ServiceResponseLoginRegister Register(CustomUser user, string password);

        ServiceResponseLoginRegister SigOut();

        //Task<bool> Login(string email, string password);
         
        //bool Register(User user);

        //TokenModel CreateToken(string email);

        Task<IdentityResult> Update(CustomUser user);

        CustomUser GetEmailUser(string email);

        
    }
}
