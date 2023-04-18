using System;

namespace Hillel_Lesson7_HW
{
    class Programm
    {
        
        static List<int> filteredRoots = new List<int>();
        
        static void Main(string[] args)
        {

            
            int[] numbers = new int[100000];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = i;
            }
            

            Filter filter = new Filter(FilterNumbers);
            

            Thread thread1 = new Thread(() =>
            {
                filter(numbers, 0, 20000);
            });
            Thread thread2 = new Thread(() =>
            {
                filter(numbers, 20000, 40000);
            });
            Thread thread3 = new Thread(() =>
            {
                filter(numbers, 40000, 60000);
            });
            Thread thread4 = new Thread(() =>
            {
                filter(numbers, 60000, 80000);
            });
            Thread thread5 = new Thread(() =>
            {
                filter(numbers, 80000, 100000);
            });

            
            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();
            thread5.Start();

            thread1.Join();
            thread2.Join();
            thread3.Join();
            thread4.Join();
            thread5.Join();
            

            foreach (int root in filteredRoots)
            {
                Console.WriteLine("{0}", root);
            }

            Console.WriteLine();



        }

        public delegate void Filter(int[] numbers, int start, int end);
        
        
        public static void FilterNumbers(int[] numbers, int start, int end)
        {
            for (int i = start; i < end; i++)
            {
                if (Math.Sqrt(numbers[i]) % 1 == 0)
                {
                    filteredRoots.Add(numbers[i]);
                }
            }
        }
        

    }
}