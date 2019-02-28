using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;
using OrganikV1.Business.Abstract;
using OrganikV1.Common;
using OrganikV1.Dal.Abstract;
using OrganikV1.Entities;

namespace OrganikV1.Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;
        private IMemoryCache _memoryCache;
        public CategoryManager(ICategoryDal categoryDal, IMemoryCache memoryCache)
        {
            _categoryDal = categoryDal;
            _memoryCache = memoryCache;
        }
        public void Add(Categories category)
        {
            _categoryDal.Add(category);
        }

        public void Delete(int catId)
        {
            _categoryDal.Delete(new Categories { catId=catId});
        }

        public List<Categories> GetAll()
        {
            var cacheItem = _memoryCache.Get<List<Categories>>(Utility.categoryKey);
            
            if (cacheItem!=null)
            {
                return cacheItem;
            }
            else
            {
                var category = _categoryDal.GetList();
                _memoryCache.Set<List<Categories>>(Utility.categoryKey, category);
                return category;
            }
           
        }

        public Categories getCategories(int catId)
        {
            return _categoryDal.Get(p=>p.catId==catId);
        }

        public int productListCount(int catId)
        {
            return _categoryDal.Count(p=>p.catId==catId);
        }

        public void RemoveCache()
        {
            _memoryCache.Remove(Utility.categoryKey);
        }

        public void Update(Categories category)
        {
            _categoryDal.Update(category);
        }
    }
}
