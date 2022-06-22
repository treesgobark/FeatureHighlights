namespace FeatureHighlights;

public class PersonClass
{
    public PersonClass(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public string Name { get; set; }
    public int Age { get; set; }

    public override string ToString()
    {
        return $"Name: { Name }" +
            $"\nAge: { Age }";
    }
}

public struct PersonStruct
{
    public PersonStruct(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public string Name { get; set; }
    public int Age { get; set; }

    public override string ToString()
    {
        return $"Name: { Name }" +
            $"\nAge: { Age }";
    }
}
