﻿namespace Frends.Regex.Replace.Definitions;

/// <summary>
/// Replace result.
/// </summary>
public class Result
{
    /// <summary>
    /// Contains Regex-replaced input.
    /// </summary>
    public string ReplacedText { get; private set; }

    internal Result(string replacedText)
    {
        ReplacedText = replacedText;
    }
}
