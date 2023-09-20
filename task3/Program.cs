using System.Diagnostics;
using System.Text;

class Task3
{
    static Int32 GCD(Int32 x, Int32 y)
    {
        if (x == 0)
        {
            return y;
        }
        if (y == 0)
        {
            return x;
        }

        if (x > y)
        {
            return GCD(x % y, y);
        }
        else
        {
            return GCD(x, y % x);
        }
    }

    static String Simplify(String str)
    {
        var buffer = str.Split('/');
        if (buffer.Length == 2)
        {
            Boolean isPositive = true;
            Int32 x = Int32.Parse(buffer[0]);
            if (x < 0)
            {
                isPositive = !isPositive;
                x = -x;
            }
            Int32 y = Int32.Parse(buffer[1]);
            if (y == 0)
            {
                throw new ArgumentException("Denominator is zero");
            }
            if (y < 0)
            {
                isPositive = !isPositive;
                y = -y;
            }
            var gcd = GCD(x, y);
            x /= gcd;
            y /= gcd;
            var res = new StringBuilder();
            res.Append(!isPositive ? "-" : "");
            res.Append(x);
            if (y == 1)
            {
                return res.ToString();
            }
            else
            {
                res.Append("/");
                res.Append(y);
                return res.ToString();
            }
        }
        else
        {
            throw new ArgumentException(str);
        }
    }

    static void Main()
    {
        Debug.Assert(Simplify("4/6") == "2/3");
        Debug.Assert(Simplify("10/11") == "10/11");
        Debug.Assert(Simplify("100/400") == "1/4");
        Debug.Assert(Simplify("8/4") == "2");
        Debug.Assert(Simplify("-8/4") == "-2");
        Debug.Assert(Simplify("8/-4") == "-2");
        Console.WriteLine("Success");
    }
}
