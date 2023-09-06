using System.Diagnostics;

class HashMap
{
    public HashMap(Int32 bucketsCount)
    {
        this.buckets = new List<LinkedList<(object key, object value)>>(bucketsCount);
        for (Int32 i = 0; i < bucketsCount; i++)
        {
            this.buckets.Add(new LinkedList<(object key, object value)>());
        }
    }

    public void Insert(object key, object value)
    {
        Int32 index = this.GetIndex(key);
        foreach (var entry in this.buckets[index])
        {
            if (entry.key.Equals(key))
            {
                return;
            }
        }
        this.buckets[index].AddLast((key, value));
    }

    public object? Find(object key)
    {
        Int32 index = this.GetIndex(key);
        foreach (var entry in this.buckets[index])
        {
            if (entry.key.Equals(key))
            {
                return entry.value;
            }
        }
        return null;
    }

    public void Remove(object key)
    {
        Int32 index = this.GetIndex(key);
        foreach (var entry in this.buckets[index])
        {
            if (entry.key.Equals(key))
            {
                this.buckets[index].Remove(entry);
                return;
            }
        }
    }

    Int32 GetIndex(object key)
    {
        return ((key.GetHashCode() % this.buckets.Count) + this.buckets.Count) % this.buckets.Count;
    }

    List<LinkedList<(object key, object value)>> buckets;
}

class Task2
{
    static void Main(String[] args)
    {
        HashMap map = new HashMap(2);
        map.Insert("a", 1);
        map.Insert(2, "b");
        map.Insert("c", "d");
        map.Insert(3, 4);
        Debug.Assert((Int32)map.Find("a") == 1);
        Debug.Assert((String)map.Find(2) == "b");
        Debug.Assert((String)map.Find("c") == "d");
        Debug.Assert((Int32)map.Find(3) == 4);
        Debug.Assert(map.Find("test") == null);
        map.Remove(2);
        Debug.Assert(map.Find(2) == null);
        map.Remove("a");
        Debug.Assert(map.Find("a") == null);
        map.Remove("c");
        Debug.Assert(map.Find("c") == null);
        map.Remove(3);
        Debug.Assert(map.Find(3) == null);
        Console.WriteLine("Success");
    }
}
