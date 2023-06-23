package homework4;

import com.opencsv.CSVReader;
import com.opencsv.CSVWriter;

import java.io.StringReader;
import java.io.StringWriter;
import java.time.LocalDate;
import java.util.Collection;
import java.util.List;
import java.util.stream.Collectors;

public class CsvSerializer extends TaskSerializer {
    public CsvSerializer() {
    }

    @Override
    public Collection<Task> deserialize(String csvData) throws Exception {
        CSVReader reader = new CSVReader(new StringReader(csvData));
        List<String[]> rows = reader.readAll();
        return rows.stream()
                .skip(1)
                .map(row -> new Task(
                        Integer.parseInt(row[0]),
                        LocalDate.parse(row[1]),
                        LocalDate.parse(row[2]),
                        row[3],
                        row[4],
                        Priority.valueOf(row[5])))
                .collect(Collectors.toList());
    }

    @Override
    public String serialize(Collection<Task> tasks) throws Exception {
        StringWriter writer = new StringWriter();
        CSVWriter csvWriter = new CSVWriter(writer);
        String[] header = new String[]{"id", "created", "due", "author", "description", "priority"};
        csvWriter.writeNext(header);
        tasks.stream()
                .map(task -> new String[]{
                        String.valueOf(task.getId()),
                        task.getCreated().toString(),
                        task.getDue().toString(),
                        task.getAuthor(),
                        task.getDescription(),
                        task.getPriority().toString()})
                .forEach(csvWriter::writeNext);
        csvWriter.close();
        return writer.toString();
    }
}
