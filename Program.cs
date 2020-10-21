using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp2
{
    class Program
    {
        static bool Check(string[] ArrayLine, int n)//Проверка строки 
        {
            if (ArrayLine.Length != n)// Сравнение количества чисел в строке
            {
                return false;
            }
            for (int i = 0; i < n; i++)
            {
                if (String.IsNullOrEmpty(ArrayLine[i]))// Проверка элемента на пустоту
                    return false;
                int val;
                bool isNum = int.TryParse(ArrayLine[i], out val);// Пытаемся преобразовать в int, если не получается возвращаем false
                if (!isNum)
                    return false;
            }
            return true;
        }
        static void WriteMatrix(int[,] arr, int n, int m)//Вывод Матрицы
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        static void WriteMaxMin(int mx, int mn)
        {
            if (mx == -2147483648 || mn == 2147483647){// Если переменные равны стандартным значениям значит массив пуст и возвращем нули
                mn = 0;
                mx = 0;
            }
            Console.WriteLine("\n" +
                $"Минимальный элемент = {mn}\n" +
                $"Максимальный элемент = {mx}\n");
        }
        static void ReadMatrix(int n, int m, int[,] arr, int[,] arr1)// Считывание двух двухмерных массивов размера n на m 
        {
            Console.WriteLine("Ввод первого массива");
            for (int i = 0; i < n; i++)
            {
                string[] MatrixLine = Console.ReadLine().Split(' ');
                while (!Check(MatrixLine, m))// Считывание строки пока она не будет введена правильно
                {
                    Console.WriteLine("Введите еще раз");
                    MatrixLine = Console.ReadLine().Split(' ');
                }
                for (int j = 0; j < m; j++)
                {
                    arr[i, j] = Convert.ToInt32(MatrixLine[j]);
                }
                
            }
           
            Console.WriteLine("Ввод второго массива");
            for (int i = 0; i < n; i++)
            {
                string[] MatrixLine = Console.ReadLine().Split(' ');
                while (!Check(MatrixLine, m))// Считывание строки пока она не будет введена правильно
                {
                    Console.WriteLine("Введите еще раз");
                    MatrixLine = Console.ReadLine().Split(' ');
                }
                for (int j = 0; j < m; j++)
                {
                    arr1[i, j] = Convert.ToInt32(MatrixLine[j]);
                }

            }
            Console.WriteLine();
        }
        static void ReadArr(int[] arr, int n)// Чтение массива
        {
            Console.WriteLine("Введите массив:");
            string[] StringArray = Console.ReadLine().Split(' ');
            while (!Check(StringArray, n))// Считывание n пока не пройдети проверку на число
            {
                Console.WriteLine("Введите еще раз");
                StringArray = Console.ReadLine().Split(' ');
            }
            for (int i = 0; i < n; i++)
            {
                arr[i] = Convert.ToInt32(StringArray[i]);
            }
            Console.WriteLine("\n");
        }
        static void WriteArr(int[] arr, int n)// Вывод массива
        {
            for(int i = 0; i < n; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }
        static void SimpleOutput()// Вывод с использованием своих алгоритмов
        {
            string[] n1;
            Console.WriteLine("Введите количество элементов:");
            n1 = Console.ReadLine().Split(' ');
            while (!Check(n1, 1))// Считывание n пока не пройдети проверку на число
            {
                Console.WriteLine("Введите еще раз");
                n1 = Console.ReadLine().Split(' ');
            }
            
            int n = Convert.ToInt32(n1[0]);
            int[] arr = new int[n];
            int[] EvenArr = new int[n];
            int k = 0;
            int mn = 2147483647, mx = -2147483648;
            ReadArr(arr, n);
            for (int i = 0; i < n; i++)
            {
                //Console.WriteLine(arr[i]);
                mn = Math.Min(mn, arr[i]);// Определение макс и мин в массиве
                mx = Math.Max(mx, arr[i]);
                if (arr[i] % 2 == 0)
                {
                    EvenArr[k] = arr[i];
                    k++;
                }
            }
            for (int i = 1; i < n; i++)// Простая сортировка пузырьком, загуглите, а то я ленив
            {
                for (int j = 1; j <= n - i; j++)
                {
                    if (arr[j - 1] > arr[j])//Changing the comporator will reverse the sort
                    {
                        int t = arr[j - 1];
                        arr[j - 1] = arr[j];
                        arr[j] = t;
                    }
                }
            }

            WriteArr(arr,n);

            Console.WriteLine("Отсортированный массив\n");

            for (int i = n-1; i >= 0; i--)
            {
                Console.Write(arr[i] + " ");
            }
            Console.WriteLine("Отсортированный в обратном порядке массив\n");

            WriteArr(EvenArr, k);
            Console.WriteLine("Четный массив\n");

            WriteMaxMin(mx, mn);
        }
       
        
        static void ComplexOutput()// Вывод с использованием встроенных инструментов
        {
            int n;
            string[] n1;
            Console.WriteLine("Введите количество элементов:");
            n1 = Console.ReadLine().Split(' ');
            while (!Check(n1, 1))// Считывание n пока не пройдети проверку на число
            {
                Console.WriteLine("Введите еще раз");
                n1 = Console.ReadLine().Split(' ');
            }
            n = Convert.ToInt32(n1[0]);
            int[] arr = new int[n];
            ReadArr(arr, n);
            Array.Sort(arr);
            WriteArr(arr, n);
            Console.WriteLine("Отсортированный массив\n");
            int mn = 2147483647, mx = -2147483648;// Значения необходимы для того чтобы всегда можно было их заменить на любое число в массиве
            List<int> EvenArr = new List<int>();
            for (int i = 0; i < n; i++)
            {
                mn = Math.Min(mn, arr[i]);
                mx = Math.Max(mx, arr[i]);
                if (arr[i] % 2 == 0)
                {
                    EvenArr.Add(arr[i]);
                }
            }
            Array.Reverse(arr);
            WriteArr(arr,n);
            Console.WriteLine("Отсортированный в обратном порядке массив\n");

            for (int i = 0; i < EvenArr.Count; i++)
            {
                Console.Write(EvenArr[i] + " ");
            }
            Console.WriteLine("Четный массив\n");

            WriteMaxMin(mx, mn);

        }
        static void Arr()
        {
            string str = " ";
            while (str != "0")
            {
               Console.WriteLine(
               "Меню:\n"+
               "А. Вывод элементов массива\n" +
               "B. Использование свойств и методов класса System.Array\n" +
               "\n" +
               "0. Назад\n"+
               "Для выбора введите букву...");
               str = Console.ReadLine().ToUpper();
               switch (str)
               {
                    case "A":
                        SimpleOutput();
                        break;
                    case "B":
                        ComplexOutput();
                        break;
                    case "0":
                        break;
               }
            }
        }
        static void MatrixArr()
        {
            Console.WriteLine("Введите длинну и ширину матрицы:");
            int n, m;
            string[] StringNandM = Console.ReadLine().Split(' ');
            while(!Check(StringNandM, 2))//Считывание M и N пока они не пройдут проверку на верность
            {
                Console.WriteLine("Введите еще раз");
                StringNandM = Console.ReadLine().Split(' ');
            }              
            n = Convert.ToInt32(StringNandM[0]);
            m = Convert.ToInt32(StringNandM[1]);
            int[,] arr = new int[n, m];
            int[,] arr1 = new int[n, m];
            ReadMatrix(n, m, arr, arr1);
            int mn = 2147483647, mx = -2147483648;
            int[,] MatrixSum = new int[n, m];
            int[,] MatrixMultiply = new int[n, m];
            int[,] MatrixDif = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    mx = Math.Max(mx, Math.Max(arr[i, j], arr1[i, j]));//Самый правый Math.Max сравнивает значения двух матриц с одинаковым индексом
                    mn = Math.Min(mn, Math.Min(arr[i, j], arr1[i, j]));//Самый левый Math.Max сравнивает максимальный из них с глобальным максимумов матриц
                    MatrixSum[i,j] = arr[i, j] + arr1[i, j];
                    MatrixMultiply[i, j] = arr[i, j] * arr1[i, j];
                    MatrixDif[i, j] = arr[i, j] - arr1[i, j];              
                }
            }
            Console.WriteLine("Сумма масивов:");
            WriteMatrix(MatrixSum, n, m);
            Console.WriteLine("Разность массивов:");
            WriteMatrix(MatrixDif, n, m);
            Console.WriteLine("Произведение массивов:");
            WriteMatrix(MatrixMultiply, n, m);
            WriteMaxMin(mx, mn);
            Console.WriteLine("Первый массив");
            WriteMatrix(arr, n, m);
            Console.WriteLine("Второй массив");
            WriteMatrix(arr1, n, m);
            Console.WriteLine();
        }
        static void JaggedArr()
        {
            Console.WriteLine("Введите количество строк массива:");
            int n;
            string[] n1;
            n1 = Console.ReadLine().Split(' ');
            while (!Check(n1, 1))// Считывание n пока не пройдети проверку на число
            {
                Console.WriteLine("Введите еще раз");
                n1 = Console.ReadLine().Split(' ');
            }
            n = Convert.ToInt32(n1[0]);
            int[][] arr = new int[n][];
            for(int i = 0; i < n; i++)
            {
                string[] StringArray = Console.ReadLine().Split(' ');
                while (!Check(StringArray, StringArray.Length))// Считывание строки пока она не будет введена правильно
                {
                    Console.WriteLine("Введите еще раз");
                    StringArray = Console.ReadLine().Split(' ');
                }
                arr[i] = new int[StringArray.Length];
                for(int j = 0; j < StringArray.Length; j++)
                {
                    arr[i][j] = Convert.ToInt32(StringArray[j]);
                }
            }
            int mn = 2147483647, mx = -2147483648;
            Console.WriteLine("Введенный массив:");
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write(arr[i][j] + " ");
                }
                Console.WriteLine();
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)//Лучше не списывать а придумать способ изменения самому
                {
                    mx = Math.Max(arr[i][j], mx);
                    mn = Math.Min(arr[i][j], mn);
                    arr[i][j] = 1; //Замена всех чисел на единичку перед этим сравнивая их с макс и мин. ПРОСТО ПОТОМУ ЧТО!!!(в задании сказано изменить массив..)
                }
            }

            Console.WriteLine("Измененный массив:");
            for (int i = 0; i < n; i++)
            {
                for(int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write(arr[i][j] + " ");
                }
                Console.WriteLine();
            }

            WriteMaxMin(mx, mn);

        }
        
        static void Main(string[] args)
        {
            int a = 1;
            while (a != 0)
            {
                Console.WriteLine(
                    "Меню:\n" +
                    "1. Работа с одномерными массивами\n" +
                    "2. Работа с двухмерными массивами\n" +
                    "3. Работа со ступенчатыми массивами\n" +
                    "0. Выход из программы\n" +
                    "\n" +
                    "Для выбора введите цифру...");
                a = Convert.ToInt32(Console.ReadLine());
                switch (a)
                {
                    case 0:
                        break;
                    case 1:                        
                        Arr();
                        break;
                    case 2:
                        MatrixArr();                      
                        break;
                    case 3:
                        JaggedArr();                        
                        break;
                    default:
                        Console.WriteLine("Введите число еще раз");
                        break;
                }
            }
        }
    }
}
