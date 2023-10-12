namespace Frends.Regex.IsMatch.Definitions;

/// <summary>
/// Result.
/// </summary>
public class Result
{
    /// <summary>
    /// IsMatch result.
    /// </summary>
    /// <example>true</example>
    public bool IsMatch { get; private set; }

    /// <summary>
    /// Matching values.
    /// </summary>
    /// <example>{foobar}</example>
    public string Data { get; private set; }

    internal Result(bool isMatch, string data)
    {
        IsMatch = isMatch;
        Data = data;
    }
}
