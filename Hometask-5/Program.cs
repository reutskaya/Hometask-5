using System;
using System.Collections.Generic;

namespace Hometask_5
{
    /// <summary>
    /// Program class is the main class of the solution.
    /// </summary>
    class Program
    {
        public static void Main(string[] args)
        {
            List<int> list = new List<int> { 1, 13, 0, 9, 88, 24 };

            Console.WriteLine("List after Map function");
            PrintList(Map(list, x => (x - 2)));

            Console.WriteLine("List after Filter function");
            PrintList(Filter(list, x => (x % 2) == 0));

            Console.WriteLine("Result ot Fold function is " + Fold(list, 8, (acc, x) => (acc + x * 2)));

            Console.ReadKey();
        }

        /// <summary>
        /// This method prints the list to the console.
        /// </summary>
        /// <param name="list">The list.</param>
        public static void PrintList(List<int> list)
        {
            if (list.Count <= 0)
            {
                Console.WriteLine("List is empty");
                throw new NullReferenceException();
            }
            else
            {
                foreach (int element in list)
                {
                    Console.WriteLine(element);
                }
            }    
        }

        /// <summary>
        /// Map method applies a function to each element of the list.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="function">The function returns integer value.</param>
        /// <returns>Changed list.</returns>
        public static List<int> Map(List<int> list, Func<int, int> function)
        {
            List<int> result = new List<int> { };
            foreach (int x in list)
            {
                result.Add(function(x));
            }
              
            return result;
        }

        /// <summary>
        /// Filter method applies a function to each element of the list.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="function">The function return true or false.</param>
        /// <returns>List of elements: function(element) = true.</returns>
        public static List<int> Filter(List<int> list, Func<int, bool> function)
        {
            List<int> result = new List<int> { };
            foreach (int x in list)
            {
                if (function(x))
                {
                    result.Add(x);
                }
            }

            return result;
        }

        /// <summary>
        /// Fold method accumulate elements of the list 
        /// starting from the current value 
        /// according to accumulation function.
        /// </summary>
        /// <param name="list">The list.</param>
        /// <param name="firstEl">The current accumulated value.</param>
        /// <param name="function">Accumulation function returns integer value.</param>
        /// <returns>New accumulated value.</returns>
        public static int Fold(List<int> list, int firstEl, Func<int, int, int> function)
        {
            int result = firstEl;
            foreach (int x in list)
            {
                result = function(result, x);
            }
            return result;
        }
    }
}