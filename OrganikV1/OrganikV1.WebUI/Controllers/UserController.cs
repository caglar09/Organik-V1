using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrganikV1.Business.Abstract;
using OrganikV1.Common;
using OrganikV1.Entities;
using OrganikV1.Entities.Entity;
using OrganikV1.WebUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrganikV1.WebUI.Controllers
{

    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IProductsService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IProductPhotoService _productPhotoService;
        private readonly ICommentService _commentService;
        public UserController(IUserService userService, IProductsService productService, ICategoryService categoryService, IProductPhotoService productPhotoService, ICommentService commentService)
        {
            _userService = userService;
            _productService = productService;
            _categoryService = categoryService;
            _productPhotoService = productPhotoService;
            _commentService = commentService;
        }

        [Route("~/User/{id?}")]
        public IActionResult Index()
        {
            return View();
        }

        #region UserSetting
        [HttpGet]
        [Route("~/User/Setting")]
        public IActionResult Setting()
        {
            try
            {
                CustomUser user = GetUserInfo();
                CustomUser customUser = new CustomUser();
                customUser = user;
                return View(customUser);

            }
            catch (Exception ex)
            {
                TempData.Add("updateStatus", ex.Message.ToString());
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        [Route("~/User/Setting")]
        public async Task<IActionResult> Setting(CustomUser customUser)
        {
            try
            {
                CustomUser user = GetUserInfo();

                user.twitter = customUser.twitter;
                user.facebook = customUser.facebook;
                user.instagram = customUser.instagram;
                user.name = customUser.name;
                user.lastname = customUser.lastname;
                user.website = customUser.website;
                user.Adress = customUser.Adress;
                user.Age = customUser.Age;
                user.Content = customUser.Content;
                user.Gender = customUser.Gender;

                Microsoft.AspNetCore.Identity.IdentityResult result = await _userService.Update(user);

                if (result.Succeeded == true)
                {
                    TempData.Add("updateStatus", "Bilgiler Başarılı bir şekilde güncellendi");
                }
                else
                {
                    TempData.Add("updateStatus", result.Errors);
                }


                return RedirectToAction("Setting");
            }
            catch (Exception ex)
            {
                TempData.Add("updateStatus", ex.Message.ToString());
                return RedirectToAction("Setting");
            }

        }
        #endregion

        #region UserImage
        [HttpGet]
        [Route("~/User/Photo")]
        public IActionResult Photo()
        {
            return View();
        }


        [HttpPost]
        [Route("~/User/Photo")]
        public IActionResult Photo(IFormFile formFile)
        {
            string name = IOExtension.Upload(formFile, "User");
            string username = User.Identity.Name;

            CustomUser user = new CustomUser();
            Task<CustomUser> info = _userService.UserInfo(null, username);

            user = info.Result;
            user.userPhoto = name;

            _userService.Update(user);

            return RedirectToAction("Index");
        }
        #endregion

        #region ProductList/Add/Update/Delete
        [HttpGet]
        [Route("~/User/Product")]
        public IActionResult Product()
        {
            string userId = GetUserInfo().Id;
            System.Collections.Generic.List<Products> productList = _productService.GetbyUserId(userId);
            return View(productList);
        }

        [HttpGet]
        [Route("~/User/Productupdate/{seoTitle}")]
        [Route("~/User/Productupdate/newProduct={newProduct}")]
        public IActionResult Productupdate(string seoTitle, string newProduct)
        {
            if (seoTitle != null)
            {
                HomeViewModel model = new HomeViewModel
                {
                    ProductsOne = _productService.getProduct(seoTitle, null),
                    Categories = _categoryService.GetAll()
                };
                return View(model);
            }

            if (newProduct == "true")
            {
                HomeViewModel model = new HomeViewModel
                {
                    Categories = _categoryService.GetAll()
                };
                return View(model);
            }
            return RedirectToAction("Product");
        }

        [HttpPost]
        [Route("~/User/Productupdate/{seoTitle}")]
        public IActionResult Productupdate(Products model, IFormFile productPhoto)
        {
            try
            {
                Products uptProd = _productService.getProduct(model.seoTitle, null);
                //uptProd.Categories =_categoryService.GetAll() ;
                Products prod = new Products
                {
                    productId = uptProd.productId,
                    catId = model.catId,
                    cinsispecies = model.cinsispecies,
                    content = model.content,
                    createdDate = DateTime.Now,
                    isDeleted = false,
                    price = model.price,
                    priceType = model.priceType,
                    province = model.province,
                    seoTitle = createURL(model.productId, model.title),
                    status = model.status,
                    stockCount = model.stockCount,
                    stockStatus = model.stockStatus,
                    title = model.title,
                    userId = GetUserInfo().Id
                };
                prod.productPhoto = (productPhoto == null ? uptProd.productPhoto : IOExtension.Upload(productPhoto, "Product"));



                _productService.Update(prod);
                _productService.RemoveCache();
                TempData.Add("updateStatus", "Ürün güncelleme işlemi başarılı");
                return RedirectToAction("Product");
            }
            catch (Exception ex)
            {
                TempData.Add("updateStatus", ex.Message);
                return RedirectToAction("Productupdate");
            }
        }

        [HttpPost]
        [Route("~/User/ProductAdd")]
        public IActionResult ProductAdd(Products model, IFormFile productPhoto)
        {
            try
            {
                Products prod = new Products
                {

                    catId = model.catId,
                    cinsispecies = model.cinsispecies,
                    content = model.content,
                    createdDate = DateTime.Now,
                    isDeleted = false,
                    price = model.price,
                    priceType = model.priceType,
                    province = model.province,
                    seoTitle = createURL(model.productId, model.title),
                    status = model.status,
                    stockCount = model.stockCount,
                    stockStatus = model.stockStatus,
                    title = model.title,
                    userId = GetUserInfo().Id
                };
                prod.productPhoto = IOExtension.Upload(productPhoto, "Product");



                _productService.Add(prod);
                _productService.RemoveCache();
                TempData.Add("updateStatus", "Ürün Ekleme işlemi başarılı");
                return RedirectToAction("Product");
            }
            catch (Exception ex)
            {
                TempData.Add("updateStatus", ex.Message);
                return RedirectToAction("Productupdate");
            }
        }


        [HttpGet]
        [Route("~/User/ProductDelete/{productId}")]
        public IActionResult ProductDelete(int productId)
        {
            if (productId != null)
            {
                Products prod = _productService.getProduct(null, productId);

                if (prod != null)
                {
                    prod.isDeleted = true;
                    _productService.Update(prod);
                    _productService.RemoveCache();
                    return RedirectToAction("Product");
                }
                TempData.Add("updateStatus", "Böyle Bir ürün bulunamadı");
                return RedirectToAction("Product");
            }

            TempData.Add("updateStatus", "Böyle Bir ürün bulunamadı");
            return RedirectToAction("Product");
        }
        #endregion

        #region ProductGallery
        [HttpGet]
        [Route("~/User/ProductGallery/{seoTitle}")]
        public IActionResult ProductGallery(string seoTitle)
        {
            if (seoTitle != null)
            {
                int prod = _productService.getProduct(seoTitle, null).productId;
                if (prod != null)
                {
                    HomeViewModel model = new HomeViewModel
                    {
                        seoTitle = seoTitle,
                        ProductsPhoto = _productPhotoService.GetProductPhotoList(prod),
                    };
                    return View(model);
                }
                TempData.Add("updateStatus", "Böyle Bir ürün bulunamadı");
                return RedirectToAction("Product");
            }
            return RedirectToAction("Product");
        }


        [HttpPost]
        [Route("~/User/ProductGallery/{seoTitle}")]
        public IActionResult ProductGallery(string seoTitle, List<IFormFile> filePhotos)
        {
            try
            {
                int productId = _productService.getProduct(seoTitle, null).productId;
                List<ProductPhoto> productPhotos = new List<ProductPhoto>();

                foreach (IFormFile photo in filePhotos)
                {
                    if (photo.Length > 0)
                    {
                        ProductPhoto pht = new ProductPhoto
                        {
                            productId = productId,
                            path = IOExtension.Upload(photo, "Product")
                        };
                        productPhotos.Add(pht);
                    }
                }

                _productPhotoService.Add(productPhotos);
                _productPhotoService.RemoveCache();
                TempData.Add("updateStatus", "Resimler Başarılı Bir şekilde Yüklendi");
                return RedirectToAction("ProductGallery/" + seoTitle);
            }
            catch (Exception ex)
            {

                TempData.Add("updateStatus", ex);
                return RedirectToAction("ProductGallery/" + seoTitle);
            }
        }

        [HttpGet]
        [Route("~/User/ProductGalleryDelete/{id}/{seoTitle}")]
        public IActionResult ProductGalleryDelete(int id, string seoTitle)
        {
            try
            {
                if (id != null)
                {
                    ProductPhoto photo = _productPhotoService.GetPhoto(id);

                    _productPhotoService.Delete(photo.photoId);

                    TempData.Add("updateStatus", "Resim Başarılı bir şekilde silindi");
                    _productPhotoService.RemoveCache();
                    return RedirectToAction("ProductGallery/" + seoTitle);
                }
                TempData.Add("updateStatus", "Resim silinemedi");
                return RedirectToAction("ProductGallery/" + seoTitle);
            }
            catch (Exception ex)
            {
                TempData.Add("updateStatus", ex);
                return RedirectToAction("ProductGallery/" + seoTitle);
            }

        }

        #endregion

        #region ProductComment
        [HttpGet]
        [Route("~/User/ProductComment/{seoTitle}")]
        public IActionResult ProductComment(string seoTitle)
        {
            if (seoTitle != null)
            {
                Products prod = _productService.getProduct(seoTitle, null);
                //List<Comments> comment = _commentService.GetAllComments(prod.productId);
                HomeViewModel model = new HomeViewModel
                {
                    Comments = _commentService.GetAllComments(prod.productId)
            };
                return View(model);
            }
            else
            {
                return RedirectToAction("Product");
            }

        }

        [HttpGet]
        [Route("~/User/ProductComment/{seoTitle}/{commentId}")]
        public IActionResult ProductComment(string seoTitle,int commentId)
        {
            if (commentId != null || commentId != 0)
            {
                Comments comment = _commentService.GetComment(commentId);
                comment.activeted = false;
                _commentService.Update(comment);
                //return View();
                return RedirectToAction("ProductComment/" + seoTitle);
            }
            else
            {
                return RedirectToAction("Product");
            }

        }
        #endregion

        public CustomUser GetUserInfo()
        {
            string username = User.Identity.Name;
            return _userService.UserInfo(null, username).Result;
        }

        public string createURL(int id, string title)
        {
            string url = title.ToLower().ToCleanUrl() + "-" + id;
            return url;
        }
    }
}