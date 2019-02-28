using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using OrganikV1.Business.Abstract;
using OrganikV1.WebUI.ViewModel;

namespace OrganikV1.WebUI.ViewComponents
{
    public class CategoriesViewComponent:ViewComponent
    {
        private readonly ICategoryService _categoryService;
        public CategoriesViewComponent(ICategoryService categoryService, IProductsService productsService, IProductPhotoService productPhotoService)
        {
            _categoryService = categoryService;
        }

        public ViewViewComponentResult Invoke()
        {
            HomeViewModel model = new HomeViewModel();
            model.Categories = _categoryService.GetAll().Where(x => x.isDeleted == false).OrderBy(x => x.catName).ToList();            
            return View(model);
        }

        
    }
}
