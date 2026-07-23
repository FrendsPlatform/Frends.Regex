namespace Frends.Regex.IsMatch.Definitions;

/// <summary>
/// Result.
/// </summary>
public class Result
{
    /// <summary>
    /// Indicates whether the task completed successfully.
    /// </summary>
    /// <example>true</example>
    public bool Success { get; private set; }

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

    /// <summary>
    /// Error information, populated when Success is false.
    /// </summary>
    /// <example>null</example>
    public Error Error { get; private set; }

    internal Result(bool isMatch, string data)
    {
        Success = true;
        IsMatch = isMatch;
        Data = data;
    }

    internal Result(Error error)
    {
        Success = false;
        Error = error;
    }
}
