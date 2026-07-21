static class Task25_FileStreamAndMemoryStream
{
    public static void Run()
    {
        var filePath = Path.Combine(Path.GetTempPath(), "filestream-demo.txt");
        File.WriteAllText(filePath, "Hello from FileStream!");

        using (FileStream fs = new(filePath, FileMode.Open, FileAccess.Read))
        {
            byte[] buffer = new byte[fs.Length];
            fs.Read(buffer, 0, buffer.Length);
            var content = System.Text.Encoding.UTF8.GetString(buffer);
            Console.WriteLine($"File content: {content}");
            System.Diagnostics.Debug.Assert(content == "Hello from FileStream!", "FileStream should read back what was written");
        }

        using (MemoryStream ms = new())
        {
            byte[] data = System.Text.Encoding.UTF8.GetBytes("In-memory data");
            ms.Write(data, 0, data.Length);
            Console.WriteLine($"Bytes written to MemoryStream: {ms.Length}");
            System.Diagnostics.Debug.Assert(ms.Length == data.Length, "MemoryStream length should match bytes written");
        }

        File.Delete(filePath);
    }
}
