import java.util.HashMap;

public abstract class Tree {
    private static final HashMap<Integer, Person> people = new HashMap<>();
    private Tree() {};

    public static void addPerson(Person person) {
        if (people.containsKey(person.getId())) {
            ConsoleIO.error(String.format("Человек с id %d уже существует", person.getId()));
            return;
        }
        people.put(person.getId(), person);
    }

    public static void clear() {
        people.clear();
        Relations.clearAll();
    }

    public static int getMaxId() {
        return getPeople().values().stream()
                .mapToInt(Person::getId)
                .max()
                .orElse(0);
    }

    public static HashMap<Integer, Person> getPeople() {
        return people;
    }

    public static Person getPerson(int id) {
        return people.getOrDefault(id, null);
    }

    public static boolean isEmpty() {
        return people.isEmpty();
    }

    public static void removePerson(Person person) {
        people.remove(person.getId());
        Relations.clear(person.getId());
        ConsoleIO.success("Человек успешно удалён");
    }
}
