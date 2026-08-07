namespace Frends.Regex.Replace.Definitions;

/// <summary>
/// Replace result.
/// </summary>
public class Result
{
    /// <summary>
    /// Indicates whether the task completed successfully.
    /// </summary>
    /// <example>true</example>
    public bool Success { get; private set; }

    /// <summary>
    /// Contains Regex-replaced input.
    /// </summary>
    /// <example>Replaced text.</example>
    public string ReplacedText { get; private set; }

    /// <summary>
    /// Error information, populated when Success is false.
    /// </summary>
    /// <example>null</example>
    public Error Error { get; private set; }

    internal Result(string replacedText)
    {
        Success = true;
        ReplacedText = replacedText;
    }

    internal Result(Error error)
    {
        Success = false;
        Error = error;
    }
}
