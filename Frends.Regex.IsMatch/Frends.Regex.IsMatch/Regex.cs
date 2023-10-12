using Frends.Regex.IsMatch.Definitions;
using System;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;

namespace Frends.Regex.IsMatch;

/// <summary>
/// Regex IsMatch Task.
/// </summary>
public static class Regex
{
    /// <summary>
    /// Frends Task for checking if a string matches a certain Regex pattern.
    /// [Documentation](https://tasks.frends.com/tasks/frends-tasks/Frends.Regex.IsMatch)
    /// </summary>
    /// <param name="input">Input parameters.</param>
    /// <returns>Object { bool IsMatch, string Data }</returns>
    public static Result IsMatch([PropertyTab] Input input)
    {
        if (input == null) throw new ArgumentNullException(nameof(input));
        else
        {
            if (string.IsNullOrEmpty(input.InputText)) throw new ArgumentNullException(nameof(input.InputText));
            if (string.IsNullOrEmpty(input.RegularExpression)) throw new ArgumentNullException(nameof(input.RegularExpression));
        }

        var regex = new System.Text.RegularExpressions.Regex(input.RegularExpression);
        var isMatch = regex.IsMatch(input.InputText);
        var matches = regex.Matches(input.InputText);
        var data = isMatch ? string.Join(", ", matches.Cast<Match>().Select(m => m.Value)) : null;
        return new Result(isMatch, data);
    }
}