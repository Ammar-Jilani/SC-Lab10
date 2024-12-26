using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopSystem
{
    public class CoffeeShop
    {
        private double coffeePrice;
        private double sandwichPrice;

        // Encapsulation
        public double CoffeePrice
        {
            get => coffeePrice;
            private set => coffeePrice = value;
        }

        public double SandwichPrice
        {
            get => sandwichPrice;
            private set => sandwichPrice = value;
        }

        // Splitting for clarity
        public void ProcessOrder(string customerName, bool wantsCoffee, bool wantsSandwich)
        {
            double total = CalculateOrderTotal(wantsCoffee, wantsSandwich);

            DisplayOrderSummary(customerName, total);
            ProcessPayment(total);
        }

        private double CalculateOrderTotal(bool wantsCoffee, bool wantsSandwich)
        {
            double total = 0;
            if (wantsCoffee) total += CoffeePrice;
            if (wantsSandwich) total += SandwichPrice;
            return total;
        }

        private void DisplayOrderSummary(string customerName, double total)
        {
            Console.WriteLine($"Order processed for: {customerName}");
            Console.WriteLine($"Total amount to pay: {total:C}");
        }

        private void ProcessPayment(double amount)
        {
            Console.WriteLine($"Processing payment of {amount:C}");
        }

        // Renaming for clarity
        public void UpdateMenuPrices(double newCoffeePrice, double newSandwichPrice)
        {
            CoffeePrice = newCoffeePrice;
            SandwichPrice = newSandwichPrice;
        }
        static void Main(string[] args)
        {

            CoffeeShop shop = new CoffeeShop();

            // Update prices
            shop.UpdateMenuPrices(3.00, 5.50);

            // Process orders
            shop.ProcessOrder("Ammar", wantsCoffee: true, wantsSandwich: true);
            shop.ProcessOrder("Tauseef", wantsCoffee: true, wantsSandwich: false);

        }

    }
}