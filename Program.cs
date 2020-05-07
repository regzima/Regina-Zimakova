using System;
using System.Collections;
using System.Text;

namespace Task_1
{
    class Program
    {
        static void Main()
        {
            //1. Создаём динамический массив и массив, из которого будем вставлять элементы
            int[] Array = new int[3] {3,2,1};
            DArray<int> DArray = new DArray<int>(10);

            Console.WriteLine("РАБОТАЕМ С МАССИВОМ");
            Console.WriteLine("");
            Console.WriteLine("1. Создаём динамический массив");
            for (int i = 0; i < DArray.Capacity(); i++)
            {
                Console.Write($" {DArray[i]}");
            }

            //2. Заполняем массив троечками, а три последних элемента оставляем пустыми
            for (int i = 0; i < DArray.Capacity() - 3; i++)
            {
                DArray.EndAddElements(3);
            }
            Console.WriteLine("");
            Console.WriteLine("2. Заполняем массив троечками, кроме трёх последних элементов");
            for (int i = 0; i < DArray.Capacity(); i++)
            {
                Console.Write($" {DArray[i]}");
            }
            Console.WriteLine("");
            //3. В начало массива добавляем 1
            Console.WriteLine("3. Добавляем единичку в начало");
            DArray.CtrlCCtrlV(1, 0);
            for (int i = 0; i < DArray.Capacity(); i++)
            {
                Console.Write($" {DArray[i]}");
            }
            Console.WriteLine("");
            //4. В середину массива добавляем 6
            Console.WriteLine("4. В середину массива добавляем 6");
            DArray.CtrlCCtrlV(6, 5);
            for (int i = 0; i < DArray.Capacity(); i++)
            {
                Console.Write($" {DArray[i]}");
            }
            Console.WriteLine("");
            //5. Добавляем 9 в конец массива
            Console.WriteLine("5. Добавляем 9 в конец массива");
            DArray.EndAddElements(9);
            for (int i = 0; i < DArray.Capacity(); i++)
            {
                Console.Write($" {DArray[i]}");
            }
            Console.WriteLine("");
            //6. Добавляем содержимое массива parr
            Console.WriteLine("6. Добавляем содержимое массива Array");
            DArray.WidthAddElements(Array);
            for (int i = 0; i < DArray.Capacity(); i++)
            {
                Console.Write($" {DArray[i]}");
            }
            Console.WriteLine("");
            //7. Удаляем из массива 3
            Console.WriteLine("7. Удаляем из массива ВСЕ 3");
            DArray.DeleteElement(3);
            DArray.DeleteElement(3);
            DArray.DeleteElement(3);
            DArray.DeleteElement(3);
            DArray.DeleteElement(3);
            DArray.DeleteElement(3);
            DArray.DeleteElement(3);
            DArray.DeleteElement(3);
            for (int i = 0; i < DArray.Capacity(); i++)
            {
                Console.Write($" {DArray[i]}");
            }
            Console.WriteLine("");
            //8. Итоговые просчеты: число заполненных элементов и общее число элементов в массиве
            Console.Write("8. В массиве заполнено элементов - ");
            Console.Write($"{DArray.Length()}");
            Console.Write(", всего элементов в массиве - ");
            Console.Write($"{DArray.Capacity()}");
            Console.Write(". Конец!");
            Console.ReadKey();
        }
    }
}

