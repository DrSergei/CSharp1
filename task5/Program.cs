class Task5
{
    static Int64 LuckyTicket(Int32 n)
    {
        if (n % 2 != 0)
        {
            throw new ArgumentException("n should be even");
        }

        var k = n / 2;

        var dp = new Int64[k * 10, k + 1];
        for (var i = 0; i < k * 10; i++)
        {
            for (var j = 0; j <= k; j++)
            {
                dp[i, j] = 0;
            }
        }
        dp[0, 0] = 1;
        for (var j = 1; j <= k; j++)
        {
            for (var i = 0; i < k * 10; i++)
            {
                Int64 s = 0;
                for (var l = 0; l < 10; l++)
                {
                    if (i - l >= 0)
                    {
                        s += dp[i - l, j - 1];
                    }
                }
                dp[i, j] = s;
            }
        }
        Int64 res = 0;
        for (var i = 0; i < 10 * k; i++)
        {
            res += dp[i, k] * dp[i, k];
        }

        return res;
    }

    static void Main()
    {
        System.Console.WriteLine(LuckyTicket(2));
        System.Console.WriteLine(LuckyTicket(4));
        System.Console.WriteLine(LuckyTicket(12));
    }
}
