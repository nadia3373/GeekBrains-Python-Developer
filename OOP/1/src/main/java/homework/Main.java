package homework;

import java.time.LocalDate;
import java.util.HashMap;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        HashMap<String, Person> tree = getMockData();
        tree.get("fleamont").displayInfo();
        tree.get("euphemia").displayInfo();
        tree.get("lily").displayInfo();
        tree.get("james").displayInfo();
        tree.get("harry").displayInfo();
        System.out.print("Choose a family member to display all their children.\nAvailable choices:\n");
        for (String s : tree.keySet()) {
            System.out.printf("%s\n", s);
        }
        System.out.println();
        Scanner scan = new Scanner(System.in);
        String choice = scan.next();
        if (tree.containsKey(choice)) {
            tree.get(choice).displayChildren();
        } else {
            System.out.println("There is no one by that name in the family.");
        }
    }

    private static HashMap<String, Person> getMockData() {
        HashMap<String, Person> tree = new HashMap<>();
        tree.put("fleamont", new Person("Fleamont Potter", LocalDate.parse("1909-01-01")));
        tree.put("euphemia", new Person("Euphemia Potter", LocalDate.parse("1909-01-01")));
        tree.put("james", new Person("James Potter", LocalDate.parse("1960-03-27")));
        tree.put("lily", new Person("Lily Potter (Evans)", LocalDate.parse("1960-01-30")));
        tree.put("harry", new Person("Harry James Potter", LocalDate.parse("1980-07-31")));

        tree.get("fleamont").relate(tree.get("euphemia"), "husband");
        tree.get("fleamont").relate(tree.get("james"), "father");
        tree.get("fleamont").relate(tree.get("lily"), "father-in-law");
        tree.get("fleamont").relate(tree.get("harry"), "grandfather");

        tree.get("euphemia").relate(tree.get("fleamont"), "wife");
        tree.get("euphemia").relate(tree.get("james"), "mother");
        tree.get("euphemia").relate(tree.get("lily"), "mother-in-law");
        tree.get("euphemia").relate(tree.get("harry"), "grandmother");

        tree.get("lily").relate(tree.get("euphemia"), "daughter-in-law");
        tree.get("lily").relate(tree.get("fleamont"), "daughter-in-law");
        tree.get("lily").relate(tree.get("james"), "wife");
        tree.get("lily").relate(tree.get("harry"), "mother");

        tree.get("james").relate(tree.get("euphemia"), "son");
        tree.get("james").relate(tree.get("fleamont"), "son");
        tree.get("james").relate(tree.get("lily"), "husband");
        tree.get("james").relate(tree.get("harry"), "father");

        tree.get("harry").relate(tree.get("euphemia"), "grandson");
        tree.get("harry").relate(tree.get("fleamont"), "grandson");
        tree.get("harry").relate(tree.get("james"), "son");
        tree.get("harry").relate(tree.get("lily"), "son");

        return tree;
    }
}
