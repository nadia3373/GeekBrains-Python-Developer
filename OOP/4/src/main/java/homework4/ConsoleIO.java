package homework4;

import java.time.LocalDate;
import java.util.Scanner;

public abstract class ConsoleIO {

    private static final String ERROR = "\u001B[31m";
    private static final String SUCCESS = "\u001B[32m";
    private static final String INFO = "\u001B[33m";
    private static final String RESET = "\u001B[0m";

    private static Scanner scan = new Scanner(System.in);

    public static void close() {
        scan.close();
    }

    public static LocalDate dateInput(String message) {
        prompt(message);
        String s = scan.nextLine();
        try {
            return LocalDate.parse(s);
        } catch (Exception e) {
            return null;
        }
    }

    public static void error(String text) {
        System.out.printf("%sERROR: %s%s\n", ERROR, text, RESET);
    }

    public static void info(String text) {
        System.out.printf("%s%s%s\n", INFO, text, RESET);
    }

    public static int intInput(String message) {
        while (true) {
            prompt(message);
            try {
                return Integer.parseInt(scan.nextLine());
            } catch (NumberFormatException e) {
                error("Введено не число");
            }
        }
    }

    public static Priority priorityInput(String text) {
        int choice;
        while(true) {
            choice = intInput(text);
            switch (choice) {
                case 1 -> {
                    return Priority.LOW;
                }
                case 2 -> {
                    return Priority.MEDIUM;
                }
                case 3 -> {
                    return Priority.HIGH;
                }

                default -> error("Введено некорректное значение");
            }
        }
    }

    public static void prompt (String text) {
        System.out.printf("%s", text);
    }

    public static String stringInput(String message) {
        prompt(message);
        return scan.nextLine();
    }

    public static void success (String text) {
        System.out.printf("%s%s%s\n", SUCCESS, text, RESET);
    }
}
