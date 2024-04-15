using Onyx.Core.Options;

namespace Onyx.Core.Commands
{
    public class ListCommand
    {
        public static void ExecuteList(ListOptions options)
        {
            if (options.ListAll)
            {
                Console.WriteLine("Listing all items:");
            }
            else
            {
                Console.WriteLine("Only listing selected items:");
            }
        }
    }
}