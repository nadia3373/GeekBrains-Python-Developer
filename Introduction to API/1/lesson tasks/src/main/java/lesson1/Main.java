package lesson1;
import java.util.Random;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) { ex2();}

    private static void ex1() {
        Scanner scan = new Scanner(System.in);
        String name = scan.nextLine();
        System.out.printf("Hello, %s", name);
    }

    private static void ex2() {
        // Задаём длину массива от 5 до 10, создаём и заполняем массив заданной длины
        int[] arr = new int[new Random().nextInt(5, 10)];
        fillArray(arr, 2);
        // Выводим массив на печать
        System.out.println("Сгенерированный массив:");
        // Подсчёт единиц в массиве и вывод результата
        printArray(arr);
        System.out.printf("\nМаксимальное количество подряд идущих единиц в массиве: %s", countSequence(arr, 1));
    }

    private static int countSequence(int[] arr, int digit) {
        /* Функция принимает массив из целых чисел и искомое число,
         * подсчитывает и возвращает длину самой продолжительной
         * последовательности из искомого числа */
        int count = 0, maxCount = 0;
        for (int i = 0; i < arr.length; i++) {
            count = arr[i] == digit ? count + 1 : 0;
            if (count > maxCount) {
                maxCount = count;
            }
        }
        return maxCount;
    }

    private static void fillArray(int[] arr, int bound) {
        /* Функция принимает числовой массив, граничное значение и заполняет массив
         * случайно сгенерированными числами от 0 до указанной границы */
        Random random = new Random();
        for (int i = 0; i < arr.length; i++) {
            arr[i] = random.nextInt(bound);
        }
    }

    private static void printArray(int[] arr) {
        /* Функция принимает числовой массив и печатает каждый из элементов в цикле */
        for (int i = 0; i < arr.length; i++) {
            System.out.printf("%s ", arr[i]);
        }
    }
}