namespace Frends.Regex.MatchResult.Definitions;
using System.Text.RegularExpressions;

/// <summary>
/// Result.
/// </summary>
public class Result(MatchCollection matches)
{
    /// <summary>
    /// Match result.
    /// </summary>
    public MatchCollection Matches { get; private set; } = matches;

}
