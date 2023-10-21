class Task3
{
    static void Solve(String str)
    {
        char[] seps = { ' ', '-', ',', '.', ':', ';' };
        var query = from word in str.Split(seps, StringSplitOptions.RemoveEmptyEntries)
                    group word by word.Length into wordGroup
                    orderby -wordGroup.Count()
                    select (wordGroup.Key, wordGroup.Count(), wordGroup);
        foreach (var group in query)
        {
            Console.Write("Длина " + group.Key + ". ");
            Console.WriteLine("Количество " + group.Item2 + ".");
            foreach (var word in group.wordGroup)
            {
                Console.WriteLine(word);
            }
            Console.WriteLine();
        }
    }

    static void Main()
    {
        Solve("Это что же получается: ходишь, ходишь в школу, а потом бац - вторая смена");
    }
}
