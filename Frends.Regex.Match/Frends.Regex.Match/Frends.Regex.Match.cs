namespace Frends.Regex.Match;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using Frends.Regex.Match.Definitions;

/// <summary>
/// Main class of the Task.
/// </summary>
public static class Regex
{
    /// <summary>
    /// Frends Task will return full info for match result.
    /// [Documentation](https://tasks.frends.com/tasks/frends-tasks/Frends.Regex.MatchResult).
    /// </summary>
    /// <param name="input">Input parameters.</param>
    /// <param name="cancellationToken">Cancellation token given by Frends.</param>
    /// <returns>RegexMatch[] matches</returns>
    public static Result Match([PropertyTab] Input input, [PropertyTab] CancellationToken cancellationToken)
    {
        if (input == null) throw new ArgumentNullException(nameof(input));
        if (string.IsNullOrEmpty(input.InputText)) throw new ArgumentNullException(null, nameof(input.InputText));
        if (string.IsNullOrEmpty(input.RegularExpression)) throw new ArgumentNullException(null, nameof(input.RegularExpression));

        var regex = new System.Text.RegularExpressions.Regex(input.RegularExpression);
        MatchCollection matches = regex.Matches(input.InputText);
        List<RegexMatch> regexMatches = new();

        foreach (Match match in matches)
        {
            regexMatches.Add(new RegexMatch
            {
                Index = match.Index,
                GroupName = match.Name,
                Value = match.Value,
                Length = match.Length,
            });
        }

        return new Result(regexMatches);
    }
}
