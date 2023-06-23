import java.time.LocalDate;

public class Male extends Person {
    public Male(String name, LocalDate birthDate, LocalDate deathDate) {
        super(name, birthDate, deathDate);
    }

    public Male(String name, LocalDate birthDate) {
        super(name, birthDate);
    }

    @Override
    public void scold(Person person) {
        if (checkRelationship(person, "father")) {
            System.out.printf("[-]%s scolded %s\n", getName(), person.getName());
            person.decreaseHappiness(5);
        } else {
            System.out.printf("%s is not %s's father and can't scold them\n", getName(), person.getName());
        }
    }

    @Override
    public void spoil(Person person) {
        if (checkRelationship(person, "father")) {
            System.out.printf("[+]%s took %s with them on a camping trip\n", getName(), person.getName());
            person.increaseHappiness(5);
        } else if (checkRelationship(person, "grandfather")) {
            System.out.printf("[+]%s bought a toy for %s\n", getName(), person.getName());
            person.increaseHappiness(7);
        } else {
            System.out.printf("%s is not %s's father or grandfather and can't spoil them\n", getName(), person.getName());
        }
    }
}
