// Вид 1
void Method1()
{
    Console.WriteLine("Автор: ...");
}

// Вид 2
void Method2(string msg)
{
    Console.WriteLine(msg);
}

// Вид 2.1
void Method21(string msg, int count)
{
    int i = 0;
    while (i < count)
    {
        Console.WriteLine(msg);
        i++;
    }
}

// Вид 3
int Method3()
{
    return DateTime.Now.Year;
}

// Вид 4
string Method4(int count, string text)
{
    string result = String.Empty;
    for (int i = 0; i < count; i++) result += text;
    return result;
}

Method1();
Method2("Текст сообщения");
Method21(msg: "Текст", count: 4);
int year = Method3();
Console.WriteLine(year);
string res = Method4(10, "test");
Console.WriteLine(res);

for (int i = 2; i <= 10; i++)
{
    for (int j = 2; j < 10; j++)
    {
        Console.WriteLine($"{i} * {j} = {i * j}");
    }
    Console.WriteLine();
}

string text = "– Я думаю, - сказал князь улыбаясь, - что, "
            + "ежели бы вас послали вместо нашего милого Винценгероде, "
            + "вы бы взяли приступом согласие прусского короля. "
            + "Вы так красноречивы. Вы дадите мне чаю?";


string Replace (string text, char oldValue, char newValue)
{
    string result = String.Empty;
    for (int i = 0; i < text.Length; i++) result += text[i] == oldValue ? $"{newValue}" : $"{text[i]}";
    return result;
}

string newText = Replace(text, ' ', '–');
newText = Replace(newText, 'к', 'К');
newText = Replace(newText, 'С', 'с');
Console.WriteLine(newText);

int[] arr = {1, 5, 4, 3, 2, 6, 7, 1, 1};

void PrintArray(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        Console.WriteLine(array[i]);
    }
}

void SelectionSort(int[] array)
{
    for (int i = 0; i < array.Length - 1; i++)
    {
        int minPosition = i;
        for (int j = i + 1; j < array.Length; j++)
        {
            if (array[j] < array[minPosition]) minPosition = j;
        }
        int temporary = array[i];
        array[i] = array[minPosition];
        array[minPosition] = temporary;
    }
}

SelectionSort(arr);
PrintArray(arr);

// Сортировка в обратном порядке.