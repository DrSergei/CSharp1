class Task3
{
    static void SolveA(List<String> strings)
    {
        List<Thread> threads = new List<Thread>();

        foreach (var str in strings)
        {
            threads.Add(new Thread(() =>
            {
                Thread.Sleep(str.Length * 1000);
                Console.WriteLine(str);
            }));
        }

        foreach (var thread in threads)
        {
            thread.Start();
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }
    }

    static List<String> SolveB(List<String> strings)
    {
        List<String> answer = new List<String>();
        List<Thread> threads = new List<Thread>();

        foreach (var str in strings)
        {
            threads.Add(new Thread(() =>
            {
                Thread.Sleep(str.Length * 1000);
                lock (answer)
                {
                    answer.Add(str);
                }
            }));
        }

        foreach (var thread in threads)
        {
            thread.Start();
        }

        foreach (var thread in threads)
        {
            thread.Join();
        }

        return answer;
    }

    static void Main(String[] args)
    {
        SolveA(new List<string> { "ABCDEFG", "A", "ABC" });

        var answer = SolveB(new List<string> { "ABCDEFG", "A", "ABC" });
        foreach (var str in answer)
        {
            Console.WriteLine(str);
        }
    }
}
