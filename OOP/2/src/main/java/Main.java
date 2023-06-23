import java.time.LocalDate;
import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        populateTree();
        Tree.showEveryone();
        System.out.print("""
                Entering the person's name and relationship status returns a list of relevant relatives.
                For example, "james son" will return the list of James's parents.
                "james" will return the list of all James's relatives.
                Available choices:
                """);
        for (String s : Tree.getPeopleList().keySet()) {
            System.out.println(s);
        }
        System.out.print("\nEnter the person's name and relationship status separated by space: ");
        Scanner scan = new Scanner(System.in);
        String[] choice = scan.nextLine().toLowerCase().split(" ");
        scan.close();
        if (choice.length >= 2) {
            Tree.showRelatives(choice[0], choice[1]);
        } else {
            Tree.showRelatives(choice[0], null);
        }
    }

    private static void populateTree() {
        Tree.addPerson("fleamont", new Male("Fleamont Potter", LocalDate.parse("1909-01-01")));
        Tree.addPerson("euphemia", new Female("Euphemia Potter", LocalDate.parse("1909-01-01")));
        Tree.addPerson("james", new Male("James Potter", LocalDate.parse("1960-03-27")));
        Tree.addPerson("lily", new Female("Lily Potter", "Evans", LocalDate.parse("1960-01-30")));
        Tree.addPerson("harry", new Male("Harry James Potter", LocalDate.parse("1980-07-31")));
        Tree.relate("fleamont", "euphemia", "husband", "wife");
        Tree.relate("fleamont", "james", "father", "son");
        Tree.relate("fleamont", "lily","father-in-law", "daughter-in-law");
        Tree.relate("fleamont", "harry", "grandfather", "grandson");
        Tree.relate("euphemia", "james", "mother", "son");
        Tree.relate("euphemia", "lily", "mother-in-law", "daughter-in-law");
        Tree.relate("euphemia", "harry", "grandmother", "grandson");
        Tree.relate("james", "lily", "husband", "wife");
        Tree.relate("james", "harry", "father", "son");
        Tree.relate("lily", "harry", "mother", "son");
    }
}