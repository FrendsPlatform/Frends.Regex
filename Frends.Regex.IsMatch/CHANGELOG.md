# Changelog
## [2.0.0] - 2026-07-23
### Changed
- Task now targets .NET 8.
- Added `Options` parameter with `ThrowErrorOnFailure` and `ErrorMessageOnFailure` settings, allowing errors to be returned as a result instead of thrown as exceptions.
- Added `CancellationToken` parameter so the task can be cancelled by Frends.
- Result now includes a `Success` flag and an `Error` object with details when the task fails.

## [1.1.0] - 2023-10-12
### Added
- Result.Data: Matching values as a string.

## [1.0.1] - 2022-02-21
### Changed
- Targeting changed to only include .NET 6.0 (removed .NET Standard 2.0)

## [1.0.0] - 2022-02-09
### Added
- Initial implementation
