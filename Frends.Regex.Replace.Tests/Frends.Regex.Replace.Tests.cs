using NUnit.Framework;
using System;

namespace Frends.Regex.Replace
{
    [TestFixture]
    class Tests
    {
        private const string shortString = "Didst thou forge the magic Sampo, Forge the lid in many colors?";

        [Test]
        public void TestReplaceThrowsOnNullParam()
        {
            Assert.Throws<ArgumentNullException>(() => { RegexReplace.Replace(null); }, "Replace() should throw ArgumentNullException when null parameters are passed.");

            Assert.Throws<ArgumentNullException>(() => {
                RegexReplace.Replace(new ReplaceParameters
                {
                    InputText = "not empty",
                    RegularExpression = ""
                });
            });

            Assert.Throws<ArgumentNullException>(() => {
                RegexReplace.Replace(new ReplaceParameters
                {
                    InputText = "",
                    RegularExpression = "not empty"
                });
            });
        }

        [Test]
        public void TestReplaceDoesntThrowOnNonNullParam()
        {
            var replaceP = new ReplaceParameters()
            {
                InputText = "not empty",
                Replacement = "not empty",
                RegularExpression = "not empty"
            };

            Assert.DoesNotThrow(() => { RegexReplace.Replace(replaceP); });
        }

        [Test]
        public void TestReplacingWorks()
        {
            var original = shortString;
            var expected = shortString.Replace("Sampo", "Ky�sti");

            var p = new ReplaceParameters
            {
                Replacement = "Ky�sti",
                InputText = original,
                RegularExpression = "[S][a][m][p][o]"
            };

            var result = RegexReplace.Replace(p);

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.ReplacedText);
        } 
    }
}
