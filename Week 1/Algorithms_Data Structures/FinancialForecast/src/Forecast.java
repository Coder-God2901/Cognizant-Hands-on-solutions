public class Forecast {

    // Recursive method to calculate future value
    public static double futureValue(double principal, double rate, int years) {
        if (years == 0) {
            return principal;
        }
        return futureValue(principal, rate, years - 1) * (1 + rate);
    }

    // Optimized version using memoization (optional)
    public static double futureValueMemo(double principal, double rate, int years, double[] memo) {
        if (years == 0) return principal;
        if (memo[years] != 0) return memo[years];

        memo[years] = futureValueMemo(principal, rate, years - 1, memo) * (1 + rate);
        return memo[years];
    }
}
