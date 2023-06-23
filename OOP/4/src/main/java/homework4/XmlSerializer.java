package homework4;

import java.io.StringWriter;
import java.util.Collection;

import com.fasterxml.jackson.annotation.JsonInclude;
import com.fasterxml.jackson.databind.DeserializationFeature;
import com.fasterxml.jackson.dataformat.xml.XmlMapper;
import com.fasterxml.jackson.datatype.jsr310.JavaTimeModule;

public class XmlSerializer extends TaskSerializer {

    private static XmlMapper xmlMapper;

    public XmlSerializer() {
        xmlMapper = new XmlMapper();
        xmlMapper.configure(DeserializationFeature.FAIL_ON_UNKNOWN_PROPERTIES, false);
        xmlMapper.setSerializationInclusion(JsonInclude.Include.NON_NULL);
        xmlMapper.registerModule(new JavaTimeModule());
    }

    @Override
    public String serialize(Collection<Task> tasks) throws Exception {
        TasksWrapper wrapper = new TasksWrapper(tasks);
        StringWriter writer = new StringWriter();
        xmlMapper.writeValue(writer, wrapper);
        return writer.toString();
    }

    @Override
    public Collection<Task> deserialize(String input) throws Exception {
        TasksWrapper wrapper = xmlMapper.readValue(input, TasksWrapper.class);
        return wrapper.getTasks();
    }
}
