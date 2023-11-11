using System.Runtime.CompilerServices;

enum Direction
{
    UP,
    DOWN,
    LEFT,
    RIGHT
}

class Board
{
    public Board(Int32 n)
    {
        this.sheeps = new Dictionary<Int32, (Int32 x, Int32 y)>();
        this.wolf.x = 0;
        this.wolf.y = 0;
        this.n = n;
        this.nextID = 4;
        this.board = new Int32[n, n];
        this.sheeps.Add(1, (0, n - 1));
        this.sheeps.Add(2, (n - 1, 0));
        this.sheeps.Add(3, (n - 1, n - 1));
    }

    public Int32 moveSheep(Int32 ID, Direction direction)
    {
        var sheep = sheeps[ID];
        if (sheep == wolf)
        {
            board[sheep.x, sheep.y]--; // died sheep
            sheeps.Remove(ID);
            return -1;
        }
        board[sheep.x, sheep.y]--;
        switch (direction)
        {
            case Direction.UP: sheep.y = Math.Min(sheep.y + 1, n - 1); break;
            case Direction.DOWN: sheep.y = Math.Max(sheep.y - 1, 0); break;
            case Direction.LEFT: sheep.x = Math.Max(sheep.x - 1, 0); break;
            case Direction.RIGHT: sheep.x = Math.Min(sheep.x + 1, n - 1); break;
        }
        board[sheep.x, sheep.y]++;
        if (board[sheep.x, sheep.y] >= 2)
        {
            board[sheep.x, sheep.y]++; // new sheep
            sheeps.Add(nextID, (sheep.x, sheep.y));
            return nextID++;
        }
        else
        {
            if (sheep == wolf)
            {
                board[sheep.x, sheep.y]--; // died sheep
                sheeps.Remove(ID);
                return -1;
            }
            return 0;
        }
    }

    public void moveWolf(Direction direction)
    {
        switch (direction)
        {
            case Direction.UP: wolf.y = Math.Min(wolf.y + 1, n - 1); break;
            case Direction.DOWN: wolf.y = Math.Max(wolf.y - 1, 0); break;
            case Direction.LEFT: wolf.x = Math.Max(wolf.x - 1, 0); break;
            case Direction.RIGHT: wolf.x = Math.Min(wolf.x + 1, n - 1); break;
        }
    }

    private Dictionary<Int32, (Int32 x, Int32 y)> sheeps;
    private (Int32 x, Int32 y) wolf;
    private Int32 n;
    private Int32 nextID;
    private Int32[,] board;
}


class Task2
{
    static Random s_random = new Random();

    static Direction getRandomDirection()
    {
        var rand = ((s_random.Next()) % 4 + 4) % 4;
        switch (rand)
        {
            case 0: return Direction.UP;
            case 1: return Direction.DOWN;
            case 2: return Direction.LEFT;
            case 3: return Direction.RIGHT;
            default: throw new Exception("unreachable");
        }
    }


    static Thread createSheepThread(Int32 ID, Board board)
    {
        return new Thread(() =>
        {
            while (true)
            {
                Thread.Sleep((s_random.Next() % 100) + 100);
                lock (board)
                {
                    var res = board.moveSheep(ID, getRandomDirection());
                    if (res == -1)
                    {
                        Console.WriteLine("died sheep");
                        return;
                    }
                    if (res > 0)
                    {
                        Console.WriteLine("new sheep");
                        createSheepThread(res, board).Start();
                    }
                }
            }
        });
    }

    static void Main(String[] args)
    {
        Board board = new Board(3);
        var threads = new List<Thread>();
        (new Thread(() =>
        {
            while (true)
            {
                Thread.Sleep((s_random.Next() % 100) + 100);
                lock (board)
                {
                    board.moveWolf(getRandomDirection());
                }
            }
        })).Start();
        createSheepThread(1, board).Start();
        createSheepThread(2, board).Start();
        createSheepThread(3, board).Start();
    }
}
