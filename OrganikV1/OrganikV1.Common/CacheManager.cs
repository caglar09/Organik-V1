using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrganikV1.Common
{
   public  class CacheManager:ICache
    {
        private readonly IMemoryCache _memoryCache;

        public CacheManager(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public ICacheEntry CreateEntry(object key)
        {
            throw new NotImplementedException();
        }

        public List<T> Get<T>(object key)
        {
            List<T> a = _memoryCache.Get<List<T>>(key);
            return a;
        }

        public void Remove(object key)
        {
            _memoryCache.Remove(key);
        }

        public List<T> Set<T>(object key, List<T> value)
        {
            _memoryCache.Set(key,value);
            var res = Get<T>(key);
            return res;
        }

      

        public bool TryGetValue(object key, List<object> value)
        {
            return _memoryCache.TryGetValue(key,out value);
        }

       

    }
}
//CacheItemRemovedCallback