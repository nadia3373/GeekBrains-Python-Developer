int[] array = {23, 15, 99, 136, 7, 0, -5, 1000};

int n = array.Length;
int find = 136;
int index = 0;

while (index < n)
{
    if (array[index] == find)
    {
        Console.WriteLine(index);
        break;
    }
    index++;
}