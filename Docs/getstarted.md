# Getting started

## Important

Escape From Tarkov and Unity references need to be obtained from
`EscapeFromTarkov_Data/Managed/` in order for the modules project to build
correctly. To know which ones you need and where to put them, see
`Modules/Modules.csproj`.

## Visual Studio Code

### Requirements

- dotnet 6.0 sdk
- visual studio code
  - ms-dotnettools.csharp

### Setup

Terminal > Run Task > setup

### Build

Terminal > Run Build Task

## Visual Studio 2022

### Requirements

- dotnet desktop workload (no optionals)

### Setup

Solution Explorer > Haru > Restore NuGet Packages

### Build

1. Solution Explorer > Launcher > Publish
2. Solution Explorer > Modules > Build
3. Solution Explorer > Server > Publish
