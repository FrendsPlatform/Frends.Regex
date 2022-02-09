using System;
using System.ComponentModel;

#pragma warning disable 1591

namespace Frends.Regex.IsMatch
{
    public static class Regex
    {
        private static void ValidateInput(MatchParameters matchParam)
        {
            if (matchParam == null)
            {
                throw new ArgumentNullException(nameof(matchParam));
            }
            else
            {
                if (string.IsNullOrEmpty(matchParam.InputText))
                {
                    throw new ArgumentNullException(nameof(matchParam.InputText));
                }
                if (string.IsNullOrEmpty(matchParam.RegularExpression))
                {
                    throw new ArgumentNullException(nameof(matchParam.RegularExpression));
                }
            }
        }

        /// <summary>
        /// Reads text and returns a boolean indicating if the text matches 
        /// with specified regular expression.
        /// [Documentation](https://github.com/FrendsPlatform/Frends.Regex/tree/main/Frends.Regex.IsMatch)
        /// </summary>
        /// <seealso cref=""/>
        /// <returns>{bool IsMatch}</returns>
        public static IsMatchResult IsMatch([PropertyTab] MatchParameters input)
        {
            ValidateInput(input);

            var regex = new System.Text.RegularExpressions.Regex(input.RegularExpression);

            return new IsMatchResult
            {
                IsMatch = regex.IsMatch(input.InputText)
            };
        }

    }
}