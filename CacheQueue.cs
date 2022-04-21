using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopify2
{
    internal class CacheQueue
    {
        public Dictionary<String,Item> CachedKeys = new Dictionary<string,Item>();
        public LinkedList<Shopify2.Item> Cache = new LinkedList<Item>();
        public int MaxSize = 100;

        public CacheQueue(int size)
        {
            this.MaxSize = size;
        }

       
        public bool Enqueue(string key, String value)
        {
            if (IsFull())
            {
                DeQueue();
            }

            if (!KeyExists(key))
            {
                Item item = new Item(key, value);
                Cache.AddFirst(item);
                CachedKeys.Add(key, item);
                return true;
            }
            
            if (KeyExists(key))
            { 
                return ReEnQueue(key, value);
            }
            return false;
        }

        public bool ReEnQueue(string key, string value)
        {
            Delete(key, out Item item);
            item.Value = value;
            return Enqueue(key, value);
        }

        public bool DeQueue()
        {
            if(Cache.Last != null )
            {
                var item = Cache.Last.Value;
                Cache.RemoveLast();
                CachedKeys.Remove(item.Key);
                return true;
            }
            return false;   
        }

        public bool Delete(string key, out Item item)
        {
            item = GetItem(key);
            if (item != null)
            {
                Cache.Remove(item);
                CachedKeys.Remove(key);
                return true;
            }
            return false;
        }


        public bool KeyExists(string key)
        {
            return CachedKeys.ContainsKey(key);
        }

        public void Print()
        {
            foreach (var item in Cache)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }

        private bool IsFull()
        {
            return Cache.Count >= MaxSize;
        }

        public int GetCount()
        {
            return Cache.Count;
        }

        public String GetItemValue(string key)
        {
            Item item = GetItem(key);
            if (item != null)
            {
                ReEnQueue(item.Key, item.Value);
                return item.Value;
            }
            return null;
        }

        public Item GetItem(string key)
        {
            if (CachedKeys.TryGetValue(key, out Item item))
            {
                return item;
            }
            return null;
        }

    }
}
