using System.Diagnostics;

class Task4
{
    static Dictionary<(Int32 count, Int32 sum), Int32> s_memory = new Dictionary<(int count, int sum), int>();

    static Int32 diceRoll(Int32 count, Int32 sum)
    {
        if (count == 0)
        {
            if (sum == 0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        if (s_memory.ContainsKey((count, sum)))
        {
            return s_memory[(count, sum)];
        }

        Int32 answer = 0;
        for (Int32 i = 1; i <= 6; i++)
        {
            answer += diceRoll(count - 1, sum - i);
        }
        s_memory.Add((count, sum), answer);

        return answer;
    }

    static void Main()
    {
        Debug.Assert(diceRoll(2, 6) == 5);
        Debug.Assert(diceRoll(2, 2) == 1);
        Debug.Assert(diceRoll(1, 3) == 1);
        Debug.Assert(diceRoll(2, 5) == 4);
        Debug.Assert(diceRoll(3, 4) == 3);
        Debug.Assert(diceRoll(4, 18) == 80);
        Debug.Assert(diceRoll(6, 20) == 4221);
        Console.WriteLine("Success");
    }
}
