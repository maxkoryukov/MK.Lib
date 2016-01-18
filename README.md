# MK.Lib

[![Build status](https://ci.appveyor.com/api/projects/status/0hyvmcaoiwetqft7?svg=true)](https://ci.appveyor.com/project/maxkoryukov/mk-lib)
[![Coverage Status](https://coveralls.io/repos/maxkoryukov/MK.Lib/badge.svg?branch=master&service=github)](https://coveralls.io/github/maxkoryukov/MK.Lib?branch=master)

My useful C# things

## Tests and Coverage

To run test you could use NUnit project. Sad, but NUnit UI is available only for 2.x.

### Coverage

Cool thing, you could use two commands:

```bat
.\coverage-calc.bat
.\coverage-report.bat
```

These commands will generate report in the `cover-html` directory.

Be careful with reports in the local `cover-history` folder - they will used to generate **historical** part of your report, **but, please, do not add them to the git**.

## Thanks

* to [**coveralls.net team**](https://github.com/coveralls-net/coveralls.net/graphs/contributors) for the detailed [HOWTO](https://github.com/coveralls-net/coveralls.net/wiki/CI-Integrations)

## No thanks

Seems like I really hate nuget, msvs and its "references"-system.
