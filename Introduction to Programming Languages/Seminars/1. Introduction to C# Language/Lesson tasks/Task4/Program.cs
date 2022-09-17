Console.Write("Введите число: ");
int num = Convert.ToInt32(Console.ReadLine());
if (num < -num) {
    num = -num;
}
int count = -num;
while (count <= num) {
    Console.WriteLine(count);
    count++;
}