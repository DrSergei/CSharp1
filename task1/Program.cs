class MyDisposable : IDisposable
{
    public void Dispose()
    {
        if (disposed) return;
        disposed = true;
        Console.WriteLine("Disposed value: " + Value);
    }

    Boolean disposed = false;

    public Int32 Value { get; set; }
}

class CacheEntry<T>
{
    public T Data { get; set; }
    public Int64 LastAccessTime { get; set; }
}

class Cache<T> where T : IDisposable
{
    public Cache(Int32 capacity, Int64 delta)
    {
        this.buffer = new Dictionary<Int32, CacheEntry<T>>();
        this.capacity = capacity;
        this.delta = delta;
    }

    public Int32 Add(T value)
    {
        var entry = new CacheEntry<T> { Data = value, LastAccessTime = DateTimeOffset.Now.ToUnixTimeMilliseconds() };
        if (buffer.Count == capacity)
        {
            Clean();
            if (buffer.Count == capacity)
            {
                throw new Exception("Failed to clean cache");
            }
        }
        var hash = value.GetHashCode();
        buffer.Add(value.GetHashCode(), entry);
        return hash;
    }

    public T Get(Int32 hash)
    {
        var entry = buffer[hash];
        entry.LastAccessTime = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        return buffer[hash].Data;
    }

    void Clean()
    {
        var time = DateTimeOffset.Now.ToUnixTimeMilliseconds();
        var keys = buffer.Where((pair) => (time - pair.Value.LastAccessTime) > delta).Select(pair => pair.Key);
        foreach (var key in keys)
        {
            buffer[key].Data.Dispose();
            buffer.Remove(key);
        }
    }

    Int32 capacity;
    Int64 delta;
    Dictionary<Int32, CacheEntry<T>> buffer;
}

class Task1
{
    static void Main()
    {
        var obj1 = new MyDisposable() { Value = 1 };
        var obj2 = new MyDisposable() { Value = 2 };
        var obj3 = new MyDisposable() { Value = 3 };
        var cache = new Cache<MyDisposable>(2, 10);
        var hash1 = cache.Add(obj1);
        obj1 = null;
        obj1 = cache.Get(hash1);
        Console.WriteLine(obj1.Value);
        Thread.Sleep(100);
        var hash2 = cache.Add(obj2);
        obj2 = null;
        obj2 = cache.Get(hash2);
        Console.WriteLine(obj2.Value);
        Thread.Sleep(100);
        var hash3 = cache.Add(obj3);
    }
}
