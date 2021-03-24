using System;
using System.Collections.Generic;

namespace Lab3._2_Review
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, decimal> menu = new Dictionary<string, decimal>
            {
                { "milk", 3.09m},
                {"eggs", 1.99m},
                {"chocolate milk", 4.49m},
                {"grapes", 2.79m},
                {"apples", 2.59m},
                {"bacon", 4.99m},
                {"ground beef", 7.89m},
                {"chicken", 9.34m }
            };



            // Customber Shopping Cart
            List<string> food = new List<string>();
            List<decimal> prices = new List<decimal>();

            // Practice
            /*
            string item = "apple";
            food.Add(item);
            decimal price = menu[item];
            prices.Add(price);

            string item2 = "banana";
            food.Add(item2);
            decimal price2 = menu[item2];
            prices.Add(price2);
            */

            bool done = false;

            while (!done)
            {
                Console.Write("What would you like to buy? ");
                string item3 = Console.ReadLine();

                if(menu.ContainsKey(item3) == false)
                {
                    // item not in menu
                    Console.WriteLine("Sorry we don't have that.");
                    // this will skip everything for the rest of the loop and start it over
                       
                    continue;
                }
                food.Add(item3);
                decimal price3 = menu[item3];
                prices.Add(price3);
                Console.Write("Would you like to add more items? (y/n)");
                string entry = Console.ReadLine();
                if (entry == "n")
                {
                    done = true;
                }
            }

            decimal totalprice = 0;



            // Print out the lists
            for (int i = 0; i < food.Count; i++)
            {
                Console.WriteLine($"{food[i]}.......{prices[i]}");
                totalprice += totalprice + prices[i];
            }
            Console.WriteLine($"The average price is {totalprice / food.Count}");
        }
    }
}
