class Task3
{
    static Int32 Solve(List<(Int32 w, Int32 h)> envelopes)
    {
        envelopes.Sort();
        var n = envelopes.Count;
        var dp = new Int32[n];
        for (Int32 i = 0; i < n; i++)
        {
            dp[i] = 1;
        }
        for (Int32 i = 1; i < n; i++)
        {
            for (Int32 j = 0; j < i; j++)
            {
                if ((envelopes[i].h > envelopes[j].h) && (envelopes[i].w > envelopes[j].w))
                {
                    dp[i] = Math.Max(dp[j] + 1, dp[i]);
                }
            }
        }

        return dp.Max();
    }

    static void Main(String[] args)
    {
        Console.WriteLine(Solve(new List<(int w, int h)>() { (5, 4), (6, 4), (6, 7), (2, 3) }));
        Console.WriteLine(Solve(new List<(int w, int h)>() { (1, 1), (1, 1), (1, 1) }));
        Console.WriteLine(Solve(new List<(int w, int h)>() { (1, 1), (2, 2), (3, 3) }));
    }
}
