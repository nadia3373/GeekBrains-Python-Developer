package homework4;

import com.fasterxml.jackson.core.type.TypeReference;
import com.fasterxml.jackson.databind.ObjectMapper;
import com.fasterxml.jackson.datatype.jsr310.JavaTimeModule;

import java.io.IOException;
import java.util.Collection;

public class JsonSerializer extends TaskSerializer {
    private ObjectMapper objectMapper;

    public JsonSerializer() {
        objectMapper = new ObjectMapper().registerModule(new JavaTimeModule());
    }

    @Override
    public Collection<Task> deserialize(String input) throws IOException {
        return objectMapper.readValue(input, new TypeReference<>() {
        });
    }

    @Override
    public String serialize(Collection<Task> tasks) throws IOException {
        return objectMapper.writeValueAsString(tasks);
    }
}
