using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrganikV1.Business.Abstract;
using OrganikV1.Common;
using OrganikV1.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace OrganikV1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductsService _productService;
        public ProductController(IProductsService productService)
        {
            _productService = productService;
        }
        // GET api/product
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categories>>> Get()
        {
            try
            {
                var products = _productService.GetAll().FindAll(x=>x.isDeleted==false);

                return Ok(ServiceResponse.GetSuccess(products, "Bütün Ürünler Listelendi"));

            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }
        // GET api/product/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Categories>> Get(int id)
        {
            try
            {
                Products product = _productService.getProduct(null,id);
                if (product.isDeleted == false)
                {
                    return Ok(product);
                }
                else
                {
                    return Ok(ServiceResponse.GetSuccess(null, $"Veri Yok"));
                }

            }
            catch (Exception ex)
            {

                return NotFound(ServiceResponse.GetError($"HATA : {ex}"));
            }

        }

        // GET api/product/jksadnjska55994 99
        [HttpGet("{userId}")]
        public IActionResult Get(string userId)
        {
            try
            {
                var userProduct = _productService.GetbyUserId(userId);

                return Ok(JsonConvert.SerializeObject(ServiceResponse.GetSuccess(userProduct, "Kullanıcıya Ait ürünler Listelendi")));

            }
            catch (Exception ex)
            {
                return Ok(JsonConvert.SerializeObject(ServiceResponse.GetError($"Hata : {ex.Message}")));
            }

        }

        //POST api/product
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Products products)
        {
            try
            {
                _productService.Add(products);
                _productService.RemoveCache();
                ServiceResponse result = ServiceResponse.GetSuccess(_productService.GetAll().FindAll(x => x.isDeleted == false), "Ürün Başarıyla Eklendi. Kategoriler Listelendi");

                return Ok(result);

            }
            catch (Exception ex)
            {
                return NotFound(ServiceResponse.GetError($"HATA : {ex}"));
            }
        }
        // PUT api/product/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Products products)
        {
            Products uptedProd = _productService.getProduct(null,id);
            if (uptedProd != null)
            {
                try
                {
                    products.productId = id;
                    products.seoTitle = createURL(id, products.title);
                    _productService.Update(products);
                    _productService.RemoveCache();
                    return Ok(ServiceResponse.GetSuccess(_productService.GetAll().FindAll(x => x.isDeleted == false), "Ürün Başarıyla Güncellendi"));
                }
                catch (Exception ex)
                {

                    return NotFound(ServiceResponse.GetError($"Ürün Güncellenemedi. Nedeni : {ex}"));
                }
            }
            else
            {
                return NotFound(ServiceResponse.GetError("Böyle Bir Ürün Yok"));
            }
        }
        // DELETE api/product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Products uptedProd = _productService.getProduct(null,id);
            if (uptedProd != null)
            {
                try
                {
                    uptedProd.isDeleted = true;

                    _productService.Update(uptedProd);

                    _productService.RemoveCache();
                    return Ok(ServiceResponse.GetSuccess(null, "Ürün Başarıyla Silindi"));
                }
                catch (Exception ex)
                {

                    return NotFound(ServiceResponse.GetError($"Silinemedi!! HATA : {ex}"));
                }
            }
            else
            {
                return NotFound(ServiceResponse.GetError("Böyle Bir Ürün Yok"));
            }
        }

        public string createURL(int id, string title)
        {
            string url = title.ToLower().ToCleanUrl() + "-" + id;
            return url;
        }
    }
}
