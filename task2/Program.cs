public class Foo
{
    public void first() { Console.Write("first"); }
    public void second() { Console.Write("second"); }
    public void third() { Console.Write("third"); }
}

class Task2
{
    static void Main(String[] args)
    {
        var sync1 = new Object();
        var sync2 = new Object();

        var foo = new Foo();

        bool firstPrinted = false;

        var thread1 = new Thread(() =>
        {
            lock (sync1)
            {
                foo.first();
                firstPrinted = true;
                Monitor.Pulse(sync1);
            }
        });

        bool secondPrinted = false;

        var thread2 = new Thread(() =>
        {
            lock (sync1)
            {
                while (!firstPrinted)
                {
                    Monitor.Wait(sync1);
                }
                lock (sync2)
                {
                    foo.second();
                    secondPrinted = true;
                    Monitor.Pulse(sync2);

                }
            }
        });

        var thread3 = new Thread(() =>
        {
            lock (sync2)
            {
                while (!secondPrinted)
                {
                    Monitor.Wait(sync2);
                }
                foo.third();
            }
        });

        thread1.Start();
        Thread.Sleep(1000);
        thread3.Start();
        Thread.Sleep(1000);
        thread2.Start();


        thread1.Join();
        thread2.Join();
        thread3.Join();
    }
}
