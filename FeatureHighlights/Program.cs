using FeatureHighlights;
using Microsoft.Extensions.DependencyInjection;

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
