class Task4
{
    static void Main()
    {
        var getTableFromFile = (String path) =>
        {
            return File.ReadAllLines(path).ToList().ConvertAll(line => line.Trim().Split('\t')).ToLookup(record => record[0], record => record.Skip(1).ToList());
        };
        var path1 = Console.ReadLine();
        var table1 = getTableFromFile(path1);
        var path2 = Console.ReadLine();
        var table2 = getTableFromFile(path2);
        foreach (var group1 in table1)
        {
            var key = group1.Key;
            if (table2.Contains(key))
            {
                var group2 = table2[key];
                foreach (var fields1 in group1)
                {
                    foreach (var fields2 in group2)
                    {
                        Console.Write(key + " ");
                        Console.Write(String.Join(" ", fields1) + " ");
                        Console.Write(String.Join(" ", fields2) + " ");
                        Console.WriteLine();
                    }
                }
            }
        }
    }
}
