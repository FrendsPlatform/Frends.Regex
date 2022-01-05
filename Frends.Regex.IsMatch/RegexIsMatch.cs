using System;
using System.ComponentModel;

#pragma warning disable 1591

namespace Frends.Regex
{
    public static class RegexIsMatch
    {
        private static void ValidateInput(object input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            else if (input is MatchParameters matchParam)
            {
                if (string.IsNullOrEmpty(matchParam.InputText))
                {
                    throw new ArgumentNullException(nameof(matchParam.InputText));
                }
                if (string.IsNullOrEmpty(matchParam.RegularExpression))
                {
                    throw new ArgumentNullException(nameof(matchParam.RegularExpression));
                }
            } else {
                throw new ArgumentException("Invalid type.", nameof(input));
            }
        }

        /// <summary>
        /// Reads text and returns a boolean indicating if the text matches 
        /// with specified regular expression.
        /// </summary>
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