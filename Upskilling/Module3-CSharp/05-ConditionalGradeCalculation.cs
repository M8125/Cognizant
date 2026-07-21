static class Task05_ConditionalGradeCalculation
{
    static string GradeWithIfElse(int score)
    {
        if (score >= 90) return "A";
        if (score >= 80) return "B";
        if (score >= 70) return "C";
        return "F";
    }

    static string GradeWithSwitchPatterns(int score) => score switch
    {
        >= 90 => "A",
        >= 80 => "B",
        >= 70 => "C",
        _ => "F"
    };

    public static void Run()
    {
        int[] scores = { 95, 82, 71, 40 };
        foreach (var score in scores)
        {
            var g1 = GradeWithIfElse(score);
            var g2 = GradeWithSwitchPatterns(score);
            Console.WriteLine($"Score {score} -> if/else: {g1}, switch pattern: {g2}");
            System.Diagnostics.Debug.Assert(g1 == g2, "Both grading methods must agree");
        }
    }
}
