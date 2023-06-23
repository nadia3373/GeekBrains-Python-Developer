import java.time.LocalDate;

public class Female extends Person {
    private String maidenName;
    public Female(String name, LocalDate birthDate, LocalDate deathDate) {
        super(name, birthDate, deathDate);
    }

    public Female(String name, LocalDate birthDate) {
        super(name, birthDate);
    }

    public Female(String name, String maidenName, LocalDate birthDate, LocalDate deathDate) {
        super(name, birthDate, deathDate);
        this.maidenName = maidenName;
    }

    public Female(String name, String maidenName, LocalDate birthDate) {
        super(name, birthDate);
        this.maidenName = maidenName;
    }

    @Override
    public void displayInfo() {
        if (maidenName != null) {
            System.out.printf(super.getStatus() ? "%s (%s) |%s – alive|\n"
                    : "%s (%s) |%s – %s|\n", super.getName(), maidenName, super.getBirthDate(), super.getDeathDate());
        } else {
            System.out.printf(super.getStatus() ? "%s |%s – alive|\n"
                    : "%s |%s – %s|\n", super.getName(), super.getBirthDate(), super.getDeathDate());
        }
        Tree.showRelatives(this, null);
    }

    @Override
    public void scold(Person person) {
        if (checkRelationship(person, "mother")) {
            System.out.printf("[-]%s yelled at %s\n", getName(), person.getName());
            person.decreaseHappiness(10);
        } else {
            System.out.printf("%s is not %s's mother and can't scold them\n", getName(), person.getName());
        }
    }

    @Override
    public void spoil(Person person) {
        if (checkRelationship(person, "mother")) {
            System.out.printf("[+]%s bought a book for %s\n", getName(), person.getName());
            person.increaseHappiness(7);
        } else if (checkRelationship(person, "grandmother")) {
            System.out.printf("[+]%s baked a cake for %s\n", getName(), person.getName());
            person.increaseHappiness(10);
        } else {
            System.out.printf("%s is not %s's mother or grandmother and can't spoil them\n", getName(), person.getName());
        }
    }
}
