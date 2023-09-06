class Task3
{
    private static Random s_generator = new Random();

    static string GeneratePassword()
    {
        Int32 length = s_generator.Next(6, 21);
        Int32 underscoreCount = 1;
        Int32 uppercaseLetterCount = s_generator.Next(2, length - underscoreCount);
        Int32 digitCount = s_generator.Next(0, Math.Min((length - uppercaseLetterCount - underscoreCount + 1) / 2, 5));
        Int32 lowercaseLetterCount = length - underscoreCount - uppercaseLetterCount - digitCount;
        List<Char> symbols = new List<Char>();
        for (Int32 i = 0; i < underscoreCount; i++)
        {
            symbols.Add('_');
        }
        for (Int32 i = 0; i < digitCount; i++)
        {
            symbols.Add((Char)s_generator.Next(48, 58)); // ASCII digit from 48 to 57
        }
        for (Int32 i = 0; i < uppercaseLetterCount; i++)
        {
            symbols.Add((Char)s_generator.Next(65, 91)); // ASCII uppercase letter from 65 to 90
        }
        for (Int32 i = 0; i < lowercaseLetterCount; i++)
        {
            symbols.Add((Char)s_generator.Next(97, 123)); // ASCII lowercase letter from 97 to 122
        }
        symbols = shuffle(symbols);
        while (!CheckDigits(symbols))
        {
            symbols = shuffle(symbols);
        }
        return new String(symbols.ToArray());
    }

    static bool CheckDigits(List<Char> password)
    {
        for (Int32 i = 0; i < password.Count - 1; i++)
        {
            if (Char.IsDigit(password[i]) && Char.IsDigit(password[i + 1]))
            {
                return false;
            }
        }
        return true;
    }

    static List<Char> shuffle(List<Char> list)
    {
        if (list.Count == 0)
        {
            return list;
        }

        Int32 last = list.Count - 1;
        while (last > 0)
        {
            Int32 index = s_generator.Next(0, last);
            Char tmp = list[index];
            list[index] = list[last];
            list[last] = tmp;
            last--;
        }
        return list;
    }

    static void Main(String[] args)
    {
        Console.WriteLine(GeneratePassword());
    }
}
