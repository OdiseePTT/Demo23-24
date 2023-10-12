using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop
{
    public class Store
    {
        private Dictionary<Product, int> inventory = new Dictionary<Product, int>();

        public void AddInventory(Product product, int quantity)
        {
            if(inventory.ContainsKey(product))
            {
                inventory[product] += quantity; 
            } else
            {
                inventory.Add(product, quantity);
            }
        }

        public void RemoveInventory(Product product, int quantity)
        {
            inventory[product] -= quantity;
        }

        public int GetInventory(Product product)
        {
            return inventory[product];
        }

        internal bool HasInventory(Product product, int quantity)
        {
            return inventory[product] >= quantity;
        }
    }
}
