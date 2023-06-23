package Homework6;

import java.util.ArrayList;
import java.util.List;
import java.util.Random;
import java.util.Scanner;

import static java.lang.Double.parseDouble;
import static java.lang.Integer.parseInt;

public class Main {
    public static void main(String[] args) {
        /*
        * 1. Подумать над структурой класса Ноутбук для магазина техники - выделить поля и методы. Реализовать в java.
        * 2. Создать множество ноутбуков (ArrayList).
        * 3. Отфильтровать ноутбуки их первоначального множества и вывести проходящие по условиям.
        * Например, спросить у пользователя минимальный размер оперативной памяти или конкретный цвет.
        * Выводить только те ноутбуки, что соответствуют условию
        */
        ArrayList<Laptop> laptops = getLaptops();
        for (Laptop laptop : laptops) {
            laptop.about();
        }
        int choice = getChoice();
        List<Laptop> result = filterLaptops(laptops, choice);
        if (!result.isEmpty()) {
            for (Laptop laptop : result) {
                laptop.about();
            }
        } else {
            System.out.println("Не найдено ноутбуков, соответствуюших условиям");
        }
    }

    private static List<Laptop> filterLaptops(ArrayList <Laptop> laptops, int choice) {
        Scanner scan = new Scanner(System.in);
        List<Laptop> result = new ArrayList<>();
        if (choice == 1) {
            System.out.print("По какому цвету отфильтровать? ");
            String color = scan.nextLine();
            result = laptops.stream().filter(laptop -> laptop.getColor().equals(color)).toList();
        }  else if (choice == 2 || choice == 3 || choice == 4) {
            try {
                if (choice == 2) {
                    System.out.print("Введите минимальный объём оперативной памяти: ");
                    int ram = parseInt(scan.next());
                    result = laptops.stream().filter(laptop -> laptop.getRam() >= ram).toList();
                } else if (choice == 3) {
                    System.out.print("Введите минимальный размер экрана: ");
                    double screen = parseDouble(scan.next());
                    result = laptops.stream().filter(laptop -> laptop.getScreenSize() >= screen).toList();
                } else if (choice == 4) {
                    System.out.print("Введите год выпуска: ");
                    int year = parseInt(scan.next());
                    result = laptops.stream().filter(laptop -> laptop.getYear() == year).toList();
                }
            } catch (Exception error) {
                System.out.println("Необходимо ввести число");
            }
        } else if (choice == 5) {
            result = laptops.stream().filter(laptop -> laptop.getCondition().equals("Сломанный")).toList();
            System.out.printf("Количество сломанных ноутбуков: %d\n", result.size());
            for (Laptop laptop : result) {
                laptop.getFixed();
            }
        } else if (choice == 0) {
            System.exit(0);
        }
        return result;
    }

    private static ArrayList<Laptop> getLaptops() {
        Random random = new Random();
        Laptop.setBasePrice(2099);
        ArrayList<Laptop> laptops = new ArrayList<>();
        String brand = "Apple";
        String[] names = new String[]{"MacBook Pro", "MacBook Air"};
        String[] models = new String[]{"MPHE3LL/A", "MPHE3LL/A", "MPHH3LL/A", "MVVL2LL/A", "MLY13LL/A", "MQD32LL/A", "MLH12LL/A", "MJLQ2LL/A"};
        String[] colors = new String[]{"Midnight", "Starlight", "Space Gray", "Silver"};
        String[] diskTypes = new String[]{"SSD", "HDD"};
        String[] processorBrands = new String[]{"Apple", "Intel"};
        String[] gpuBrands = new String[]{"Apple", "Intel", "AMD"};
        String[] conditions = new String[]{"Новый", "Подержанный", "Восстановленный", "Сломанный"};
        int[] years = new int[]{2023, 2022, 2019, 2016, 2015};
        int[] memory = new int[]{8, 16, 32};
        int[] capacity = new int[]{256, 512, 1024};
        double[] screenSizes = new double[]{13.0, 13.3, 13.6, 14, 16.0};
        Laptop laptop;
        for (int id = 1; id < 11; id++) {
            laptop = new Laptop(brand, names[random.nextInt(names.length)], models[random.nextInt(models.length)],
                    colors[random.nextInt(colors.length)], diskTypes[random.nextInt(diskTypes.length)],
                    processorBrands[random.nextInt(processorBrands.length)], gpuBrands[random.nextInt(gpuBrands.length)],
                    conditions[random.nextInt(conditions.length)], id, years[random.nextInt(years.length)],
                    memory[random.nextInt(memory.length)], capacity[random.nextInt(capacity.length)],
                    screenSizes[random.nextInt(screenSizes.length)]);
            laptops.add(laptop);
        }
        return laptops;
    }

    private static int getChoice() {
        Scanner scan = new Scanner(System.in);
        int choice = 0;
        while(true) {
            try {
                System.out.print("""
                    1 – отфильтровать ноутбуки по цвету
                    2 – отфильтровать ноутбуки по объёму оперативной памяти
                    3 – отфильтровать ноутбуки по размеру экрана
                    4 – отфильтровать ноутбуки по году выпуска
                    5 – починить все сломанные ноутбуки
                    0 – выход

                    Введите команду:\s""");
                choice = parseInt(scan.nextLine());
                if (choice >= 0 && choice < 6) {
                    break;
                } else {
                    System.out.println("Некорректный выбор");
                }
            } catch (Exception error) {
                System.out.println("Введите целое число");
            }
        }
        return choice;
    }
}
