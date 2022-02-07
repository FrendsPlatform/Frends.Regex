using NUnit.Framework;
using System;

namespace Frends.Regex.Tests
{
    [TestFixture]
    class Tests
    {
        private const string shortString = "Didst thou forge the magic Sampo, Forge the lid in many colors?";

        #region null param testing

        [Test]
        public void TestReplaceThrowsOnNullParam()
        {
            Assert.Throws<ArgumentNullException>(() => { RegexReplace.Replace(null); }, "Replace() should throw ArgumentNullException when null parameters are passed.");

            Assert.Throws<ArgumentNullException>(() =>
            {
                RegexReplace.Replace(new ReplaceParameters
                {
                    InputText = "not empty",
                    RegularExpression = ""
                });
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                RegexReplace.Replace(new ReplaceParameters
                {
                    InputText = "",
                    RegularExpression = "not empty"
                });
            });
        }

        #endregion

        #region non-null param testing

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

        #endregion

        #region work-as-intended testing

        [Test]
        public void TestReplacingWorks()
        {
            var original = shortString;
            var expected = shortString.Replace("Sampo", "Kyosti");

            var p = new ReplaceParameters
            {
                Replacement = "Kyosti",
                InputText = original,
                RegularExpression = "[S][a][m][p][o]"
            };

            var result = RegexReplace.Replace(p);

            Assert.IsNotNull(result);
            Assert.AreEqual(expected, result.ReplacedText);
        }
        #endregion
    }
}
