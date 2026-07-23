using System;

namespace Frends.Regex.IsMatch.Definitions;

/// <summary>
/// Error information returned when the task fails and ThrowErrorOnFailure is false.
/// </summary>
public class Error
{
    /// <summary>
    /// Error message.
    /// </summary>
    /// <example>An error occurred.</example>
    public string Message { get; set; }

    /// <summary>
    /// The exception that caused the error.
    /// </summary>
    public Exception AdditionalInfo { get; set; }
}
