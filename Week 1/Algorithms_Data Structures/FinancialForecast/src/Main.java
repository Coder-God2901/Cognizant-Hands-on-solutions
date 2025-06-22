public class Main {
    public static void main(String[] args) {
        double principal = 10000; // ₹10,000 initial investment
        double rate = 0.08;       // 8% annual growth
        int years = 5;            // forecast for 5 years

        System.out.println("=== Recursive Forecast ===");
        double futureValue = Forecast.futureValue(principal, rate, years);
        System.out.printf("Future Value after %d years: ₹%.2f\n", years, futureValue);

        System.out.println("\n=== Memoized Forecast ===");
        double[] memo = new double[years + 1];
        double futureValueMemo = Forecast.futureValueMemo(principal, rate, years, memo);
        System.out.printf("Future Value with Memoization: ₹%.2f\n", futureValueMemo);
    }
}
