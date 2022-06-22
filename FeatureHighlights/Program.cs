using System;

namespace FeatureHighlights;

public class Program
{
    static void Main(string[] args)
    {
        PersonClass p1class = new PersonClass("Erik", 368_456);
        PersonStruct p1struct = new PersonStruct("Erik", 368_456);

        PersonClass p2class = new PersonClass("Mikhail", 0xFF);
        PersonStruct p2struct = new PersonStruct("Mikhail", 0xFF);

        PerformTest(p1class, p1struct);
        PerformTest(p2class, p2struct);

        Console.WriteLine('\n' + p1class.ToString());
        p1class = p2class;
        Console.WriteLine(p1class);
        p2class.Name = "Tim";
        Console.WriteLine(p1class);

        Console.WriteLine('\n' + p1struct.ToString());
        p1struct = p2struct;
        Console.WriteLine(p1struct);
        p2struct.Name = "Tim";
        Console.WriteLine(p1struct);
    }

    public static void PerformTest(PersonClass person1, PersonStruct person2)
    {
        Console.WriteLine("*********************** Begin Test ***********************");
        Console.WriteLine(person1);
        Console.WriteLine(person2);
        Console.WriteLine("\n******* Reference Type (class) Test ********");
        PerformTest(person1);
        Console.WriteLine("\n********* Value Type (struct) Test *********");
        PerformTest(person2);
        Console.WriteLine("************************ End Test ************************");
    }

    public static void PerformTest(PersonClass person)
    {
        Console.WriteLine("\nPass by value:");
        EditPerson(person);
        Console.WriteLine("Edited: " + person);

        ReplacePerson(person);
        Console.WriteLine("Replaced: " + person);

        Console.WriteLine("\nPass by reference:");
        EditPerson(ref person);
        Console.WriteLine("Edited: " + person);

        ReplacePerson(ref person);
        Console.WriteLine("Replaced: " + person);
    }

    public static void PerformTest(PersonStruct person)
    {
        Console.WriteLine("\nPass by value:");
        EditPerson(person);
        Console.WriteLine("Edited: " + person);

        ReplacePerson(person);
        Console.WriteLine("Replaced: " + person);

        Console.WriteLine("\nPass by refence:");
        EditPerson(ref person);
        Console.WriteLine("Edited: " + person);

        ReplacePerson(ref person);
        Console.WriteLine("Replaced: " + person);
    }

    public static void EditPerson(PersonClass person)
    {
        person.Name = person.Name.ToUpper();
        person.Age++;
    }

    public static void EditPerson(PersonStruct person)
    {
        person.Name = person.Name.ToUpper();
        person.Age++;
    }

    public static void ReplacePerson(PersonClass person)
    {
        person = new PersonClass("Bob", 0b1101001);
    }

    public static void ReplacePerson(PersonStruct person)
    {
        person = new PersonStruct("Bob", 0b1101001);
    }

    public static void EditPerson(ref PersonClass person)
    {
        person.Name = person.Name.ToUpper();
        person.Age++;
    }

    public static void EditPerson(ref PersonStruct person)
    {
        person.Name = person.Name.ToUpper();
        person.Age++;
    }

    public static void ReplacePerson(ref PersonClass person)
    {
        person = new PersonClass("Bob", 0b1101001);
    }

    public static void ReplacePerson(ref PersonStruct person)
    {
        person = new PersonStruct("Bob", 0b1101001);
    }
}
