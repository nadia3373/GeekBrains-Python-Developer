import lombok.*;

import java.io.Serializable;
import java.time.LocalDate;

@Getter
@Setter
public class Person implements Serializable {
    private static int counter = 1;
    private int id;
    @NonNull
    private Gender gender;
    @NonNull
    private String name;
    @NonNull
    private LocalDate birthDate;
    private LocalDate deathDate;

    private boolean alive;
    public Person(String name, LocalDate birthDate, Gender gender) {
        this.id = Tree.isEmpty() ? counter++ : Tree.getMaxId() + 1;
        this.name = name;
        this.birthDate = birthDate;
        this.gender = gender;
        this.alive = true;
    }

    public Person(String name, LocalDate birthDate, LocalDate deathDate, Gender gender) {
        this.id = Tree.isEmpty() ? counter++ : Tree.getMaxId() + 1;
        this.name = name;
        this.birthDate = birthDate;
        this.gender = gender;
        this.deathDate = deathDate;
        this.alive = false;
    }

    public Person(int id, String name, LocalDate birthDate, Gender gender) {
        this.id = id;
        this.name = name;
        this.birthDate = birthDate;
        this.gender = gender;
        this.alive = true;
    }

    public Person(int id, String name, LocalDate birthDate, LocalDate deathDate, Gender gender) {
        this.id = id;
        this.name = name;
        this.birthDate = birthDate;
        this.deathDate = deathDate;
        this.gender = gender;
        this.alive = false;
    }

    public String toString() {
        return "id: " + id + "\n"
                + "Name: " + name + "\n"
                + "(" + birthDate + "-" + (alive ? "alive" : deathDate) + ")\n"
                + "Gender: " + gender;
    }
}
