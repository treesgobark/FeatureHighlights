using FeatureHighlights;

DataObjectManager<Person> personManager = new();
List<Guid> myPersonIds = new();

Func<Person, Person> mutator1 = person =>
{
    person.Name = "John";
    person.Age = 24;
    return person;
};
myPersonIds.Add(personManager.Create(mutator1));

Func<Person, Person> mutator2 = person =>
{
    person.Name = "Jack";
    person.Age = 27;
    return person;
};
myPersonIds.Add(personManager.Create(mutator2));

Console.WriteLine(personManager);
myPersonIds.ForEach(id => Console.Write(id + " "));

Func<int, int> increment = num => num + 1;
Console.WriteLine(increment(5));
increment += increment;
Console.WriteLine(increment(5));
