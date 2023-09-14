using System.Diagnostics;

interface IPoint
{
    public double Module()
    {
        return Math.Sqrt(x * x + y * y);
    }

    Int32 x { get; set; }
    Int32 y { get; set; }
}

struct SPoint : IPoint
{
    public int x { get; set; }
    public int y { get; set; }
}

interface IMoveablePoint : IPoint
{
    public void Move(Int32 dx, Int32 dy)
    {
        x += dx;
        y += dy;
    }
}

struct SMoveablePoint : IMoveablePoint
{
    public Int32 x { get; set; }
    public Int32 y { get; set; }
}

class Task3
{
    static void Main()
    {
        Object point = (Object)(new SPoint());
        Debug.Assert(((IPoint)point).Module() == 0);
        Object moveablePoint = (Object)(new SMoveablePoint());
        Debug.Assert(((IMoveablePoint)moveablePoint).Module() == 0);
        ((IMoveablePoint)moveablePoint).Move(3, 4);
        Debug.Assert(((IMoveablePoint)moveablePoint).Module() == 5);
        Console.WriteLine("Success");
    }
}
