int Max(int arg1, int arg2, int arg3)
{
    int result = arg1;
    if (arg2 > result) result = arg2;
    if (arg3 > result) result = arg3;
    return result;
}

int max = Max(Max(15, 21, 39), Max(12, 2311, 33), Max(13, 23, 313));

Console.WriteLine(max);