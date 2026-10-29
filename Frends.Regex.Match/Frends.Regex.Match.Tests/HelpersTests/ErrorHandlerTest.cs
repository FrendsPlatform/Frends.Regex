namespace Frends.Regex.Match.Tests.HelpersTests;

using System;
using System.Threading;
using NUnit.Framework;

[TestFixture]
internal class ErrorHandlerTest : TestBase
{
    private const string CustomErrorMessage = "CustomErrorMessage";

    [Test]
    public void Should_Throw_Error_When_ThrowErrorOnFailure_Is_True()
    {
        var input = DefaultInput();
        input.RegularExpression = "(unclosed";
        var ex = Assert.Catch<Exception>(() => Regex.Match(input, DefaultOptions(), CancellationToken.None));
        Assert.That(ex, Is.Not.Null);
    }

    [Test]
    public void Should_Return_Failed_Result_When_ThrowErrorOnFailure_Is_False()
    {
        var input = DefaultInput();
        input.RegularExpression = "(unclosed";
        var options = DefaultOptions();
        options.ThrowErrorOnFailure = false;
        var result = Regex.Match(input, options, CancellationToken.None);
        Assert.That(result.Success, Is.False);
        Assert.That(result.Error, Is.Not.Null);
    }

    [Test]
    public void Should_Use_Custom_ErrorMessageOnFailure()
    {
        var input = DefaultInput();
        input.RegularExpression = "(unclosed";
        var options = DefaultOptions();
        options.ErrorMessageOnFailure = CustomErrorMessage;
        var ex = Assert.Throws<Exception>(() => Regex.Match(input, options, CancellationToken.None));
        Assert.That(ex.Message, Contains.Substring(CustomErrorMessage));
    }
}
