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

        public static void Hashes()
        {
            Console.WriteLine();
            Console.WriteLine("####################################################################################################");
            Console.WriteLine();
        }

        public static void FillArray(int[] arr, int[] quantity = null, string type = null)
        {
            Random random = new Random();
            int choice;
            if (type == "random")
            {
                // Список для хранения свободных индексов в итоговом массиве для равномерного распределения 0 и 1 по всему массиву.
                List<int> indices = new List<int>();
                for (int count = arr.Length - 1; count >= 0; count--) indices.Add(count);
                for (int count = 0; count < arr.Length; count++)
                {
                    // Случайный выбор 0 или 1, затем случайный выбор индекса из списка свободных индексов и помещение в массив по этому индексу выбранного числа.
                    choice = 1;
                    if (quantity[0] > 0 && quantity[1] > 0) choice = random.Next(0, 2);
                    else if (quantity[0] > 0) choice = 0;
                    int index = random.Next(indices.Count);
                    if (choice == 1) arr[indices[index]] = choice;
                    indices.Remove(indices[index]);
                    quantity[choice]--;
                }
            }
            else if (type == "consecutive")
            {
                for (int count = 0; count < arr.Length; count++)
                {
                    choice = quantity[0] > 0 ? 0 : 1;
                    if (choice == 1) arr[count] = choice;
                    quantity[choice]--;
                }
            }
            else for (int count = 0; count < arr.Length; count++) arr[count] = random.Next(1, 100);
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