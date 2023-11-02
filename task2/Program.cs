class Task2
{
    static void Main(String[] args)
    {
        Object sync1 = new Object();
        Object sync2 = new Object();

        bool first = false;
        bool second = false;

        var thread1 = new Thread(() =>
        {
            for (Int16 i = 0; i < 10; i++)
            {
                lock (sync1)
                {
                    Console.WriteLine("thread1: " + i);
                    first = true;
                    Monitor.Pulse(sync1);
                }
                lock (sync2)
                {
                    while (!second)
                    {
                        Monitor.Wait(sync2);
                    }
                    second = false;
                }
            }
        });

        var thread2 = new Thread(() =>
        {
            for (Int16 i = 0; i < 10; i++)
            {
                lock (sync1)
                {
                    while (!first)
                    {
                        Monitor.Wait(sync1);
                    }
                    first = false;
                }
                lock (sync2)
                {
                    Console.WriteLine("thread2: " + i);
                    second = true;
                    Monitor.Pulse(sync2);
                }
            }
        });

        thread1.Start();
        Thread.Sleep(1000);
        thread2.Start();

        thread1.Join();
        thread2.Join();
    }
}
