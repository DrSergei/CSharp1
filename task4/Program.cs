using System.Diagnostics;

class Task4
{
    static Int64 Flip(Int64 n)
    {
        var buffer = n.ToString().ToCharArray();
        Array.Reverse(buffer);
        return Int64.Parse(new String(buffer));
    }

    static (Int64 seed, Int64 steps) PalSeq(Int64 palindrome)
    {
        Int64 seed = 1;
        while (seed < palindrome)
        {
            Int64 steps = 0;
            Int64 cur = seed;
            while (cur < palindrome)
            {
                cur += Flip(cur);
                steps++;
                if (cur == palindrome)
                {
                    return (seed, steps);
                }
            }
            seed++;
        }
        return (seed, 0);
    }

    static void Main()
    {
        Debug.Assert(PalSeq(4884) == (3, 9));
        Debug.Assert(PalSeq(1) == (1, 0));
        Debug.Assert(PalSeq(11) == (5, 2));
        Debug.Assert(PalSeq(3113) == (199, 3));
        Console.WriteLine("Success");
    }
}
