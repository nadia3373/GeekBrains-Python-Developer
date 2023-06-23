package homework4;

import java.util.*;

public abstract class TaskScheduler {
    private static Map<Integer, Task> tasks = new TreeMap<>();

    public static void addTask(Task task) {
        tasks.put(task.getId(), task);
    }

    public static void clear() {
        tasks.clear();
    }

    public static boolean contains(int id) {
        return tasks.containsKey(id);
    }

    public static void deleteTask(int id) {
        tasks.remove(id);
    }

    public static Collection<Task> getAllTasks() {
        return tasks.values();
    }

    public static int getMaxId() {
        return Collections.max(tasks.keySet());
    }

    public static Task getTaskById(int id) {
        return tasks.get(id);
    }

    public static boolean isEmpty() {
        return tasks.isEmpty();
    }

    public static void sortByCreation() {
        List<Task> sortedTasks = new ArrayList<>(tasks.values());
        sortedTasks.sort(Comparator.comparing(Task::getCreated));
        tasks.replaceAll((id, task) -> sortedTasks.remove(0));
    }

    public static void sortByDue() {
        List<Task> sortedTasks = new ArrayList<>(tasks.values());
        sortedTasks.sort(Comparator.comparing(Task::getDue));
        tasks.replaceAll((id, task) -> sortedTasks.remove(0));
    }

    public static void sortByPriority() {
        List<Task> sortedTasks = new ArrayList<>(tasks.values());
        sortedTasks.sort(Comparator.comparing(Task::getPriority));
        tasks.replaceAll((id, task) -> sortedTasks.remove(0));
    }
}

