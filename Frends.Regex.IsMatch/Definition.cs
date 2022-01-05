#pragma warning disable 1591

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Frends.Regex
{
    public class MatchParameters
    {
        /// <summary>
        /// Text to be examined.
        /// </summary>
        [DisplayFormat(DataFormatString = "Text")]
        [DefaultValue("Lorem ipsum dolor sit amet.")]
        public string InputText { get; set; }

        /// <summary>
        /// Regular expression pattern.
        /// </summary>
        [DisplayFormat(DataFormatString = "Text")]
        [DefaultValue(" ")]
        [Required]
        public string RegularExpression { get; set; }
    }

    public class IsMatchResult
    {
        public bool IsMatch { get; set; }
    }
}
