using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoffeeShopSystem; // Ensure this matches your namespace for CoffeeShop
using System;

namespace Testing
{
    [TestClass]
    public class CoffeeShopTests
    {
        private CoffeeShop coffeeShop;

        [TestInitialize]
        public void Setup()
        {
            // Initialize CoffeeShop instance before each test
            coffeeShop = new CoffeeShop();
            coffeeShop.UpdateMenuPrices(3.00, 5.50); // Set default prices
        }

        [TestMethod]
        public void CalculateOrderTotal_OnlyCoffee_ReturnsCorrectTotal()
        {
            // Arrange
            bool wantsCoffee = true;
            bool wantsSandwich = false;

            // Act
            double total = InvokeCalculateOrderTotal(wantsCoffee, wantsSandwich);

            // Assert
            Assert.AreEqual(3.00, total, "Total for coffee-only order is incorrect.");
        }

        [TestMethod]
        public void CalculateOrderTotal_OnlySandwich_ReturnsCorrectTotal()
        {
            // Arrange
            bool wantsCoffee = false;
            bool wantsSandwich = true;

            // Act
            double total = InvokeCalculateOrderTotal(wantsCoffee, wantsSandwich);

            // Assert
            Assert.AreEqual(5.50, total, "Total for sandwich-only order is incorrect.");
        }

        [TestMethod]
        public void CalculateOrderTotal_CoffeeAndSandwich_ReturnsCorrectTotal()
        {
            // Arrange
            bool wantsCoffee = true;
            bool wantsSandwich = true;

            // Act
            double total = InvokeCalculateOrderTotal(wantsCoffee, wantsSandwich);

            // Assert
            Assert.AreEqual(8.50, total, "Total for coffee and sandwich order is incorrect.");
        }

        [TestMethod]
        public void CalculateOrderTotal_NothingOrdered_ReturnsZero()
        {
            // Arrange
            bool wantsCoffee = false;
            bool wantsSandwich = false;

            // Act
            double total = InvokeCalculateOrderTotal(wantsCoffee, wantsSandwich);

            // Assert
            Assert.AreEqual(0.00, total, "Total for no items ordered is incorrect.");
        }

        // Helper method to test the private method using reflection
        private double InvokeCalculateOrderTotal(bool wantsCoffee, bool wantsSandwich)
        {
            var method = typeof(CoffeeShop)
                .GetMethod("CalculateOrderTotal", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            return (double)method.Invoke(coffeeShop, new object[] { wantsCoffee, wantsSandwich });
        }
    }
}
