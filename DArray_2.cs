using System;

namespace Task_2
{
    public class DArray_2<T> where T:new()
    {

        private const int deafultCapacity = 8;
        private T[] array;

        public DArray_2()
        {
            array = new T[deafultCapacity];
        }

        public DArray_2(int size)
        {
            array = new T[size];
        }
        public DArray_2(T[] arr)
        {
            array = new T[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            { array[i] = arr[i]; }
        }
        public int Length
            { get; private set; }

        public int Size
        {
            get { 
                return array.Length; 
            }
            set { 
            }
        }

        public void PlusSize(int c) //увеличиваем ёмкость
        {
            if (c != Length)
            { if (c > 0)
                { 
                    T[] newItems = new T[c];
                    if (Length > 0) { 
                        Array.Copy(array, 0, newItems, 0, Length); 
                                    }  array = newItems;
                } else 
                {
                    array = new T[deafultCapacity];
                }
            }
        }

        public void Add(T item) //добавляем в массив новый элемент
        {
            if (Length == Size) PlusSize(Size*2);
            array[Length++] = item;
        }

        public void AddRange(T[] a) //добавляем несколько элементов в массив
        {
            if (Size-Length < a.Length)
            {
                PlusSize(Size + a.Length);
            }
            for (int i=0; i < a.Length; i++)
            {
                array[Length] = a[i];
                Length++;
            }
        }

        public void DeleteIndex (int index) //удаляем элемент по индексу
        {
            Length--;
            if (index < Length)
            {
                Array.Copy(array, index + 1, array, index, Length - index);
            }
            T t = default;
            array[Length] = t;
        }

        public bool Delete(T item) //удаляем элементы
        {
            int index = Array.IndexOf(array, item, 0, Length); ;
            if (index >= 0)
            {
                DeleteIndex(index);
                return true;
            }
            else { }
            return false;
        }

        public void Insert(T arr, int index) //вставка
        {
            if ((index > Size) || (index < 0)) throw new ArgumentOutOfRangeException();
            if (Size == Length) //если некуда вставлять
            {
                PlusSize(Size * 2);
            }

            for (int i = 0; i < Length - index; i++)
            {
                array[Length-i] = array[Length-i-1];
            }
            array[index] = arr; // можно вставлять
        }

        // Метод фильтрации
        public void Filter(Func<T, bool> func)
        {
            for (int i = 0; i < Length; i++)
            {
                if (!func(array[i]))
                {
                    DeleteIndex(i--);
                }
            }
        }

        public delegate bool Del(T t1);

        // Метод фильтрации с делегатом в качестве параметра
        public void FilterDelegate(Del D)
        {
            for (int i = 0; i < Length; i++)
            {
                if (!D (array[i]))
                {
                    DeleteIndex(i--);
                }
            }
        }

        //Метод сортировки
        public void Sort(Func<T, T, int>func)
        {
            T temp;

            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (func(array[j], array[j + 1]) == 1)
                    {
                        temp = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }

        //Компоратор, сравнивающий целые числа, числа с плавающей точкой и длины строк
        static public int Comparator(T t1, T t2)
        {
            if (int.TryParse(t1.ToString(), out int i1) == false)
                i1 = int.MaxValue;
            int.TryParse(t2.ToString(), out int i2);
            if (Double.TryParse(t1.ToString(), out double d1) == false)
                d1 = double.MaxValue;
            Double.TryParse(t2.ToString(), out double d2);
            string s1 = t1.ToString();
            string s2 = t2.ToString();
            if (i1 != int.MaxValue)
            {
                if (i1 == i2)
                    return 0;
                else if (i1 > i2)
                    return 1;
                else
                    return -1;
            }
            else if (d1 != Double.MaxValue)
            {
                if (d1 == d2)
                    return 0;
                else if (d1 > d2)
                    return 1;
                else
                    return -1;
            }
            else
            {
                if (s1.Length == s2.Length)
                    return 0;
                else if (s1.Length > s2.Length)
                    return 1;
                else
                    return -1;
            }
        }

        //Индексатор
        public T this[int i]
        { get { return array[i]; } set { array[i] = value; } }
    }
}