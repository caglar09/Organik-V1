using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrganikV1.Common
{
   public interface ICache
    {
        bool TryGetValue(object key, List<object> value);


        ICacheEntry CreateEntry(object key);

        void Remove(object key);

        List<T> Get<T>(object key);

        List<T> Set<T>(object key, List<T> value);
    }
}
