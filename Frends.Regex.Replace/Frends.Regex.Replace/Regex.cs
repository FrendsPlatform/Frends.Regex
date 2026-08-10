using Frends.Regex.Replace.Definitions;
using Frends.Regex.Replace.Helpers;
using System;
using System.ComponentModel;
using System.Threading;

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
    /// <param name="input">Input parameters.</param>
    /// <param name="options">Options for error handling.</param>
    /// <param name="cancellationToken">Cancellation token given by Frends.</param>
    /// <returns>Object { bool Success, string ReplacedText, Error Error }</returns>
    public static Result Replace([PropertyTab] Input input, [PropertyTab] Options options, CancellationToken cancellationToken)
    {
        if (input == null) throw new ArgumentNullException(nameof(input));
        if (string.IsNullOrEmpty(input.InputText)) throw new ArgumentNullException(nameof(input.InputText));
        if (string.IsNullOrEmpty(input.Replacement)) throw new ArgumentNullException(nameof(input.Replacement));
        if (string.IsNullOrEmpty(input.RegularExpression)) throw new ArgumentNullException(nameof(input.RegularExpression));

        try
        {
            cancellationToken.ThrowIfCancellationRequested();

            var regex = new System.Text.RegularExpressions.Regex(input.RegularExpression);
            string resultValue = regex.Replace(input.InputText, input.Replacement);
            return new Result
            {
                Success = true,
                ReplacedText = resultValue,
            };
        }
        catch (Exception ex)
        {
            return ex.Handle(options);
        }
    }
}
