using Frends.Regex.Replace.Definitions;
using NUnit.Framework;
using System;
using System.Threading;

namespace Frends.Regex.Replace.Tests;

[TestFixture]
internal class ErrorHandlerTests
{
    private const string CustomErrorMessage = "CustomErrorMessage";

    private static Input InvalidInput => new Input
    {
        InputText = "test",
        Replacement = "foo",
        RegularExpression = "[invalid"
    };

    [Test]
    public void Should_Throw_Error_When_ThrowErrorOnFailure_Is_True()
    {
        var options = new Options { ThrowErrorOnFailure = true };
        var ex = Assert.Throws<Exception>((TestDelegate)(() =>
            Regex.Replace(InvalidInput, options, CancellationToken.None)));
        Assert.That(ex, Is.Not.Null);
        Assert.That(ex.Message, Is.Not.Null.And.Not.Empty);
    }

    [Test]
    public void Should_Return_Failed_Result_When_ThrowErrorOnFailure_Is_False()
    {
        var options = new Options { ThrowErrorOnFailure = false };
        var result = Regex.Replace(InvalidInput, options, CancellationToken.None);
        Assert.That(result.Success, Is.False);
        Assert.That(result.Error, Is.Not.Null);
        Assert.That(result.Error.Message, Is.Not.Null.And.Not.Empty);
    }

    [Test]
    public void Should_Use_Custom_ErrorMessageOnFailure()
    {
        var options = new Options { ThrowErrorOnFailure = true, ErrorMessageOnFailure = CustomErrorMessage };
        var ex = Assert.Throws<Exception>((TestDelegate)(() =>
            Regex.Replace(InvalidInput, options, CancellationToken.None)));
        Assert.That(ex, Is.Not.Null);
        Assert.That(ex.Message, Does.Contain(CustomErrorMessage));
    }
}
