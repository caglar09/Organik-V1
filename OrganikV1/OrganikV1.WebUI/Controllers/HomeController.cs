using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Caching.Distributed;
using OrganikV1.Business.Abstract;
using OrganikV1.Common;
using OrganikV1.Entities;
using OrganikV1.WebUI.Models;
using OrganikV1.WebUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OrganikV1.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductsService _productService;
        private readonly IProductPhotoService _productPhotoService;
        private readonly IUserService _userService;

        private readonly ICommentService _commentService;

        public HomeController(ICategoryService categoryService, IProductsService productsService, IProductPhotoService productPhotoService, IUserService userService, ICommentService commentService)
        {
            _categoryService = categoryService;
            _productService = productsService;
            _productPhotoService = productPhotoService;
            _userService = userService;
            _commentService = commentService;
        }

        [Route("/")]
        [Route("/{catId}")]
        [Route("/{page}")]
        [Route("/{catId}/{page}")]
        [HttpGet]
        public IActionResult Index(int page = 1, int catId=0)
        {
            
            int pageSize = 10;
            if (ModelState.IsValid)
            {
                try
                {
                    var products= _productService.GetbyCategories(catId);
                    HomeViewModel model = new HomeViewModel();
                    model.Products = products.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                    model.PageCount = (int)Math.Ceiling(products.Count/(double)pageSize);
                    model.PageSize = pageSize;
                    model.CurrentCategory = catId;
                    model.CurrentPage = page;

                    if (model.Products.Count != 0)
                    {
                        model.ProductsPhoto = _productPhotoService.GetAll();
                    }
                    return View(model);
                }
                catch (Exception)
                {

                    return View("Error");
                }
            }
            return View();
        }

        [Route("/product/{Url}")]
        [HttpGet]
        public IActionResult Product(string Url)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var prod = _productService.getProduct(Url, null);
                    var comment = _commentService.GetAllComments(prod.productId).Where(x=>x.activeted==true && x.isDeleted==false).ToList();
                    HomeViewModel model = new HomeViewModel
                    {
                        ProductsOne = prod,
                        Comments = comment,
                    };

                    model.ProductsPhoto = _productPhotoService.GetProductPhotoList(model.ProductsOne.productId);

                    if (model.ProductsOne.userId != null || model.ProductsOne.userId != "")
                    {
                        model.productUser = _userService.UserInfo(model.ProductsOne.userId,null).Result;
                    }
                    //ViewData["Message"] = "Your application description page.";

                    return View(model);
                }
                catch (Exception)
                {

                    return View("Error");
                }
            }

            return View();

        }

        [Route("/category/{catId}")]
        [HttpGet]
        public IActionResult category(int catId)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    HomeViewModel model = new HomeViewModel
                    {
                        //model.CategoryOne = _categoryService.getCategories(catId);
                        Products = _productService.GetAll().Where(x => x.isDeleted == false && x.catId == catId).OrderByDescending(x => x.createdDate).ToList()
                    };
                    if (model.Products.Count != 0)
                    {
                        model.ProductsPhoto = _productPhotoService.GetAll();
                    }
                    return View(model);
                }
                catch (Exception)
                {

                    return View("Error");
                }
            }

            return View();

        }


        [Route("/UserDetail/{Id}")]
        [HttpGet]
        public IActionResult UserDetail(string Id)
        {
            if (Id!=null || Id!="")
            {
                var user=_userService.UserInfo(Id, null);
                var product = _productService.GetbyUserId(Id);
                HomeViewModel model = new HomeViewModel();

                model.productUser = user.Result;
                model.Products = product;
                return View(model);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        //Comment Add
        [Route("/AddComment")]
        [HttpPost]
        public async Task<IActionResult> AddComment(string Url,Comments comments)
        {
            try
            {
                comments.commentDate = DateTime.Now;
                comments.activeted = true;
                comments.isDeleted = false;
                _commentService.Add(comments);
                //TempData.Add("commentStatus", "Yorum Ekleme işlemi başarılı");
                return Redirect("product/"+Url);
            }
            catch (Exception ex)
            {
                //TempData.Add("commentStatus", ex.Message);
                return Redirect("product/" + Url);
            }
          
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
