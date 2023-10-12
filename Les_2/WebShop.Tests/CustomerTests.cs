using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop.Tests
{

    public class CustomerTests
    {



        /*
         * Context: we maken een programma voor het beheer van de inventaris van een webshop
         * Test case: Aankoop lukt indien voldoende voorraad
         * Beschrijving: indien de klant producten koopt die voldoende voorradig zijn, wordt de aankoop succesvol afgerond en wordt de inventaris bijgewerkt.
         * Pre-condities: er zijn 10 flessen shampoo beschikbaar in de inventaris
         * Stappen: de klant koopt 5 flessen shampoo
         * Resultaten (post-condities):
         *  De aankoop is gelukt
         *  5 flessen shampoo in basket
         *  Het aantal flessen shampoo van de inventaris werd met 5 verlaagd
         * 
         */
        [Fact]

        public void Purchase_WithEnoughInventoryInStore_PurchaseSucceedAndInventoryIsChanged()
        {
            // Arrange
            Store store = new Store();
            store.AddInventory(Product.Shampoo, 10);
            Customer sut = new Customer();
            Dictionary<Product, int> expectedBasket = new Dictionary<Product, int>() { { Product.Shampoo, 5 } }; 

            // Act
            bool result = sut.Purchase(store, Product.Shampoo, 5);

            // Assert
            Assert.True(result);
            Assert.Equal(5, store.GetInventory(Product.Shampoo));
            Assert.Equal(5, sut.Basket[Product.Shampoo]);
            Assert.Equal(expectedBasket, sut.Basket);

            result.Should().BeTrue();
            store.GetInventory(Product.Shampoo).Should().Be(5);
            sut.Basket[Product.Shampoo].Should().Be(5);
            sut.Basket.Should().BeEquivalentTo(expectedBasket);

        }
    }
}
