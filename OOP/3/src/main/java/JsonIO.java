import jakarta.json.*;
import jakarta.json.stream.JsonGenerator;
import jakarta.json.stream.JsonGeneratorFactory;

import java.io.*;
import java.nio.file.Files;
import java.nio.file.Path;
import java.time.LocalDate;
import java.util.*;

public abstract class JsonIO {
    private static Path result = Path.of("result.json");
    private static Path source = Path.of("source.json");
    private JsonIO() {
    }

    private static JsonObject jsonify(Person person, String relation) {
        HashMap<String, ArrayList<Integer>> personRelations = Relations.get(person.getId(), relation);
        JsonObjectBuilder personBuilder = Json.createObjectBuilder()
                .add("id", person.getId())
                .add("name", person.getName())
                .add("gender", person.getGender().toString())
                .add("birthDate", person.getBirthDate().toString())
                .add("deathDate", person.getDeathDate() == null ? "" : person.getDeathDate().toString())
                .add("alive", person.isAlive());
        if (personRelations != null) {
            JsonObjectBuilder relationsBuilder = Json.createObjectBuilder();
            for (Map.Entry<String, ArrayList<Integer>> entry : personRelations.entrySet()) {
                JsonArrayBuilder relationArrayBuilder = Json.createArrayBuilder();
                for (Integer id : entry.getValue()) {
                    relationArrayBuilder.add(id);
                }
                relationsBuilder.add(entry.getKey(), relationArrayBuilder.build());
            }
            personBuilder.add("relations", relationsBuilder.build());
        }
        return personBuilder.build();
    }

    public static Person parsePerson(JsonObject object) {
        int id = object.getInt("id");
        Gender gender = Gender.valueOf(object.getString("gender"));
        String name = object.getString("name");
        LocalDate birthDate = LocalDate.parse(object.getString("birthDate"));
        return object.getString("deathDate").isEmpty() ? new Person(id, name, birthDate, gender)
                : new Person(id, name, birthDate, LocalDate.parse(object.getString("deathDate")), gender);
    }

    public static HashMap<String, ArrayList<Integer>> parseRelations(JsonObject relationsObject) {
        HashMap<String, ArrayList<Integer>> relations = new HashMap<>();
        for (String relation : relationsObject.keySet()) {
            JsonArray relationArray = relationsObject.getJsonArray(relation);
            ArrayList<Integer> people = new ArrayList<>();
            for (JsonValue relationValue : relationArray) {
                int person = Integer.parseInt(relationValue.toString());
                people.add(person);
            }
            relations.put(relation, people);
        }
        return relations;
    }

    public static boolean read() {
        try (InputStream stream = new FileInputStream(source.toFile())) {
            JsonReader reader = Json.createReader(stream);
            JsonArray people = reader.readArray();
            HashMap<Integer, HashMap<String, ArrayList<Integer>>> relations = new HashMap<>();
            for (JsonValue personObject : people) {
                JsonObject object = (JsonObject) personObject;
                Person person = parsePerson(object);
                Tree.addPerson(person);
                if (object.containsKey("relations")) {
                    JsonObject relationsObject = object.getJsonObject("relations");
                    relations.put(person.getId(), parseRelations(relationsObject));
                }
            }
            for (Map.Entry<Integer, HashMap<String, ArrayList<Integer>>> idsEntry : relations.entrySet()) {
                for (Map.Entry<String, ArrayList<Integer>> relationsEntry : idsEntry.getValue().entrySet()) {
                    for (Integer id : relationsEntry.getValue()) {
                        Relations.add(idsEntry.getKey(), id, relationsEntry.getKey(), null);
                    }
                }
            }
            return true;
        } catch (Exception e) {
            return false;
        }
    }

    public static boolean write(Collection<Person> people, String relation) {
        try (BufferedWriter writer = Files.newBufferedWriter(result)) {
            JsonGeneratorFactory generatorFactory = Json.createGeneratorFactory(new HashMap<>(Map.of(JsonGenerator.PRETTY_PRINTING, true)));
            JsonGenerator generator = generatorFactory.createGenerator(writer);
            generator.writeStartArray();
            people.forEach(person -> {
                JsonObject personJson = jsonify(person, relation);
                generator.write(personJson);
            });
            generator.writeEnd();
            generator.close();
            return true;
        } catch (IOException e) {
            return false;
        }
    }
}
