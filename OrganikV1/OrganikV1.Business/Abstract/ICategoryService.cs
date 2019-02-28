using System;
using System.Collections.Generic;
using System.Text;
using OrganikV1.Entities;
namespace OrganikV1.Business.Abstract
{
   public interface ICategoryService
    {
        List<Categories> GetAll();

        Categories getCategories(int catId);

        //List<Categories> GetbyCategories(int catId);
        //List<Products> GetbyUserId(string userId);

        int productListCount(int catId);

        //int userProductCount(string userId);

        void Add(Categories category);
        void Update(Categories category);
        void Delete(int catId);

        void RemoveCache();
    }
}
