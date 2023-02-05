import java.util.*;

public class Main {
    public static void main(String[] args) {
        task1();
        task2();
    }

    private static void task1() {
        System.out.println("Задание 1. Заполнить список десятью случайными числами. Отсортировать список методом sort() и вывести его на экран.");
        ArrayList<Integer> arr = fillArray(10, -99, 100);
        printArray(arr, "Заполненный список: ");
        Collections.sort(arr);
        printArray(arr, "Отсортированный список: ");
    }

    private static void task2() {
        System.out.println("Задание 2. Заполнить список названиями планет Солнечной системы в произвольном порядке с повторениями. \n" +
                           "Вывести название каждой планеты и количество его повторений в списке. Пройти по списку из предыдущего задания и удалить повторяющиеся элементы.");
        String[] names = new String[] {"Mercury", "Venus", "Mars", "Earth", "Pluto"};
        ArrayList<String> planets = randomElements(names);
        System.out.printf("Заполненный список: %s\n", planets);
        for (int i = 0; i < names.length; i++) {
            if (planets.contains(names[i])) {
                System.out.printf("%s: %d\n", names[i], Collections.frequency(planets, names[i]));
            }
        }
        HashSet <String> p = new HashSet<String>(planets);
        System.out.printf("Сокращённый список: %s", p);
    }

    private static ArrayList<Integer> fillArray(int size, int minElem, int maxElem) {
        Random random = new Random();
        ArrayList<Integer> arr = new ArrayList<Integer>();
        for (int i = 0; i < size; i++) {
            arr.add(random.nextInt(minElem, maxElem));
        }
        return arr;
    }

    public static void printArray(List<Integer> arr, String helpText) {
        System.out.printf("%s", helpText);
        for (int i = 0; i < arr.size(); i++) {
            System.out.printf(i == 0 ? "[%s, " : i == arr.size() - 1 ? "%s]" : "%s, ", arr.get(i));
        }
        System.out.println();
    }

    public static ArrayList<String> randomElements(String[] pool) {
        Random random = new Random();
        ArrayList<String> arr = new ArrayList<String>();
        int size = random.nextInt(5, 11);
        for (int i = 0; i < size; i++) {
            arr.add(pool[random.nextInt(0, pool.length)]);
        }
        return arr;
    }
}
