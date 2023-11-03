class Task4
{
    static Double HandleFile(String file)
    {
        var lines = File.ReadAllLines(file);
        var command = lines[0];
        var numbers = lines[1].Split(' ').Select((s) => Double.Parse(s));
        if (command == "1")
        {
            return numbers.Aggregate((acc, number) => acc + number);
        }
        else if (command == "2")
        {
            return numbers.Aggregate((acc, number) => acc * number);
        }
        else if (command == "3")
        {
            return numbers.Aggregate(0.0, (acc, number) => acc + number * number);
        }
        else
        {
            throw new Exception("Invalid command");
        }
    }

    static void Solve(String directory, Int16 numberOfThreads)
    {
        var files = (from file in Directory.EnumerateFiles(directory) select file).ToArray();
        var outFile = Path.Join(directory, "out.dat");
        using (var writer = new StreamWriter(outFile))
        {
            var routine = (Int32 l, Int32 r) =>
            {
                for (Int32 i = l; i < r; i++)
                {
                    var res = HandleFile(files[i]);
                    lock (writer)
                    {
                        writer.WriteLine(res);
                    }
                }
            };
            var chunk = files.Length / numberOfThreads;
            var threads = new List<Thread>();
            for (Int16 i = 0; i < numberOfThreads; i++)
            {
                var l = i * chunk;
                var r = (i + 1) * chunk + ((i == numberOfThreads - 1) ? files.Length % numberOfThreads : 0);
                var thread = new Thread(() =>
                {
                    routine(l, r);
                });
                thread.Start();
                threads.Add(thread);
            }
            foreach (var thread in threads)
            {
                thread.Join();
            }
        }
    }

    static void Main(String[] args)
    {
        var directory = Console.ReadLine();
        Solve(directory, 2);
    }
}
