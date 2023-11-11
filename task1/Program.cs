class Honey
{
    public Honey(Int16 capacity)
    {
        this.capacity = capacity;
        this.size = size;
    }

    public void inc()
    {
        size++;
    }

    public Boolean isFull()
    {
        return size == capacity;
    }

    public void clear()
    {
        size = 0;
    }

    private Int16 size;
    private Int16 capacity;
}

class Task1
{
    static Random s_random = new Random();

    static void Main(String[] args)
    {
        var honey = new Honey(2);
        var sync = new Object();

        new Thread(() =>
        {
            while (true)
            {
                lock (sync)
                {
                    while (!honey.isFull())
                    {
                        Monitor.Wait(sync);
                    }
                    honey.clear();
                    Console.WriteLine("Bear");
                    Monitor.PulseAll(sync);
                }
            }
        }).Start(); // bear
        for (Int16 i = 0; i < 10; i++)
        {
            new Thread(() =>
            {
                while (true)
                {
                    Thread.Sleep(s_random.Next() % 100 + 100);
                    lock (sync)
                    {
                        while (honey.isFull())
                        {
                            Monitor.Wait(sync);
                        }
                        honey.inc();
                        Console.WriteLine("Bee");
                        if (honey.isFull())
                        {
                            Monitor.PulseAll(sync);
                        }
                    }
                }
            }).Start();
        }
    }
}
