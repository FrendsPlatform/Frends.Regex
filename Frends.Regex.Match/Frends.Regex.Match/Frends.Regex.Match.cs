namespace Frends.Regex.Match;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using Frends.Regex.Match.Definitions;
using Frends.Regex.Match.Helpers;

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
    /// <param name="options">Additional parameters.</param>
    /// <param name="cancellationToken">Cancellation token given by Frends.</param>
    /// <returns>object { bool Success, List&lt;RegexMatch&gt; Matches, object Error { string Message, Exception AdditionalInfo } }</returns>
    public static Result Match([PropertyTab] Input input, [PropertyTab] Options options, CancellationToken cancellationToken)
    {
        try
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

            return new Result
            {
                Success = true,
                Matches = regexMatches,
                Error = null,
            };
        }
        catch (Exception ex)
        {
            return ex.Handle(options);
        }
    }
}
