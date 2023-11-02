class Task1
{
    static void Main(String[] args)
    {
        var mutex1 = new Mutex();
        var mutex2 = new Mutex();

        var thread1 = new Thread(() =>
        {
            mutex1.WaitOne();
            Thread.Sleep(1000);
            mutex2.WaitOne();
        });

        var thread2 = new Thread(() =>
        {
            mutex2.WaitOne();
            Thread.Sleep(1000);
            mutex1.WaitOne();
        });

        thread1.Start();
        thread2.Start();

        thread1.Join();
        thread2.Join();
    }
}
