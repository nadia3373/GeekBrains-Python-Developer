using System;

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

        public static bool SolveEquations(double[,] arr, double[] answer)
        {
            // Если оба коэффициента при x != 0, система решается методом Крамера.
            // Если коэффициент при x в одном из уравнений = 0, то y известен из этого уравнения и подставляется во второе.
            // arr[0, 0] – b1, arr[0, 1] – k1, arr[1, 0] – b2, arr[1, 1] – k2
            // y = 1, а также b1 и b2 получают противоположные знаки при переносе в другую часть уравнения.
            if (arr[0, 1] != 0 && arr[1, 1] != 0)
            {
                double det = (arr[0, 1] * (-1)) - (arr[1, 1] * (-1));
                if (det != 0)
                {
                    double detX = (-arr[0, 0] * (-1)) - (-arr[1, 0] * (-1));
                    double detY =  (arr[0, 1] * (-arr[1, 0])) - (arr[1, 1] * (-arr[0, 0]));
                    answer[0] = detX / det;
                    answer[1] = detY / det;
                    return true;
                }
            }
            else if (arr[0, 1] == 0 && arr[1, 1] != 0)
            {
                answer[1] = arr[0, 0];
                answer[0] = (answer[1] - arr[1, 0]) / arr[1, 1];
                return true;
            }
            else if (arr[1, 1] == 0 && arr[0, 1] != 0)
            {
                answer[1] = arr[1, 0];
                answer[0] = (answer[1] - arr[0, 0]) / arr[0, 1];
                return true;
            }
            return false;
        }
    }
}