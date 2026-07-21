public class ForecastService {
    double predictFutureValue(double currentValue, double growthRate, int years) {
        if (years == 0) {
            return currentValue;
        }
        double nextValue = currentValue + (currentValue * growthRate);
        return predictFutureValue(nextValue, growthRate, years - 1);
    }
}
