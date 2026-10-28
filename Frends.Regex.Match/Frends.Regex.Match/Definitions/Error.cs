using System;

namespace Frends.Regex.Match.Definitions;

/// <summary>
/// Error that occurred during the task.
/// </summary>
public class Error
{
    /// <summary>
    /// Summary of the error.
    /// </summary>
    /// <example>Invalid regular expression pattern.</example>
    public string Message { get; set; }

    /// <summary>
    /// Additional information about the error.
    /// </summary>
    /// <example>System.ArgumentException: Invalid pattern</example>
    public Exception AdditionalInfo { get; set; }
}
