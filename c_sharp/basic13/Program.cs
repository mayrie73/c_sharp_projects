using System;
using System.Collections.Generic;
namespace basic13
{
    class Program
    {
        //Program that prints all the numbers from 1 to 255.
        public static void printOneTo255()
        {
            for (int i = 1; i <= 255; i++)
            {
                Console.WriteLine(i);
            }
        }
        // Program that prints all the odd numbers from 1 to 255.
        public static void printOddsOneTo255()
        {
            for (int i = 1; i <= 255; i++)
            {
                if (i % 2 == 1)
                {
                    Console.WriteLine(i);
                }
            }
        }
        // Print Sum of Numbers 1-255 as the numbers get printed.
        public static void printSumOneTo255()
        {
            int sum = 0;
            for (int i = 1; i <= 255; i++)
            {
                Console.WriteLine("New Number: {0} Sum: {1}", i, sum);
                sum += i;

            }
        }
        //Iterating through an Array
        public static void iterateArray(int[] arr)
        {
            foreach (int entry in arr)
            {
                Console.WriteLine(entry);
            }
        }
        //Program that takes any array and prints the maximum value in the array.
        public static void findMax(int[] arr)
        {
            int max = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }
            Console.WriteLine(max);
        }
        //Program that takes an array, and prints the AVERAGE of the values in the array. 
        public static void findAverage(int[] arr)
        {
            int sum = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];
            }
            int average = sum / arr.Length;
            Console.WriteLine(average);
        }
        //Program that creates an array 'y' that contains all the odd numbers between 1 to 255. 
        public static int[] printOddNums()
        {
            List<int> oddList = new List<int>();
            for (int i = 1; i <= 255; i++)
            {
                if (i % 2 == 1)
                {
                    oddList.Add(i);
                    Console.WriteLine(i);
                }
            }
            return oddList.ToArray();
        }
        // Program that takes an array and returns the number of values in that array whose value is greater than a given value y.
        public static int greaterThanY(int[] arr, int y)
        {
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > y)
                {
                    count++;
                }
            }
            Console.WriteLine(count);
            return count;
        }
        // Given an array of numbers, multiply each number by itself
        public static int[] squareNum(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = arr[i] * arr[i];
                Console.WriteLine(arr[i]);
            }
            return arr;
        }
        //Program that replaces negative numbers in an array with 0
        public static int[] replaceNegativesNums(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0)
                {
                    arr[i] = 0;
                }
                Console.WriteLine(arr[i]);
            }
            return arr;
        }
        //Program that prints the max, min, and average values in an array.
        public static void printMinMaxAverage(int[] arr)
        {
            int sum = 0;
            int max = arr[0];
            int min = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > max) { max = arr[i]; }
                if (arr[i] < min) { min = arr[i]; }
                sum += arr[i];
            }
            int average = sum / arr.Length;
            Console.WriteLine(min);
            Console.WriteLine(max);
            Console.WriteLine(average);

        }
        //Program that shifts each number in an array by one to the front and adds '0' to the end.
        public static int[] shiftArray(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                arr[i] = arr[i + 1];
                Console.WriteLine(arr[i]);
            }
            arr[arr.Length - 1] = 0;
            Console.WriteLine(arr[arr.Length - 1]);
            return arr;
        }
        //Program that takes an array of numbers and replaces any negative number with the string 'Dojo'
        public static object[] numbersToString(object[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if ((int)arr[i] < 0)
                {
                    arr[i] = "Dojo";
                }
                Console.WriteLine(arr[i]);
            }
            return arr;
        }

        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            //printOneTo255();
            //printOddsOneTo255();
            //printSumOneTo255();
            //int[] arr = {1,3,5,7,9,13};
            //iterateArray(arr);
            //int[] arr = {-1, -3, 0, 20, 15, 200};
            //findMax(arr);
            //int [] arr = {10, 10, 10};
            //findAverage(arr);
            //printOddNums();
            //int[] arr = { -1, -3, 0, 20, 15, 200 };
            //greaterThanY(arr, 3);
            //int [] arr = {10, 2, 3};
            //squareNum(arr);
            //replaceNegativesNums(arr);
            //printMinMaxAverage(arr);
            //int[] arr = { 1, 3, 10, 0, 15, 30, 60 };
            //shiftArray(arr);
            object[] arr = { -1, 1, -2, 2, -3, 3 };
            numbersToString(arr);
        }
    }
}
