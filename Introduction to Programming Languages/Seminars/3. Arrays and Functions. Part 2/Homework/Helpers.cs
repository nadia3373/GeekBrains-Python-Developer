namespace Tasks
{
    class Helpers
    {
        public static void Hashes()
        {
            Console.WriteLine();
            Console.WriteLine("####################################################################################################");
            Console.WriteLine();
        }

        public static double CalculateDistance(int[] arr1, int[] arr2)
        {
            // Для n-мерного пространства.
            // double result = 0;
            // for (int count = 0; count < arr1.Length; count++) result += Math.Pow(arr2[count] - arr1[count], 2);
            // return Math.Sqrt(result);

            // Расстояние между точками в 3D пространстве вычилсяется по формуле: √(bx-ax)^2 + (by-ay)^2 + (bz-az)^2
            return Math.Sqrt(Math.Pow(arr2[0] - arr1[0], 2) + Math.Pow(arr2[1] - arr1[1], 2) + Math.Pow(arr2[2] - arr1[2], 2));
        }

        public static void PopulateArray(int[] arr)
        {
            for (int count = 0; count < arr.Length; count++)
            {
                Console.Write(count == 0 ? "x: " : count == 1 ? "y: " : "z: ");
                arr[count] = Convert.ToInt32(Console.ReadLine());
            }
        }

        public static void PrintCubes(int number, string type)
        {
            if (type == "reverse") for (int count = 1; count >= number; count--) Console.WriteLine($"{count}\t->\t{Math.Pow(count, 3)}\t");
            else for (int count = 1; count <= number; count++) Console.WriteLine($"{count}\t->\t{Math.Pow(count, 3)}\t");
        }

        public static int ReverseNumber(int number)
        {
            int result = 0;
            while (Math.Abs(number) > 0)
            {
                result = result * 10 + number % 10;
                number /= 10;
            }
            return result;
        }
    }
}