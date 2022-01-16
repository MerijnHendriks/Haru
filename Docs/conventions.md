# Programming conventions

## Rules

These are differences from the dotnet style guide:

- indentation: 4 spaces
- namespace sorting order: `System` > 3rd party > project
- only declare variables not above the method if it's impossible otherwise
- only use `type` when `var` cannot be used
- only use labdas for LINQ
- always indent for scope
- always leave a space between control structures creating scope
- always add a line separation between variable declarations and control structure when scope is more than two lines
- never use multiple variable initialization
- never use shorthand control structure notation
- never use single comments (`//`) for block comments or commenting more than one line
- never inline single comments (`//`) horizontally

## Examples

### Good

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

### Bad

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
