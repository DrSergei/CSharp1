class Task3
{
    static Int32 SunLoungers(String str)
    {
        var data = ("0" + str + "0").ToCharArray();
        Int32 res = 0;
        for (Int32 i = 1; i < data.Length - 1; i++)
        {
            if (data[i - 1] == '0' && data[i] == '0' && data[i + 1] == '0')
            {
                data[i] = '1';
                res++;
            }
        }
        return res;
    }

    static void Main()
    {
        System.Console.WriteLine(SunLoungers("10001"));
        System.Console.WriteLine(SunLoungers("00101"));
        System.Console.WriteLine(SunLoungers("0"));
        System.Console.WriteLine(SunLoungers("000"));
    }
}
