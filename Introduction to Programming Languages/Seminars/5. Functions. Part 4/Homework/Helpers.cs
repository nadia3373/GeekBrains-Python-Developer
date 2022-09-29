namespace Homework
{
    class Helpers
    {
        public static int CountElements(int[] arr, string element, string type)
        {
            int result = 0;
            if (element == "number" && type == "even")
            {
                for (int numberIndex = 0; numberIndex < arr.Length; numberIndex++) if (arr[numberIndex] % 2 == 0) result++;
            }
            else if (element == "index" && type == "odd") for (int index = 0; index < arr.Length; index++) if (index % 2 == 1) result += arr[index];
            return result;
        }

        public static void Hashes()
        {
            Console.WriteLine();
            Console.WriteLine("####################################################################################################");
            Console.WriteLine();
        }

        public static void PopulateArray(int[] arr, int min, int max)
        {
            Random random = new Random();
            for (int count = 0; count < arr.Length; count++) arr[count] = random.Next(min, max);
        }

        public static void PopulateArray(double[] arr, double min, double max)
        {
            Random random = new Random();
            for (int count = 0; count < arr.Length; count++) arr[count] = Math.Round(min + (max - min) * random.NextDouble(), 2);
        }

        public static void PrintArray<T>(T[] arr)
        {
            for (int count = 0; count < arr.Length; count++)
            {
                if (count == arr.Length - 1) Console.WriteLine($"{arr[count]}");
                else Console.Write($"{arr[count]} ");
            }
        }
    }
}