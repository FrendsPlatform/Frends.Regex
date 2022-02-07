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
        public void TestIsMatchThrowsOnNullParam()
        {
            Assert.Throws<ArgumentNullException>(() => { RegexIsMatch.IsMatch(null); }, "IsMatch() should throw ArgumentNullException when null parameters are passed.");

            Assert.Throws<ArgumentNullException>(() =>
            {
                RegexIsMatch.IsMatch(new MatchParameters
                {
                    InputText = "not empty",
                    RegularExpression = ""
                });
            });

            Assert.Throws<ArgumentNullException>(() =>
            {
                RegexIsMatch.IsMatch(new MatchParameters
                {
                    InputText = "",
                    RegularExpression = "not empty"
                });
            });
        }

        #endregion

        #region non-null param testing

        [Test]
        public void TestIsMatchDoesntThrowOnNonNullParam()
        {
            var matchP = new MatchParameters()
            {
                RegularExpression = "not empty",
                InputText = "not empty"
            };

            Assert.DoesNotThrow(() => { RegexIsMatch.IsMatch(matchP); });
        }

        #endregion

        #region work-as-intended testing

        [Test]
        public void TestIsMatchWorks()
        {
            var p = new MatchParameters
            {
                InputText = "{this ain't no thang}",
                RegularExpression = "^{(.*?)}$"
            };
            var result = RegexIsMatch.IsMatch(p);
            Assert.IsTrue(result.IsMatch);

            p = new MatchParameters
            {
                InputText = "sdfsdfsdf{this ain't no thang}",
                RegularExpression = "^{(.*?)}$"
            };
            result = RegexIsMatch.IsMatch(p);
            Assert.IsFalse(result.IsMatch);
        }

        #endregion
    }
}
 