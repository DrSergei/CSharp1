using System.Diagnostics;

class ImmutableArray
{
    public ImmutableArray(List<Int32> values)
    {
        _values = values;
    }

    public Int32 get(Int32 index)
    {
        return this._values[index];
    }

    public ImmutableArray set(Int32 index, Int32 value)
    {
        var values = new List<Int32>(_values);
        values[index] = value;
        return new ImmutableArray(values);
    }

    public ImmutableArray append(Int32 value)
    {
        var values = new List<Int32>(_values);
        values.Add(value);
        return new ImmutableArray(values);
    }

    public Int32 Count
    {
        get
        {
            return _values.Count;
        }
    }

    private List<Int32> _values;
}

class Task2
{
    static void Main()
    {
        ImmutableArray array1 = new ImmutableArray(new List<int> { 1, 2, 3 });
        Debug.Assert(array1.Count == 3);
        Debug.Assert(array1.get(0) == 1);
        Debug.Assert(array1.get(1) == 2);
        Debug.Assert(array1.get(2) == 3);
        ImmutableArray array2 = array1.set(0, 4);
        Debug.Assert(array1.Count == 3);
        Debug.Assert(array1.get(0) == 1);
        Debug.Assert(array1.get(1) == 2);
        Debug.Assert(array1.get(2) == 3);
        Debug.Assert(array2.Count == 3);
        Debug.Assert(array2.get(0) == 4);
        Debug.Assert(array2.get(1) == 2);
        Debug.Assert(array2.get(2) == 3);
        ImmutableArray array3 = array2.append(5);
        Debug.Assert(array2.Count == 3);
        Debug.Assert(array2.get(0) == 4);
        Debug.Assert(array2.get(1) == 2);
        Debug.Assert(array2.get(2) == 3);
        Debug.Assert(array3.Count == 4);
        Debug.Assert(array3.get(0) == 4);
        Debug.Assert(array3.get(1) == 2);
        Debug.Assert(array3.get(2) == 3);
        Debug.Assert(array3.get(3) == 5);
        Console.WriteLine("Success");
    }
}
