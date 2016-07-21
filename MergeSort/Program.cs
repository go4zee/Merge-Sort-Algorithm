using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Program p = new Program();
            Console.WriteLine("Enter the array elements to sort(Press Esc to start sort):");

            var inputNumbers = readlineWithCancel();
            foreach (int i in inputNumbers)
                Console.WriteLine();
            if (NotEmpty(inputNumbers.ToList()))
            {
                var sorted = MergeSort(inputNumbers);
                Console.WriteLine("Sorted Array:");
                for (int i = 0; i < sorted.Length; i++)
                {
                    Console.WriteLine(sorted[i]);
                }
            }
            Console.ReadKey();
        }


        private static int[] MergeSort(int[] numbers)
        {
            if (numbers.Length <= 1) return numbers;

            var left = new List<int>();
            var right = new List<int>();

            Divide(numbers, left, right);

            left = MergeSort(left.ToArray()).ToList();
            right = MergeSort(right.ToArray()).ToList();

            return Merge(left, right);
        }

        private static int[] Merge(List<int> left, List<int> right)
        {
            var result = new List<int>();

            while ((NotEmpty(left)) && (NotEmpty(right)))
            {
                if (left.First() <= right.First())
                {
                    MoveValueFromSourceToResult(left, result);
                }
                else
                {
                    MoveValueFromSourceToResult(right, result);
                }
            }

            while ((NotEmpty(left)))
            {
                MoveValueFromSourceToResult(left, result);
            }
            while (NotEmpty(right))
            {
                MoveValueFromSourceToResult(right, result);
            }

            return result.ToArray();
        }

        private static void MoveValueFromSourceToResult(List<int> list, List<int> result)
        {
            result.Add(list.First());
            list.RemoveAt(0);
        }

        private static bool NotEmpty(List<int> listToCheck)
        {
            return listToCheck.Count > 0;
        }

        private static void Divide(int[] numbers, List<int> left, List<int> right)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (i % 2 > 0)
                    left.Add(numbers[i]);
                else
                    right.Add(numbers[i]);

            }
        }

        /// <summary>
        /// Reads the given input stream for numbers and adds to the array until Esc key is pressed
        /// </summary>
        /// <returns></returns>
        private static int[] readlineWithCancel()
        {
            List<int> input = new List<int>();
            ConsoleKeyInfo cki;
            int i = 0;
            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Escape)
                {
                    Console.Write(key.KeyChar);
                    var enteredKey = key.KeyChar + Console.ReadLine();
                    if (int.TryParse(enteredKey, out i))
                        input.Add(int.Parse(enteredKey));
                    else
                        Console.WriteLine("\nError: Please Enter Numbers:");
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine("\nEntered Array:");
            foreach (int k in input)
                Console.WriteLine(k);

            return input.ToArray();
        }
    }
}


