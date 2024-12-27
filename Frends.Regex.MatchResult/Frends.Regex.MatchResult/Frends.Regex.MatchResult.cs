namespace Frends.Regex.MatchResult;

using System;
using System.ComponentModel;
using System.Threading;
using Frends.Regex.MatchResult.Definitions;

/// <summary>
/// Regex MatchResult Task.
/// </summary>
public static class Regex
{
    /// <summary>
    /// Frends Task for getting full result of a match.
    /// [Documentation](https://tasks.frends.com/tasks/frends-tasks/Frends.Regex.MatchResult).
    /// </summary>
    /// <param name="input">What to repeat.</param>
    /// <param name="cancellationToken">Cancellation token given by Frends.</param>
    /// <returns>Object { string Output }.</returns>
    public static Result MatchResult([PropertyTab] Input input, CancellationToken cancellationToken)
    {
        if (input == null) throw new ArgumentNullException(nameof(input));
        if (string.IsNullOrEmpty(input.InputText)) throw new ArgumentNullException(null, nameof(input.InputText));
        if (string.IsNullOrEmpty(input.RegularExpression)) throw new ArgumentNullException(null, nameof(input.RegularExpression));

        var regex = new System.Text.RegularExpressions.Regex(input.RegularExpression);
        var matches = regex.Matches(input.InputText);
        return new Result(matches);
    }
}
