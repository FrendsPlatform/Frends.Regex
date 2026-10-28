# Changelog

## [2.0.0] - 2026-10-28
### Changed
- **[Breaking Change]** Added the `Options` parameter to the Task. It contains `ThrowErrorOnFailure` and `ErrorMessageOnFailure` for controlling error handling.
- **[Breaking Change]** The Task result now contains `Success` and `Error` properties. When `ThrowErrorOnFailure` is false, failures are returned in the result instead of being thrown.
- Updated the target framework to .NET 8.
- Added missing examples to the result documentation.

## [1.0.0] - 2024-12-31
### Changed
- Initial implementation
