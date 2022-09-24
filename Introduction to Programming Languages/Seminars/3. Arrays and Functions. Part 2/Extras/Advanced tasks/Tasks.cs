namespace ExtrasAdvanced
{
    class Programs
    {
        public static void Task1()
        {
            Console.Write("Задача 1. На ввод подаётся номер четверти. Создаются 3 случайные точки в этой четверти. Определите самый оптимальный маршрут для торгового менеджера, который выезжает из центра координат.\nВведите номер четверти: ");
            int number = Convert.ToInt32(Console.ReadLine());
            int[] point = new int[8];
            if (number > 0 && number < 5) Helpers.GetRandomCoordinates(number, point);
            else Console.Write("Некорректный номер четверти.");
            Console.WriteLine("Координаты случайных точек: ");
            for (int count = 0; count < point.Length; count += 2) Console.WriteLine($"Точка {(count + 2) / 2}. X: {point[count]}, Y: {point[count + 1]}.");
            Helpers.BestRoute(point);
        }
    }
}