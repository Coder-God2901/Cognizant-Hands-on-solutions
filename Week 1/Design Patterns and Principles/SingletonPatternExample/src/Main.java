public class Main {
    public static void main(String[] args) {
        // Gets the singleton instance
        Logger logger1 = Logger.getInstance();
        logger1.log("First message");

        // Gets the instance again
        Logger logger2 = Logger.getInstance();
        logger2.log("Second message");

        // Check if both are the same instance
        if (logger1 == logger2) {
            System.out.println("Both logger1 and logger2 are the same instance.");
        } else {
            System.out.println("Different instances. Singleton not working.");
        }
    }
}
