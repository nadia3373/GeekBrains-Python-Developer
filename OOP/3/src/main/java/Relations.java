import java.util.ArrayList;
import java.util.HashMap;

public abstract class Relations {
    private static HashMap<Integer, HashMap<String, ArrayList<Integer>>> relations = new HashMap<>();

    public static void add(int person1, int person2, String r1, String r2) {
        Person p1 = Tree.getPerson(person1);
        Person p2 = Tree.getPerson(person2);
        if (!areRelated(p1.getId(), p2.getId()))
        {
            relations.putIfAbsent(p1.getId(), new HashMap<>());
            relations.putIfAbsent(p2.getId(), new HashMap<>());
            relations.get(p1.getId()).putIfAbsent(r1, new ArrayList<>());
            relations.get(p1.getId()).get(r1).add(p2.getId());
            if (r2 != null) {
                relations.get(p2.getId()).putIfAbsent(r2, new ArrayList<>());
                relations.get(p2.getId()).get(r2).add(p1.getId());
            }
            ConsoleIO.success("Родственная связь успешно добавлена");
        } else {
            ConsoleIO.error(String.format("%s и %s уже являются родственниками", p1.getName(), p2.getName()));
        }
    }

    private static boolean areRelated(int id, int id1) {
        HashMap<String,ArrayList<Integer>> rels = relations.get(id);
        if (rels != null) {
            return rels.values().stream().anyMatch(list -> list.contains(id1));
        }
        return false;
    }

    public static void clear(int id1) {
        relations.entrySet().stream()
                .flatMap(entry -> entry.getValue().entrySet().stream())
                .flatMap(rel -> rel.getValue().stream())
                .forEach(id2 -> remove(id2, id1));
        relations.remove(id1);
    }

    public static void clearAll() {
        relations.clear();
    }

    public static HashMap<String, ArrayList<Integer>> get(int id, String relation) {
        HashMap<String, ArrayList<Integer>> result = relations.get(id);
        return result == null ? null
                : relation == null ? null
                : relation.equals("all") ? result
                : result.containsKey(relation) ? new HashMap<>() {{put(relation, result.get(relation));}}
                : null;
    }

    public static void remove(int id1, int id2) {
        HashMap<String, ArrayList<Integer>> rels = relations.get(id1);
        if (rels == null) {
            ConsoleIO.error("У выбранного человека нет родственных связей");
            return;
        }
        rels.values().forEach(list -> list.remove(Integer.valueOf(id2)));
        rels.entrySet().removeIf(entry -> entry.getValue().isEmpty());
    }
}
