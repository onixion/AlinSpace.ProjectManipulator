<img src="https://github.com/onixion/AlinSpace.ProjectManipulator/blob/main/Assets/Icon.png" width="200" height="200">

# AlinSpace.ProjectManipulator
.NET project file manipulator.

## Why?

When you manage a lot of nuget packages with complex dependency trees, you **need** a library to interact with the project files.

This library is mostly used to update version numbers of project dependencies.

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

## Example - Get projects from a solution file

Note: Solution files can only be read.

```csharp
// Read solution.
var solution = Solution.Read("MySolution.sln");

// Access projects.
var project = solution.Projects.First();

var name = project.Name;
var path = project.PathToProjectFile;
```
