class Task7
{
    static List<(Int32, Int32, Int32)> ThreeSum(List<Int32> numbers)
    {
        var sum3 = from x in Enumerable.Range(0, numbers.Count)
                   from y in Enumerable.Range(0, x)
                   from z in Enumerable.Range(0, y)
                   where numbers[x] + numbers[y] + numbers[z] == 0
                   select (numbers[z], numbers[y], numbers[x]);
        var sum2 = from x in Enumerable.Range(0, numbers.Count)
                   from y in Enumerable.Range(0, x)
                   where numbers[x] + numbers[y] == 0
                   select (0, numbers[y], numbers[x]);
        return sum3.Concat(sum2).OrderBy(l => l.Item1).Distinct().ToList();
    }

    static void Main()
    {
        Console.WriteLine("Test1");
        foreach (var list in ThreeSum(new List<Int32> { 0, 1, -1, -1, 2 }))
        {
            Console.WriteLine(list.Item1 + " " + list.Item2 + " " + list.Item3);
        }

        Console.WriteLine("Test2");
        foreach (var list in ThreeSum(new List<Int32> { 0, 0, 0, 5, -5 }))
        {
            Console.WriteLine(list.Item1 + " " + list.Item2 + " " + list.Item3);
        }

        Console.WriteLine("Test3");
        foreach (var list in ThreeSum(new List<Int32> { 1, 2, 3 }))
        {
            Console.WriteLine(list.Item1 + " " + list.Item2 + " " + list.Item3);
        }
        Console.WriteLine();

        Console.WriteLine("Test4");
        foreach (var list in ThreeSum(new List<Int32> { 1 }))
        {
            Console.WriteLine(list.Item1 + " " + list.Item2 + " " + list.Item3);
        }
        Console.WriteLine();
    }
}
