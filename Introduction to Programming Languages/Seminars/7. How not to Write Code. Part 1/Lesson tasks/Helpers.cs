using System;

namespace Lesson_tasks
{
    class Helpers
    {
        public static void FillArray(int[,] arr, int min, int max)
        {
            Random random = new Random();
            for (int count = 0; count < arr.GetLength(0); count++)
            for (int index = 0; index < arr.GetLength(1); index++) arr[count, index] = random.Next(min, max);
        }

        public static void FillIndices(int[,] arr)
        {
            for (int count = 0; count < arr.GetLength(0); count++)
            for (int index = 0; index < arr.GetLength(1); index++) arr[count, index] = count + index;
        }

        public static void Hashes()
        {
            Console.WriteLine();
            Console.WriteLine("####################################################################################################");
            Console.WriteLine();
        }

        public static void PrintArray<T>(T[,] arr)
        {
            for (int count = 0; count < arr.GetLength(0); count++)
            {
                for (int index = 0; index < arr.GetLength(1); index++)
                {
                    if (index == arr.GetLength(1) - 1) Console.WriteLine($"{arr[count, index], 3}");
                    else Console.Write($"{arr[count, index], 3}\t");
                }
            }
        }

        public static void ReplaceEven(int[,] arr)
        {
            for (int count = 0; count < arr.GetLength(0); count++)
            for (int index = 0; index < arr.GetLength(1); index++) if (count % 2 == 0 && index % 2 == 0) arr[count, index] = arr[count, index] * arr[count, index];
        }

        public static int SumMainDiagonal(int[,] arr)
        {
            int result = 0;
            for (int count = 0; count < arr.GetLength(0); count++)
            for (int index = 0; index < arr.GetLength(1); index++) if (count == index) result += arr[count, index];
            return result;
        }

        public static void StartGame(int[,] arr)
        {
            int count = 0, drawCount = 0, games = 0, losesCount = 0, winsCount = 0;
            for (int index = 0; index < arr.GetLength(1); index++)
            {
                if (arr[count, index] - arr[count + 1, index] >= Math.Abs(3)) games++;
                if (arr[count, index] > arr[count + 1, index])
                {
                    winsCount++;
                    Console.WriteLine($"{index + 1}. Выигрыш");
                }
                else if (arr[count, index] < arr[count + 1, index])
                {
                    Console.WriteLine($"{index + 1}. Проигрыш");
                    losesCount++;
                }
                else
                {
                    Console.WriteLine($"{index + 1} Ничья");
                    drawCount++;
                }
            }
            Console.WriteLine("Результаты: ");
            Console.WriteLine($"Количество выигрышей команды: {winsCount}, количество проигрышей команды: {losesCount}, количество ничьих команды: {drawCount}");
            Console.WriteLine($"Количество игр, в которых разность забитых и пропущенных мячей была большей или равной трем: {games}");
            Console.WriteLine($"Общее количество очков команды: {winsCount * 3 + drawCount}");
        }
    }
}