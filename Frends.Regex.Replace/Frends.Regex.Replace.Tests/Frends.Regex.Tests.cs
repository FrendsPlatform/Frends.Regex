using Frends.Regex.Replace.Definitions;
using NUnit.Framework;
using System;
using System.Threading;

namespace Frends.Regex.Replace.Tests;

[TestFixture]
class Tests
{
    private const string shortString = "Didst thou forge the magic Sampo, Forge the lid in many colors?";
    private static readonly Options DefaultOptions = new Options();

    [Test]
    public void TestReplaceThrowsOnNullParam()
    {
        Assert.Throws<ArgumentNullException>(() => { Regex.Replace(null, DefaultOptions, default); }, "Replace() should throw ArgumentNullException when null parameters are passed.");

        Assert.Throws<ArgumentNullException>(() =>
        {
            Regex.Replace(new Input
            {
                InputText = "not empty",
                RegularExpression = ""
            }, DefaultOptions, default);
        });

        Assert.Throws<ArgumentNullException>(() =>
        {
            Regex.Replace(new Input
            {
                InputText = "",
                RegularExpression = "not empty"
            }, DefaultOptions, default);
        });
    }

    [Test]
    public void TestReplaceDoesntThrowOnNonNullParam()
    {
        var replaceP = new Input
        {
            InputText = "not empty",
            Replacement = "not empty",
            RegularExpression = "not empty"
        };

        Assert.DoesNotThrow(() => { Regex.Replace(replaceP, DefaultOptions, default); });
    }

    [Test]
    public void TestReplacingWorks()
    {
        var original = shortString;
        var expected = shortString.Replace("Sampo", "Kyosti");

        var p = new Input
        {
            Replacement = "Kyosti",
            InputText = original,
            RegularExpression = "[S][a][m][p][o]"
        };

        var result = Regex.Replace(p, DefaultOptions, default);

        Assert.IsNotNull(result);
        Assert.IsTrue(result.Success);
        Assert.AreEqual(expected, result.ReplacedText);
    }
}
