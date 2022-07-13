using FeatureHighlights;
using Microsoft.Extensions.DependencyInjection;

//Demo1();
//Demo2();
//Demo3();
//Demo4();
//Demo5();
//Demo6();

static void Demo1()
{
    ServiceCollection serviceCollection = new();

    serviceCollection.AddSingleton<ConsolePrintingService>();
    serviceCollection.AddSingleton<DebugPrintingService>();

    ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

    ConsolePrintingService console = serviceProvider.GetService<ConsolePrintingService>()!;
    DebugPrintingService debug = serviceProvider.GetService<DebugPrintingService>()!;

    console.Print("This is a console test print in Demo1");
    console.PrintCallsign();

    debug.Print("This is a debug test print in Demo1");
    debug.PrintCallsign();
}

static void Demo2()
{
    ServiceCollection serviceCollection = new();

    serviceCollection.AddSingleton<IPrintingService, ConsolePrintingService>();
    serviceCollection.AddSingleton<IPrintingService, DebugPrintingService>();

    ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

    IPrintingService printingService = serviceProvider.GetService<IPrintingService>()!;

    printingService.Print("This is test print 1 in Demo2");
    printingService.PrintCallsign();

    //**************************************************************************************

    ServiceCollection serviceCollection2 = new();

    serviceCollection2.AddSingleton<IPrintingService, DebugPrintingService>();
    serviceCollection2.AddSingleton<IPrintingService, ConsolePrintingService>();

    ServiceProvider serviceProvider2 = serviceCollection2.BuildServiceProvider();

    IPrintingService printingService2 = serviceProvider2.GetService<IPrintingService>()!;

    printingService2.Print("This is test print 2 in Demo2");
    printingService2.PrintCallsign();
}

static void Demo3()
{
    ServiceCollection serviceCollection = new();

    serviceCollection.AddSingleton<ConsolePrintingService>();

    serviceCollection.AddSingleton<IPrintingService, ConsolePrintingService>(x => x.GetService<ConsolePrintingService>());
    serviceCollection.AddSingleton<IPrintingService, DebugPrintingService>();

    ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

    IEnumerable<IPrintingService> printingServices = serviceProvider.GetService<IEnumerable<IPrintingService>>()!;
    var console = serviceProvider.GetService<ConsolePrintingService>()!;

    int count = 0;

    console.Print($"This is test print { count } in Demo3");
    console.PrintCallsign();
    foreach (var printingService in printingServices)
    {
        printingService.Print($"This is test print { ++count } in Demo3");
        printingService.PrintCallsign();
    }
}

static void Demo4()
{
    ServiceCollection serviceCollection = new();

    serviceCollection.AddSingleton<IPrintingService, DebugPrintingService>();
    serviceCollection.AddSingleton<IPrintingService, ConsolePrintingService>();

    serviceCollection.AddSingleton<IDataAnalyzer<Person>, PersonAnalyzer>();

    ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

    IDataAnalyzer<Person> personAnalyzer = serviceProvider.GetService<IDataAnalyzer<Person>>()!;

    Person joe = new Person("Joe", 68);
    Person john = new Person("John", 70);

    personAnalyzer.Analyze(joe);
    personAnalyzer.Analyze(john);
}

static void Demo5()
{
    ServiceCollection serviceCollection = new();

    serviceCollection.AddSingleton<IPrintingService, ConsolePrintingService>();
    serviceCollection.AddSingleton<IPrintingService, DebugPrintingService>();

    serviceCollection.AddSingleton<IDataAnalyzer<Person>, PersonAnalyzer>();

    ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

    IDataAnalyzer<Person> personAnalyzer = serviceProvider.GetService<IDataAnalyzer<Person>>()!;

    Person joe = new Person("Joe", 68);
    Person john = new Person("John", 70);

    personAnalyzer.Analyze(joe);
    personAnalyzer.Analyze(john);
}

static void Demo6()
{
    ServiceCollection serviceCollection = new();

    serviceCollection.AddScoped<IPrintingService, ConsolePrintingService>();

    serviceCollection.AddScoped<IDataAnalyzer<Person>, PersonAnalyzer>();

    ServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

    IServiceScopeFactory scopeFactory = serviceProvider.GetService<IServiceScopeFactory>()!;

    using (IServiceScope scope1 = scopeFactory.CreateScope())
    {
        IDataAnalyzer<Person> personAnalyzer1 = scope1.ServiceProvider.GetService<IDataAnalyzer<Person>>()!;
        IDataAnalyzer<Person> personAnalyzer2 = scope1.ServiceProvider.GetService<IDataAnalyzer<Person>>()!;
        Person joe = new Person("Joe", 68);
        personAnalyzer1.Analyze(joe);
        personAnalyzer2.Analyze(joe);
    }

    using (IServiceScope scope2 = scopeFactory.CreateScope())
    {
        IDataAnalyzer<Person> personAnalyzer1 = scope2.ServiceProvider.GetService<IDataAnalyzer<Person>>()!;
        IDataAnalyzer<Person> personAnalyzer2 = scope2.ServiceProvider.GetService<IDataAnalyzer<Person>>()!;
        Person joe = new Person("Joe", 68);
        personAnalyzer1.Analyze(joe);
        personAnalyzer2.Analyze(joe);
    }
}

