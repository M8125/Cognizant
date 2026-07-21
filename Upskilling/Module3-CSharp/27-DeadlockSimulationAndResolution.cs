static class Task27_DeadlockSimulationAndResolution
{
    static readonly object lockA = new();
    static readonly object lockB = new();

    static bool TryAcquireBoth(object first, object second, string label)
    {
        if (Monitor.TryEnter(first, TimeSpan.FromSeconds(1)))
        {
            try
            {
                Thread.Sleep(100);
                if (Monitor.TryEnter(second, TimeSpan.FromSeconds(1)))
                {
                    try
                    {
                        Console.WriteLine($"{label} acquired both locks");
                        return true;
                    }
                    finally { Monitor.Exit(second); }
                }
                Console.WriteLine($"{label} could not acquire the second lock - backing off to avoid deadlock");
                return false;
            }
            finally { Monitor.Exit(first); }
        }
        Console.WriteLine($"{label} could not acquire the first lock");
        return false;
    }

    public static void Run()
    {
        var t1 = new Thread(() => TryAcquireBoth(lockA, lockB, "Thread1"));
        var t2 = new Thread(() => TryAcquireBoth(lockB, lockA, "Thread2"));

        t1.Start();
        t2.Start();
        t1.Join();
        t2.Join();

        Console.WriteLine("Program finished without hanging - deadlock avoided via TryEnter timeouts");
    }
}
