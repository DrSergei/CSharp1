class Task1
{
    static void Main(String[] args)
    {
        var random = new Random();
        var digits = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
        var digits1 = digits.OrderBy(x => random.Next()).ToList();
        var digits2 = digits.OrderBy(x => random.Next()).ToList();
        var digits3 = digits.OrderBy(x => random.Next()).ToList();
        var digits4 = digits.OrderBy(x => random.Next()).ToList();
        var digits5 = digits.OrderBy(x => random.Next()).ToList();
        var digits6 = digits.OrderBy(x => random.Next()).ToList();
        var digits7 = digits.OrderBy(x => random.Next()).ToList();
        var digits8 = digits.OrderBy(x => random.Next()).ToList();
        using (var writer = new StreamWriter("tmp.txt"))
        {
            for (Int64 i = 0; i < 100000000; i++)
            {
                var j = i;
                writer.Write(digits1[(Int32)(i % 10)]);
                i /= 10;
                writer.Write(digits2[(Int32)(i % 10)]);
                i /= 10;
                writer.Write(digits3[(Int32)(i % 10)]);
                i /= 10;
                writer.Write(digits4[(Int32)(i % 10)]);
                i /= 10;
                writer.Write(digits5[(Int32)(i % 10)]);
                i /= 10;
                writer.Write(digits6[(Int32)(i % 10)]);
                i /= 10;
                writer.Write(digits7[(Int32)(i % 10)]);
                i /= 10;
                writer.WriteLine(digits8[(Int32)(i % 10)]);
                i = j;
            }
        }
    }
}
