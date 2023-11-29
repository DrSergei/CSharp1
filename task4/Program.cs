class Task4
{
    static String FindFile(String pattern)
    {
        var queue = new Queue<DirectoryInfo>();
        queue.Enqueue(new DirectoryInfo(@"c:\Temp\"));
        while (queue.Count > 0)
        {
            var currentDirectory = queue.Dequeue();
            try
            {
                foreach (var file in currentDirectory.GetFiles())
                {
                    if (file.Name.Contains(pattern))
                    {
                        return file.FullName;
                    }
                }
                foreach (var dir in currentDirectory.GetDirectories())
                {
                    queue.Enqueue(dir);
                }
            }
            catch (UnauthorizedAccessException e)
            {
                Console.WriteLine(e.Message);
            }
        }
        throw new Exception("Couldn't find a file");
    }

    static void Main(String[] args)
    {
        Console.WriteLine(FindFile("test.txt"));
    }
}
