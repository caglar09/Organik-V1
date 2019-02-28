using Microsoft.AspNetCore.Mvc;
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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET api/category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Categories>>> Get()
        {
            try
            {
                List<Categories> cat = _categoryService.GetAll().FindAll(x=>x.isDeleted==false);

                return Ok(ServiceResponse.GetSuccess(cat, "Bütün Kategoriler Listelendi"));

            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        // GET api/category/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Categories>> Get(int id)
        {
            try
            {
                Categories cat = _categoryService.getCategories(id);
                if (cat.isDeleted == false)
                {
                    return Ok(cat);
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

        // POST api/category
        //[HttpPost]
        //public async Task<IActionResult> Post([FromBody] Categories categories)
        //{
        //    try
        //    {
        //        _categoryService.Add(categories);
        //        _categoryService.RemoveCache();
        //        ServiceResponse result = ServiceResponse.GetSuccess(_categoryService.GetAll().FindAll(x => x.isDeleted == false), "Kategori Başarıyla Eklendi. Kategoriler Listelendi");
           
        //        return Ok(result);
                
        //    }
        //    catch (Exception ex)
        //    {
        //        return NotFound(ServiceResponse.GetError($"HATA : {ex}"));
        //    }
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> Put(int id, [FromBody] Categories categories)
        //{
        //    Categories uptedCat = _categoryService.getCategories(id);
        //    if (uptedCat != null)
        //    {
        //        try
        //        {
        //            categories.catId = id;
        //            categories.seoTitle = createURL(id,categories.catName);
        //            _categoryService.Update(categories);
        //            _categoryService.RemoveCache();
        //            return Ok(ServiceResponse.GetSuccess(_categoryService.GetAll().FindAll(x => x.isDeleted == false), "Kategori Başarıyla Güncellendi"));
        //        }
        //        catch (Exception ex)
        //        {

        //            return NotFound(ServiceResponse.GetError($"Kategori Güncellenemedi. Nedeni : {ex}"));
        //        }
        //    }
        //    else
        //    {
        //        return NotFound(ServiceResponse.GetError("Böyle Bir Kategori Yok"));
        //    }
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    Categories uptedCat = _categoryService.getCategories(id);
        //    if (uptedCat!=null)
        //    {
        //        try
        //        {
        //            uptedCat.isDeleted = true;

        //            _categoryService.Update(uptedCat);

        //            _categoryService.RemoveCache();
        //            return Ok(ServiceResponse.GetSuccess(null, "Kategori Başarıyla Silindi"));
        //        }
        //        catch (Exception ex)
        //        {

        //            return NotFound(ServiceResponse.GetError($"Silinemedi!! HATA : {ex}"));
        //        }
        //    }
        //    else
        //    {
        //        return NotFound(ServiceResponse.GetError("Böyle Bir Kategori Yok"));
        //    }
        //}


        public string createURL(int id, string title)
        {
            string url = title.ToLower().ToCleanUrl() + "-" + id;
            return url;
        }
    }
}
