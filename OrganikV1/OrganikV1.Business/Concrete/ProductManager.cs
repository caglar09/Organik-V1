using Microsoft.Extensions.Caching.Memory;
using OrganikV1.Business.Abstract;
using OrganikV1.Common;
using OrganikV1.Dal.Abstract;
using OrganikV1.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace OrganikV1.Business.Concrete
{
    public class ProductManager : IProductsService
    {
        private IProductsDal _productsDal;
        private IMemoryCache _memoryCache;
        public ProductManager(IProductsDal productsDal,IMemoryCache memoryCache)
        {
            _productsDal = productsDal;
            _memoryCache = memoryCache;
        }

        public void Add(Products product)
        {
            _productsDal.Add(product);
        }

        public void Delete(int productId)
        {
            _productsDal.Delete(new Products { productId=productId});
        }

        public List<Products> GetAll()
        {
            var cacheItem = _memoryCache.Get<List<Products>>(Utility.productKey);

            if (cacheItem!=null)
            {
                return cacheItem;
            }
            else
            {
                var item = _productsDal.GetList(x=>x.isDeleted==false);
                _memoryCache.Set<List<Products>>(Utility.productKey,item);
                return item;
            }
            
        }

        public List<Products> GetbyCategories(int catId)
        {
            return _productsDal.GetList(p => p.catId == catId||catId==0 && p.isDeleted==false);
        }

        public List<Products> GetbyUserId(string userId)
        {
            return _productsDal.GetList(p => p.userId == userId && p.isDeleted==false);
        }

        public Products getProduct(string Url,int? id)
        {
            if (id.HasValue)
            {
                return _productsDal.FirstOrDefault(p => p.productId == id && p.isDeleted==false);
            }
            return _productsDal.FirstOrDefault(p => p.seoTitle == Url && p.isDeleted == false);
        }

        public int productListCount()
        {
            return _productsDal.GetList(p=>p.isDeleted == false).Count;
        }

        public void RemoveCache()
        {
            _memoryCache.Remove(Utility.productKey);
        }

        public void Update(Products product)
        {
            _productsDal.Update(product);
        }

        public int userProductCount(string userId)
        {
            return _productsDal.GetList(p => p.userId == userId && p.isDeleted == false).Count;
        }
    }
}
