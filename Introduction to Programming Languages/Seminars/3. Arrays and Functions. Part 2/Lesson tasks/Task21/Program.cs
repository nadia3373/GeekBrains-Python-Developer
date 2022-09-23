// Напишите программу, которая принимает на вход координаты двух точек и находит расстояние между ними в 2D пространстве.

// Расстояние между двумя точками на плоскости находится по формуле: √(x2 - x1)^2 + (y2 - y1)^2

// Вариант решения с массивом.
// Console.Write("Введите координаты x и y первой точки через пробел: ");
// int[] coordinatesA = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
// Console.Write("Введите координаты x и y второй точки через пробел: ");
// int[] coordinatesB = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();
// Console.WriteLine(coordinatesA.Length == 2 && coordinatesB.Length == 2 ? $"Расстояние между точками: {Math.Round(Math.Sqrt(Math.Pow(coordinatesB[0] - coordinatesA[0], 2)
//                   + Math.Pow(coordinatesB[1] - coordinatesA[1], 2)), 2)}": "Введено некорректное количество координат.");

// Вариант решения с отдельными переменными.
Console.Write("Введите координаты первой точки.\nX: ");
int ax = Convert.ToInt32(Console.ReadLine());
Console.Write("Y: ");
int ay = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите координаты второй точки.\nX: ");
int bx = Convert.ToInt32(Console.ReadLine());
Console.Write("Y: ");
int by = Convert.ToInt32(Console.ReadLine());
Console.WriteLine(Math.Round(Math.Sqrt(Math.Pow(bx - ax, 2) + Math.Pow(by - ay, 2)), 2));