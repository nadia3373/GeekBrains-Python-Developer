import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        System.out.println("Добро пожаловать!");
        System.out.print("Введите сообщение: ");
        String message = scanner.nextLine();

        System.out.println("Вы ввели сообщение: " + message);

        scanner.close();
    }
}
