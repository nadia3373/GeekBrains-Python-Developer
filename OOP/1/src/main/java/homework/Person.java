package homework;

import java.time.LocalDate;
import java.util.ArrayList;
import java.util.HashMap;

public class Person {
    private String name;
    private int happiness;
    private LocalDate birthDate, deathDate;
    private boolean alive;
    private HashMap<String, ArrayList<Person>> relationships = new HashMap<>();

    public Person(String name, LocalDate birthDate) {
        this.name = name;
        this.happiness = 100;
        this.birthDate = birthDate;
        this.alive = true;
    }

    public Person(String name, LocalDate birthDate, LocalDate deathDate) {
        this.name = name;
        this.happiness = 100;
        this.birthDate = birthDate;
        this.alive = false;
    }

    public String getName() {
        return name;
    }

    public int getHappiness() {
        return happiness;
    }

    public LocalDate getBirthDate() {
        return birthDate;
    }

    public LocalDate getDeathDate() {
        return deathDate;
    }

    public boolean getStatus() {
        return alive;
    }

    public HashMap<String, ArrayList<Person>> getRelationships() {
        return relationships;
    }

    public void setName(String name) {
        this.name = name;
    }

    public void setBirthDate(LocalDate birthDate) {
        this.birthDate = birthDate;
    }

    public void die(LocalDate date) {
        if (alive) {
            alive = false;
            deathDate = date;
            System.out.printf("%s died.", name);
        } else {
            System.out.printf("%s is already dead.", name);
        }
    }

    public void displayChildren() {
        if (relationships.containsKey("father")) {
            System.out.printf("%s's children:\n", name);
            for (Person child : relationships.get("father")) {
                child.displayInfo();
            }
        }
        if (relationships.containsKey("mother")) {
            System.out.printf("%s's children:\n", name);
            for (Person child : relationships.get("mother")) {
                child.displayInfo();
            }
        }
        if ((!relationships.containsKey("father")) && (!relationships.containsKey("mother"))) {
            System.out.printf("%s has no children\n", name);
        }
    }

    public void displayInfo() {
        if (alive) {
            System.out.printf("%s (%s – alive)\n", name, birthDate);
        } else {
            System.out.printf("%s (%s – %s)\n", name, birthDate, deathDate);
        }
        System.out.printf("Happiness: %d\n", happiness);
        System.out.println("Connections:");
        for (String s : relationships.keySet()) {
            System.out.printf("%s to: ", s);
            for (int i = 0; i < relationships.get(s).size(); i++) {
                System.out.printf(i == relationships.get(s).size() - 1 ? "%s" : "%s, ", relationships.get(s).get(i).name);
            }
            System.out.println();
        }
        System.out.println();
    }

    public void relate(Person person, String relationship) {
        if (!relationships.containsKey(relationship)) {
            relationships.put(relationship, new ArrayList<Person>());
        }
        relationships.get(relationship).add(person);
    }

    public void scold(Person person) {
        if (relationships.containsKey("father")) {
            if (relationships.get("father").contains(person)) {
                System.out.printf("[-]%s scolded %s\n", name, person.name);
                person.decreaseHappiness(5);
            }
        } else if (relationships.containsKey("mother")) {
            if (relationships.get("mother").contains(person)) {
                System.out.printf("[-]%s yelled at %s\n", name, person.name);
                person.decreaseHappiness(10);
            }
        } else {
            System.out.printf("%s is not a parent and can't scold anyone\n", name);
        }
    }

    public void spoil(Person person) {
        if (relationships.containsKey("grandfather")) {
            if (relationships.get("grandfather").contains(person)) {
                System.out.printf("[+]%s took %s with them on a camping trip\n", name, person.name);
                person.increaseHappiness(5);
            };
        } else if (relationships.containsKey("grandmother")) {
            if (relationships.get("grandmother").contains(person)) {
                System.out.printf("[+]%s baked a cake for %s\n", name, person.name);
                person.increaseHappiness(10);
            };
        } else if (relationships.containsKey("father")) {
            if (relationships.get("father").contains(person)) {
                System.out.printf("[+]%s bought a toy for %s\n", name, person.name);
                person.increaseHappiness(7);
            }
        } else if (relationships.containsKey("mother")) {
            if (relationships.get("mother").contains(person)) {
                System.out.printf("[+]%s bought a book for %s\n", name, person.name);
                person.increaseHappiness(7);
            }
        } else {
            System.out.printf("%s is not a grandparent or a parent and can't spoil anyone\n", name);
        }
    }

    private void decreaseHappiness(int happiness) {
        while (this.happiness - happiness < 0) {
            happiness -= 1;
        }
        if (happiness == 0) {
            System.out.printf("%s's happiness can't be decreased anymore.\n", name);
        } else {
            this.happiness -= happiness;
        }
        if (this.happiness == 0) {
            System.out.printf("%s's happiness is at the lowest.\n", name);
        }
    }

    private void increaseHappiness(int happiness) {
        while (this.happiness + happiness > 100) {
            happiness -= 1;
        }
        if (happiness == 0) {
            System.out.printf("%s's happiness can't be increased anymore.\n", name);
        } else {
            this.happiness += happiness;
        }
        if (this.happiness == 100) {
            System.out.printf("%s's happiness is at the highest.\n", name);
        }
    }
}
