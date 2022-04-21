using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopify2
{
    public class Item
    {
        public string Key;
        public string Value;

        public Item(string key, string value)
        {
            this.Key = key;
            this.Value = value;
        }
    }
}
