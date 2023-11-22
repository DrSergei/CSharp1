public class ZeroEvenOdd
{
    private int n;
    private int state;
    private object sync;

    public ZeroEvenOdd(int n)
    {
        this.n = n;
        this.state = 0;
        this.sync = new object();
    }

    public void Zero(Action<int> printNumber)
    {
        for (int i = 0; i < n; i++)
        {
            lock (sync)
            {
                while (state != 0)
                {
                    Monitor.Wait(sync);
                }
                printNumber(0);
                state = i % 2 + 1;
                Monitor.PulseAll(sync);
            }
        }
    }

    public void Even(Action<int> printNumber)
    {
        for (int i = 2; i <= n; i += 2)
        {
            lock (sync)
            {
                while (state != 2)
                {
                    Monitor.Wait(sync);
                }
                printNumber(i);
                state = 0;
                Monitor.PulseAll(sync);
            }
        }
    }

    public void Odd(Action<int> printNumber)
    {
        for (int i = 1; i <= n; i += 2)
        {
            lock (sync)
            {
                while (state != 1)
                {
                    Monitor.Wait(sync);
                }
                printNumber(i);
                state = 0;
                Monitor.PulseAll(sync);
            }
        }
    }
}

class Task1
{
    static void Main(String[] args)
    {
        var zeo = new ZeroEvenOdd(5);
        var printNumbers = (int n) =>
        {
            Console.Write(n);
        };

        var zero = new Thread(() =>
        {
            zeo.Zero(printNumbers);
        });
        var even = new Thread(() =>
        {
            zeo.Even(printNumbers);
        });
        var odd = new Thread(() =>
        {
            zeo.Odd(printNumbers);
        });

        odd.Start();
        Thread.Sleep(100);
        even.Start();
        Thread.Sleep(100);
        zero.Start();
    }
}
