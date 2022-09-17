string[] days = new string[7] {"Пондельник", "Вторник", "Среда", "Четверг", "Пятница", "Суббота", "Воскресенье"};
Console.Write("Введите номер дня недели: ");
int dayNumber = Convert.ToInt32(Console.ReadLine());
if (dayNumber >= 1 && dayNumber <= 7) {
    Console.WriteLine(days[--dayNumber]);
}