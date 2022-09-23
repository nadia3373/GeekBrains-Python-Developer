// Напишите программу, которая выводит слечайное трёхзначное число и удаляет вторую цифру этого числа.

void ReduceNumber()
{
    int number = new Random().Next(100, 1000);
    int reducedNumber = number / 100 * 10 + number % 10;
    Console.WriteLine(number + "->" + reducedNumber);
}

ReduceNumber();