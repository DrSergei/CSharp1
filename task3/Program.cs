using System.Collections;

class MyNode<T>
{
    public MyNode<T> Next { get; set; }
    public MyNode<T> Previous { get; set; }
    public T Value { get; set; }
}

class MyEnumerator<T> : IEnumerator<T>
{
    public MyEnumerator(MyNode<T> start, MyNode<T> end)
    {
        _start = start;
        _curr = start;
        _end = end;
    }

    MyNode<T> _start;
    MyNode<T> _curr;
    MyNode<T> _end;


    public T Current => _curr.Value;

    object IEnumerator.Current => Current;

    public void Dispose()
    {
    }

    public bool MoveNext()
    {
        if (_curr.Next != _end)
        {
            _curr = _curr.Next;
            return true;
        }
        return false;
    }

    public void Reset()
    {
        _curr = _start;
    }
}

class MyLinkedList<T> : IEnumerable<T>
{
    public MyLinkedList()
    {
        Start = new MyNode<T>();
        End = new MyNode<T>();
        Start.Next = End;
        End.Previous = Start;
        Count = 0;
    }

    public void Add(T value)
    {
        var tmp = new MyNode<T>();
        tmp.Value = value;
        tmp.Next = End;
        tmp.Previous = End.Previous;
        End.Previous = tmp;
        tmp.Previous.Next = tmp;
        Count++;
    }

    public Boolean Remove(T value)
    {
        var curr = Start.Next;
        while (curr != End)
        {
            if (curr.Value.Equals(value))
            {
                curr.Previous.Next = curr.Next;
                curr.Next.Previous = curr.Previous;
                Count--;
                return true;
            }
            curr = curr.Next;
        }
        return false;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new MyEnumerator<T>(Start, End);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public Int32 Count { get; set; }
    MyNode<T> Start { get; set; }
    MyNode<T> End { get; set; }
}

class Task3
{
    static void Main()
    {
        var list = new MyLinkedList<Int32>();
        list.Add(1);
        list.Add(2);
        list.Add(3);
        foreach (var value in list)
        {
            Console.Write(value + " ");
        }
        Console.WriteLine("\n" + list.Count);

        list.Remove(1);
        list.Remove(3);
        list.Remove(5);
        foreach (var value in list)
        {
            Console.Write(value + " ");
        }
        Console.WriteLine("\n" + list.Count);
    }
}
