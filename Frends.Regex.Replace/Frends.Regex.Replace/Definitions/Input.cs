using System.ComponentModel.DataAnnotations;

namespace Frends.Regex.Replace.Definitions
{
    /// <summary>
    /// Input parameters.
    /// </summary>
    public class Input
    {
        /// <summary>
        /// Text to be modified.
        /// </summary>
        /// <example>Example text.</example>
        [DisplayFormat(DataFormatString = "Text")]
        public string InputText { get; set; }

        /// <summary>
        /// Regular expression pattern.
        /// </summary>
        /// <example>abc*</example>
        [DisplayFormat(DataFormatString = "Text")]
        [Required]
        public string RegularExpression { get; set; } = " ";

        /// <summary>
        /// Text to replace regex matches with.
        /// </summary>
        /// <example>foo</example>
        [DisplayFormat(DataFormatString = "Text")]
        [Required]
        public string Replacement { get; set; } = " ";
    }
}
