package homework4;

import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlElementWrapper;
import com.fasterxml.jackson.dataformat.xml.annotation.JacksonXmlRootElement;
import lombok.NoArgsConstructor;

import java.util.Collection;

@JacksonXmlRootElement(localName = "tasks")
@NoArgsConstructor
public class TasksWrapper {

    @JacksonXmlElementWrapper(useWrapping = false)
    private Collection<Task> tasks;

    public TasksWrapper(Collection<Task> tasks) {
        this.tasks = tasks;
    }

    public Collection<Task> getTasks() {
        return tasks;
    }
}
