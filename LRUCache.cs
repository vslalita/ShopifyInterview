using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopify2
{
    internal class LRUCache
    {
        private CacheQueue Cache;
        private int CacheSize = 100;

        public LRUCache(int cacheSize)
        {
            this.Cache = new CacheQueue(cacheSize);
            this.CacheSize = cacheSize;
        }

        public bool Write(string key, string value)
        {
            return Cache.Enqueue(key, value);
        }

        public string Read(string key)
        {
            return Cache.GetItemValue(key);
        }

        public void Clear()
        {
            Cache = new CacheQueue(CacheSize);
        }

        public int Count()
        {
            return Cache.GetCount();
        }

        public bool Delete(string key)
        {
            return Cache.Delete(key, out var item);
        }

        public void Print()
        {
            Cache.Print();
        }

    }
}
