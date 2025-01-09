namespace Frends.Regex.Match.Definitions;

using System.ComponentModel.DataAnnotations;

/// <summary>
/// Input parameters.
/// </summary>
public class Input
{
    /// <summary>
    /// Text to be examined.
    /// </summary>
    /// <example>Example text.</example>
    [DisplayFormat(DataFormatString = "Text")]
    public string InputText { get; set; }

    /// <summary>
    /// Regular expression pattern.
    /// </summary>
    /// <example>abc*</example>
    [DisplayFormat(DataFormatString = "Text")]
    [Required]
    public string RegularExpression { get; set; } = " ";
}