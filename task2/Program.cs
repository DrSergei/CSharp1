using System.Diagnostics;

class Task3
{
    static object? FindIntersection(LinkedList<Object> l1, LinkedList<Object> l2)
    {
        var i1 = l1.First;
        var i2 = l2.First;
        if (i1 == null || i2 == null)
        {
            return null;
        }
        Int32 k = 0;
        while (k < 3)
        {
            if (i1?.ValueRef == i2?.ValueRef)
            {
                return i1?.ValueRef;
            }
            i1 = i1?.Next;
            if (i1 == null)
            {
                i1 = l2.First;
                k++;
            }
            i2 = i2?.Next;
            if (i2 == null)
            {
                i2 = l1.First;
                k++;
            }
        }
        return null;
    }

    static void Main()
    {
        var l1 = new LinkedList<Object>();
        var l2 = new LinkedList<Object>();
        var o1 = new Object();
        var o2 = new Object();
        var o3 = new Object();
        var o4 = new Object();
        var o5 = new Object();
        l1.AddLast(o1);
        l1.AddLast(o2);
        l1.AddLast(o4);
        l1.AddLast(o5);
        l2.AddLast(o3);
        l2.AddLast(o4);
        l2.AddLast(o5);
        Debug.Assert(FindIntersection(l1, l2) == o4);
        l1.Clear();
        l2.Clear();
        Debug.Assert(FindIntersection(l1, l2) == null);
        l1.AddLast(o1);
        l2.AddLast(o1);
        Debug.Assert(FindIntersection(l1, l2) == o1);
        l2.Clear();
        l2.AddLast(o2);
        Debug.Assert(FindIntersection(l1, l2) == null);
        l1.AddLast(o2);
        Debug.Assert(FindIntersection(l1, l2) == o2);
        Console.WriteLine("Success");
    }
}
