package homework4;

import java.time.LocalDate;
import java.util.*;

public abstract class App {

    private static void addTask() {
        LocalDate created = ConsoleIO.dateInput("Введите дату создания задачи (оставьте пустой, чтобы заполнить текущей датой): ");
        created = created == null ? LocalDate.now() : created;
        LocalDate due = ConsoleIO.dateInput("Введите дату, до которой нужно выполнить задачу (формат YYYY-MM-DD): ");
        if (due == null) {
            ConsoleIO.error("Некорректный формат даты");
            return;
        }
        String author = ConsoleIO.stringInput("Введите имя автора: ");
        String description = ConsoleIO.stringInput("Введите описание задачи: ");
        Priority priority = ConsoleIO.priorityInput("Введите приоритет задачи (1 – низкий, 2 – средний, 3 – высокий): ");
        TaskScheduler.addTask(new Task(created, due, author, description, priority));
    }

    public static void clear() {
        TaskScheduler.clear();
        ConsoleIO.success("Список задач успешно очищен");
    }

    private static boolean errorIfEmpty() {
        if (TaskScheduler.isEmpty()) {
            ConsoleIO.error("Список задач пуст");
            return false;
        }
        return true;
    }

    private static void option(int choice) {
        switch (choice) {
            case 1 -> readFromFile();
            case 2 -> printAllTasks();
            case 3 -> addTask();
            case 4 -> removeTask();
            case 5 -> saveToFile();
            case 6 -> clear();
            case 7 -> sort();
            case 0 -> {
                ConsoleIO.info("Программа завершила работу");
                ConsoleIO.close();
            }

            default -> ConsoleIO.error("Некорректный выбор");
        }
    }

    private static void printAllTasks() {
        if (errorIfEmpty()) {
            TaskScheduler.getAllTasks().forEach(task -> ConsoleIO.info(task.toString()));
        }
    }

    private static void readFromFile() {
        int choice = ConsoleIO.intInput("Выберите формат файла для загрузки данных: 1 – json, 2 – xml, 3 – csv: ");
        TaskSerializer serializer = null;
        String fileName = null;
        switch (choice) {
            case 1 -> {
                serializer = new JsonSerializer();
                fileName = "source.json";
            }
            case 2 -> {
                serializer = new XmlSerializer();
                fileName = "source.xml";
            }
            case 3 -> {
                serializer = new CsvSerializer();
                fileName = "source.csv";
            }

            default -> ConsoleIO.error("Некорректный выбор");
        }
        if (serializer != null) {
            try {
                Collection<Task> tasks = FileManager.read(fileName, serializer);
                tasks.forEach(TaskScheduler::addTask);
                ConsoleIO.success(String.format("Задачи успешно загружены из файла %s", fileName));
            } catch (Exception e) {
                e.printStackTrace();
                ConsoleIO.error(String.format("Произошла ошибка при чтении файла %s", fileName));
            }
        }
    }

    private static void removeTask() {
        if (taskChoices()) {
            int choice = ConsoleIO.intInput("Введите id задачи: ");
            if (TaskScheduler.contains(choice)) {
                TaskScheduler.deleteTask(choice);
            } else {
                ConsoleIO.error("Некорректный выбор");
            }
        }
    }

    private static void saveToFile() {
        int choice = ConsoleIO.intInput("Выберите формат файла для сохранения: 1 – json, 2 – xml, 3 – csv: ");
        TaskSerializer serializer = null;
        String fileName = null;
        Collection<Task> tasks = TaskScheduler.getAllTasks();
        switch (choice) {
            case 1 -> {
                serializer = new JsonSerializer();
                fileName = "result.json";
            }
            case 2 -> {
                serializer = new XmlSerializer();
                fileName = "result.xml";
            }
            case 3 -> {
                serializer = new CsvSerializer();
                fileName = "result.csv";
            }

            default -> ConsoleIO.error("Некорректный выбор");
        }
        if (serializer != null) {
            try {
                FileManager.write(fileName, tasks, serializer);
                ConsoleIO.success(String.format("Результат успешно записан в файл %s", fileName));
            } catch (Exception e) {
                e.printStackTrace();
                ConsoleIO.error(String.format("Произошла ошибка при записи в файл %s", fileName));
            }
        }
    }

    public static void sort() {
        int choice = ConsoleIO.intInput("Введите 1 для сортировки задач по дате создания, " +
                "2 – для сортировки по дедлайну, 3 – для сортировки по приоритету: ");
        switch (choice) {
            case 1 -> TaskScheduler.sortByCreation();
            case 2 -> TaskScheduler.sortByDue();
            case 3 -> TaskScheduler.sortByPriority();

            default -> ConsoleIO.error("Некорректный выбор");
        }
    }

    public static void start() {
        int choice;
        do {
            choice = ConsoleIO.intInput("""
            Доступные команды:
            1. Загрузить список задач из файла
            2. Просмотреть все задачи
            3. Добавить задачу
            4. Удалить задачу
            5. Сохранить задачи в файл
            7. Сортировать задачи
            6. Очистить список задач
            0. Выход
                                
            Введите число:\s""");
            option(choice);
        } while (choice != 0);
    }

    public static boolean taskChoices() {
        if (errorIfEmpty()) {
            TaskScheduler.getAllTasks().forEach(task -> ConsoleIO.info(String.format("%d. %s", task.getId(), task.getDescription())));
            return true;
        }
        return false;
    }
}

