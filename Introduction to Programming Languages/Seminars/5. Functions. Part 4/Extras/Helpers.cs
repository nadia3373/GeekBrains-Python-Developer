namespace Extras
{
    class Helpers
    {
        public static void CartesianProduct (int[] arr, int num1, int num2)
        {
            int num1Size = (int)Math.Floor(Math.Log10(num1)) + 1, num2Size = (int)Math.Floor(Math.Log10(num2)) + 1, index = 0;
            for (int power1 = num1Size - 1; power1 >= 0; power1--)
            {
                for (int power2 = num2Size - 1; power2 >= 0; power2--)
                {
                    arr[index] = (int)(num1 / Math.Pow(10, power1) % 10) * (int)(num2 / Math.Pow(10, power2) % 10);
                    index++;
                }
            }
        }

        public static void FillArray (int[] arr, int min, int max)
        {
            Random random = new Random();
            for (int count = 0; count < arr.Length; count++) arr[count] = random.Next(min, max);
        }

        public static int FindMaxSum (int[][] arr)
        {
            int maxSum = 0, maxIndex = 0;
            for (int count = 0; count < arr.Length; count++)
            {
                int currentSum = 0;
                for (int index = 0; index < arr[count].Length; index++) currentSum += arr[count][index];
                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                    maxIndex = count;
                }
            }
            return maxIndex;
        }

        public static int FindNumbers ()
        {
            int result = 0;
            for (int count = 1; count < 1000000; count++)
            {
                if (count % 10 != 0)
                {
                    int digits = (int)Math.Floor(Math.Log10(count)) + 1;
                    int sum = 0, product = 1;
                    for (int power = digits - 1; power >= 0; power--)
                    {
                        int digit = (int)(count / Math.Pow(10, power) % 10);
                        sum += digit;
                        product *= digit;
                    }
                    if (product % 3 == 0 && product / 3 == sum) result++;
                }
            }
            return result;
        }

        public static bool FindSequence (int[] arr, int number)
        {
            int digits = (int)Math.Floor(Math.Log10(number)) + 1;
            for (int count = 0; count <= arr.Length - digits; count++)
            {
                int length = 0, power = digits - 1;
                for (int index = count; index <= count + digits - 1; index++, power--) if ((int)(number / Math.Pow(10, power) % 10) == arr[index]) length++;
                if (length == digits) return true;
            }
            return false;
        }

        public static void Hashes()
        {
            Console.WriteLine();
            Console.WriteLine("####################################################################################################");
            Console.WriteLine();
        }

        public static void PrintArray (int[] arr)
        {
            for (int count = 0; count < arr.Length; count++)
            {
                if (count == arr.Length - 1) Console.WriteLine($"{arr[count]}]");
                else if (count == 0) Console.Write($"[{arr[count]}, ");
                else Console.Write($"{arr[count]}, ");
            }
        }

        public static int Simple ()
        {
            int result = 0;
            for (int count = 1; count < 1000000; count++)
            {
                if (count % 10 != 0 && count % 3 == 0)
                {
                    int digits = (int)Math.Floor(Math.Log10(count)) + 1;
                    int sum = 0, product = 1;
                    for (int power = digits - 1; power >= 0; power--)
                    {
                        int digit = (int)(count / Math.Pow(10, power) % 10);
                        sum += digit;
                        product *= digit;
                    }
                    if (product / 3 == sum) result++;
                }
            }
            return result;
        }
    }
}