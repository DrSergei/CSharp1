using System.Collections;

class Lake : IEnumerable<Int32>
{
    public Lake(List<Int32> stones)
    {
        var tmp = stones.OrderBy(stone => 1 - stone % 2).ToList();
        var index = tmp.FindIndex(stone => stone % 2 == 0);
        if (index != -1)
        {
            tmp.Reverse(index, tmp.Count - index);
        }
        this.sorted_stones = tmp;
    }

    public IEnumerator<Int32> GetEnumerator()
    {
        return sorted_stones.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    List<Int32> sorted_stones;
}

class Task1
{
    static void Main()
    {
        var lake1 = new Lake(new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 });
        foreach (var stone in lake1)
        {
            Console.Write(stone + " ");
        }
        Console.WriteLine();

        var lake2 = new Lake(new List<int>() { 13, 23, 1, -8, 4, 9 });
        foreach (var stone in lake2)
        {
            Console.Write(stone + " ");
        }
        Console.WriteLine();
    }
}
