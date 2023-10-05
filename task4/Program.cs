using System.Text;

class Task4
{
    static Boolean IsPrime(UInt64 q)
    {
        for (UInt64 i = 2; i < q; i++)
        {
            if (q % i == 0)
            {
                return false;
            }
        }
        return true;
    }
    static UInt64 NextPrimeNumber(UInt64 p)
    {
        UInt64 q = p + 1;
        while (true)
        {
            if (IsPrime(q))
            {
                return q;
            }
            q++;
        }
    }

    static String ExpressFactors(UInt64 n)
    {
        var builder = new StringBuilder();
        UInt64 p = 2;
        UInt64 count = 0;
        while (n > 1)
        {
            if (n % p == 0)
            {
                count++;
                n /= p;
            }
            else
            {
                if (count > 0)
                {
                    builder.Append(" x ");
                    builder.Append(p);
                    if (count > 1)
                    {
                        builder.Append("^" + count);
                    }
                }
                count = 0;
                p = NextPrimeNumber(p);
            }
        }
        if (count > 0)
        {
            builder.Append(" x ");
            builder.Append(p);
            if (count > 1)
            {
                builder.Append("^" + count);
            }
        }
        var res = builder.ToString();
        return res.Substring(3);
    }

    static void Main()
    {
        System.Console.WriteLine(ExpressFactors(2));
        System.Console.WriteLine(ExpressFactors(4));
        System.Console.WriteLine(ExpressFactors(10));
        System.Console.WriteLine(ExpressFactors(60));
    }
}
