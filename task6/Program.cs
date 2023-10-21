class Task6
{
    static String swap(String s, Int32 n, Int32 m)
    {
        var arr = s.ToCharArray();
        var tmp = arr[n];
        arr[n] = arr[m];
        arr[m] = tmp;
        return new String(arr);
    }
    static (UInt64 max, UInt64 min) MaxMin(UInt64 n)
    {
        String str = n.ToString();
        Int32 l = str.Length;
        var xs = Enumerable.Range(0, l);
        var ys = Enumerable.Range(0, l);
        var variants = from x in xs
                       from y in ys
                       select swap(str, x, y) into tmp
                       where tmp.First() != '0'
                       select UInt64.Parse(tmp);
        return (variants.Max(), variants.Min());
    }

    static void Main()
    {
        Console.WriteLine(MaxMin(12340));
        Console.WriteLine(MaxMin(98761));
        Console.WriteLine(MaxMin(9000));
        Console.WriteLine(MaxMin(11321));
    }
}
