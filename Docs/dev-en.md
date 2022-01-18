[EN](dev-en.md)
[中文](dev-cn.md)

# Technical Documentation

## Introduction

Project Haru (春) is a minimal modding framework for Escape From Tarkov (EFT).
The goal is to provide a minimal implementation for other people to play and
extend EFT's functionality.

This project does not aim for accuracy, correctness or speed. However, it does
focus on modularity, maintainability, minimalism and simplicity.

## Legal notice

The reversed source and data is covered under
`Koninkrijk Der Nederlanden Auteurswet Artikel 45m 1c`
(english: `Kingdom of The Netherlands Copyright Act Article 45m 1c`).
The reversed source and data is relevant to discussion and development of
interoperability of the Haru project as an add-on module for EFT. The API used
for comminucating with EFT is not made publicly available by
BattleState Games Limited for 3rdparty usage.

Please consult the copyright laws of your country for the legality of reverse
engineering the before contributing to this project.

## Getting started

### Important

Because the EFT and Unity assembly references cannot be redistributed, you need
to obtain these from your EFT client. These assemblies are located at
`EscapeFromTarkov_Data/Managed/`. See `Modules/Modules.csproj` where the
referenced assemblies need to be placed.

### Requirements

- dotnet 6.0 sdk
- visual studio code
  - ms-dotnettools.csharp

### Setup

Terminal > Run Task > setup

### Build

Terminal > Run Build Task

## Solution

### Configuration

#### Build system

`dotnet` is used exclusively to ensure cross-platform compatability and support
for multiple IDE's (Visual Studio Code, Visual Studio 2022).

### Projects

#### Launcher

Minimal CLI-based game launcher

##### Launch process

The game is started using the appropiate launch arguments with high priority.

##### EFT launch arguments

**Name**  | **Description**
--------- | ------------------------
`-token`  | Account token
`-config` | EFT client configuration

##### EFT client configuration

```json
{
    "backendurl": "https://prod.escapefromtarkov.com",
    "version": "live"
}
```

- `backendurl`: main server address.
   The game can connect without ssl connection using the `http` protocol
- `version`: game channel (`live`, `dev`, etc)

#### Modules

Runtime patches to allow the game to reach the main menu

##### Hook

The hooking method is NLog's target system. This means that we fake being an
NLog logger extension so NLog automatically loads the assembly with the patches
and executes it.

Both BePinEx and MelonLoader were considered, but the NLog hook has my
preference due to having the least dependencies, requiring less files and the
project setup is simpler.

##### Patching

Harmony 2.0 is used for runtime patching. `Haru.Modules.Reflection` contains a
wrapper around this library to make it easier to use.

- `APatch` is an abstracted wrapper of the Harmony API.
- Specializations classes (like `PrefixPatch`) implement the patching method.
- Patches (like `BattleyePatch`) specify the original method and what needs
  to be patched in.

##### Build configuration

In order to build the project on Linux and OSX without requiring mono, the
`net472` references are obtained from NuGet using the
`Microsoft.NETFramework.ReferenceAssemblies` package.

#### Server

Minimal server emulator

#### zlib.net

Zlib library used by EFT without their modifications

#### websocket-sharp

Minimal websocket server for handling websockets in EFT

## Programming conventions

### Rules

These are differences from the dotnet style guide:

- indentation: 4 spaces
- namespace sorting order: `System` > 3rd party > project
- only use `type` when `var` cannot be used
- only use LINQ for lookups in module patches
- only use labdas for LINQ
- always indent for scope
- always leave a space between control structures creating scope
- always add a line separation between variable declarations and control
  structure when scope is more than two lines
- Always declare variables at the top of the method unless it's impossible to
  do so
- never use multiple variable initialization
- never use shorthand control structure notation
- never use single comments (`//`) for block comments or commenting more than
  one line
- never inline single comments (`//`) horizontally

### Examples

#### Good

```cs
using System;
using 3rdparty.CookieJar;
using Haru.Example.Model;

namespace Haru.Example
{
    public class Test
    {
        public void Run()
        {
            var jar = new Jar();
            var chocoCookie = new Cookie();
            var biscuit = new Cookie();
            var value = "hello world!";
            var isEnabled = true;

            if (isEnabled)
            {
                // show value when enabled
                Console.WriteLine(value);
            }

            /* this
             * is
             * a
             * block
             * comment
             */
            switch (Jar.count)
            {
                case 1:
                    Console.WriteLine("Only one cookie remaining!");
                    break;

                case 5:
                    Console.WriteLine("The jar is half full!");
                    break;

                case 10:
                    Console.WriteLine("The jar is full!");
                    break;

                default:
                    // do nothing
                    break;
            }

            while (true)
            {
                // keep program alive
            }
        }
    }
}
```

#### Bad

```cs
using Haru.Example.Model;
using 3rdparty.CookieJar;
using System;

namespace Haru.Example
{
    public class Test
    {
        public void Run()
        {
            var chocoCookie = new Cookie(),
                biscuit = new Cookie();
            string value = "hello world!";
            bool isEnabled = true;

            if (isEnabled)  // show value when enabled
                Console.WriteLine(value);
            
            // this
            // is
            // a
            // block
            // comment
            var jar = new Jar();
            switch (Jar.count) {
            case 1:
                Console.WriteLine("Only one cookie remaining!");
                break;
            case 5:
                Console.WriteLine("The jar is half full!");
                break;
            case 10:
                Console.WriteLine("The jar is full!");
                break;
            default:
                // do nothing
                break;
            }
            while (true) {}
        }
    }
}
```
