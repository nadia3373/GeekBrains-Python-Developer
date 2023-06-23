import java.util.ArrayList;
import java.util.HashMap;

public abstract class Tree {
    private static HashMap<String, Person> people = new HashMap<>();

    public static void addPerson(String name, Person person) {
        people.put(name, person);
    }

    public static HashMap<String, Person> getPeopleList() {
        return people;
    }

    public static void relate(String p1, String p2, String r1, String r2) {
        HashMap<String, ArrayList<Person>> p1Relationships = people.get(p1).getRelationships();
        HashMap<String, ArrayList<Person>> p2Relationships = people.get(p2).getRelationships();
        if (!p1Relationships.containsKey(r1)) {
            p1Relationships.put(r1, new ArrayList<Person>());
        }
        if (!p2Relationships.containsKey(r2)) {
            p2Relationships.put(r2, new ArrayList<Person>());
        }
        p1Relationships.get(r1).add(people.get(p2));
        p2Relationships.get(r2).add(people.get(p1));
    }

    public static void removePerson(Person person) {
        for (String s : people.keySet()) {
            if (people.get(s).equals(person)) {
                people.remove(s);
                return;
            }
        }
    }
    
    public static void showEveryone() {
        for (String s : people.keySet()) {
            people.get(s).displayInfo();
        }
    }

    public static void showRelatives(Object p, String relationship) {
        Person person = p instanceof Person ? (Person) p : people.getOrDefault(p, null);
        if (person != null) {
            HashMap<String, ArrayList<Person>> relationships = person.getRelationships();
            if (relationship != null) {
                if (relationships.containsKey(relationship)) {
                    ArrayList<Person> l = relationships.get(relationship);
                    System.out.printf("%s is a %s to: ", person.getName(), relationship);
                    for (int i = 0; i < l.size() - 1; i++) {
                        System.out.printf("%s, ", l.get(i).getName());
                    }
                    System.out.printf("%s", l.get(l.size() - 1).getName());
                    System.out.println();
                } else {
                    System.out.printf("%s doesn't have any %ss", person.getName(), relationship);
                }
                System.out.println();
            } else {
                System.out.printf("%s's relatives\n", person.getName());
                for (String s : relationships.keySet()) {
                    ArrayList<Person> l = relationships.get(s);
                    System.out.printf("%s to: ", s);
                    for (int i = 0; i < l.size() - 1; i++) {
                        System.out.printf("%s, ", l.get(i).getName());
                    }
                    System.out.printf("%s", l.get(l.size() - 1).getName());
                    System.out.println();
                }
                System.out.println();
            }
        } else {
            System.out.println("There is no one by that name in the family.");
        }
    }
}
