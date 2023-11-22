class MyArray
{
    private int[] buffer;
    private ReaderWriterLockSlim sync;
    private Random random;

    public MyArray(int[] arr)
    {
        this.buffer = arr;
        this.sync = new ReaderWriterLockSlim();
        this.random = new Random();
    }

    public int Min()
    {
        int res = 0;
        sync.EnterReadLock();
        res = buffer.Min();
        sync.ExitReadLock();
        return res;
    }

    public double Avg()
    {
        double res = 0;
        sync.EnterReadLock();
        res = buffer.Average();
        sync.ExitReadLock();
        return res;
    }

    public void Sort()
    {
        sync.EnterWriteLock();
        Array.Sort(buffer);
        sync.ExitWriteLock();
    }

    public void RandomSwap()
    {
        sync.EnterWriteLock();
        var l = random.Next(buffer.Length);
        var r = random.Next(buffer.Length);
        var tmp = buffer[l];
        buffer[l] = buffer[r];
        buffer[r] = tmp;
        sync.ExitWriteLock();
    }
}

class Task2
{
    static void Main(String[] args)
    {
        int[] arr = { 1, 2, 3, 4, 5 };
        var myArray = new MyArray(arr);
        var min = new Thread(() =>
        {
            var random = new Random();
            while (true)
            {
                Thread.Sleep(random.Next(1000));
                Console.WriteLine(myArray.Min());
            }
        });
        var avg = new Thread(() =>
        {
            var random = new Random();
            while (true)
            {
                Thread.Sleep(random.Next(1000));
                Console.WriteLine(myArray.Avg());
            }
        });
        var sort = new Thread(() =>
        {
            var random = new Random();
            while (true)
            {
                Thread.Sleep(random.Next(1000));
                myArray.Sort();
                Console.WriteLine("Sort");
            }
        });
        var swap = new Thread(() =>
        {
            var random = new Random();
            while (true)
            {
                Thread.Sleep(random.Next(1000));
                myArray.RandomSwap();
                Console.WriteLine("Swap");
            }
        });
        min.Start();
        avg.Start();
        sort.Start();
        swap.Start();
    }
}
