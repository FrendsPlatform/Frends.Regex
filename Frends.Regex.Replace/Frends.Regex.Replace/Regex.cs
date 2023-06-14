using Frends.Regex.Replace.Definitions;
using System;
using System.ComponentModel;

namespace Frends.Regex.Replace;

/// <summary>
/// Regex Replace task.
/// </summary>
public static class Regex
{
    /// <summary>
    /// Reads text and replaces substring(s) matching with specified regular expression.
    /// [Documentation](https://tasks.frends.com/tasks/frends-tasks/Frends.Regex.Replace)
    /// </summary>
    /// <returns>string ReplacedText</returns>
    public static Result Replace([PropertyTab] Input input)
    {
        if (input == null) throw new ArgumentNullException(nameof(input));
        else
        {
            if (string.IsNullOrEmpty(input.InputText))
                throw new ArgumentNullException(nameof(input.InputText));
            if (string.IsNullOrEmpty(input.Replacement))
                throw new ArgumentNullException(nameof(input.Replacement));
            if (string.IsNullOrEmpty(input.RegularExpression))
                throw new ArgumentNullException(nameof(input.RegularExpression));
        }

        var regex = new System.Text.RegularExpressions.Regex(input.RegularExpression);
        string resultValue = regex.Replace(input.InputText, input.Replacement);
        return new Result(resultValue);
    }
}