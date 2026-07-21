static class Task23_AsyncFileUploadSimulation
{
    static async Task<string> UploadFileAsync(string fileName)
    {
        await Task.Delay(3000);
        if (string.IsNullOrWhiteSpace(fileName))
            throw new ArgumentException("File name cannot be empty");
        return $"'{fileName}' uploaded successfully";
    }

    public static async Task Run()
    {
        try
        {
            var result = await UploadFileAsync("report.pdf");
            Console.WriteLine(result);
            System.Diagnostics.Debug.Assert(result.Contains("uploaded successfully"), "Upload should succeed for a valid file name");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Upload failed: {ex.Message}");
        }

        try
        {
            await UploadFileAsync("");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Expected failure caught: {ex.Message}");
        }
    }
}
