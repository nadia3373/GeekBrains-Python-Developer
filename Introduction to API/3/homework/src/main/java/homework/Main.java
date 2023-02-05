package homework;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Random;

public class Main {
    public static void main(String[] args) {
        task1();
        task2();
    }

    private static void task1() {
        System.out.println("Задание 1. Пусть дан произвольный список целых чисел, удалить из него четные числа (в языке уже есть что-то готовое для этого)");
        ArrayList<Integer> arr = fillArray(-99, 100);
        System.out.printf("Заполненный список: %s\n", arr);
        arr.removeIf(n -> (n % 2 == 0));
        System.out.printf("Список только с нечётными числами: %s\n", arr);
    }

    private static void task2() {
        System.out.println("\nЗадание 2. Задан целочисленный список ArrayList. Найти минимальное, максимальное и среднее арифметическое из этого списка.");
        ArrayList<Integer> arr = fillArray(-99, 100);
        System.out.printf("Заполненный список: %s\n", arr);
        System.out.printf("Min: %s, max: %s, average: %.2f\n",
                          Collections.min(arr), Collections.max(arr), (double) arr.stream().mapToInt(Integer::intValue).sum() / arr.size());
    }

    private static ArrayList<Integer> fillArray(int minElem, int maxElem) {
        Random random = new Random();
        ArrayList<Integer> arr = new ArrayList<Integer>();
        int size = random.nextInt(5, 11);
        for (int i = 0; i < size; i++) {
            arr.add(random.nextInt(minElem, maxElem));
        }
        return arr;
    }
}
