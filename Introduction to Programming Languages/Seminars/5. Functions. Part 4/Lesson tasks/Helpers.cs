namespace Lesson
{
    class Helpers
    {
        public static int Calculate (string type, int[] arr, int min = 0, int max = 0)
        {
            int result = 0;
            if (type == "positive")
            {
                for (int count = 0; count < arr.Length; count++) if (arr[count] > 0) result += arr[count];
            }
            else if (type == "negative")
            {
                for (int count = 0; count < arr.Length; count++) if (arr[count] < 0) result += Math.Abs(arr[count]);
            }
            else if (type == "range") if (min < max) for (int count = 0; count < arr.Length; count++) if (arr[count] >= min && arr[count] <= max) result++;
            return result;
        }

        public static void FillArray (int[] arr, int min, int max)
        {
            Random random = new Random();
            for (int count = 0; count < arr.Length; count++) arr[count] = random.Next(min, max);
        }

        public static int[] FindProducts (int[] arr)
        {
            int[] products = new int[arr.Length / 2];
            for (int count = 1; count <= products.Length; count++) products[count - 1] = arr[count - 1] * arr[arr.Length - count];
            return products;
        }

        public static void Hashes()
        {
            Console.WriteLine();
            Console.WriteLine("####################################################################################################");
            Console.WriteLine();
        }

        public static void PrintArray<T> (T[] arr)
        {
            for (int count = 0; count < arr.Length; count++)
            {
                if (count == arr.Length - 1) Console.WriteLine($"{arr[count]}");
                else Console.Write($"{arr[count]} ");
            }
        }

        public static void ReverseNumbers (int[] arr)
        {
            for (int count = 0; count < arr.Length; count++) arr[count] *= -1;
        }
    }
}