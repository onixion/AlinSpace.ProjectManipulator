<img src="https://github.com/onixion/AlinSpace.ProjectManipulator/blob/main/Assets/Icon.png" width="200" height="200">

# AlinSpace.ProjectManipulator
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
project.SetDependencyVersion("AutoMapper", new Version(11, 0, 0));
project.Save();
```
