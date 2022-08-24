using Frends.Regex.IsMatch.Definitions;
using NUnit.Framework;
using System;

namespace Frends.Regex.IsMatch.Tests;

[TestFixture]
class Tests
{
    [Test]
    public void TestIsMatchThrowsOnNullParam()
    {
        Assert.Throws<ArgumentNullException>(() => { Regex.IsMatch(null); }, "IsMatch() should throw ArgumentNullException when null parameters are passed.");

        Assert.Throws<ArgumentNullException>(() =>
        {
            Regex.IsMatch(new Input
            {
                InputText = "not empty",
                RegularExpression = ""
            });
        });

        Assert.Throws<ArgumentNullException>(() =>
        {
            Regex.IsMatch(new Input
            {
                InputText = "",
                RegularExpression = "not empty"
            });
        });
    }

    [Test]
    public void TestIsMatchDoesntThrowOnNonNullParam()
    {
        var matchP = new Input
        {
            RegularExpression = "not empty",
            InputText = "not empty"
        };

        Assert.DoesNotThrow(() => { Regex.IsMatch(matchP); });
    }

    [Test]
    public void TestIsMatchWorks()
    {
        var p = new Input
        {
            InputText = "{this ain't no thang}",
            RegularExpression = "^{(.*?)}$"
        };
        var result = Regex.IsMatch(p);
        Assert.IsTrue(result.IsMatch);

        p = new Input
        {
            InputText = "sdfsdfsdf{this ain't no thang}",
            RegularExpression = "^{(.*?)}$"
        };
        result = Regex.IsMatch(p);
        Assert.IsFalse(result.IsMatch);
    }
}