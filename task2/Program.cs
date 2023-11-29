using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

[Serializable]
class Group
{
    public decimal GroupId { get; set; }
    public string Name { get; set; }
    public List<Student> Students { get; set; }
    // no need to serialize this
    [field: NonSerialized]
    public int StudentsCount { get; set; }

    [OnDeserialized]
    private void OnDeserialized(StreamingContext context)
    {
        StudentsCount = Students.Count;
    }
}

[Serializable]
class Student
{
    public decimal StudentId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public Group Group { get; set; }
}

class Task2
{
    static void Main(String[] args)
    {
        var student1 = new Student { StudentId = 1, FirstName = "A", LastName = "A", Age = 1, Group = null };
        var student2 = new Student { StudentId = 2, FirstName = "B", LastName = "B", Age = 2, Group = null };
        var students = new List<Student>() { student1, student2 };
        var group = new Group { GroupId = 1, Name = "", Students = students, StudentsCount = students.Count };

        using (var stream = new MemoryStream())
        {
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, group);
            stream.Position = 0;
            var newGroup = (Group)formatter.Deserialize(stream);
            Console.WriteLine(newGroup.GroupId + " " + newGroup.Name);
            foreach (var student in newGroup.Students)
            {
                Console.WriteLine(student.StudentId + " " + student.FirstName + " " + student.LastName + " " + student.Age);
            }
            Console.WriteLine(newGroup.StudentsCount);
        }
    }
}
