public class ForecastServiceTest {
    public static void main(String[] args) {
        ForecastService forecast = new ForecastService();

        double result = forecast.predictFutureValue(100000.0, 0.08, 5);
        assert Math.abs(result - 146932.81) < 0.01 : "5-year forecast should match expected value";

        assert forecast.predictFutureValue(50000.0, 0.05, 0) == 50000.0 : "years=0 should return input unchanged";

        double generic = forecast.predictFutureValue(50000.0, 0.05, 10);
        double closedForm = 50000.0 * Math.pow(1.05, 10);
        assert Math.abs(generic - closedForm) < 0.01 : "Recursive result should match closed-form formula";

        System.out.printf("100000 @ 8%% for 5 years = %.2f%n", result);
        System.out.println("Forecast checks passed.");
    }
}
