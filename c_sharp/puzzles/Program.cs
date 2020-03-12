using System;
using System.Collections.Generic;
namespace puzzles
{
    class Program
    {
        //Create a function called RandomArray() that returns an integer array
        //Place 10 random integer values between 5-25 into the array
        public static void RandomArray()
        {
            int[] numArray = new int[10];
            Random rand = new Random();
            for (int i = 0; i < numArray.Length; i++)
            {
                numArray[i] = rand.Next(5, 26);
            }
            //Print the min and max values of the array
            // Print the sum of all the values
            int min = numArray[0];
            int max = numArray[0];
            int sum = 0;
            for (int i = 0; i < numArray.Length; i++)
            {
                if (numArray[i] < min)
                {
                    min = numArray[i];
                }
                if (numArray[i] > max)
                {
                    max = numArray[i];
                }
                sum += numArray[i];
            }
            Console.WriteLine(min);
            Console.WriteLine(max);
            Console.WriteLine(sum);
        }
        //Create a function called TossCoin() that returns a string
        public static int TossCoin()
        {
            //Have the function print "Tossing a Coin!"
            Console.WriteLine("Tossing a Coin");
            //Randomize a coin toss with a result signaling either side of the coin
            Random rand = new Random();
            int result = rand.Next(0, 2);
            //Have the function print either "Heads" or "Tails"
            if (result == 0)
            {
                Console.WriteLine("Heads");
            }
            else
            {
                Console.WriteLine("Tails");
            }
            //Finally, return the result
            return result;
        }
        //Create another function called TossMultipleCoins(int num) that returns a Double
        //Have the function call the tossCoin function multiple times based on num value
        //Have the function return a Double that reflects the ratio of head toss to total toss
        public static double TossMultipleCoins(int num)
        {
            int headCount = 0;
            int tailCount = 0;
            for (int i = 0; i < num; i++)
            {
                int result = TossCoin();
                if (result == 0)
                {
                    headCount++;
                }
                else
                {
                    tailCount++;
                }
            }
            if (headCount > tailCount)
            {
                double ratio = tailCount / headCount;
                Console.WriteLine(ratio);
                return ratio;
            }
            else
            {
                double ratio = headCount / tailCount;
                Console.WriteLine(ratio);
                return ratio;
            }
        }
        //Build a function Names that returns an array of strings
        //Create an array with the values: Todd, Tiffany, Charlie, Geneva, Sydney
        //Shuffle the array and print the values in the new order
        //Return an array that only includes names longer than 5 characters
        public static string[] Names()
        {
            string[] nameArr = { "Todd", "Tiffany", "Charlie", "Geneva", "Sydney" };
            Random rand = new Random();
            for (int i = 0; i < nameArr.Length; i++)
            {
                int index = rand.Next(0, nameArr.Length);
                string temp = nameArr[index];
                nameArr[index] = nameArr[i];
                nameArr[i] = temp;
            }
            foreach (string entry in nameArr)
            {
                Console.WriteLine(entry);
            }
            List<string> newArr = new List<string>();
            for (int i = 0; i < nameArr.Length; i++)
            {
                if (nameArr[i].Length > 5)
                {
                    newArr.Add(nameArr[i]);
                }
            }
            foreach (string entry in newArr)
            {
                Console.WriteLine(entry);
            }
            return newArr.ToArray();
        }
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //RandomArray();
            //TossCoin();
            //TossMultipleCoins(5);
            // Names();
        }
    }
}
