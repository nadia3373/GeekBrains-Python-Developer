namespace Tasks
{
    class Programs
    {
        public static void Task19()
        {
            Console.Write("Задача 19. Напишите программу, которая принимает на вход пятизначное число и проверяет, является ли оно палиндромом.\nВведите число: ");
            int number = Convert.ToInt32(Console.ReadLine());
            // Получить перевёрнутое число, в цикле записывая последнюю цифру числа number в новую переменную и уменьшая number на разряд. Сравнить полученное число с оригинальным.
            int reversed = Helpers.ReverseNumber(number);
            Console.WriteLine($"{number} -> {reversed}\nЧисло {number} {(number == reversed ? "является" : "не является")} палиндромом.");
            Helpers.Hashes();
        }

        public static void Task21() // Вариант с последовательным вводом каждой координаты.
        {
            Console.Write("Задача 21. Напишите программу, которая принимает на вход координаты двух точек и находит расстояние между ними в 3D пространстве.\n" +
                          "Введите координаты точки A:\n");
            // Создать и заполнить массивы координатами точек. Вызвать метод для вычисления расстояния по формуле.
            int[] pointA = new int[3], pointB = new int[3];
            Helpers.PopulateArray(pointA);
            Console.WriteLine("Введите координаты точки B: ");
            Helpers.PopulateArray(pointB);
            Console.WriteLine($"Расстояние от точки A({pointA[0]},{pointA[1]},{pointA[2]}) до точки B({pointB[0]},{pointB[1]},{pointB[2]}) = {Math.Round(Helpers.CalculateDistance(pointA, pointB), 2)}");
            Helpers.Hashes();
        }

        public static void Task21Alt() // Вариант с заполнением массива из одной строки.
        {
            Console.Write("Задача 21. Напишите программу, которая принимает на вход координаты двух точек и находит расстояние между ними в 3D пространстве.\n" +
                          "Введите координаты x, y и z точки A через пробел: ");
            //int[] pointA = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
            int[] pointA = Array.ConvertAll(Console.ReadLine().Split(), int.Parse);
            Console.Write("Введите координаты x, y и z точки B через пробел: ");
            int[] pointB = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
            Console.WriteLine(pointA.Length == 3 && pointB.Length == 3 ? $"Расстояние от точки A({pointA[0]},{pointA[1]},{pointA[2]}) до точки B({pointB[0]},{pointB[1]},{pointB[2]})" +
                              $"= {Math.Round(Helpers.CalculateDistance(pointA, pointB), 2)}" : "Некорректное количество координат.");
            Helpers.Hashes();
        }

        public static void Task23()
        {
            Console.Write("Задача 23. Напишите программу, которая принимает на вход число (N) и выдаёт таблицу кубов чисел от 1 до N.\nВведите число: ");
            int number = Convert.ToInt32(Console.ReadLine());
            Helpers.PrintCubes(number, number > 1 ? "normal" : "reverse");
            Helpers.Hashes();
        }
    }
}