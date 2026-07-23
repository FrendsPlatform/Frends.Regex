using Frends.Regex.IsMatch.Definitions;
using System;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;

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
    /// <param name="options">Options for error handling.</param>
    /// <param name="cancellationToken">Cancellation token given by Frends.</param>
    /// <returns>Object { bool Success, bool IsMatch, string Data, Error Error }</returns>
    public static Result IsMatch([PropertyTab] Input input, [PropertyTab] Options options, CancellationToken cancellationToken)
    {
        if (input == null) throw new ArgumentNullException(nameof(input));
        if (string.IsNullOrEmpty(input.InputText)) throw new ArgumentNullException(nameof(input.InputText));
        if (string.IsNullOrEmpty(input.RegularExpression)) throw new ArgumentNullException(nameof(input.RegularExpression));

        try
        {
            cancellationToken.ThrowIfCancellationRequested();

            var regex = new System.Text.RegularExpressions.Regex(input.RegularExpression);
            var isMatch = regex.IsMatch(input.InputText);
            var matches = regex.Matches(input.InputText);
            var data = isMatch ? string.Join(", ", matches.Cast<Match>().Select(m => m.Value)) : null;
            return new Result(isMatch, data);
        }
        catch (Exception ex)
        {
            if (ex is OperationCanceledException) throw;

            if (options.ThrowErrorOnFailure)
            {
                var message = string.IsNullOrEmpty(options.ErrorMessageOnFailure)
                    ? ex.Message
                    : options.ErrorMessageOnFailure;
                throw new Exception(message, ex);
            }

            var errorMessage = string.IsNullOrEmpty(options.ErrorMessageOnFailure)
                ? ex.Message
                : $"{options.ErrorMessageOnFailure}: {ex.Message}";

            return new Result(new Error { Message = errorMessage, AdditionalInfo = ex });
        }
    }
}