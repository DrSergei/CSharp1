class Task4
{
    static Boolean Solve(String[,] board)
    {
        Boolean squares = true;
        var threadSquares = new Thread(() =>
        {
            for (Int16 i = 0; i < 3; i++)
            {
                for (Int16 j = 0; j < 3; j++)
                {
                    var numbers = new HashSet<String>();
                    for (Int16 di = -1; di <= 1; di++)
                    {
                        for (Int16 dj = -1; dj <= 1; dj++)
                        {
                            if (board[3 * i + di + 1, 3 * j + dj + 1] == ".")
                            {
                                continue;
                            }
                            if (!numbers.Add(board[3 * i + di + 1, 3 * j + dj + 1]))
                            {
                                squares = false;
                                return;
                            }
                        }
                    }
                }
            }
        });

        Boolean rows = true;
        var threadRows = new Thread(() =>
        {
            for (Int16 i = 0; i < 9; i++)
            {
                var numbers = new HashSet<String>();
                for (Int16 j = 0; j < 9; j++)
                {
                    if (board[i, j] == ".")
                    {
                        continue;
                    }
                    if (!numbers.Add(board[i, j]))
                    {
                        rows = false;
                        return;
                    }
                }
            }
        });

        Boolean columns = true;
        var threadColumns = new Thread(() =>
        {
            for (Int16 i = 0; i < 9; i++)
            {
                var numbers = new HashSet<String>();
                for (Int16 j = 0; j < 9; j++)
                {
                    if (board[j, i] == ".")
                    {
                        continue;
                    }
                    if (!numbers.Add(board[j, i]))
                    {
                        columns = false;
                        return;
                    }
                }
            }
        });

        threadSquares.Start();
        threadRows.Start();
        threadColumns.Start();

        threadSquares.Join();
        threadRows.Join();
        threadColumns.Join();

        return squares && rows && columns;
    }
    static void Main(String[] args)
    {
        Console.WriteLine(Solve(new String[,]
        {
            {"5", "3", ".", ".", "7", ".", ".", ".", "."},
            {"6", ".", ".", "1", "9", "5", ".", ".", "."},
            {".", "9", "8", ".", ".", ".", ".", "6", "."},
            {"8", ".", ".", ".", "6", ".", ".", ".", "3"},
            {"4", ".", ".", "8", ".", "3", ".", ".", "1"},
            {"7", ".", ".", ".", "2", ".", ".", ".", "6"},
            {".", "6", ".", ".", ".", ".", "2", "8", "."},
            {".", ".", ".", "4", "1", "9", ".", ".", "5"},
            {".", ".", ".", ".", "8", ".", ".", "7", "9"}
        }
        ));

        Console.WriteLine(Solve(new String[,]
        {
            {"8", "3", ".", ".", "7", ".", ".", ".", "."},
            {"6", ".", ".", "1", "9", "5", ".", ".", "."},
            {".", "9", "8", ".", ".", ".", ".", "6", "."},
            {"8", ".", ".", ".", "6", ".", ".", ".", "3"},
            {"4", ".", ".", "8", ".", "3", ".", ".", "1"},
            {"7", ".", ".", ".", "2", ".", ".", ".", "6"},
            {".", "6", ".", ".", ".", ".", "2", "8", "."},
            {".", ".", ".", "4", "1", "9", ".", ".", "5"},
            {".", ".", ".", ".", "8", ".", ".", "7", "9"}
        }
        ));
    }
}
