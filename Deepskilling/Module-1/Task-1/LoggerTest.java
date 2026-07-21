public class LoggerTest {
    public static void main(String[] args) {
        Logger logger1 = Logger.getInstance();
        Logger logger2 = Logger.getInstance();
        assert logger1 == logger2 : "getInstance must always return the same instance";

        logger1.log("First message");
        logger2.log("Second message");
        assert logger1.getLogCount() == 2 : "Log count should be shared across references";

        System.out.println("Total logs: " + logger1.getLogCount());
        System.out.println("Singleton check passed.");
    }
}
