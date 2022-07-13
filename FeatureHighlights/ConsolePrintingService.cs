using System.Text;

namespace FeatureHighlights;

public class ConsolePrintingService : IPrintingService
{
    public ConsolePrintingService()
    {
        Guid = Guid.NewGuid();
    }

    public Guid Guid { get; }

    public void Print(string text)
    {
        Console.WriteLine(text);
    }

    public void PrintMany(string separator, params string[] text)
    {
        StringBuilder sb = new();
        for (int i = 0; i < text.Length; i++)
        {
            sb.Append(text[i]);
            if (i < text.Length - 1)
            {
                sb.Append(separator);
            }
        }
        sb.AppendLine();
        sb.Append($"Printed by: { GetType().Name }: { Guid }");
        Console.WriteLine(sb.ToString());
    }
}