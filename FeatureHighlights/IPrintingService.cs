namespace FeatureHighlights;

public interface IPrintingService
{
    /// <summary>
    /// Prints a single string.
    /// </summary>
    /// <param name="text">The string to be printed.</param>
    void Print(string text);

    /// <summary>
    /// Prints any number of strings, separated by a given string.
    /// </summary>
    /// <param name="separator">The string to print between each input.</param>
    /// <param name="text">The instances of text to be printed.</param>
    void PrintMany(string separator, params string[] text);

    /// <summary>
    /// Prints identifying information for this printing service.
    /// </summary>
    void PrintCallsign();
}
