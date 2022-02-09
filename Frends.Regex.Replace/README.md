# Frends.Regex.Replace


[![Frends.Regex.IsMatch Main](https://github.com/FrendsPlatform/Frends.Regex/actions/workflows/IsMatch_build_and_test_on_main.yml/badge.svg)](https://github.com/FrendsPlatform/Frends.Regex/actions/workflows/IsMatch_build_and_test_on_main.yml)
![MyGet](https://img.shields.io/myget/frends-tasks/v/Frends.Regex.Replace?label=NuGet)
 ![GitHub](https://img.shields.io/github/license/FrendsPlatform/Frends.Regex?label=License)
 ![Coverage](https://app-github-custom-badges.azurewebsites.net/Badge?key=FrendsPlatform/Frends.Regex/Frends.Regex.Replace|main)

Replaces a regex-matching portion of string with a predefined substring.

## Installing

You can install the Task via frends UI Task View or you can find the NuGet package from the following NuGet feed
https://www.myget.org/F/frends-tasks/api/v2.

## Properties

| Property | Type | Description | Example |
| -------- | -------- | -------- | -------- |
| InputText | `string` | Original text                          | `foo` |
| RegularExpression | `string` | The regular expression                 | `[f].*?[o]` |
| Replacement | `string` | Text to replace the regex matches with | `boo` |

## Returns

A result object ReplaceResult with parameters:

| Property | Type | Description | Example |
| -------- | -------- | -------- | -------- |
| ReplacedText | `string` | The original text, with replaced regex matches | `boo` |

Usage:
To fetch result use syntax:

`#result.ReplacedText`

## Building

Clone a copy of the repository

`git clone https://github.com/CommunityHiQ/Frends.Regex.git`

Rebuild the project

`dotnet build`

Run tests

`dotnet test`

Create a NuGet package

`dotnet pack --configuration Release`

# Changelog

## [1.0.0] - 2022-02-09
### Added
- Initial implementation