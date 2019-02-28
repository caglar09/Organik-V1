using OrganikV1.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrganikV1.Business.Abstract
{
   public interface IProductsService
    {
        List<Products> GetAll();

        Products getProduct(string Url, int? id);

        List<Products> GetbyCategories(int catId);
        List<Products> GetbyUserId(string userId);

        int productListCount();

        int userProductCount(string userId);

        void Add(Products product);
        void Update(Products product);
        void Delete(int productId);
        void RemoveCache();

    }
}
