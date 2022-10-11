using System;
using System.Collections.Generic;
using System.Threading;

namespace Homework
{
    class Helpers
    {
        #region Common

        public static void FillArray(int[,] arr, int min, int max)
        {
            Random random = new Random();
            int firstLength = arr.GetLength(0), secondLength = arr.GetLength(1);
            for (int firstCount = 0; firstCount < firstLength; firstCount++)
            for (int secondCount = 0; secondCount < secondLength; secondCount++) arr[firstCount, secondCount] = random.Next(min, max);
        }

        public static void Hashes()
        {
            Console.WriteLine();
            for (int count = 0; count < Console.WindowWidth; count++) Console.Write("#");
            Console.WriteLine("\n");
        }

        public static int IncreaseToMultiple(int number)
        {
            if (number % 8 == 0) return number;
            else return IncreaseToMultiple(number += 1);
        }

        public static void PrintArray<T>(T[,] arr, int posX = -1)
        {
            Random random = new Random();
            int firstLength = arr.GetLength(0), secondLength = arr.GetLength(1);
            for (int firstCount = 0; firstCount < firstLength; firstCount++)
            {
                if (posX != -1) Console.SetCursorPosition(posX, Console.CursorTop);
                for (int secondCount = 0; secondCount < secondLength; secondCount++) Console.Write($"{arr[firstCount, secondCount]}\t");
                Console.WriteLine();
            }
        }
        #endregion

        #region Task54
        public static void DescendingSort(int[,] arr)
        {
            for (int count = 0; count < arr.GetLength(0); count++)
            {
                for (int index = 0; index < arr.GetLength(1); index++)
                {
                    for (int current = index + 1; current < arr.GetLength(1); current++)
                    if (arr[count, index] < arr[count, current]) (arr[count, index], arr[count, current]) = (arr[count, current], arr[count, index]);
                }
            }
        }
        #endregion
        
        #region Task56
        public static int FindMinRow(int[,] arr)
        {
            int  minRow = 0, minSum = 0;
            for (int count = 0; count < arr.GetLength(0); count++)
            {
                int sum = Int32.MaxValue;
                for (int index = 0; index < arr.GetLength(1); index++) sum += arr[count, index];
                if (sum < minSum)
                {
                    minRow = count;
                    minSum = sum;
                }
            }
            return minRow;
        }
        #endregion

        #region Task58
        public static void AddNumber(int[] pos, string[,] arr, string direction, int startRow, int startCol)
        {
            // Убедиться, что счётчик не превышает доступное количество элементов.
            if (pos[4] <= arr.GetLength(0) * arr.GetLength(1))
            {
                // Если направление движения вправо, заполнять массив вправо до достижения предела.
                if (direction == "right") for (; pos[1] < pos[3]; pos[1]++, pos[4]++) arr[pos[0], pos[1]] = pos[4] < 10 ? "0" + pos[4] : "" + pos[4];
                // Если направление движения вниз, начать на строку ниже и заполнять массив вниз до достижения предела.
                else if (direction == "down") for (pos[0] += 1, pos[1] -= 1; pos[0] < pos[2]; pos[0]++, pos[4]++) arr[pos[0], pos[1]] = pos[4] < 10 ? "0" + pos[4] : "" + pos[4];
                // Если направление движения влево, начать на один столбец левее и заполнять массив влево до достижения предела.
                else if (direction == "left") for (pos[0] -= 1, pos[1] -= 1; pos[1] > startCol; pos[1]--, pos[4]++) arr[pos[0], pos[1]] = pos[4] < 10 ? "0" + pos[4] : "" + pos[4];
                // Если направление движения вверх, заполнять массив вверх до достижения предела.
                else for (; pos[0] > startRow; pos[0]--, pos[4]++) arr[pos[0], pos[1]] = pos[4] < 10 ? "0" + pos[4] : "" + pos[4];
            }
            Helpers.PrintNicely(arr);
        }

        public static void FillSpirally(int[] pos, string[,] arr)
        {
            // 1 цикл функции – проход по 4 направлением движения (квадратной границе) и уменьшение размеров границы.
            // Функция повторяется рекурсивно до тех пор, пока не сравняются начало и конец строки или начало и конец столбца.
            if (pos[0] >= pos[2] || pos[1] >= pos[3]) return;
            int startRow = pos[0], startCol = pos[1];
            string[] directions = {"right", "down", "left", "up"};
            foreach(string direction in directions) AddNumber(pos, arr, direction, startRow, startCol);
            pos[0]++;
            pos[1]++;
            pos[2]--;
            pos[3]--;
            FillSpirally(pos, arr);
        }

        public static void PrintNicely(string[,] arr)
        {
            Console.Clear();
            Console.SetCursorPosition(0, 4);
            Helpers.PrintArray(arr);
            Thread.Sleep(100);
        }
        #endregion

        #region Task60
        public static void FillArray(int[,,] arr, int min, int max)
        {
            Random random = new Random();
            // Список для хранения занятых чисел.
            List<int> takenNumbers = new List<int>();
            int firstLength = arr.GetLength(0), secondLength = arr.GetLength(1), thirdLength = arr.GetLength(2);
            for (int firstCount = 0; firstCount < firstLength; firstCount++)
            {
                for (int secondCount = 0; secondCount < secondLength; secondCount++)
                {
                    for (int thirdCount = 0; thirdCount < thirdLength; thirdCount++)
                    {
                        int number;
                        do number = random.Next(min, max);
                        while (takenNumbers.Contains(number));
                        arr[firstCount, secondCount, thirdCount] = number;
                        takenNumbers.Add(number);
                    }
                }
            }
        }

        public static void PrintArray(int[,,] arr)
        {
            int firstLength = arr.GetLength(0), secondLength = arr.GetLength(1), thirdLength = arr.GetLength(2);
            for (int thirdCount = 0; thirdCount < thirdLength; thirdCount++)
            {
                for (int firstCount = 0; firstCount < firstLength; firstCount++)
                {
                    for (int secondCount = 0; secondCount < secondLength; secondCount++) Console.Write($"{arr[firstCount, secondCount, thirdCount]}({firstCount}, {secondCount}, {thirdCount})\t");
                    Console.WriteLine();
                }
            }
        }
        #endregion
        
        #region Task61
        public static int[,] MultiplyMatrices(int[,] matrix1, int[,] matrix2)
        {
            int rows1 = matrix1.GetLength(0), cols1 = matrix1.GetLength(1), rows2 = matrix2.GetLength(0), cols2 = matrix2.GetLength(1);
            int[,] result = new int[rows1, cols2];
            for(int firstCount = 0; firstCount < rows1; firstCount++)
            {
                for(int secondCount = 0; secondCount < cols2; secondCount++)
                {
                    int sum = 0;
                    for (int thirdCount = 0; thirdCount < cols1; thirdCount++) sum += matrix1[firstCount, thirdCount] * matrix2[thirdCount, secondCount];
                    result[firstCount, secondCount] = sum;
                }
            }
            return result;
        }
        #endregion
    }
}