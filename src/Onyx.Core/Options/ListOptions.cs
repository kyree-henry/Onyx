using CommandLine;

namespace Onyx.Core.Options
{
    public class ListOptions
    {
        [Option('a', "all", HelpText = "List all items.")]
        public bool ListAll { get; set; }
    }
}