public class CustomAttribute : Attribute
{
    public CustomAttribute(String author, Int32 number, String description, params String[] reviewers)
    {
        this.author = author;
        this.number = number;
        this.description = description;
        this.reviewers = reviewers;
    }

    public String author;
    public Int32 number;
    public String description;
    public String[] reviewers;
}

[Custom("Joe", 2, "Class to work with health data.", "Arnold", "Bernard")]
public class HealthScore
{
    [Custom("Andrew", 3, "Method to collect health data.", "Sam", "Alex")]
    public static long CalcScoreData()
    {
        return 0;
    }

    public static long Calc()
    {
        return 0;
    }
}

class Task2
{
    static void Main(String[] args)
    {
        var type = typeof(HealthScore);
        foreach (var attribute in type.GetCustomAttributes(false).Concat(type.GetMethods().SelectMany((method) => method.GetCustomAttributes(false))))
        {
            if (attribute is CustomAttribute)
            {
                var customAttribute = (CustomAttribute)attribute;
                Console.WriteLine(customAttribute.author);
                Console.WriteLine(customAttribute.number);
                Console.WriteLine(customAttribute.description);
                foreach (var reviewer in customAttribute.reviewers)
                {
                    Console.WriteLine(reviewer);
                }
            }
        }

    }
}
