public class Logger {
    // Step 1: private static instance of the class
    private static Logger instance;

    // Step 2: keeps the constructor private
    private Logger() {
        System.out.println("Logger initialized");
    }

    // Step 3: public static method to get the instance
    public static synchronized Logger getInstance() {
        if (instance == null) {
            instance = new Logger();
        }
        return instance;
    }

    // Step 4: method to simulate/print logging
    public void log(String message) {
        System.out.println("Log: " + message);
    }
}
