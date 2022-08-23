namespace Frends.Regex.IsMatch.Definitions;

/// <summary>
/// Result.
/// </summary>
public class Result
{
    /// <summary>
    /// IsMatch result.
    /// </summary>
    public bool IsMatch { get; private set; }

    internal Result(bool isMatch)
    {
        IsMatch = isMatch;
    }
}
