using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Lab3._2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Guenther's Market!\n");

            
            
            
            Dictionary<string, decimal> items = new Dictionary<string, decimal>();

            items.Add("milk", 3.09m);
            items.Add("eggs", 1.99m);
            items.Add("chocolate milk", 4.49m);
            items.Add("grapes", 2.79m);
            items.Add("apples", 2.59m);
            items.Add("bacon", 4.99m);
            items.Add("ground beef", 7.89m);
            items.Add("chicken", 9.34m);


            Dictionary<string, decimal> items2 = new Dictionary<string, decimal>
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


            int largestKeyLen = 0;
            foreach (var key in items)
            {
                if (largestKeyLen < key.Key.Length)
                {
                    largestKeyLen = key.Key.Length;
                }
            }

            int itemSpace = largestKeyLen + 6;
            
            
            static void ShowList(int itemSpace, Dictionary<string, decimal> items)
            {
                int counter = 0;
                string listTitle = "Item" + new string(' ', itemSpace - 1) + "Price";
                Console.WriteLine(listTitle);
                Console.WriteLine("=================================");

                foreach (KeyValuePair<string, decimal> item in items)
                {
                    counter += 1;

                    string periods = new string('.', (itemSpace - item.Key.Length));

                    Console.WriteLine($"{counter}. {item.Key}{periods}${item.Value}");
                }
            }
            ShowList(itemSpace, items);

            // ask user to enter an item name
            // if the item exists, display the item and price and add that item and it's price to the user's oder
            // if the item doesn't exist, display and error and re-prompt the user

            static string addItem(Dictionary<string, decimal> dict)
            {
                bool valid = false;
                while (!valid)
                {
                    Console.Write("\nWhat item would you like to order? ");
                    string addition = Console.ReadLine().ToLower();
                    if (dict.ContainsKey(addition))
                    {
                        return addition;
                        valid = true;
                    }
                    else
                    {
                        int addInt = 0;
                        bool asInt = Int32.TryParse(addition, out addInt);
                        if (asInt && addInt >= 1 && addInt <= dict.Count)
                        {
                            int i = 0;
                            foreach (var n in dict)
                            {
                                i += 1;
                                if (addInt == i)
                                {
                                    return n.Key;
                                }
                            }
                            valid = true;
                        }
                        else
                        {
                            Console.WriteLine("Sorry, we don't have those. Please try again.");
                        }
                    }
                    
                }
                return "";
            }
            List<string> itemList = new List<string>();
            List<decimal> priceList = new List<decimal>();
            List<int> quantList = new List<int>();

            bool doneAdding = false;
            while (!doneAdding)
            {
                string userInput = addItem(items);

                Console.WriteLine($"\nYou selected {userInput} at the price of ${items[userInput]}.\n");
                
                if (itemList.IndexOf(userInput, 0) >= 0)
                {
                    int currentIndex = itemList.IndexOf(userInput, 0);
                    int currentQuant = quantList[currentIndex];
                    int newQuant = currentQuant + 1;
                    quantList[currentIndex] = newQuant;
                }
                else
                {
                    itemList.Add(userInput);
                    priceList.Add(items[userInput]);
                    quantList.Add(1);
                }
                
                
                bool validAns = false;
                while (!validAns)
                {
                    Console.Write("Would you like to add more items? (y/n): ");
                    string ans = Console.ReadLine().ToLower();
                    if (ans == "y" || ans == "n")
                    {
                        validAns = true;
                        if (ans == "y")
                        {
                            //Console.WriteLine("Let me just grab that list for you.");
                            //Thread.Sleep(500);
                            Console.Clear();
                            ShowList(itemSpace, items);
                        }
                        else
                        {
                            doneAdding = true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Sorry, that is not a valid input. Please try again. (Hint: 'y' or 'n')");
                    }
                }
                
            }
            Console.Clear();          
            Console.WriteLine("\nThanks for you order!");
            Console.WriteLine("Here's what you got:\n");

            string wordSpaces = new string(' ', itemSpace - 4);


            string listTitle = $"Item{wordSpaces}Price{wordSpaces.Substring(0, wordSpaces.Length / 2)}Quantity";
            Console.WriteLine(listTitle);
            string bar = "============================================";
            Console.WriteLine(bar);
            string secondPeriods = new string('.', itemSpace - 5);

            for (int i = 0; i < itemList.Count; i++)
            {
                string periods = new String('.', (itemSpace - itemList[i].Length));
                //string periods = new String('.', 8);

                Console.WriteLine($"{itemList[i]}{periods}${priceList[i]}{secondPeriods}{quantList[i]}");
            }
            
            // make a variable for average
            // fix formatting for Quantity

            Console.WriteLine(bar);

            
            
            decimal totalPrice = 0m;
            for (int i = 0; i < priceList.Count; i++)
            {
                totalPrice += priceList[i] * quantList[i];
            }

            // This was not working right.
            //decimal avg = Math.Round(priceList.Sum() / quantList.Sum(), 2);

            decimal avg = Math.Round(totalPrice / quantList.Sum(), 2);


            string listAvg = $"Average{new String(' ', itemSpace - 7)}${avg}{new String(' ',secondPeriods.Length)}{quantList.Sum()}\n";
            Console.WriteLine(listAvg);
            Console.WriteLine();

            decimal cheapPrice = 0;

            for (int i = 0; i < priceList.Count; i++)
            {
                if (i == 0)
                {
                    cheapPrice = priceList[i];
                }
                else
                {
                    if (priceList[i] < cheapPrice)
                    {
                        cheapPrice = priceList[i];
                    }
                }
            }

            //int currentIndex = itemList.IndexOf(userInput, 0);

            string cheapItem = itemList[priceList.IndexOf(cheapPrice, 0)];
            Console.WriteLine($"The cheapest item you purchased was {cheapItem}!\n");

            decimal expenPrice = 0;

            for (int i = 0; i < priceList.Count; i++)
            {
                if (i == 0)
                {
                    expenPrice = priceList[i];
                }
                else
                {
                    if (priceList[i] > expenPrice)
                    {
                        expenPrice = priceList[i];
                    }
                }
            }

            string expenItem = itemList[priceList.IndexOf(expenPrice, 0)];
            Console.WriteLine($"The most expensive item you purchased was {expenItem}!\n");

        }
    }
}
