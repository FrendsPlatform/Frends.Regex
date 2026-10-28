namespace Frends.Regex.Match.Definitions;

using System.Collections.Generic;

/// <summary>
/// Result.
/// </summary>
public class Result
{
    /// <summary>
    /// Indicates if the task completed successfully.
    /// </summary>
    /// <example>true</example>
    public bool Success { get; set; }

    /// <summary>
    /// Match result.
    /// </summary>
    /// <example>[ { Index = 0, Value = "foo", GroupName = "0", Length = 3 } ]</example>
    public List<RegexMatch> Matches { get; set; }

    /// <summary>
    /// Error that occurred during task execution.
    /// </summary>
    /// <example>object { string Message, Exception AdditionalInfo }</example>
    public Error Error { get; set; }
}
