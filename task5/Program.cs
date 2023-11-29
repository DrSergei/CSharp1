using System.Text;

class Task5
{
    static String Rational(Int32 a, Int32 b)
    {
        var answer = new StringBuilder("0.");
        var remainder = a % b;

        var remainders = new List<Int32>();
        var digits = new List<Int32>();
        while (remainder != 0)
        {
            if (remainders.Contains(remainder))
            {
                var index = remainders.IndexOf(remainder);
                for (Int32 i = 0; i < index; i++)
                {
                    answer.Append(digits[i]);
                }
                answer.Append('(');
                for (Int32 i = index; i < digits.Count; i++)
                {
                    answer.Append(digits[i]);
                }
                answer.Append(')');
                return answer.ToString();
            }

            remainders.Add(remainder);
            remainder *= 10;
            digits.Add(remainder / b);
            remainder %= b;
        }
        for (Int32 i = 0; i < digits.Count; i++)
        {
            answer.Append(digits[i]);
        }
        return answer.ToString();
    }

    static void Main(String[] args)
    {
        Console.WriteLine(Rational(2, 5));
        Console.WriteLine(Rational(1, 6));
        Console.WriteLine(Rational(1, 3));
        Console.WriteLine(Rational(1, 7));
        Console.WriteLine(Rational(1, 77));
    }
}
