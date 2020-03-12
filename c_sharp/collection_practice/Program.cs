using System;
using System.Collections.Generic;

namespace collection_practice
{
    class Program
    {
        static void Main(string[] args)
        {
            //array to hold interger values 0 - 9
            int[] numArray = new int[9];
            int[] numArray1 = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            foreach (int value in numArray1)
            {
                Console.WriteLine(value);
            }
            //An array of the names "Tim", "Martin", "Nikki", & "Sara"
            string[] myNames = new string[4] { "Tim", "Martin", "Nikki", "Sara" };
            foreach (string name in myNames)
            {
                Console.WriteLine(name);
            }
            //An array of length 10 that alternates between true and false values, starting with true
            bool[] myArray = new bool[10];
            for (var i = 0; i < 10; i += 2)
            {
                myArray[i] = true;
            }
            foreach (bool value in myArray)
            {
                Console.WriteLine(value);
            }
            // INFO: MULTIPLICATION TABLE.
            // With the values 1-10, use code to generate a multiplication table.
            int[,] multiTable = new int[10, 10];
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    multiTable[x, y] = (x + 1) * (y + 1);

                    Console.Write(string.Format("{0} ", multiTable[x, y]));
                }
                Console.Write(Environment.NewLine);
            }

            //Create a list of Ice Cream flavors that holds at least 5 different flavors
            // Initializing an empty list of Ice Cream flavors
            List<string> iceCream = new List<string>();
            // Use the add function in a similar fashion to push
            iceCream.Add("Chocolate");
            iceCream.Add("Caramel");
            iceCream.Add("Strawberry");
            iceCream.Add("Dulce de Leche");
            iceCream.Add("Strawberry Cheesecake");
            {
                //Output the length of this list after building it 
                Console.WriteLine("The current Ice-Cream flavors we have are");
                for (var i = 0; i < iceCream.Count; i++)
                {
                    Console.WriteLine("-" + iceCream[i]);
                }
                //Output the third flavor in the list, then remove this value.
                Console.WriteLine(iceCream[2]);
                iceCream.RemoveAt(2);
            }
            //Output the new length of the list 
            Console.WriteLine("The current Ice-Cream flavors we have are");
            for (var i = 0; i < iceCream.Count; i++)
            {
                Console.WriteLine("-" + iceCream[i]);
            }
            //Create a Dictionary that will store both string keys as well as string values
            Dictionary<string, string> userInfo = new Dictionary<string, string>();

            userInfo.Add("Chasity", "null");
            userInfo.Add("Charles", "null");
            userInfo.Add("Cornelius", "null");
            userInfo.Add("Mary", "null");
            userInfo.Add("Jasmine", "null");
            {
                foreach (var entry in userInfo)
                {
                    Console.WriteLine(entry.Key + " - " + entry.Value);
                }
                //For each name key, select a random flavor from the flavor list above and store it as the value
                Random rand = new Random();
                var keys = new List<string>(userInfo.Keys);
                foreach (string key in keys)
                {
                    userInfo[key] = iceCream[rand.Next(iceCream.Count)];
                }
                //Loop through the Dictionary and print out each user's name and their associated ice cream flavor.
                foreach (var entry in userInfo)
                {
                    Console.WriteLine(entry.Key + " - " + entry.Value);
                }
            }
        }
    }
}

