class Queue
{
    public Queue(Int32 n)
    {
        this.size = 0;
        this.capaity = n;
    }

    public Boolean Enqueue()
    {
        if (size == capaity)
        {
            return false;
        }
        size++;
        return true;
    }

    public Boolean Dequeue()
    {
        if (size == 0)
        {
            return false;
        }
        size--;
        return true;
    }

    public Boolean Empty()
    {
        return size == 0;
    }

    private Int32 size;
    private Int32 capaity;
}

class Task3
{
    static void Main(String[] args)
    {
        var queue = new Queue(3);
        var sync = new Object();
        var hairdresser = new Thread(() =>
        {
            while (true)
            {
                lock (sync)
                {
                    while (queue.Empty())
                    {
                        Monitor.Wait(sync);
                    }
                    queue.Dequeue();
                    Console.WriteLine("Took visitor");
                }
                Thread.Sleep(1000);
                Console.WriteLine("Handled visitor");
            }
        });
        var visitors = new Thread(() =>
        {
            while (true)
            {
                Thread.Sleep(111);
                lock (sync)
                {
                    if (queue.Enqueue())
                    {
                        Monitor.Pulse(sync);
                        Console.WriteLine("Added visitor");
                    }
                    else
                    {
                        Console.WriteLine("Skipped visitor");
                    }
                }
            }
        });
        hairdresser.Start();
        visitors.Start();
    }
}
