namespace Extras
{
    class Helpers
    {
        public static bool CheckIfPalindrome(int[] arr)
        {
            for (int count = 1; count <= arr.Length / 2; count++) if (arr[count - 1] != arr[arr.Length - count]) return false;
            return true;
        }

        public static int[] ConvertToBinary(int number)
        {
            // Размер массива для записи определяется количеством цифр в двоичном представлении числа.
            int[] result = new int[(int)Math.Log(number, 2) + 1];
            for (int count = result.Length - 1; number > 0; count--, number /= 2) result[count] = number % 2;
            return result;
        }

        public static int[] CountSequences(int[] arr)
        {
            int[] counts = new int[100];
            for (int count = 1; count < arr.Length; count++) counts[arr[count]]++;
            return counts;
        }

        public static void FillArray(int[] arr, int zeros = 0, int ones = 0, string type = null)
        {
            Random random = new Random();
            if (type == "random")
            {
                // Список для хранения свободных индексов в итоговом массиве для равномерного распределения 0 и 1 по всему массиву.
                List<int> indices = new List<int>();
                for (int count = arr.Length - 1; count >= 0; count--) indices.Add(count);
                while (ones > 0)
                {
                    int index = random.Next(indices.Count);
                    arr[indices[index]] = 1;
                    indices.Remove(indices[index]);
                    ones--;
                }
            }
            else if (type == "consecutive") for (int count = zeros; ones > 0; count++, ones--) arr[count] = 1;
            else for (int count = 0; count < arr.Length; count++) arr[count] = random.Next(1, 100);
        }

        public static void Hashes()
        {
            Console.WriteLine();
            Console.WriteLine("####################################################################################################");
            Console.WriteLine();
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