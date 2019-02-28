using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using OrganikV1.Business.Abstract;
using OrganikV1.WebUI.ViewModel;
using System.Linq;

namespace OrganikV1.WebUI.ViewComponents
{
    public class IndexSliderViewComponent : ViewComponent
    {
        private readonly IProductsService _productService;
        private readonly IProductPhotoService _productPhotoService;
        public IndexSliderViewComponent(IProductsService productsService, IProductPhotoService productPhotoService)
        {
            _productService = productsService;
            _productPhotoService = productPhotoService;
        }

        public ViewViewComponentResult Invoke()
        {
            HomeViewModel model = new HomeViewModel();
            model.LatesProducts = _productService.GetAll().Where(x => x.isDeleted == false).OrderByDescending(x => x.createdDate).Take(5).ToList();

            return View(model);
        }


    }
}
