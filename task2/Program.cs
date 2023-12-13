class Task2
{
    static String Permutations(String str)
    {
        var chars = str.ToArray();
        var n = chars.Length;
        var buffer = new List<String>() { "" };
        for (int i = 0; i < n; i++)
        {
            var value = chars[i].ToString();
            var tmp = new List<String>();
            for (int j = 0; j <= i; j++)
            {
                tmp.AddRange(buffer.Select(str => str.Insert(j, value)));
            }
            buffer = tmp;
        }
        buffer.Sort();
        return String.Join(" ", buffer.ToArray());
    }

    static void Main()
    {
        Console.WriteLine(Permutations("AB"));
        Console.WriteLine(Permutations("CD"));
        Console.WriteLine(Permutations("EF"));
        Console.WriteLine(Permutations("NOT"));
        Console.WriteLine(Permutations("RAM"));
        Console.WriteLine(Permutations("YAW"));
    }
}
