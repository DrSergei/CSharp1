class Task1
{
    static void Main(String[] args)
    {
        for (Int16 i = 0; i < 1000; i++)
        {
            Int16 shared = 0;

            var thread1 = new Thread(() =>
            {
                shared++;
            });

            var thread2 = new Thread(() =>
            {
                shared++;
            });

            var thread3 = new Thread(() =>
            {
                shared++;
            });

            var thread4 = new Thread(() =>
            {
                shared++;
            });

            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();

            thread1.Join();
            thread2.Join();
            thread3.Join();
            thread4.Join();

            if (shared != 4)
            {
                Console.WriteLine("Race condition");
            }
        }
    }
}
