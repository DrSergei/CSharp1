abstract class Abstract
{
    public abstract void Fun();
}

interface IFirst
{
    void Fun();
}

interface ISecond
{
    void Fun();
}

class Test : Abstract, IFirst, ISecond
{
    public override void Fun()
    {
        System.Console.WriteLine("Abstract");
    }

    void IFirst.Fun()
    {
        System.Console.WriteLine("First");
    }

    void ISecond.Fun()
    {
        System.Console.WriteLine("Second");
    }
}

class Task2
{
    static void Main()
    {
        var test = new Test();
        test.Fun();
        ((IFirst)test).Fun();
        ((ISecond)test).Fun();
    }
}
