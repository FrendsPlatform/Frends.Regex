using Frends.Regex.IsMatch.Definitions;
using System;
using System.ComponentModel;

namespace Frends.Regex.IsMatch;

/// <summary>
/// Regex IsMatch task.
/// </summary>
public static class Regex
{
    /// <summary>
    /// Reads text and returns a boolean indicating if the text matches with specified regular expression.
    /// [Documentation](https://tasks.frends.com/tasks/frends-tasks/Frends.Regex.IsMatch)
    /// </summary>
    /// <returns>{bool IsMatch}</returns>
    public static Result IsMatch([PropertyTab] Input input)
    {
        if (input == null) throw new ArgumentNullException(nameof(input));
        else
        {
            if (string.IsNullOrEmpty(input.InputText)) throw new ArgumentNullException(nameof(input.InputText));
            if (string.IsNullOrEmpty(input.RegularExpression)) throw new ArgumentNullException(nameof(input.RegularExpression));
        }

        var regex = new System.Text.RegularExpressions.Regex(input.RegularExpression);
        return new Result(regex.IsMatch(input.InputText));
    }
}