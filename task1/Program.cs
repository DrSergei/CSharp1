using System;

class TestEventArgs : EventArgs
{
    public String Message { get; set; }
}

class Publisher
{
    public void Publish(string message)
    {
        EventBus.Instance.Publish(this, new TestEventArgs { Message = message });
    }
}

class EventBus
{
    private static EventBus _instance;

    private EventBus()
    {
        actions = new Dictionary<Object, List<Action<TestEventArgs>>>();
    }

    public static EventBus Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new EventBus();
            }
            return _instance;
        }
    }

    private readonly Dictionary<Object, List<Action<TestEventArgs>>> actions;

    public void Subsribe(Object publisher, Action<TestEventArgs> eventHandler)
    {
        if (!actions.ContainsKey(publisher))
        {
            actions.Add(publisher, new List<Action<TestEventArgs>>());
        }
        actions[publisher].Add(eventHandler);
    }

    public void Unsubsribe(Object publisher, Action<TestEventArgs> eventHandler)
    {
        if (actions.ContainsKey(publisher))
        {
            actions[publisher].Remove(eventHandler);
        }
    }

    public void Publish(Object publisher, TestEventArgs args)
    {
        if (actions.ContainsKey(publisher))
        {
            foreach (var action in actions[publisher])
            {
                action(args);
            }
        }
    }
}

class Subscriber1
{
    public void EventHandler(TestEventArgs e)
    {
        System.Console.WriteLine("Subscriber1:" + e.Message);
    }
}

class Subscriber2
{
    public void EventHandler(TestEventArgs e)
    {
        System.Console.WriteLine("Subscriber2:" + e.Message);
    }
}

class Task1
{
    static void Main()
    {
        Publisher publisher1 = new Publisher();
        Publisher publisher2 = new Publisher();
        Subscriber1 subscriber1 = new Subscriber1();
        Subscriber2 subscriber2 = new Subscriber2();
        EventBus.Instance.Subsribe(publisher1, subscriber1.EventHandler);
        EventBus.Instance.Subsribe(publisher1, subscriber2.EventHandler);
        EventBus.Instance.Subsribe(publisher2, subscriber2.EventHandler);
        publisher1.Publish("Test publisher1");
        publisher2.Publish("Test publisher2");
        EventBus.Instance.Unsubsribe(publisher1, subscriber1.EventHandler);
        EventBus.Instance.Unsubsribe(publisher1, subscriber2.EventHandler);
        EventBus.Instance.Unsubsribe(publisher2, subscriber2.EventHandler);
        publisher1.Publish("Test publisher1");
        publisher2.Publish("Test publisher2");
    }
}
