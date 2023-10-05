using System.Diagnostics;

class StackList<T>
{
    public StackList(Int32 limit)
    {
        this.limit = limit;
        this.data = new List<Stack<T>>();
    }

    public void Push(T value)
    {
        if (data.Count == 0)
        {
            data.Add(new Stack<T>());
        }
        if (data.Last().Count == limit)
        {
            data.Add(new Stack<T>());
        }
        data.Last().Push(value);
    }

    public T Pop()
    {
        if (data.Count == 0)
        {
            throw new Exception("StackList is empty");
        }
        var res = data.Last().Pop();
        if (data.Last().Count == 0)
        {
            data.RemoveAt(data.Count - 1);
        }
        return res;
    }

    Int32 limit;
    List<Stack<T>> data;
}

class Task2
{
    static void Main()
    {
        var stack = new StackList<Int32>(2);
        stack.Push(1);
        stack.Push(2);
        stack.Push(3);
        stack.Push(4);
        stack.Push(5);
        Debug.Assert(stack.Pop() == 5);
        Debug.Assert(stack.Pop() == 4);
        Debug.Assert(stack.Pop() == 3);
        Debug.Assert(stack.Pop() == 2);
        Debug.Assert(stack.Pop() == 1);
        try
        {
            stack.Pop();
        }
        catch (Exception e)
        {
            Debug.Assert(e.Message == "StackList is empty");
        }
    }
}
