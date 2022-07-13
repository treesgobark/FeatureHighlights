namespace FeatureHighlights;

public interface IDataAnalyzer<T>
{
    /// <summary>
    /// Prints various metrics for an instance of a data type.
    /// </summary>
    /// <param name="data">The data to be analyzed.</param>
    void Analyze(T data);
}
