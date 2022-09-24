namespace Extras
{
    class Helpers
    {
        public static string CheckIfContains(int number)
        {
            int sevens = 0, fours = 0;
            while (number > 0)
            {
                if (number % 10 == 4) fours += 1;
                else if (number % 10 == 7) sevens += 1;
                number /= 10;
            }
            return $"{(fours > 0 || sevens > 0 ? fours > 0 && sevens > 0 ? $"содержит число 4 – {fours} раз(а), число 7 – {sevens} раз(а)" : fours > 0 ? $"содержит число 4 – {fours} раз(а)" : $"содержит число 7 – {sevens} раз(а)" : "не содержит ни 4, ни 7.")}";
        }

        public static int[] PopulateArray(int[] arr)
        {
            for (int count = 0; count < arr.Length; count++) arr[count] = count + 1;
            return arr;
        }
    }

}