# flaky-demo-dotnet

Demo repository for exercising a flaky-test detector against GitHub Actions logs
(dotnet test + xUnit).

- `CalcTests.cs` contains stable facts plus two intentionally flaky facts
  (`Flaky*`) that fail with ~40% probability per run.
- `.github/workflows/tests.yml` (`Tests` → `unit-tests`) runs
  `dotnet test --verbosity normal` so the standard
  `Failed Namespace.Class.Method [N ms]` lines appear in the log.
