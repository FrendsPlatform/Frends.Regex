using System;
using System.ComponentModel;
using Frends.Regex;

#pragma warning disable 1591

namespace Frends.Regex.Replace
{
    public static class Regex
    {
        private static void ValidateInput(ReplaceParameters replaceParams)
        {
            if (replaceParams == null)
            {
                throw new ArgumentNullException(nameof(replaceParams));
            }
            else
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