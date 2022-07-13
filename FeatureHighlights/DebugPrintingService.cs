using System.Diagnostics;
using System.Text;

namespace FeatureHighlights;

public class DebugPrintingService : IPrintingService
{
    public DebugPrintingService()
    {
        Guid = Guid.NewGuid();
    }

    public Guid Guid { get; }

    public void Print(string text)
    {
        Debug.WriteLine(text);
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
        Debug.WriteLine(sb.ToString());
    }

    public void PrintCallsign()
    {
        Debug.WriteLine($"Printed by: { GetType().Name }: { Guid }");
    }
}