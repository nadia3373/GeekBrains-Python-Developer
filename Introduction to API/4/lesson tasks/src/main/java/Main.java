import java.util.LinkedList;
import java.util.Scanner;

import static java.lang.Integer.parseInt;

public class Main {
    public static void main(String[] args) {
        task1();
    }

    private static void task1() {
        // Реализовать консольное приложение, которое:
        // Принимает от пользователя строку вида "text~num". Нужно расплитить строку по ~, сохранить text в связный список на позицию num.
        // Если введено print~num, выводит строку из позиции num в связном списке и удаляет её из списка.
        Scanner scan = new Scanner(System.in);
        String s;
        LinkedList<String> storage = new LinkedList<>();
        while (true) {
            System.out.print("Введите текст и номер позиции: ");
            s = scan.next();
            if (s.equals(("exit"))) {
                System.exit(0);
            } else if (s.contains("~")) {
                String text = s.split("~")[0];
                try {
                    int pos = parseInt(s.split("~")[1]);
                    if (pos > storage.size() || pos < 0) {
                        throw new Exception();
                    }
                    if (text.equals(("print"))) {
                        System.out.printf("Элемент %s удалён\n", storage.remove(pos));
                    } else {
                        storage.add(pos, text);
                    }
                }
                catch (Exception error) {
                    System.out.println("Некорректный номер позиции");
                }
            } else {
                System.out.println("Ввод не соответствует установленному формату");
            }
            for (int i = 0; i < storage.size(); i++) {
                System.out.println(storage.get(i));
            }
        }
    }
}