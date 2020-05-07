using System;

namespace Task_1
{
    internal class DArray<datatype>
    {
        private int size;
        private int a;
        private datatype[] array;

        //1. Создаём конструктор без параметров:
        public DArray()
        {
            array = new datatype[10];
            size = 10;
        }

        //2. Создаём конструктор с одним целочисленным параметром
        public DArray(int n)
        {
            if (n <= 0)
            { n = 3; }
            array = new datatype[n];
            size = n;
        }

        //3. Создаём конструктор, который принимает в качестве параметра длину массива
        public DArray(datatype[] arr)
        {
            array = new datatype[arr.Length];
            size = arr.Length;
        }

        //4. Создаём метод, который позволяет добавить элемент в конец массива
        public void EndAddElements(datatype item)
        {
            Edit(a); array[a] = item; a++;
        }

        //5. Создаём метод, который позволяет добавить перечисление в конец массива
        public void WidthAddElements(datatype[] x)
        {
            int n = 0;
            for (int i = 0; i < x.Length; i++)
            {
                EditArray(a, n, x.Length);
                array[a] = x[n];
                a++; n++;
            }
        }

        //6. Создаём метод, который позволяем поменять размер массива
        private void Edit(int v)
        {
            if (size <= v)
            {
                while (size <= v) { PlusSize(); }
                datatype[] k = new datatype[size];
                for (int i = 0; i < array.Length; i++) { k[i] = array[i]; }
                array = k;
            }
        }

        //7. Создаём метод, который позволяет добавить элементы из массива в массив
        private void EditArray(int v, int count, int length)
        {
            if (size <= v)
            {
                while (size <= v) { PlusSizeArray(count, length); }
                datatype[] temparray = new datatype[size];
                for (int i = 0; i < array.Length; i++) { temparray[i] = array[i]; }
                array = temparray;
            }
        }

        //8. Создаём метод, который добавляет три элемента к массиву, если нет мест
        private void PlusSize()
        {
            size += 3;
        }
        private void PlusSizeArray(int count, int length)
        {
            size += length - count;
        }
        //8. Создаём метод, который удаляет элемент из массива
        public bool DeleteElement(datatype item)
        {
            for (int i = 0; i < a; i++)
            {
                if (array[i].Equals(item))
                {
                    IndexOfArray(i);
                    return true;
                }
            }
            return false;
        }

        //9. Находим индекс элемента
        private void IndexOfArray(int v)
        {
            if (v>=a) { throw new IndexOutOfRangeException(); }
            int ind = v+1;
            if (ind<a)
            {
                datatype[] k = new datatype[size];
                Array.Copy(array, 0, k, 0, ind);
                Array.Copy(array, ind, k, v, a-ind);
                array = k;
            } a--; //пустые элементы не имеют индекса
        }

        //10. Создаём метод вставки элемента в массив
        public bool CtrlCCtrlV(datatype item, int v)
        {
            if (v >= size) { throw new IndexOutOfRangeException(); }
            datatype[] k = new datatype[size];
            int length = k.Length;
            Array.Copy(array, 0, k, 0, v);
            k[v] = item;
            for (int i = v + 1; i <= length; i++)
            {
                if (k.Length - (a + 1) < 0)
                {
                    PlusSize();
                    datatype[] t = new datatype[size];
                    for (int j = 0; j < k.Length; j++) 
                    { 
                        t[j] = k[j]; 
                    }
                    k = t;
                }
                try { k[i] = array[i - 1]; }
                catch{}
            }
            array = k;
            a++;
            return true;
        }

        //11. Ищем длину заполненного массива
        public int Length()
        { return a; }

        //12. Ищем длину всего массива
        public int Capacity()
        { return array.Length; }

        //13. Инициализируем динамический массив
        public datatype this[int i]
        { get { return array[i]; } set { array[i] = value; } }
    }
}