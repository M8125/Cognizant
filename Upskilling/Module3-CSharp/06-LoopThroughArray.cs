static class Task06_LoopThroughArray
{
    public static void Run()
    {
        int[] numbers = { 1, 2, 3, 4, 5 };

        Console.WriteLine("for loop (stop at 4):");
        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] == 4) break;
            Console.WriteLine(numbers[i]);
        }

        Console.WriteLine("foreach loop (skip even numbers):");
        foreach (var n in numbers)
        {
            if (n % 2 == 0) continue;
            Console.WriteLine(n);
        }

        Console.WriteLine("while loop:");
        int idx = 0;
        while (idx < numbers.Length)
        {
            Console.WriteLine(numbers[idx]);
            idx++;
        }

        Console.WriteLine("do-while loop:");
        idx = 0;
        do
        {
            Console.WriteLine(numbers[idx]);
            idx++;
        } while (idx < numbers.Length);

        System.Diagnostics.Debug.Assert(numbers.Length == 5, "Array should have at least 5 elements");
    }
}
