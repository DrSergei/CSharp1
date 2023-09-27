delegate Double Function(Double x);

class Task3
{
    static Int32 s_n = 100000;
    static Double Integrate(Function f, Double a, Double b)
    {
        Double dx = (b - a) / s_n;
        Double curr = a;
        Double res = 0;
        for (var i = 0; i < s_n; i++)
        {
            res += dx * (f(curr) + f(curr + dx)) / 2;
            curr += dx;
        }
        return res;
    }

    static void Main()
    {
        System.Console.WriteLine(Integrate((x) => x, 0, 2));
        System.Console.WriteLine(Integrate((x) => x * x, 0, 3));
        System.Console.WriteLine(Integrate((x) => 1, 0, 1));
    }
}
