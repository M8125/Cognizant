public class Product {
    final int productId;
    final String productName;
    final String category;

    Product(int productId, String productName, String category) {
        this.productId = productId;
        this.productName = productName;
        this.category = category;
    }

    @Override
    public String toString() {
        return "Product{id=" + productId + ", name='" + productName + "', category='" + category + "'}";
    }
}
