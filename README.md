<img src="https://github.com/onixion/AlinSpace.ProjectManipulator/blob/main/Assets/Icon.png" width="200" height="200">

# AlinSpace.ProjectManipulator
.NET project file manipulator.

## Why?

When you manage a lot of nuget packages with complex dependency trees, you **need** a library to interact with the project files.

## Example - Increment major version number

```csharp
// Open project.
var project = Project.Open("MyProject.csproj");

// Increment major version number.
project.VersionIncrementMajor();

// Save.
project.Save();
```

## Example - Set version of a specific dependency

```csharp
// Open project.
var project = Project.Open("MyProject.csproj");

// Find the dependency.
var dependency = project
  .GetDependencies()
  .First(x => x.Name == "AutoMapper");

// Set version.
dependency.Version = new Version(11, 0, 0));

// Save.
project.Save();
```
