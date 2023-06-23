package homework4;

import java.util.Collection;

public abstract class TaskSerializer {
    public abstract Collection<Task> deserialize(String input) throws Exception;
    public abstract String serialize(Collection<Task> tasks) throws Exception;
}
