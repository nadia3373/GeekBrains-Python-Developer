import java.time.LocalDate;
import java.util.*;

public abstract class App {

    private static void addPerson() {
        String name = ConsoleIO.stringInput("Введите имя: ");
        LocalDate birthDate = ConsoleIO.dateInput("Введите дату рождения (формат YYYY-MM-DD): ");
        if (birthDate == null) {
            ConsoleIO.error("Некорректный формат даты");
            return;
        }

        LocalDate deathDate = ConsoleIO.dateInput("Введите дату смерти (формат YYYY-MM-DD), введите 0, если человек жив: ");
        Gender gender = ConsoleIO.readGender();
        if (gender == null) {
            ConsoleIO.error("Выбрано некорректное значение пола");
            return;
        }

        Tree.addPerson((deathDate == null) ? new Person(name, birthDate, gender) : new Person(name, birthDate, deathDate, gender));
    }

    private static void addRelation() {
        if (peopleChoices()) {
            Person person1 = Tree.getPerson(ConsoleIO.intInput("id 1 человека: "));
            Person person2 = Tree.getPerson(ConsoleIO.intInput("id 2 человека: "));;
            if (person1 != null && person2 != null && (!person1.equals(person2))) {
                String relation = ConsoleIO.stringInput("Введите название родственной связи между 1 и 2 человеком: ");
                Relations.add(person1.getId(), person2.getId(), relation, null);
                relation = ConsoleIO.stringInput("Введите название родственной связи между 2 и 1 человеком: ");
                Relations.add(person2.getId(), person1.getId(), relation, null);
            } else {
                ConsoleIO.error("Некорректный выбор");
            }
        }
    }

    public static void clearTree() {
        Tree.clear();
        Relations.clearAll();
        ConsoleIO.success("Дерево успешно очищено");
    }

    private static boolean errorIfTreeIsEmpty() {
        if (Tree.isEmpty()) {
            ConsoleIO.error("Дерево пустое");
            return false;
        }
        return true;
    }

    private static void option(int choice) {
        switch (choice) {
            case 1 -> printTree();
            case 2 -> printPerson();
            case 3 -> printRelatives();
            case 4 -> addRelation();
            case 5 -> removeRelation();
            case 6 -> addPerson();
            case 7 -> removePerson();
            case 8 -> readTree();
            case 9 -> clearTree();
            case 0 -> {
                ConsoleIO.info("Программа завершила работу");
                ConsoleIO.close();
            }

            default -> ConsoleIO.error("Некорректный выбор");
        }
    }

    private static void printRelatives() {
        if (peopleChoices()) {
            Person person = Tree.getPerson(ConsoleIO.intInput("Выберите человека: "));
            if (person == null) {
                ConsoleIO.error("Некорректный выбор");
                return;
            }

            HashMap<String, ArrayList<Integer>> relations = Relations.get(person.getId(), "all");
            if (relations == null) {
                ConsoleIO.error("У выбранного человека нет родственных связей");
                return;
            }

            List<String> relationshipOptions = new ArrayList<>(relations.keySet());
            printRelationshipOptions(relationshipOptions);

            int relationshipChoice = ConsoleIO.intInput("Выберите родственную связь: ");
            if (relationshipChoice < 1 || relationshipChoice > relationshipOptions.size()) {
                ConsoleIO.error("Некорректный выбор");
                return;
            }

            printPersonDetails(person, relationshipOptions.get(relationshipChoice - 1));
            if (promptSaveToFile()) {
                saveToFile(new HashSet<>() {{add(person);}}, relationshipOptions.get(relationshipChoice - 1));
            }
        }
    }

    private static boolean peopleChoices() {
        if (errorIfTreeIsEmpty()) {
            Tree.getPeople().values().forEach(person -> ConsoleIO.info(String.format("%d. %s", person.getId(), person.getName())));
            return true;
        }
        return false;
    }

    private static void printPerson() {
        if (peopleChoices()) {
            int choice = ConsoleIO.intInput("Выберите человека: ");
            Person person;
            if ((person = Tree.getPerson(choice)) != null) {
                printPersonDetails(person, "all");
                if (promptSaveToFile()) {
                    saveToFile(new HashSet<>() {{add(person);}}, "all");
                }
            } else {
                ConsoleIO.error("Некорректный выбор");
            }
        }
    }

    private static void printPersonDetails(Person person, String relation) {
        ConsoleIO.info(person.toString());
        HashMap<String, ArrayList<Integer>> relations = Relations.get(person.getId(), relation);
        if (relations == null) {
            ConsoleIO.info("Родственники, соответствующие запросу, не найдены");
            ConsoleIO.info("------------------");
            return;
        }

        relations.forEach((rel, ids) -> {
            ConsoleIO.info(String.format("\n%s to: ", rel));
            ids.stream().map(Tree::getPerson).map(Person::getName).forEach(ConsoleIO::info);
        });
        ConsoleIO.info("------------------");
    }

    private static void printRelationshipOptions(List<String> relations) {
        ConsoleIO.info("Выберите родственную связь:");
        for (int i = 0; i < relations.size(); i++) {
            ConsoleIO.info(String.format("%d. %s", i + 1, relations.get(i)));
        }
    }

    private static boolean printTree() {
        if (errorIfTreeIsEmpty()) {
            Tree.getPeople().values().forEach(person -> printPersonDetails(person, "all"));
            if (promptSaveToFile()) {
                saveToFile(Tree.getPeople().values(), "all");
            }
            return true;
        }
        return false;
    }

    private static boolean promptSaveToFile() {
        return ConsoleIO.stringInput("Сохранить результат в файл? (y, n): ").equals("y");
    }

    private static void readTree() {
        if (JsonIO.read()) {
            ConsoleIO.success("Дерево успешно загружено");
        } else {
            ConsoleIO.error("Произошла ошибка при чтении дерева из файла");
        }
    }

    private static void removePerson() {
        if (peopleChoices()) {
            int choice = ConsoleIO.intInput("Выберите человека: ");
            Tree.removePerson(Tree.getPerson(choice));
        }
    }

    private static void removeRelation() {
        if (peopleChoices()) {
            int choice = ConsoleIO.intInput("id 1 человека: ");
            Person person1 = Tree.getPerson(choice);
            choice = ConsoleIO.intInput("id 2 человека: ");
            Person person2 = Tree.getPerson(choice);;
            if (person1 != null && person2 != null && (!person1.equals(person2))) {
                Relations.remove(person1.getId(), person2.getId());
                Relations.remove(person2.getId(), person1.getId());
            } else {
                ConsoleIO.error("Некорректный выбор");
            }
        }
    }

    private static void saveToFile(Collection<Person> people, String relation) {
        if (JsonIO.write(people, relation)) {
            ConsoleIO.success("Результат успешно записан в файл result.json");
        } else {
            ConsoleIO.error("Произошла ошибка при записи в файл result.json");
        }
    }

    public static void start() {
        int choice;
        do {
            choice = ConsoleIO.intInput("""
            Доступные команды:
            1. Посмотреть дерево полностью
            2. Посмотреть информацию об определённом человеке
            3. Посмотреть определённых родственников
            4. Добавить родственную связь
            5. Удалить родственную связь
            6. Добавить человека
            7. Удалить человека
            8. Считать дерево из файла
            9. Очистить дерево
            0. Выход
                                
            Введите число:\s""");
            option(choice);
        } while (choice != 0);
    }
}
