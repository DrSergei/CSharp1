public class FooBar
{
    private int n;
    public FooBar(int n)
    {
        this.n = n;
    }
    public void Foo(Action printFoo)
    {

        for (int i = 0; i < n; i++)
        {

            printFoo();
        }
    }
    public void Bar(Action printBar)
    {

        for (int i = 0; i < n; i++)
        {

            printBar();
        }
    }
}

class Task3
{
    static void Main(String[] args)
    {
        Object sync1 = new Object();
        Object sync2 = new Object();

        bool first = false;
        bool second = false;

        var foobar = new FooBar(10);

        var thread1 = new Thread(() =>
        {
            foobar.Foo(() =>
            {
                lock (sync1)
                {
                    Console.Write("foo");
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
            });
        });

        var thread2 = new Thread(() =>
        {
            foobar.Bar(() =>
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
                    Console.Write("bar");
                    second = true;
                    Monitor.Pulse(sync2);
                }
            });
        });

        thread2.Start();
        Thread.Sleep(1000);
        thread1.Start();

        thread1.Join();
        thread2.Join();
    }
}
