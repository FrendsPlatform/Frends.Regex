namespace Frends.Regex.Match.Tests;

using Frends.Regex.Match.Definitions;

internal abstract class TestBase
{
    protected static Input DefaultInput() => new() { InputText = "foobar", RegularExpression = "f" };

    protected static Options DefaultOptions() => new();
}
