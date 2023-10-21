class Task4
{
    static Dictionary<String, String> s_dict = new Dictionary<String, String>()
    {
        {"this", "эта"},
        {"dog", "собака"},
        {"eats", "ест"},
        {"too", "слишком"},
        {"much", "много"},
        {"vegetables", "овощей"},
        {"after", "после"},
        {"lunch", "обеда"}
    };

    static void Translate(String str, UInt16 n)
    {
        foreach (var line in str.Split().Select(word => s_dict[word.ToLower()].ToUpper()).Chunk(n))
        {
            foreach (var word in line)
            {
                Console.Write(word + " ");
            }
            Console.WriteLine();
        }
    }
    static void Main()
    {
        Translate("This dog eats too much vegetables after lunch", 3);
    }
}
