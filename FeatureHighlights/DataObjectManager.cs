namespace FeatureHighlights;

public class DataObject
{
    public Guid Uid { get; } = Guid.NewGuid();
}

public class DataObjectManager<T> where T : DataObject, new()
{
    protected List<T> ObjectList { get; } = new();

    public Guid Create(Func<T, T>? mutatorFunc = null)
    {
        T obj = new();
        if (mutatorFunc != null)
        {
            obj = mutatorFunc(obj);
        }
        ObjectList.Add(obj);
        return obj.Uid;
    }

    public override string ToString()
    {
        string?[] strings = ObjectList.Select(obj => obj.ToString()).ToArray();
        return $"{{{ string.Join(", ", strings) }}}";
    }
}

public class Person : DataObject
{
    public string Name { get; set; } = "";
    public int Age { get; set; }

    public override string ToString()
    {
        return $"({ Name }, { Age })";
    }
}
