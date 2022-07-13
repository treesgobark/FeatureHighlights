﻿namespace FeatureHighlights;

public class Person
{
    public Person(string name, int age)
    {
        Id = Guid.NewGuid();
        Name = name;
        Age = age;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
}
