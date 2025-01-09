namespace Frends.Regex.Match.Definitions;

using System.Collections.Generic;

using System.Text.RegularExpressions;

/// <summary>
/// Result.
/// </summary>
public class Result
{
    internal Result(List<RegexMatch> matches)
    {
        Matches = matches;
    }

    /// <summary>
    /// Match result.
    /// </summary>
    public List<RegexMatch> Matches { get; private set; }
}