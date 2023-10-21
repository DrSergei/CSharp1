class Person
{
    public String Name { get; set; }
}

class Task2
{

    static List<Person> Solve(IEnumerable<Person> persons)
    {
        return persons.Where((person, i) => person.Name.Length > i).ToList();
    }

    static void Main()
    {
        var person1 = new Person() { Name = "1" };
        var person2 = new Person() { Name = "2" };
        var person3 = new Person() { Name = "3" };
        var person4 = new Person() { Name = "4444" };
        var person5 = new Person() { Name = "555" };
        var persons = new List<Person>() { person1, person2, person3, person4, person5 };
        foreach (var person in Solve(persons))
        {
            Console.WriteLine(person.Name);
        }
    }
}
