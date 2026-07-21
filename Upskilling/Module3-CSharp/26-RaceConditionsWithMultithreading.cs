static class Task26_RaceConditionsWithMultithreading
{
    static int counter = 0;
    static readonly object lockObj = new();

    static void IncrementSafely()
    {
        for (int i = 0; i < 1000; i++)
        {
            lock (lockObj)
            {
                counter++;
            }
        }
    }

    public static void Run()
    {
        counter = 0;
        var threads = new List<Thread>();
        for (int i = 0; i < 10; i++)
            threads.Add(new Thread(IncrementSafely));

        foreach (var t in threads) t.Start();
        foreach (var t in threads) t.Join();

        Console.WriteLine($"Final counter value: {counter}");
        System.Diagnostics.Debug.Assert(counter == 10000, "lock should prevent race conditions, giving an exact total");
    }
}
