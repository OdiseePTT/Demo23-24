using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop
{
    public class Customer
    {
        private Dictionary<Product, int> basket = new Dictionary<Product, int>();

        public Dictionary<Product, int> Basket { get => basket; private set => basket = value; }

        public bool Purchase(Store store, Product product, int quantity)
        {
            if (!store.HasInventory(product, quantity))
            {
                return false;
            }

            store.RemoveInventory(product, quantity);

            basket.Add(product, quantity);

            return true;
        }
    }
}
