# AlinSpace.DotNetProject
[![NuGet version (AlinSpace.Exceptions)](https://img.shields.io/nuget/v/AlinSpace.Exceptions.svg?style=flat-square)](https://www.nuget.org/packages/AlinSpace.Exceptions/)

.NET project file manipulator.

## Why?

When you manage a lot of nuget packages with complex dependency trees, you **need** a library to interact with the project files.

## Example - Increment major version number

```csharp
var project = Project.Open("MyProject.csproj");
project.VersionIncrementMajor();
project.Save();
```

## Example - Set version of dependency

```csharp
var project = Project.Open("MyProject.csproj");
project.SetDependencyVersion(new Version(5, 0, 0));
project.Save();
```
