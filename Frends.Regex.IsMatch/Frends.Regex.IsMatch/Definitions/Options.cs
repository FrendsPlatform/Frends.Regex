using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Frends.Regex.IsMatch.Definitions;

/// <summary>
/// Options for the IsMatch task.
/// </summary>
public class Options
{
    /// <summary>
    /// Whether to throw an exception on failure.
    /// When false, errors are returned in the Result object instead.
    /// </summary>
    /// <example>true</example>
    [DefaultValue(true)]
    public bool ThrowErrorOnFailure { get; set; } = true;

    /// <summary>
    /// Custom error message used when ThrowErrorOnFailure is enabled or an error result is returned.
    /// Leave empty to use the original exception message.
    /// </summary>
    /// <example>Regex match failed</example>
    [DisplayFormat(DataFormatString = "Text")]
    [DefaultValue("")]
    public string ErrorMessageOnFailure { get; set; } = string.Empty;
}
