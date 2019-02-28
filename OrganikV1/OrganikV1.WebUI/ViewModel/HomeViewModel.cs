using OrganikV1.Entities;
using OrganikV1.Entities.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrganikV1.WebUI.ViewModel
{
    public class HomeViewModel
    {
        public List<Categories> Categories { get; set; }
        public Categories CategoryOne { get; set; }
        public List<Products> Products { get; set; }

        public Products ProductsOne { get; set; }
        public CustomUser productUser { get; set; }
        public List<ProductPhoto> ProductsPhoto { get; set; }

        public List<Products> LatesProducts { get; set; }

        public List<Comments> Comments { get; set; }

        public CustomUser userInfo { get; set; }

        public string seoTitle { get; set; }

        public int PageSize { get; set; }

        public int PageCount { get; set; }

        public int CurrentCategory { get; set; }

        public int CurrentPage { get; set; }

    }
}
