using System;
using System.ComponentModel;
using Frends.Regex;

#pragma warning disable 1591

namespace Frends.Regex
{
    public static class RegexReplace
    {
        private static void ValidateInput(object input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }
            else if (input is ReplaceParameters replaceParams)
            {
                if (string.IsNullOrEmpty(replaceParams.InputText))
                {
                    throw new ArgumentNullException(nameof(replaceParams.InputText));
                }
                if (string.IsNullOrEmpty(replaceParams.Replacement))
                {
                    throw new ArgumentNullException(nameof(replaceParams.Replacement));
                }
                if (string.IsNullOrEmpty(replaceParams.RegularExpression))
                {
                    throw new ArgumentNullException(nameof(replaceParams.RegularExpression));
                }
            } else {
                throw new ArgumentException("Invalid type.", nameof(input));
            }
        }

        /// <summary>
        /// Reads text and replaces substring(s) matching with specified regular expression.
        /// </summary>
        /// <returns>{string ReplacedText}</returns>
        public static ReplaceResult Replace([PropertyTab] ReplaceParameters input)
        {
            ValidateInput(input);

            var regex = new System.Text.RegularExpressions.Regex(input.RegularExpression);

            string resultValue = regex.Replace(input.InputText, input.Replacement);

            var output = new ReplaceResult
            {
                ReplacedText = resultValue
            };

            return output;
        }
    }
}