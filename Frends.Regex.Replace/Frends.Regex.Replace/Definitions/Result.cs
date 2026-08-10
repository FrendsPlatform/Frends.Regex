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
    public bool Success { get; set; }

    /// <summary>
    /// Contains Regex-replaced input.
    /// </summary>
    /// <example>Replaced text.</example>
    public string ReplacedText { get; set; }

    /// <summary>
    /// Error information, populated when Success is false.
    /// </summary>
    /// <example>null</example>
    public Error Error { get; set; }
}
