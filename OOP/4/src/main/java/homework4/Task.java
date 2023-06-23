package homework4;

import com.fasterxml.jackson.annotation.JsonFormat;
import lombok.Getter;
import lombok.NoArgsConstructor;
import lombok.Setter;

import java.time.LocalDate;

@Getter
@Setter
@NoArgsConstructor
public class Task {
    private static int counter = 1;
    private int id;
    @JsonFormat(shape = JsonFormat.Shape.STRING, pattern = "yyyy-MM-dd")
    private LocalDate created, due;
    private String author, description;
    private Priority priority;

    public Task(LocalDate created, LocalDate due, String author, String description, Priority priority) {
        this.id = TaskScheduler.isEmpty() ? counter++ : TaskScheduler.getMaxId() + 1;
        this.created = created;
        this.due = due;
        this.author = author;
        this.description = description;
        this.priority = priority;
    }

    public Task(int id, LocalDate created, LocalDate due, String author, String description, Priority priority) {
        this.id = id;
        this.created = created;
        this.due = due;
        this.author = author;
        this.description = description;
        this.priority = priority;
    }

    public String toString() {
        return "id: " + id + "\n"
                + "Created at: " + created + "\n"
                + "Due date: " + due + "\n"
                + "Author: " + author + "\n"
                + "Description: " + description + "\n"
                + "Priority: " + priority + "\n";
    }
}

