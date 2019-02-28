using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrganikV1.Business.Abstract;
using OrganikV1.Common;
using System;
using System.Threading.Tasks;
namespace OrganikV1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IProductsService _productService;
        public UserController(IUserService userService, IProductsService productsService)
        {
            _userService = userService;
            _productService = productsService;
        }

        [HttpGet("userinfo/{userId}")]
        public async Task<IActionResult> GetUserInfo(string userId)
        {
            try
            {
                Entities.Entity.CustomUser userInfo = await _userService.UserInfo(userId, "");

                return Ok(JsonConvert.SerializeObject(ServiceResponse.GetSuccess(userInfo, "Bütün Bilgiler Listelendi")));

            }
            catch (Exception ex)
            {
                return Ok(JsonConvert.SerializeObject(ServiceResponse.GetError($"Hata : {ex.Message}")));
            }
            
        }

        [HttpGet("userproductlist/{userId}")]
        public IActionResult GetUserProductList(string userId)
        {
            try
            {
                var userProduct =  _productService.GetbyUserId(userId);

                return Ok(JsonConvert.SerializeObject(ServiceResponse.GetSuccess(userProduct, "Kullanıcıya Ait ürünler Listelendi")));

            }
            catch (Exception ex)
            {
                return Ok(JsonConvert.SerializeObject(ServiceResponse.GetError($"Hata : {ex.Message}")));
            }

        }

        // GET api/category
        // [HttpGet]
        // public async Task<ActionResult<IEnumerable<Categories>>> Get()
        // {
        //     try
        //     {
        //         List<Products> products = _userService.GetAll().FindAll(x=>x.isDeleted==false);

        //         return Ok(ServiceResponse.GetSuccess(products, "Bütün Ürünler Listelendi"));

        //     }
        //     catch (Exception ex)
        //     {
        //         return NotFound(ex);
        //     }
        // }
        // // GET api/category/5
        // [HttpGet("{id}")]
        // public async Task<ActionResult<Categories>> Get(int id)
        // {
        //     try
        //     {
        //         Products product = _productService.getProduct(null,id);
        //         if (product.isDeleted == false)
        //         {
        //             return Ok(product);
        //         }
        //         else
        //         {
        //             return Ok(ServiceResponse.GetSuccess(null, $"Veri Yok"));
        //         }

        //     }
        //     catch (Exception ex)
        //     {

        //         return NotFound(ServiceResponse.GetError($"HATA : {ex}"));
        //     }

        // }
        // //POST api/category
        //[HttpPost]
        // public async Task<IActionResult> Post([FromBody] Products products)
        // {
        //     try
        //     {
        //         _productService.Add(products);
        //         _productService.RemoveCache();
        //         ServiceResponse result = ServiceResponse.GetSuccess(_productService.GetAll().FindAll(x => x.isDeleted == false), "Ürün Başarıyla Eklendi. Kategoriler Listelendi");

        //         return Ok(result);

        //     }
        //     catch (Exception ex)
        //     {
        //         return NotFound(ServiceResponse.GetError($"HATA : {ex}"));
        //     }
        // }
        // // PUT api/values/5
        // [HttpPut("{id}")]
        // public async Task<IActionResult> Put(int id, [FromBody] Products products)
        // {
        //     Products uptedProd = _productService.getProduct(null,id);
        //     if (uptedProd != null)
        //     {
        //         try
        //         {
        //             products.productId = id;
        //             products.seoTitle = createURL(id, products.title);
        //             _productService.Update(products);
        //             _productService.RemoveCache();
        //             return Ok(ServiceResponse.GetSuccess(_productService.GetAll().FindAll(x => x.isDeleted == false), "Ürün Başarıyla Güncellendi"));
        //         }
        //         catch (Exception ex)
        //         {

        //             return NotFound(ServiceResponse.GetError($"Ürün Güncellenemedi. Nedeni : {ex}"));
        //         }
        //     }
        //     else
        //     {
        //         return NotFound(ServiceResponse.GetError("Böyle Bir Ürün Yok"));
        //     }
        // }
        // // DELETE api/values/5
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> Delete(int id)
        // {
        //     Products uptedProd = _productService.getProduct(null,id);
        //     if (uptedProd != null)
        //     {
        //         try
        //         {
        //             uptedProd.isDeleted = true;

        //             _productService.Update(uptedProd);

        //             _productService.RemoveCache();
        //             return Ok(ServiceResponse.GetSuccess(null, "Ürün Başarıyla Silindi"));
        //         }
        //         catch (Exception ex)
        //         {

        //             return NotFound(ServiceResponse.GetError($"Silinemedi!! HATA : {ex}"));
        //         }
        //     }
        //     else
        //     {
        //         return NotFound(ServiceResponse.GetError("Böyle Bir Ürün Yok"));
        //     }
        // }

        public string createURL(int id, string title)
        {
            string url = title.ToLower().ToCleanUrl() + "-" + id;
            return url;
        }
    }
}
