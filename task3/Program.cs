public class H2O
{
    public H2O()
    {
    }
    public void Hydrogen(Action releaseHydrogen)
    {
        // releaseHydrogen() outputs "H". Do not change or remove this line.
        releaseHydrogen();
    }
    public void Oxygen(Action releaseOxygen)
    {
        // releaseOxygen() outputs "O". Do not change or remove this line.
        releaseOxygen();
    }
}

class Task3
{
    static void Main(String[] args)
    {
        int count_atoms = 0;
        var sync = new Object();
        var hydrogenSemaphore = new Semaphore(1, 1);
        var oxygenSemaphore = new Semaphore(2, 2);

        var random = new Random();
        while (true)
        {
            var type = random.Next(3);
            if (type == 0) // Hydrogen
            {
                (new Thread(() =>
                {
                    hydrogenSemaphore.WaitOne();
                    lock (sync)
                    {
                        count_atoms++;
                        if (count_atoms == 3)
                        {
                            count_atoms = 0;
                            Monitor.PulseAll(sync);
                        }
                        else
                        {
                            Monitor.Wait(sync);
                        }
                        Console.Write('H');
                    }
                    hydrogenSemaphore.Release();
                })).Start();
            }
            else // Oxygen
            {
                (new Thread(() =>
                {

                    oxygenSemaphore.WaitOne();
                    lock (sync)
                    {
                        count_atoms++;
                        if (count_atoms == 3)
                        {
                            count_atoms = 0;
                            Monitor.PulseAll(sync);
                        }
                        else
                        {
                            Monitor.Wait(sync);
                        }
                        Console.Write('O');
                    }
                    oxygenSemaphore.Release();
                })).Start();
            }
        }
    }
}
