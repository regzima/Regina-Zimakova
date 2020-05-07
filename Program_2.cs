using System;

namespace Task_2
{
    internal class Program_2
    {
        private static void Main(string[] args)
        {
            var a = new DArray_2<int>();
            a.Add(8); // добавляем 8-ку в массив
            for (int i = 0; i < a.Size; i++)
            Console.Write(a[i] + " ");
            Console.WriteLine();
            Console.WriteLine();
            int[] A = new int[7] {1,2,3,4,5,6,7};
            a.AddRange(A); //передаём содержимое в а

            //В метод Sort передается лямбда выражение
            a.Sort((t1, t2) =>
            {
                string s1 = t1.ToString();
                string s2 = t2.ToString();
                if (s1.Length == s2.Length)
                    return 0;
                else if (s1.Length > s2.Length)
                    return 1;
                else
                    return -1;
            });

            a.Sort(DArray_2<int>.Comparator);
            for (int i = 0; i < a.Size; i++)
                Console.Write(a[i] + " ");
            Console.WriteLine();
            a.FilterDelegate((o) => o > 5); //оставляем все, что больше 5-ти
            Console.WriteLine();
            for (int i = 0; i < a.Size; i++)
                Console.Write(a[i] + " ");
            Console.WriteLine();
            var d = new DArray_2<double>();
            double[] arrD = new double[8] {5.55, 3.33, 7.77, 2.22, 8.88, 4.44, 6.66, 1.11};
            d.AddRange(arrD);
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < d.Size; i++)
                Console.Write(d[i] + " ");
            Console.WriteLine();
            Console.WriteLine();
            d.Sort(DArray_2<double>.Comparator); //сравниваем числа между собой и переставляем в порядке возрастания
            for (int i = 0; i < d.Size; i++)
                Console.Write(d[i] + " ");
            d.Filter((o) => o > 4); //оставляем все, что больше 4
            Console.WriteLine();
            Console.WriteLine();
            for (int i = 0; i < d.Size; i++)
                Console.Write(d[i] + " ");
            Console.ReadKey();
        }
    }
}