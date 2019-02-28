using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using OrganikV1.Business.Abstract;
using OrganikV1.Common;
using OrganikV1.Dal.Abstract;
using OrganikV1.Entities.Entity;
using System;
using System.Linq;
//using OrganikV1.Web.ViewModel;
using System.Threading.Tasks;

namespace OrganikV1.Business.Concrete
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        private UserManager<CustomUser> _userManager;
        private RoleManager<CustomUserRole> _roleManager;
        private SignInManager<CustomUser> _signInManager;
        private readonly IMemoryCache _memoryCache;
        ServiceResponseLoginRegister model;
        public UserManager(IUserDal userDal, UserManager<CustomUser> userManager, SignInManager<CustomUser> signInManager, RoleManager<CustomUserRole> roleManager, IMemoryCache memoryCache)
        {
            _userDal = userDal;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _memoryCache = memoryCache;
           
        }

        public bool CheckEmailControl(string email)
        {
            Task<CustomUser> user = _userManager.FindByEmailAsync(email);
            if (user.Result != null)
            {
                return false;
            }
            return true;
        }

        public bool CheckUserControl(string username)
        {
            Task<CustomUser> user = _userManager.FindByNameAsync(username);

            if (user != null)
            {
                return true;
            }
            return false;
        }

        //public  CustomUser GetUser(string email)
        //{
        //    var user = _userManager.FindByEmailAsync(email);
        //    return  user;
        //}

        public ServiceResponseLoginRegister Login(CustomUser user, string password, bool isPersistent, bool lockoutOnFailure)
        {
            bool userControl = CheckUserControl(user.UserName);
            if (userControl)
            {
                CustomUser loginUser = _userManager.Users.FirstOrDefault(x => x.UserName == user.UserName || x.Email == user.Email);
                if (loginUser.EmailConfirmed==false)
                {
                    return ServiceResponseLoginRegister.GetStatus(EmailConfirm: false, LoginStatus: null, SignOutStatus: false, RoleStatus: null, RegisterStatus: null);
                }
                var result = _signInManager.PasswordSignInAsync(loginUser.UserName, password: password, isPersistent: isPersistent, lockoutOnFailure: lockoutOnFailure).Result;
                if (result.Succeeded)
                {
                    Task<ExternalLoginInfo> loginInfo = _signInManager.GetExternalLoginInfoAsync();
                    if (loginInfo != null)
                    {
                        _signInManager.SignInAsync(loginUser, isPersistent);
                       
                        return ServiceResponseLoginRegister.GetStatus(EmailConfirm: null, LoginStatus: 1, SignOutStatus: false, RoleStatus: null, RegisterStatus: null);
                    }
                    return ServiceResponseLoginRegister.GetStatus(EmailConfirm: null, LoginStatus: 2, SignOutStatus: false, RoleStatus: null, RegisterStatus: null);
                }
                return ServiceResponseLoginRegister.GetStatus(EmailConfirm: null, LoginStatus: 2, SignOutStatus: false, RoleStatus: null, RegisterStatus: null);

            }
            return ServiceResponseLoginRegister.GetStatus(EmailConfirm: null, LoginStatus: 3, SignOutStatus: false, RoleStatus: null, RegisterStatus: null);
        }

        public ServiceResponseLoginRegister Register(CustomUser user, string password)
        {
            bool userControl = CheckEmailControl(user.Email);

            if (userControl)
            {
                CustomUser newUser = new CustomUser
                {
                    Email = user.Email,
                    EmailConfirmed = false,
                    name = user.name,
                    lastname = user.lastname,
                    createdDate = DateTime.Now,
                    activated = false,
                    userPhoto = "null",
                    UserName = Common.Utility.ToCleanUrl(user.name.ToLower() + user.lastname.ToLower()),
                };

                IdentityResult ıdentityResult = _userManager.CreateAsync(newUser, password).Result;
                if (ıdentityResult.Succeeded)
                {

                    if (!_roleManager.RoleExistsAsync("Admin").Result)
                    {
                        CustomUserRole role = new CustomUserRole
                        {
                            Name = "Admin"
                        };
                        IdentityResult roleResult = _roleManager.CreateAsync(role).Result;

                        if (!roleResult.Succeeded)
                        {
                            return ServiceResponseLoginRegister.GetStatus(EmailConfirm: null, LoginStatus: null, SignOutStatus: false, RoleStatus: 2, RegisterStatus: null);
                            //return View(vm);
                        }
                    }
                    _userManager.AddToRoleAsync(newUser, "Admin").Wait();
                    return ServiceResponseLoginRegister.GetStatus(EmailConfirm: null, LoginStatus: null, SignOutStatus: false, RoleStatus: null, RegisterStatus: 1);
                }
            }
          
            return ServiceResponseLoginRegister.GetStatus(EmailConfirm: null, LoginStatus: null, SignOutStatus: false, RoleStatus: null, RegisterStatus: 3);

        }

        public ServiceResponseLoginRegister SigOut()
        {
            Task a = _signInManager.SignOutAsync();
            if (a.IsCompletedSuccessfully)
            {
                return ServiceResponseLoginRegister.GetStatus(EmailConfirm: null, LoginStatus: null, SignOutStatus: true, RoleStatus: null, RegisterStatus: null);

            }

            
            return ServiceResponseLoginRegister.GetStatus(EmailConfirm:null,LoginStatus:null, SignOutStatus:false, RoleStatus:null,RegisterStatus:null);

        }

        public async Task<IdentityResult> Update(CustomUser user)
        {
            // _userDal.Update(user);
            return _userManager.UpdateAsync(user).Result;
        }

        public CustomUser userControl(string userId)
        {
            CustomUser u = _userDal.Get(x => x.Id == userId);

            if (u != null)
            {
                return u;
            }
            return null;
        }

        public Task<CustomUser> UserInfo(string userId, string username)
        {
            if (userId != null)
            {
                return _userManager.FindByIdAsync(userId);
            }

            if (username != null)
            {
                return _userManager.FindByNameAsync(username);
            }

            return null;
        }

        public TokenModel CreateToken(string email)
        {
            Task<CustomUser> user = _userManager.FindByEmailAsync(email);
            if (user.Result == null)
            {
                return null;
            }
            if (user.Result.EmailConfirmed == false)
            {
                string CToken = new Guid().ToString();

                user.Result.SecurityStamp = CToken;

                _userManager.UpdateAsync(user.Result);

                var tokenModel = new TokenModel
                {
                    UserId = user.Result.Id,
                    CToken = CToken
                };
                return tokenModel;
            }

            return null;
        }

        public CustomUser GetEmailUser(string email)
        {
            return _userManager.FindByEmailAsync(email).Result;
        }
    }

}
