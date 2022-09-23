// Напишите программу, которая по заданному номеру четверти показывает диапазон возможных координат точек вв этой четверти (x и y).

Console.Write("Введите номер четверти: ");
int section = Convert.ToInt32(Console.ReadLine());
Console.WriteLine(section > 0 && section < 5 ? $"Диапазон возможных координат в {section} четверти: {CheckSectionSigns(section)}" : "Некорректный номер четверти.");

string CheckSectionSigns(int number)
{
    if (number == 1) return "x \u2208 (0; +\u221E), y \u2208 (0; +\u221E)";
    else if (number == 2) return "x \u2208 (-\u221E; 0), y \u2208 (0; +\u221E)";
    else if (number == 3) return "x \u2208 (-\u221E; 0), y \u2208 (-\u221E; 0)";
    else return "x \u2208 (0; +\u221E), y \u2208 (-\u221E; 0)";
}