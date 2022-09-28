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

        public static int[] PopulateArray(int[] arr, int[] quantity = null, string type = null)
        {
            Random random = new Random();
            if (type == "random" || type == "consecutive")
            {
                int limit = quantity[0] + quantity[1];
                int[] indices = new int[arr.Length];
                for (int count = 0; count < limit; count++)
                {
                    // Если количество нулей и единиц не исчерпано и тип заполнения - случайный, генерируется 0 или 1.
                    // Если исчерпано количество нулей или единиц, выбирается тот элемент, который не исчерпан.
                    int choice = 1;
                    if (quantity[0] > 0 && quantity[1] > 0 && type == "random") choice = random.Next(2);
                    else if (quantity[0] > 0) choice = 0;
                    // Число 0 или 1 помещается в ячейку массива по сгенерированному адресу только в том случае, если найдена ячейка, которая ещё не занята.
                    // Иначе генерируется другой адрес ячейки.
                    if (type == "random")
                    {
                        int index;
                        while (true)
                        {
                            index = random.Next(arr.Length);
                            if (indices[index] == 0)
                            {
                                arr[index] = choice;
                                indices[index] = 1;
                                break;
                            }
                        }
                    }
                    else arr[count] = choice;
                    quantity[choice]--;
                }
            }
            else for (int count = 0; count < arr.Length; count++) arr[count] = random.Next(1, 100);
            return arr;
        }

        public static void PrintArray(int[] arr)
        {
            for (int count = 0; count < arr.Length; count++)
            {
                if (count == arr.Length - 1) Console.WriteLine(arr[count]);
                else Console.Write($"{arr[count]}, ");
            }
        }
    }
}