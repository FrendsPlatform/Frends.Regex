using Frends.Regex.IsMatch.Definitions;
using NUnit.Framework;
using System;

namespace Frends.Regex.IsMatch.Tests;

[TestFixture]
class Tests
{
    private static readonly Options DefaultOptions = new Options();

    [Test]
    public void TestIsMatchThrowsOnNullParam()
    {
        Assert.Throws<ArgumentNullException>(() => { Regex.IsMatch(null, DefaultOptions, default); }, "IsMatch() should throw ArgumentNullException when null parameters are passed.");

        Assert.Throws<ArgumentNullException>(() =>
        {
            Regex.IsMatch(new Input
            {
                InputText = "not empty",
                RegularExpression = ""
            }, DefaultOptions, default);
        });

        Assert.Throws<ArgumentNullException>(() =>
        {
            Regex.IsMatch(new Input
            {
                InputText = "",
                RegularExpression = "not empty"
            }, DefaultOptions, default);
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

        Assert.DoesNotThrow(() => { Regex.IsMatch(matchP, DefaultOptions, default); });
    }

    [Test]
    public void TestIsMatchWorks()
    {
        var p = new Input
        {
            InputText = "{this ain't no thang}",
            RegularExpression = "^{(.*?)}$"
        };
        var result = Regex.IsMatch(p, DefaultOptions, default);
        Assert.IsTrue(result.Success);
        Assert.IsTrue(result.IsMatch);
        Assert.AreEqual("{this ain't no thang}", result.Data);

        p = new Input
        {
            InputText = "sdfsdfsdf{this ain't no thang}",
            RegularExpression = "^{(.*?)}$"
        };
        result = Regex.IsMatch(p, DefaultOptions, default);
        Assert.IsTrue(result.Success);
        Assert.IsFalse(result.IsMatch);
        Assert.IsNull(result.Data);
    }

    [Test]
    public void TestIsMatchReturnsErrorWhenThrowErrorOnFailureIsFalse()
    {
        var options = new Options { ThrowErrorOnFailure = false };
        var result = Regex.IsMatch(new Input
        {
            InputText = "test",
            RegularExpression = "[invalid"
        }, options, default);

        Assert.IsFalse(result.Success);
        Assert.IsNotNull(result.Error);
        Assert.IsNotNull(result.Error.Message);
    }
}