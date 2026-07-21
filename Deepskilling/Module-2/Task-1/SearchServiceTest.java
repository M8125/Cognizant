import java.util.Arrays;
import java.util.Comparator;

public class SearchServiceTest {
    public static void main(String[] args) {
        Product[] products = {
            new Product(101, "Desk Lamp", "Home"),
            new Product(102, "Bluetooth Speaker", "Electronics"),
            new Product(103, "Coffee Mug", "Kitchen"),
            new Product(104, "Notebook", "Stationery"),
            new Product(105, "Wireless Mouse", "Electronics")
        };

        SearchService search = new SearchService();

        Product linearHit = search.linearSearch(products, "Desk Lamp");
        assert linearHit != null && linearHit.productId == 101 : "Linear search should find Desk Lamp";

        Product linearMiss = search.linearSearch(products, "Monitor");
        assert linearMiss == null : "Linear search should not find Monitor";

        Product[] sorted = Arrays.copyOf(products, products.length);
        Arrays.sort(sorted, Comparator.comparing(p -> p.productName, String::compareToIgnoreCase));

        Product binaryHit = search.binarySearch(sorted, "Desk Lamp");
        assert binaryHit != null && binaryHit.productId == 101 : "Binary search should find Desk Lamp";

        Product binaryMiss = search.binarySearch(sorted, "Monitor");
        assert binaryMiss == null : "Binary search should not find Monitor";

        System.out.println("Linear/Binary search checks passed.");
    }
}
