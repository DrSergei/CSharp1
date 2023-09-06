using System.Diagnostics;

class MinStack
{
    public MinStack()
    {
        this.buffer = new List<(Int32 value, Int32 min)>();
    }

    public void Push(Int32 value)
    {
        if (this.buffer.Count == 0)
        {
            this.buffer.Add((value, value));
        }
        else
        {
            this.buffer.Add((value, Math.Min(value, this.buffer.Last().min)));
        }
    }

    public Int32? Pop()
    {
        if (this.buffer.Count == 0)
        {
            return null;
        }

        Int32 res = this.buffer.Last().value;
        this.buffer.RemoveAt(this.buffer.Count - 1);
        return res;
    }

    public Int32? MinValue
    {
        get
        {
            if (this.buffer.Count == 0)
            {
                return null;
            }

            return this.buffer.Last().min;
        }
    }

    List<(Int32 value, Int32 min)> buffer;
}

class Task4
{
    static void Main(String[] args)
    {
        MinStack stack = new MinStack();
        Debug.Assert(stack.MinValue == null);
        stack.Push(2);
        stack.Push(1);
        stack.Push(3);
        Debug.Assert(stack.MinValue == 1);
        Debug.Assert(stack.Pop() == 3);
        Debug.Assert(stack.Pop() == 1);
        Debug.Assert(stack.MinValue == 2);
        Debug.Assert(stack.Pop() == 2);
        Debug.Assert(stack.Pop() == null);
        Console.WriteLine("Success");
    }
}
