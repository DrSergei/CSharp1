using System.Diagnostics;

class HashMap
{
    public HashMap(Int32 degree)
    {
        this._buffer = new (Object key, Object value, Boolean active)[1 << degree];
    }

    public void Insert(Object key, Object value)
    {
        Int32 hash = this.GetHash(key);
        for (Int32 i = 0; i < this._buffer.Length; i++)
        {
            Int32 index = this.GetIndex(hash, i);
            if (!this._buffer[index].active)
            {
                this._buffer[index] = (key, value, true);
                return;
            }
        }
    }

    public Object? Find(Object key)
    {
        Int32 hash = this.GetHash(key);
        for (Int32 i = 0; i < this._buffer.Length; i++)
        {
            Int32 index = this.GetIndex(hash, i);
            if (this._buffer[index].active && this._buffer[index].key.Equals(key))
            {
                return this._buffer[index].value;
            }
        }
        return null;
    }

    public void Remove(Object key)
    {
        Int32 hash = this.GetHash(key);
        for (Int32 i = 0; i < this._buffer.Length; i++)
        {
            Int32 index = this.GetIndex(hash, i);
            if (this._buffer[index].active && this._buffer[index].key.Equals(key))
            {
                this._buffer[index].active = false;
                return;
            }
        }
    }

    Int32 GetHash(Object key)
    {
        return ((key.GetHashCode() % this._buffer.Length) + this._buffer.Length) % this._buffer.Length;
    }

    Int32 GetIndex(Int32 hash, Int32 i)
    {
        return (hash + (i + i * i) / 2) % this._buffer.Length;
    }

    (Object key, Object value, Boolean active)[] _buffer;
}

class Task1
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