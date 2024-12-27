namespace Frends.Regex.MatchResult.Tests;

using System;
using Frends.Regex.MatchResult.Definitions;
using NUnit.Framework;

[TestFixture]
internal class UnitTests
{
    [Test]
    public void TestMatchResultThrowsOnNullParam()
    {
        Assert.Throws<ArgumentNullException>(() => { Regex.MatchResult(null, default); });

        Assert.Throws<ArgumentNullException>(() =>
        {
            Regex.MatchResult(
                new Input { InputText = "not empty", RegularExpression = string.Empty }, default);
        });

        Assert.Throws<ArgumentNullException>(() =>
        {
            Regex.MatchResult(
                new Input { InputText = string.Empty, RegularExpression = "not empty" }, default);
        });
    }

    [Test]
    public void TestIsMatchDoesntThrowOnNonNullParam()
    {
        var matchInput = new Input { InputText = "not empty", RegularExpression = "not empty" };
        Assert.DoesNotThrow(() => { Regex.MatchResult(matchInput, default); });
    }

    [Test]
    public void TestIsMatchWorks()
    {
        var p = new Input
        {
            InputText = "{this ain't no thang}",
            RegularExpression = "^{(.*?)}$",
        };
        var result = Regex.MatchResult(p, default);
        Assert.AreEqual(1, result.Matches.Count);

        p = new Input
        {
            InputText = "sdfsdfsdf{this ain't no thang}",
            RegularExpression = "^{(.*?)}$",
        };
        result = Regex.MatchResult(p, default);
        Assert.AreEqual(0, result.Matches.Count);
    }
}
