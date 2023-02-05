import java.io.PrintWriter;
import java.nio.charset.StandardCharsets;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        task1();
        task2();
    }

    public static void task1() {
        /* 1. Напишите метод, который принимает на вход строку (String) и определяет является ли строка палиндромом (возвращает boolean значение). */
        Scanner scan = new Scanner(System.in);
        StringBuilder sb = new StringBuilder();
        System.out.print("Задание 1. Введите строку: ");
        sb.append(scan.next());
        System.out.println(sb.toString().equals(sb.reverse().toString()) ? "Строка является палиндромом" : "Строка не является палиндромом");
        scan.close();
    }

    public static void task2() {
        /* 2. Напишите метод, который составит строку, состоящую из 100 повторений слова TEST и метод,
        * который запишет эту строку в простой текстовый файл, обработайте исключения. */
        String result = constructString("TEST", 100);
        System.out.println("\nЗадание 2. " + (writeString(result) ? "Строка успешно записана в файл result.txt" : "Произошла ошибка при записи строки в файл"));
    }

    private static String constructString(String src, int repeat) {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < repeat; i++) {
            sb.append(src);
        }
        return sb.toString();
    }

    private static boolean writeString(String s) {
        PrintWriter file = null;
        try {
            file = new PrintWriter("result.txt", StandardCharsets.UTF_8);
            file.println(s);
            file.close();
        } catch (Exception error) {
            return false;
        }
        return true;
    }
}
