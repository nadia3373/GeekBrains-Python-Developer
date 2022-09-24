namespace ExtrasAdvanced
{
    class Helpers
    {
        public static void BestRoute(int[] arr)
        {
            double[,] distances = new double[4, 4];
            for (int first = 0; first < arr.Length; first += 2)
            {
                for (int second = first; second < arr.Length; second += 2)
                {
                    Console.WriteLine($"{first} | {second}");
                    distances[first / 2, second / 2] = CalculateDistance(first, second, arr);
                }
            }
            for (int x = 0; x < distances.GetLength(0); x += 1) {
                for (int y = 0; y < distances.GetLength(1); y += 1) {
                    Console.WriteLine(distances[x, y]);
                }
            }
        }

        public static double CalculateDistance(int num1, int num2, int[] arr)
        {
            return Math.Sqrt(Math.Pow(arr[num2] - arr[num1], 2) + Math.Pow(arr[num2 + 1] - arr[num1 + 1], 2));
        }

        public static int[] GetRandomCoordinates(int number, int[] arr)
        {
            arr[0] = 0;
            arr[1] = 0;
            Random random = new Random();
            for (int count = 2; count < arr.Length; count += 2)
            {
                if (number == 1 || number == 4)
                {
                    arr[count] = random.Next(1, Convert.ToInt32(Math.Sqrt(Int32.MaxValue / 2)));
                    if (number == 1) arr[count + 1] = random.Next(1,  Convert.ToInt32(Math.Sqrt(Int32.MaxValue / 2)));
                    else arr[count + 1] = random.Next(-1,  Convert.ToInt32(Math.Sqrt(Int32.MinValue / 2)));
                }
                else
                {
                    arr[count] = random.Next(-1,  Convert.ToInt32(Math.Sqrt(Int32.MinValue / 2)));
                    if (number == 2) arr[count + 1] = random.Next(1,  Convert.ToInt32(Math.Sqrt(Int32.MaxValue / 2)));
                    else arr[count + 1] = random.Next(-1,  Convert.ToInt32(Math.Sqrt(Int32.MinValue / 2)));
                }
            }
            return arr;
        }
    }
}