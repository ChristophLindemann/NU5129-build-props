# Demonstation of NU5129 warning

This repository contains a project which demonstrates, 
that NuGet will generate a `NU5129` warning,
when there are `build\*.props` files
but the `build\<package.id>.props` file has a source name which 
is different:

_Releated to NuGet issue [#8806](https://github.com/NuGet/Home/issues/8806)_

```
PackageFiles
    build\A.Some.Props.File.props
        BuildAction = None
        Link = build\A.Some.Props.File.props
        Pack = true
        PackagePath = build/
    build\Package.props.default
        BuildAction = None
        Link = build\NU5129.Build.Props.Problem.props
        Pack = true
        PackagePath = build/NU5129.Build.Props.Problem.props
```


## How-to

In the `NU5129.Build.Props.Problem.csproj` file set the
`$(Behaviour)` property to 
- `DifferentName`: NU5129 build warning
- `SameName`: No problem, everything works fine

### `DifferentName`

`> dotnet build -c release -t:Rebuild -p:Behaviour=DifferentName`

**Result:**
```
Microsoft (R) Build Engine version 16.4.0+e901037fe for .NET Core
Copyright (C) Microsoft Corporation. All rights reserved.

  Restore completed in 41,15 ms for E:\TFS\Bla\NU5129-build-props\NU5129.Build.Props.Problem.csproj.
  NU5129.Build.Props.Problem -> E:\TFS\Bla\NU5129-build-props\bin\Release\net461\NU5129.Build.Props.Problem.dll
  NU5129.Build.Props.Problem -> E:\TFS\Bla\NU5129-build-props\bin\Release\netstandard2.0\NU5129.Build.Props.Problem.dll
  Successfully created package 'E:\TFS\Bla\NU5129-build-props\bin\Release\NU5129.Build.Props.Problem.1.0.3.nupkg'.
C:\Program Files\dotnet\sdk\3.1.100\Sdks\NuGet.Build.Tasks.Pack\buildCrossTargeting\NuGet.Build.Tasks.Pack.targets(198,5): warning NU5129: - At least one .props file was found in 'build/', but 'build/NU5129.Build.Props.Problem.props' was not. [E:\TFS\Bla\NU5129-build-props\NU5129.Build.Props.Problem.csproj]
C:\Program Files\dotnet\sdk\3.1.100\Sdks\NuGet.Build.Tasks.Pack\buildCrossTargeting\NuGet.Build.Tasks.Pack.targets(198,5): warning NU5129:  [E:\TFS\Bla\NU5129-build-props\NU5129.Build.Props.Problem.csproj]
  Behaviour: DifferentName
  Pack Input
  PackTask::PackageFiles: PackagePath=build/; Identity=build\A.Some.Props.File.props;
  PackTask::PackageFiles: PackagePath=build/NU5129.Build.Props.Problem.props; Identity=build\Package.props.default;

Build succeeded.

C:\Program Files\dotnet\sdk\3.1.100\Sdks\NuGet.Build.Tasks.Pack\buildCrossTargeting\NuGet.Build.Tasks.Pack.targets(198,5): warning NU5129: - At least one .props file was found in 'build/', but 'build/NU5129.Build.Props.Problem.props' was not. [E:\TFS\Bla\NU5129-build-props\NU5129.Build.Props.Problem.csproj]
C:\Program Files\dotnet\sdk\3.1.100\Sdks\NuGet.Build.Tasks.Pack\buildCrossTargeting\NuGet.Build.Tasks.Pack.targets(198,5): warning NU5129:  [E:\TFS\Bla\NU5129-build-props\NU5129.Build.Props.Problem.csproj]
    1 Warning(s)
    0 Error(s)

Time Elapsed 00:00:02.62
```

### `SameName`

`> dotnet build -c release -t:Rebuild -p:Behaviour=SameName`

**Result:**
```
Microsoft (R) Build Engine version 16.4.0+e901037fe for .NET Core
Copyright (C) Microsoft Corporation. All rights reserved.

  Restore completed in 45,22 ms for E:\TFS\Bla\NU5129-build-props\NU5129.Build.Props.Problem.csproj.
  NU5129.Build.Props.Problem -> E:\TFS\Bla\NU5129-build-props\bin\Release\net461\NU5129.Build.Props.Problem.dll
  NU5129.Build.Props.Problem -> E:\TFS\Bla\NU5129-build-props\bin\Release\netstandard2.0\NU5129.Build.Props.Problem.dll
  Successfully created package 'E:\TFS\Bla\NU5129-build-props\bin\Release\NU5129.Build.Props.Problem.1.0.3.nupkg'.
  Behaviour: SameName
  Pack Input
  PackTask::PackageFiles: PackagePath=build/; Identity=build\A.Some.Props.File.props;
  PackTask::PackageFiles: PackagePath=build/NU5129.Build.Props.Problem.props; Identity=build/NU5129.Build.Props.Problem.props;

Build succeeded.
    0 Warning(s)
    0 Error(s)

Time Elapsed 00:00:02.70
```
