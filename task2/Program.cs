class Person
{
    public String Name { get; set; }
    public UInt16 Age { get; set; }
}

class NameComparer : Comparer<Person>
{
    public override int Compare(Person l, Person r)
    {
        var comp = l.Name.Count().CompareTo(r.Name.Count());
        if (comp != 0)
        {
            return comp;
        }

        if (l.Name == "" && r.Name == "")
        {
            return 0;
        }

        return String.Compare(l.Name.First().ToString(), r.Name.First().ToString(), StringComparison.OrdinalIgnoreCase);
    }
}

class AgeComparer : Comparer<Person>
{
    public override int Compare(Person l, Person r)
    {
        return l.Age.CompareTo(r.Age);
    }
}

class Task2
{
    static void Main()
    {
        var person1 = new Person();
        person1.Name = "Bob";
        person1.Age = 10;
        var person2 = new Person();
        person2.Name = "bil";
        person2.Age = 18;
        var person3 = new Person();
        person3.Name = "Alisa";
        person3.Age = 25;

        var nameComparer = new NameComparer();
        Console.WriteLine(nameComparer.Compare(person1, person2));
        Console.WriteLine(nameComparer.Compare(person1, person3));
        Console.WriteLine(nameComparer.Compare(person2, person3));

        var ageComparer = new AgeComparer();
        Console.WriteLine(ageComparer.Compare(person1, person2));
        Console.WriteLine(ageComparer.Compare(person1, person3));
        Console.WriteLine(ageComparer.Compare(person2, person3));
    }
}
