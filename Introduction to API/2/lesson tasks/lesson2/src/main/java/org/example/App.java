package org.example;

import java.util.Scanner;

/**
 * Hello world!
 *
 */
public class App 
{
    public static void main( String[] args )
    {
        /* Дано четное число N (>0) и символы c1 и c2. Написать метод, который вернет строку длины N, которая состоит из чередующихся символов c1 и c2, начиная с c1. */
        task1();
        /* Напишите метод, который сжимает строку. */
        // task2();
    }

    public static StringBuilder compressString(StringBuilder sb) {
        char current = sb.charAt(0);
        int count = 0;
        StringBuilder r = new StringBuilder();
        for (int i = 0; i < sb.length(); i++) {
            if (sb.charAt(i) == current) {
                count++;
            } else {
                r.append(Integer.toString(count)).append(current);
                count = 1;
                current = sb.charAt(i);
            }
        }
        r.append(Integer.toString(count)).append(current);
        return r;
    }

    public static char getChar() {
        Scanner scan = new Scanner(System.in);
        char c = ' ';
        System.out.printf("Введите символ: ");
        if (scan.hasNext()) {
            c = scan.next().charAt(0);
        }
        scan.close();
        return c;
    }

    public static int getIntInput() {
        Scanner scan = new Scanner(System.in);
        int num = 0;
        while (scan.hasNext()) {
            try {
                num = Integer.parseInt(scan.next());
                return num;
            }
            catch (NumberFormatException exc){
                System.out.println("Введено некорректное значение");
            }
        }
        scan.close();
        return num;
    }

    public static String getString() {
        Scanner scan = new Scanner(System.in);
        String s = "";
        if (scan.hasNext()) {
            s = scan.nextLine();
        }
        scan.close();
        return s;
    }

    public static void task1() {
        System.out.printf("Введите длину строки: ");
        int n = getIntInput();
        char c1 = getChar(), c2 = getChar();
        StringBuilder sb = new StringBuilder();
        while (sb.length() < n) {
            sb.append(c1).append(c2);
        }
        sb.delete(sb.length() - 1, sb.length());
        System.out.printf("Сгенерированная строка: %s\n", sb.toString());
    }

    public static void task2() {
        System.out.printf("Введите строку: ");
        StringBuilder sb = new StringBuilder();
        sb.append(getString());
        System.out.println(sb.toString());
        StringBuilder c = compressString(sb);
        System.out.printf("Сжатая строка: %s\n", c.toString());
    }
}
