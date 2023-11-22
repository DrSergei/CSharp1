using System.Collections.Concurrent;

class Task4
{
    static void Main(String[] args)
    {
        var random = new Random();
        int n = 3;
        int m = 2;
        int k = 4;

        int[,] arr1 = new int[n, m];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                arr1[i, j] = random.Next(5);
            }
        }

        int[,] arr2 = new int[m, k];
        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < k; j++)
            {
                arr2[i, j] = random.Next(5);
            }
        }

        ConcurrentQueue<int> queue = new ConcurrentQueue<int>();
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < k; j++)
            {
                queue.Enqueue(i * k + j);
            }
        }

        int countThreads = 3;
        var sync = new Object();
        int finishedThreads = 0;
        int[,] arr3 = new int[n, k];
        for (int i = 0; i < countThreads; i++)
        {
            (new Thread(() =>
            {
                int tmp;
                var random = new Random();
                while (queue.TryDequeue(out tmp))
                {
                    var i = tmp / k;
                    var j = tmp % k;

                    var res = 0;
                    for (int t = 0; t < m; t++)
                    {
                        res += arr1[i, t] * arr2[t, j];
                    }
                    arr3[i, j] = res;
                    Thread.Sleep(random.Next(1000));
                }
                lock (sync)
                {
                    finishedThreads++;
                    Monitor.Pulse(sync);
                }
            })).Start();
        }

        lock (sync)
        {
            while (finishedThreads != countThreads)
            {
                Monitor.Wait(sync);
            }
        }
        Console.WriteLine("Done");
    }
}
