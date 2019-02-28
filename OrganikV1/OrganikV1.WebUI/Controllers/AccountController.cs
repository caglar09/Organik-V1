using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OrganikV1.Business.Abstract;
using OrganikV1.Business.Concrete;
using OrganikV1.Common;
using OrganikV1.Entities.Entity;
using OrganikV1.WebUI.ViewModel;
using System.Threading.Tasks;

namespace OrganikV1.WebUI.Controllers
{
    [Route("/Account")]
    public class AccountController : Controller
    {
        private IUserService _userService;
        private UserManager<CustomUser> _userManager;
        public AccountController(IUserService userService, UserManager<CustomUser> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }
        //[Route("~/Account/{username}")]

        #region SignIn/SignOut/resetPassword/confirmMail
        #region Login
        [Route("/Account/Login")]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [Route("/Account/Login")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(Login user)
        {
            if (ModelState.IsValid)
            {

                //var InfoUser=_userService.GetUser(user.email);
                CustomUser a = new CustomUser
                {
                    Email = user.email,
                    PasswordHash = user.password
                };
                Common.ServiceResponseLoginRegister res = _userService.Login(a, user.password, false, false);
                if (res.EmailConfirm == false)
                {
                    TempData.Add("loginstatus", "Email adresiniz onaylanmamış");
                    return View();
                }

                return RedirectToAction("Index", "User");

            }
            return View();

        }
        #endregion

        #region register
        [Route("/Account/Register")]
        public IActionResult Register()
        {
            return View();
        }


        [HttpPost]
        [Route("/Account/Register")]
        public async Task<IActionResult> Register(NewUser user)
        {
            if (ModelState.IsValid)
            {
                if (user.password != user.passwordConfirm)
                {
                    TempData.Add("loginstatus", "şifreler uyuşmuyor");
                    return View();
                }
                CustomUser newuser = new CustomUser
                {
                    name = user.name,
                    lastname = user.lastname,
                    Email = user.email,

                };
                Common.ServiceResponseLoginRegister result = _userService.Register(newuser, user.password);
                if (result.RegisterStatus == 1)
                {
                    bool status = SendConfirmMail(user.email);
                    if (status == true)
                    {
                        TempData.Add("ConfirmMail", "Aktivasyon Linki mail adresinize gönderildi. Lütfen mail adresinize gelen linke tıklayarak hesabınızı aktifleştiriniz. Aksi halde hesabınıza giriş yapamazsınız.");
                    }
                    else
                    {
                        TempData.Add("ConfirmMail", "Aktivasyon Linki mail adresinize gönderilemedi. Lütfen yönetici ile iletişime geçiniz.");
                    }
                }
                else
                {
                    if (result.RegisterStatus == 2)
                    {
                        TempData.Add("loginstatus", "Gerekli Role Oluşturulamadı");
                    }

                    if (result.RegisterStatus == 3)
                    {
                        TempData.Add("loginstatus", "aynı email ile kayıtlı kullanıcı var");
                    }
                    return RedirectToAction("Login");

                }

                return RedirectToAction("Login");
            }
            TempData.Add("loginstatus", "Girilen Bilgiler Eksik");
            return View();
        }
        #endregion

        #region signout
        [HttpGet]
        [Route("/Account/SignOut")]
        public async Task<IActionResult> SignOut()
        {
            ServiceResponseLoginRegister res = _userService.SigOut();
            if (res.SignOutStatus == true)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData.Add("loginstatus", "Çıkış Yaparken hata oluştu");
                return RedirectToAction("Index", "User");
            }


        }
        #endregion

        #region resetPassword
        [HttpGet]
        [Route("/Account/ResetPassword")]
        public IActionResult ResetPassword()
        {
            return View();
        }
        #endregion

        #region confirmMail
        [Route("/Account/UpdateEmailConfirm/{Id}/token={token}")]
        [HttpGet]
        public IActionResult UpdateEmailConfirm(string Id, string token)
        {
            if (Id == null || token == null)
            {
                TempData.Add("ConfirmMail", "yanlış aktivasyon kodu kullanıldı");
                return RedirectToAction("Index");
            }
            else
            {
                //var user = _userManager.FindByIdAsync(Id);
                CustomUser cuser = _userManager.FindByIdAsync(Id).Result;
                if (cuser == null)
                {
                    TempData.Add("ConfirmMail", "Hesabınız daha önceden onaylanmış olabilir. Eğer hesabınızla ilgili sıkıntı yaşıyorsanız Lütfen Admin ile iletişime geçiniz..");
                    return RedirectToAction("Login");
                }

                if (cuser.SecurityStamp == token)
                {
                    cuser.EmailConfirmed = true;
                    Task<IdentityResult> result = _userManager.UpdateAsync(cuser);
                    if (result.Result.Succeeded)
                    {
                        TempData.Add("ConfirmMail", "Hesabınız başarılı bir şekilde onaylandı. ");
                        return RedirectToAction("Login");
                    }
                    else
                    {
                        TempData.Add("ConfirmMail", "Hesabınız Onaylanamadı. Lütfen tekrar deneyin. Eğer hesabınızla ilgili sıkıntı yaşıyorsanız Lütfen Admin ile iletişime geçiniz..");
                        return RedirectToAction("Login");
                    }
                }
                else
                {
                    TempData.Add("ConfirmMail", "Hesabınız Onaylanamadı. Lütfen tekrar deneyin. Eğer hesabınızla ilgili sıkıntı yaşıyorsanız Lütfen Admin ile iletişime geçiniz..");
                    return RedirectToAction("Login");
                }
            }

        }
        #endregion
        #endregion

        public bool SendConfirmMail(string email)
        {
            if (email != null)
            {
                CustomUser UserEmail = _userService.GetEmailUser(email);
                Common.TokenModel token = CreateToken(UserEmail.Email);
                string ConfirmLink = Url.Action("UpdateEmailConfirm", "Account", new
                {
                    Id = token.UserId,
                    token = token.CToken,
                }, protocol: HttpContext.Request.Scheme);

                MailManager mail = new MailManager();
                bool res = mail.SendMail("infoorganik.09@gmail.com", UserEmail.Email, "Mail Aktivation", UserEmail.name + " " + UserEmail.lastname, ConfirmLink);
                if (res == true)
                {
                    //TempData.Add("updateStatus", "Aktivasyon maili gönderildi.");
                    return true;
                }
                else
                {
                    // TempData.Add("updateStatus", "Aktivasyon maili gönderilemedi");
                    return false;
                }
            }
            else
            {
                return false;
            }
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
                //string CToken = new Guid(user.Result.SecurityStamp).ToString();

                //user.Result.SecurityStamp = CToken;

                //_userManager.UpdateAsync(user.Result);

                TokenModel tokenModel = new TokenModel
                {
                    UserId = user.Result.Id,
                    CToken = user.Result.SecurityStamp
                };
                return tokenModel;
            }

            return null;
        }
    }
}