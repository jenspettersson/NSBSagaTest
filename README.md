# NSBSagaTest
Repro of possible bug in NServiceBus Test framework regarding Sagas

## Symptom
When running `dotnet test` inside a Linux container (in this repo `microsoft/dotnet:2.2.104-sdk` on Docker For Windows with Linux containers) the test executor hangs if you test a Saga from at least two different tests in parallel and the saga does some sort of async operation.

This is not the case when running tests with `dotnet test` on a Windows 10 computer or directly from Visual Studio.

## How to reproduce
Clone the repo and and run `docker build -t nsb-lab .` in the root. This will try to run all the tests while running on `microsoft/dotnet:2.2.104-sdk`. The result should be:

```
Test run for /app/NSBSagaTest.Tests/bin/Debug/netcoreapp2.2/NSBSagaTest.Tests.dll(.NETCoreApp,Version=v2.2)
Microsoft (R) Test Execution Command Line Tool Version 15.9.0
Copyright (c) Microsoft Corporation.  All rights reserved.

Starting test execution, please wait...

```

and it hangs "forever" on the last line.

I've included a `xunit.runner.json` file with both `parallelizeAssembly` and `parallelizeTestCollections` set to true (I think this is the default for the runner on Linux) and if you change it to:

```
{
  "parallelizeAssembly": true,
  "parallelizeTestCollections": false
}
```

and run the docker command again, the tests should pass.

```
Test run for /app/NSBSagaTest.Tests/bin/Debug/netcoreapp2.2/NSBSagaTest.Tests.dll(.NETCoreApp,Version=v2.2)
Microsoft (R) Test Execution Command Line Tool Version 15.9.0
Copyright (c) Microsoft Corporation.  All rights reserved.

Starting test execution, please wait...

Total tests: 4. Passed: 4. Failed: 0. Skipped: 0.
Test Run Successful.
Test execution time: 6.5840 Seconds
```
