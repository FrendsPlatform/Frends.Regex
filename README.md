# Frends.Regex

Frends tasks for regular expressions

[![Actions Status](https://github.com/FrendsPlatform/Frends.Regex/actions/workflows/build_and_test_on_main.yml/badge.svg)](https://github.com/FrendsPlatform/Frends.Regex/actions) ![MyGet](https://img.shields.io/myget/frends-community/v/Frends.Regex) [![License: UNLICENSED](https://img.shields.io/badge/License-UNLICENSED-yellow.svg)](https://opensource.org/licenses/UNLICENSED) 

- [Installing](#installing)
- [Tasks](#tasks)
     - [Frends.Regex.Replace](#frendsregexreplace)
     - [Frends.Regex.IsMatch](#frendsregexismatch)
- [Building](#building)
- [Contributing](#contributing)
- [Change Log](#change-log)

# Installing

You can install the Task via frends UI Task View or you can find the NuGet package from the following NuGet feed
https://www.myget.org/F/frends-community/api/v3/index.json and in Gallery view in MyGet https://www.myget.org/feed/frends-community/package/nuget/Frends.Regex

# Tasks

## Frends.Regex.Replace

Replaces a regex-matching portion of string with a predefined substring.

### Properties

| Property | Type | Description | Example |
| -------- | -------- | -------- | -------- |
| InputText | `string` | Original text                          | `foo` |
| RegularExpression | `string` | The regular expression                 | `[f].*?[o]` |
| Replacement | `string` | Text to replace the regex matches with | `boo` |

### Returns

A result object ReplaceResult with parameters:

| Property | Type | Description | Example |
| -------- | -------- | -------- | -------- |
| ReplacedText | `string` | The original text, with replaced regex matches | `boo` |

Usage:
To fetch result use syntax:

`#result.ReplacedText`

## Frends.Regex.IsMatch

Returns a boolean depicting if the input text matches with the specified regular expression.

### Properties

| Property          | Type     | Description             | Example     |
| ----------------- | -------- | ----------------------- | ----------- |
| InputText         | `string` | Text to test with regex | `foo`       |
| RegularExpression | `string` | The regular expression  | `[f].*?[o]` |

### Returns

A result object IsMatchResult with parameters:

| Property | Type   | Description                                          | Example |
| -------- | ------ | ---------------------------------------------------- | ------- |
| IsMatch  | `bool` | `true` if the text is a regex match, `false` if not. | `boo`   |

Usage:
To fetch result use syntax:

`#result.IsMatch`

# Building

Clone a copy of the repository

`git clone https://github.com/CommunityHiQ/Frends.Regex.git`

Rebuild the project

`dotnet build`

Run tests

`dotnet test`

Create a NuGet package

`dotnet pack --configuration Release`

# Contributing
When contributing to this repository, please first discuss the change you wish to make via issue, email, or any other method with the owners of this repository before making a change.

1. Fork the repository on GitHub
2. Clone the project to your own machine
3. Commit changes to your own branch
4. Push your work back up to your fork
5. Submit a Pull request so that we can review your changes

NOTE: Be sure to merge the latest from "upstream" before making a pull request!

# Change Log

| Version | Changes |
| ------- | ------- |
| 0.0.1   | Development still going on |
