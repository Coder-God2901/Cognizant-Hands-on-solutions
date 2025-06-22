public class Main {
    public static void main(String[] args) {
        Product[] products = {
            new Product(101, "Laptop", "Electronics"),
            new Product(102, "Shoes", "Footwear"),
            new Product(103, "Watch", "Accessories"),
            new Product(104, "Phone", "Electronics"),
            new Product(105, "T-shirt", "Clothing")
        };

        System.out.println("=== Linear Search ===");
        Product result1 = SearchAlgorithms.linearSearch(products, "Phone");
        System.out.println(result1 != null ? result1 : "Product not found");

        System.out.println("\n=== Binary Search ===");
        SearchAlgorithms.sortProductsByName(products); // important step!
        Product result2 = SearchAlgorithms.binarySearch(products, "Phone");
        System.out.println(result2 != null ? result2 : "Product not found");
    }
}
