import java.time.LocalDate;
import java.util.ArrayList;
import java.util.HashMap;

public abstract class Person {
    private String name;
    private int happiness;
    private LocalDate birthDate, deathDate;
    private boolean alive;
    private HashMap<String, ArrayList<Person>> relationships;
    protected Person(String name, LocalDate birthDate, LocalDate deathDate) {
        this.alive = false;
        this.birthDate = birthDate;
        this.deathDate = deathDate;
        this.name = name;
        this.happiness = 100;
        this.relationships = new HashMap<>();
    }

    protected Person(String name, LocalDate birthDate) {
        this.alive = true;
        this.birthDate = birthDate;
        this.name = name;
        this.happiness = 100;
        this.relationships = new HashMap<>();
    }

    protected abstract void scold(Person person);

    protected abstract void spoil(Person person);

    protected LocalDate getBirthDate() {
        return birthDate;
    }

    protected LocalDate getDeathDate() {
        return deathDate;
    }

    protected int getHappinessLevel() {
        return happiness;
    }

    protected String getName() {
        return name;
    }

    protected HashMap<String, ArrayList<Person>> getRelationships() {
        return relationships;
    }

    protected boolean getStatus() {
        return alive;
    }

    protected void setBirthDate(LocalDate birthDate) {
        this.birthDate = birthDate;
    }

    protected void setName(String name) {
        this.name = name;
    }

    protected boolean checkRelationship(Person person, String relationship) {
        if (relationship.equals("father") || relationship.equals("mother")) {
            if (relationships.containsKey(relationship)) {
                return relationships.get(relationship).contains(person);
            }
        } else {
            for (String s : relationships.keySet()) {
                if (s.endsWith(relationship)) {
                    return relationships.get(relationship).contains(person);
                }
            }
        }
        return false;
    }

    protected void decreaseHappiness(int happiness) {
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

    public void die(LocalDate date) {
        if (alive) {
            alive = false;
            deathDate = date;
            System.out.printf("%s died.\n", name);
        } else {
            System.out.printf("%s is already dead.\n", name);
        }
    }

    protected void displayInfo() {
        System.out.printf(alive ? "%s |%s – alive|\n" : "%s |%s – %s|\n", name, birthDate, deathDate);
        Tree.showRelatives(this, null);
    }

    protected void increaseHappiness(int happiness) {
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
