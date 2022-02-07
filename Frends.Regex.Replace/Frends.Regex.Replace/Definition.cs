#pragma warning disable 1591

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Frends.Regex
{
    /// <summary>
    /// Parameters class usually contains parameters that are required.
    /// </summary>
    public class ReplaceParameters
    {
        /// <summary>
        /// Text to be modified.
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

        /// <summary>
        /// Text to replace regex matches with.
        /// </summary>
        [DisplayFormat(DataFormatString = "Text")]
        [DefaultValue(" ")]
        [Required]
        public string Replacement { get; set; }
    }

    /// <summary>
    /// Represents a result of Regex replacement task.
    /// </summary>
    public class ReplaceResult
    {
        /// <summary>
        /// Contains Regex-replaced input.
        /// </summary>
        [DisplayFormat(DataFormatString = "Text")]
        public string ReplacedText;
    }
}
