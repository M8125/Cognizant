using System.Diagnostics;

class FileLogger28
{
    private readonly TextWriterTraceListener fileListener;

    public FileLogger28(string logFilePath)
    {
        fileListener = new TextWriterTraceListener(logFilePath);
        Trace.Listeners.Add(fileListener);
        Trace.Listeners.Add(new ConsoleTraceListener());
        Trace.AutoFlush = true;
    }

    public void Log(string message) => Trace.WriteLine($"[{DateTime.Now:HH:mm:ss}] {message}");

    public void Close()
    {
        fileListener.Flush();
        fileListener.Close();
        Trace.Listeners.Remove(fileListener);
    }
}

static class Task28_LoggingWithSystemDiagnosticsTrace
{
    public static void Run()
    {
        var logPath = Path.Combine(Path.GetTempPath(), "trace-log.txt");
        var logger = new FileLogger28(logPath);

        logger.Log("Application started");
        logger.Log("Doing some work");
        logger.Log("Application finished");
        logger.Close();

        var fileContent = File.ReadAllText(logPath);
        Console.WriteLine($"Log file contains {fileContent.Split('\n').Length - 1} entries");

        System.Diagnostics.Debug.Assert(fileContent.Contains("Application started"), "Log file should contain the logged message");

        File.Delete(logPath);
    }
}
