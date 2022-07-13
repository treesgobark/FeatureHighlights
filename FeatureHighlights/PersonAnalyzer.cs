namespace FeatureHighlights;

public class PersonAnalyzer : IDataAnalyzer<Person>
{
    private readonly IPrintingService _printingService;

    public PersonAnalyzer(IPrintingService printingService)
    {
        _printingService = printingService;
    }

    public void Analyze(Person data)
    {
        _printingService.Print("Person has 3 Properties:\n");
        _printingService.PrintMany("|", data.Id.ToString(), data.Name, data.Age.ToString());
    }
}
