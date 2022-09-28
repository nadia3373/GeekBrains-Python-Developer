namespace Homework
{
    class Helpers
    {
        public static void Hashes()
        {
            Console.WriteLine();
            Console.WriteLine("####################################################################################################");
            Console.WriteLine();
        }

        public static int[] PopulateArray(int[] arr)
        {
            Random random = new Random();
            for (int count = 0; count < arr.Length; count++) arr[count] = random.Next(Int32.MinValue + 1, Int32.MaxValue);
            return arr;
        }

        public static int Power(int number, int power)
        {
            int result = number;
            for (int count = 1; count < power; count++) result *= number;
            return result;
        }

        public static void PrintArray(int[] arr)
        {
            for (int count = 0; count < arr.Length; count++) Console.Write(count == arr.Length - 1 ? $"{arr[count]}\n" : $"{arr[count]}, ");
        }

        public static int[] SortArray(int[] arr)
        {
            int min;
            for (int count = 0; count < arr.Length; count++)
            {
                min = count;
                for (int index = count; index < arr.Length; index++) if (Math.Abs(arr[index]) < Math.Abs(arr[min])) min = index;
                int temp = arr[count];
                arr[count] = arr[min];
                arr[min] = temp;
            }
            return arr;
        }

        public static int SumDigits(int number)
        {
            int result = 0;
            for (; number > 0; number /= 10) result += number % 10;
            return result;
        }
    }
}