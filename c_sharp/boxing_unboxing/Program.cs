using System;
using System.Collections.Generic;

namespace boxing_unboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create an empty List of type object
            List<object> myList = new List<object>();
            //Add the following values to the list: 7, 28, -1, true, "chair"
            myList.Add(7);
            myList.Add(28);
            myList.Add(-1);
            myList.Add(true);
            myList.Add("chair");
            //Loop through the list and print all values
            foreach (object entry in myList)
            {
                Console.WriteLine(entry);
            }
            //Add all values that are Int type together and output the sum
            int sum = 0;
            foreach (object entry in myList)
            {
                if (entry is int)
                {
                    Console.WriteLine(entry);
                    sum += (int)entry;
                }
                else
                {
                    continue;
                }
            }
             Console.WriteLine(sum);
        }
    }
}
