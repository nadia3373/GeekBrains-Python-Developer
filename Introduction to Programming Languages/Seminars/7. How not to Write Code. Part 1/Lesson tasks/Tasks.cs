using System;

namespace Lesson_tasks
{
    class Tasks
    {
        public static void Task46()
        {
            Console.WriteLine("Задача 46: Задайте двумерный массив размером m×n, заполненный случайными целыми числами.");
            int rows = 0, columns = 0;
            do 
            {
                try
                {
                    Console.Write("Введите количество строк: ");
                    rows = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Введите количество столбцов: ");
                    columns = Convert.ToInt32(Console.ReadLine());
                    if (rows < 1 || columns < 1) throw new Exception($"Оба значения должны быть больше 0.");
                }
                catch (Exception error)
                {
                    Console.WriteLine($"Ошибка: {error.Message}");
                }
            }
            while (rows < 1 || columns < 1);
            int[,] numbers = new int[rows, columns];
            Helpers.FillArray(numbers, -10, 10);
            Helpers.PrintArray(numbers);
            Helpers.Hashes();
        }

        public static void Task48()
        {
            Console.WriteLine("Задача 48: Задайте двумерный массив размера m на n, каждый элемент в массиве находится по формуле: A = m+n. Выведите полученный массив на экран.");
            int rows = 0, columns = 0;
            do 
            {
                try
                {
                    Console.Write("Введите количество строк: ");
                    rows = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Введите количество столбцов: ");
                    columns = Convert.ToInt32(Console.ReadLine());
                    if (rows < 1 || columns < 1) throw new Exception($"Оба значения должны быть больше 0.");
                }
                catch (Exception error)
                {
                    Console.WriteLine($"Ошибка: {error.Message}");
                }
            }
            while (rows < 1 || columns < 1);
            int[,] numbers = new int[rows, columns];
            Helpers.FillIndices(numbers);
            Helpers.PrintArray(numbers);
            Helpers.Hashes();
        }

        public static void Task49()
        {
            Console.WriteLine("Задача 49: Задайте двумерный массив. Найдите элементы, у которых оба индекса чётные, и замените эти элементы на их квадраты.");
            int rows = 0, columns = 0;
            do 
            {
                try
                {
                    Console.Write("Введите количество строк: ");
                    rows = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Введите количество столбцов: ");
                    columns = Convert.ToInt32(Console.ReadLine());
                    if (rows < 1 || columns < 1) throw new Exception($"Оба значения должны быть больше 0.");
                }
                catch (Exception error)
                {
                    Console.WriteLine($"Ошибка: {error.Message}");
                }
            }
            while (rows < 1 || columns < 1);
            int[,] numbers = new int[rows, columns];
            Helpers.FillArray(numbers, -10, 10);
            Console.WriteLine("Заполненный массив: ");
            Helpers.PrintArray(numbers);
            Helpers.ReplaceEven(numbers);
            Console.WriteLine("Массив с заменёнными значениями: ");
            Helpers.PrintArray(numbers);
            Helpers.Hashes();
        }

        public static void Task51()
        {
            Console.WriteLine("Задача 51: Задайте двумерный массив. Найдите сумму элементов, находящихся на главной диагонали (с индексами (0,0); (1;1) и т.д.");
            int rows = 0, columns = 0;
            do 
            {
                try
                {
                    Console.Write("Введите количество строк: ");
                    rows = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Введите количество столбцов: ");
                    columns = Convert.ToInt32(Console.ReadLine());
                    if (rows < 1 || columns < 1) throw new Exception($"Оба значения должны быть больше 0.");
                }
                catch (Exception error)
                {
                    Console.WriteLine($"Ошибка: {error.Message}");
                }
            }
            while (rows < 1 || columns < 1);
            int[,] numbers = new int[rows, columns];
            Helpers.FillArray(numbers, -10, 10);
            Console.WriteLine("Заполненный массив: ");
            Helpers.PrintArray(numbers);
            Console.WriteLine($"Сумма элементов, находящихся на главной диагонали: {Helpers.SumMainDiagonal(numbers)}");
            Helpers.Hashes();
        }

        public static void Additional()
        {
            Console.WriteLine("Дан двумерный массив из двух строк и двадцати двух столбцов. В его первой строке записано количество мячей, " +
                              "забитых футбольной командой в той или иной игре, во второй — количество пропущенных мячей в этой же игре. " +
                              "а) Для  каждой  проведенной  игры  напечатать  словесный  результат:  выигрыш, ничья или проигрыш. " +
                              "б) Определить количество выигрышей данной команды. " +
                              "в) Определить  количество  выигрышей  и  количество  проигрышей данной команды. " +
                              "г) Определить количество выигрышей, количество ничьих и количество проигрышей данной команды. " +
                              "д) Определить,  в  скольких  играх  разность  забитых  и  пропущенных  мячей была большей или равной трем. " +
                              "е) Определить общее число очков, набранных командой (за выигрыш даются 3 очка, за ничью — 1, за проигрыш — 0).");
            int [,] numbers = new int[2, 22];
            Helpers.FillArray(numbers, 1, 10);
            Helpers.PrintArray(numbers);
            Helpers.StartGame(numbers);
            Helpers.Hashes();
        }
    }
}