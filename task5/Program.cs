using System.Diagnostics;

class Task5
{
    static Int32 Solve(List<Int32> heights)
    {
        if (heights.Count <= 1)
        {
            return 0;
        }

        List<Int32> prefixMax = new List<Int32>();
        prefixMax.Add(heights[0]);
        for (Int32 i = 1; i < heights.Count; i++)
        {
            prefixMax.Add(Math.Max(heights[i], prefixMax.Last()));
        }

        List<Int32> suffixMax = new List<Int32>();
        suffixMax.Add(heights.Last());
        for (Int32 i = heights.Count - 2; i >= 0; i--)
        {
            suffixMax.Add(Math.Max(heights[i], suffixMax.Last()));
        }

        Int32 answer = 0;
        for (Int32 i = 0; i < heights.Count; i++)
        {
            Int32 height = Math.Min(prefixMax[i], suffixMax[heights.Count - 1 - i]);
            answer += height - heights[i];
        }
        return answer;
    }

    static void Main()
    {
        Debug.Assert(Solve(new List<int>() { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }) == 6);
        Debug.Assert(Solve(new List<int>() { 4, 2, 0, 3, 2, 5 }) == 9);
        Console.WriteLine("Success");
    }
}
