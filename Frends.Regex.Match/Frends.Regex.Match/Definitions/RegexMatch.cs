namespace Frends.Regex.Match.Definitions;

/// <summary>
/// Returned type.
/// </summary>
public class RegexMatch
{
    /// <summary>
    /// The zero-based starting position in the original string where the captured substring is found.
    /// </summary>
    /// <example>4</example>
    public int Index { get; set; }

    /// <summary>
    /// The substring that is captured by the match.
    /// </summary>
    /// <example>foo</example>
    public string Value { get; set; }

    /// <summary>
    /// The name of the capturing group represented by the current instance.
    /// </summary>
    /// <example>0</example>
    public string GroupName { get; set; }

    /// <summary>
    /// The length of the captured substring.
    /// </summary>
    /// <example>3</example>
    public int Length { get; set; }
}