using System;

namespace Hillel_Lesson7_HW
{
    class Programm
    {
        static void Main(string[] args)
        {

            
            int[] numbers = new int[100000];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = i;
                // Console.WriteLine(i);
            }

            List<int> filteredRoots = new List<int>();


            Filter filter = new Filter(FilterNumbers);
            
            




            Console.WriteLine();



        }

        public delegate void Filter(int[] numbers, int start, int end, List<int> filteredNumbers);

        public static void FilterNumbers(int[] numbers, int start, int end, List<int> filteredNumbers)
        {
            for (int i = start; i < end; i++)
            {
                if (Math.Sqrt(numbers[i]) % 1 == 0)
                {
                    filteredNumbers.Add(numbers[i]);
                }
            }
        }



    }
}