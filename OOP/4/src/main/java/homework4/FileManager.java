package homework4;

import org.apache.commons.io.FileUtils;

import java.io.File;
import java.util.Collection;

public abstract class FileManager {
    public static Collection<Task> read(String fileName, TaskSerializer serializer) throws Exception {
        File file = new File(fileName);
        String content = FileUtils.readFileToString(file, "UTF-8");
        return serializer.deserialize(content);
    }

    public static boolean write(String fileName, Collection<Task> tasks, TaskSerializer serializer) throws Exception {
        String content = serializer.serialize(tasks);
        File file = new File(fileName);
        FileUtils.writeStringToFile(file, content, "UTF-8");
        return true;
    }
}
