namespace Frends.Regex.Match.Tests;

using System;
using System.Collections.Generic;
using FluentAssertions;
using Frends.Regex.Match.Definitions;
using NUnit.Framework;

[TestFixture]
internal class UnitTests
{
    [Test]
    public void MatchThrowsOnNullParam()
    {
        Assert.Throws<ArgumentNullException>(() => { Regex.Match(null, default); });

        Assert.Throws<ArgumentNullException>(() =>
        {
            Regex.Match(
                new Input { InputText = "not empty", RegularExpression = string.Empty }, default);
        });

        Assert.Throws<ArgumentNullException>(() =>
        {
            Regex.Match(
                new Input { InputText = string.Empty, RegularExpression = "not empty" }, default);
        });
    }

    [Test]
    public void MatchDoesntThrowOnNonNullParam()
    {
        var matchInput = new Input { InputText = "not empty", RegularExpression = "not empty" };
        Assert.DoesNotThrow(() => { Regex.Match(matchInput, default); });
    }

    [Test]
    public void MatchWorksWithEmptyResult()
    {
        List<RegexMatch> expectedResult = new();
        var p = new Input
        {
            InputText = "foobar",
            RegularExpression = "x",
        };
        var result = Regex.Match(p, default);
        result.Matches.Should().BeEquivalentTo(expectedResult);
    }

    [Test]
    public void MatchWorksWithSingleResult()
    {
        List<RegexMatch> expectedResult = new()
        {
            new() { Index = 0, Value = "f", GroupName = "0", Length = 1 },
        };
        var p = new Input
        {
            InputText = "foobar",
            RegularExpression = "f",
        };
        var result = Regex.Match(p, default);
        result.Matches.Should().BeEquivalentTo(expectedResult);
    }

    [Test]
    public void MatchWorksWithMultipleResults()
    {
        var p = new Input
        {
            InputText = "foobaro",
            RegularExpression = "(o|ar)(o)",
        };
        List<RegexMatch> expectedResult = new()
        {
            new() { Index = 1, Value = "oo", GroupName = "0", Length = 2 },
            new() { Index = 4, Value = "aro", GroupName = "0", Length = 3 },
        };

        var result = Regex.Match(p, default);
        result.Matches.Should().BeEquivalentTo(expectedResult);
    }
}
