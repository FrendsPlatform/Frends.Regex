using Frends.Regex.IsMatch.Definitions;
using NUnit.Framework;
using System;
using System.Threading;

namespace Frends.Regex.IsMatch.Tests;

[TestFixture]
class Tests
{
    private static readonly Options DefaultOptions = new Options();

    [Test]
    public void TestIsMatchThrowsOnNullParam()
    {
        Assert.Throws<ArgumentNullException>(() => { Regex.IsMatch(null, DefaultOptions, CancellationToken.None); }, "IsMatch() should throw ArgumentNullException when null parameters are passed.");

        Assert.Throws<ArgumentNullException>(() =>
        {
            Regex.IsMatch(new Input
            {
                InputText = "not empty",
                RegularExpression = ""
            }, DefaultOptions, CancellationToken.None);
        });

        Assert.Throws<ArgumentNullException>(() =>
        {
            Regex.IsMatch(new Input
            {
                InputText = "",
                RegularExpression = "not empty"
            }, DefaultOptions, CancellationToken.None);
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

        Assert.DoesNotThrow(() => { Regex.IsMatch(matchP, DefaultOptions, CancellationToken.None); });
    }

    [Test]
    public void TestIsMatchWorks()
    {
        var p = new Input
        {
            InputText = "{this ain't no thang}",
            RegularExpression = "^{(.*?)}$"
        };
        var result = Regex.IsMatch(p, DefaultOptions, CancellationToken.None);
        Assert.IsTrue(result.Success);
        Assert.IsTrue(result.IsMatch);
        Assert.AreEqual("{this ain't no thang}", result.Data);

        p = new Input
        {
            InputText = "sdfsdfsdf{this ain't no thang}",
            RegularExpression = "^{(.*?)}$"
        };
        result = Regex.IsMatch(p, DefaultOptions, CancellationToken.None);
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
        }, options, CancellationToken.None);

        Assert.IsFalse(result.Success);
        Assert.IsNotNull(result.Error);
        Assert.IsNotNull(result.Error.Message);
    }
}