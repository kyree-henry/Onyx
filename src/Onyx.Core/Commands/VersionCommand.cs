using System.CommandLine;
using System.CommandLine.NamingConventionBinder;
using System.Reflection;

namespace Onyx.Core.Commands
{
    public class VersionCommand
    {
        public static Option<string> VerboseOption => new
        (
                aliases: new[] { "-v", "--v", "-version", "--version", "version" },
                description: "Show version information"
        )
        {
            AllowMultipleArgumentsPerToken = true
        };

        public static Command Create()
        {
            Command command = new("version", "Show version information");
            command.Handler = CommandHandler.Create<bool>((verbose) =>
            {
                Handler();
            });
            command.AddOption(VerboseOption);

            //command.SetHandler(a => { Handler(); }, VerboseOption);
            return command;
        }

        private static void Handler()
        {
            string? versionString = Assembly.GetEntryAssembly()?
                                    .GetCustomAttribute<AssemblyInformationalVersionAttribute>()?
                                    .InformationalVersion
                                    .ToString();

            Console.WriteLine($"Onyx Version {versionString}");
        }
    }
}