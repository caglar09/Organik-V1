using Microsoft.Extensions.Caching.Memory;
using OrganikV1.Business.Abstract;
using OrganikV1.Common;
using OrganikV1.Dal.Abstract;
using OrganikV1.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrganikV1.Business.Concrete
{
    public class ProductPhotoManager : IProductPhotoService
    {
        private IProductPhotoDal _productPhotoDal;
        private IMemoryCache _memoryCache;
        public ProductPhotoManager(IProductPhotoDal productPhotoDal,IMemoryCache memoryCache)
        {
            _productPhotoDal = productPhotoDal;
            _memoryCache = memoryCache;
        }

        public List<ProductPhoto> GetAll()
        {
            var cacheItem = _memoryCache.Get<List<ProductPhoto>>(Utility.productPhotoKey);
            if (cacheItem!=null)
            {
                return cacheItem;
            }
            else
            {
                var list = _productPhotoDal.GetList();
                _memoryCache.Set<List<ProductPhoto>>(Utility.productPhotoKey,list);
                return list;
            }
        }

        public List<ProductPhoto> GetProductPhotoList(int productId)
        {
            var item = _productPhotoDal.GetList(x=>x.productId==productId);
            return item;
        }

        public int productPhotoCount(int productId)
        {
            return _productPhotoDal.Count(p=>p.productId==productId);
        }
        public void Add(List<ProductPhoto> photo)
        {
            foreach (var item in photo)
            {
                _productPhotoDal.Add(item);
            }
           
        }

        public void Delete(int photoId)
        {
            _productPhotoDal.Delete(new ProductPhoto { photoId = photoId });
        }
        public void Update(ProductPhoto photo)
        {
            _productPhotoDal.Update(photo);
        }

        public void RemoveCache()
        {
            _memoryCache.Remove(Utility.productPhotoKey);
        }

        public ProductPhoto GetPhoto(int id)
        {
          return _productPhotoDal.Get(x => x.photoId == id);
        }
    }
}
