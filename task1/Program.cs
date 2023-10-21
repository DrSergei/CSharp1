class Person
{
    public String Name { get; set; }
}

class Task1
{

    static String Solve(IEnumerable<Person> persons, Char delimeter)
    {
        return new String(persons.Skip(3).SelectMany(p => p.Name + delimeter).SkipLast(1).ToArray());
    }

    static void Main()
    {
        var person1 = new Person() { Name = "1" };
        var person2 = new Person() { Name = "2" };
        var person3 = new Person() { Name = "3" };
        var person4 = new Person() { Name = "4" };
        var person5 = new Person() { Name = "5" };
        var persons = new List<Person>() { person1, person2, person3, person4, person5 };
        Console.WriteLine(Solve(persons, ';'));
    }
}
