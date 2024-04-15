using Onyx.Core.Commands;
using System.CommandLine;
using System.CommandLine.Builder;
using System.CommandLine.NamingConventionBinder;
using System.CommandLine.Parsing;
using System.ComponentModel.DataAnnotations;

namespace Onyx.CLI
{
    class Program
    {
        static async Task<int> Main(string[] args)
        {
            RootCommand rootCommand = new("Onyx");
            rootCommand.AddGlobalOption(VersionCommand.VerboseOption);

            // get version command
            rootCommand.AddCommand(VersionCommand.Create());


            rootCommand.Handler = CommandHandler.Create((ParseResult parseResult) =>
            {
                if (parseResult.Tokens.Count == 0)
                {
                    Console.WriteLine("    ___________________\r\n  /                    \\\r\n /                      \\\r\n|      ▄▄▄▄▄▄▄▄▄▄▄▄▄▄    |        WELCOME\r\n|     █   . . . . . .█   |        TO\r\n|     █   . . . . . .█   |        ONYX\r\n|     █   ...... . . █   |\r\n|     █  .......  . .█   |\r\n|     █  .......  . .█   |\r\n|     █   . . . . . .█   |\r\n|     █   . . . . . .█   |\r\n|     █   . . . . . .█   |\r\n|     █   . . . . . .█   |\r\n|     █   . . . . . .█   |\r\n|     █   . . . . . .█   |\r\n|     █               █  |\r\n|      ▀▀▀▀▀▀▀▀▀▀▀▀▀▀▀   |\r\n");
                    return Task.FromResult(1);
                }
                else
                {
                    Console.WriteLine("Unrecognized command or option.");
                    return Task.FromResult(1);
                }
            });


            CommandLineBuilder commandLineBuilder = new(rootCommand);
            Parser? parser = commandLineBuilder.Build();

            return await parser.InvokeAsync(args).ConfigureAwait(false);
        }
    }
}