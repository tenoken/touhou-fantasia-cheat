using TouhouFantasiaCheat.Cheats;
using TouhouFantasiaCheat.Commands.Interfaces;

namespace TouhouFantasiaCheat.Commands
{
    public class EnableCommand : ICommand
    {
        public void Execute(string command)
        {

        }

        public void PrintUsage()
        {
            Console.WriteLine("Usage: enable <command>");
            Console.WriteLine("Example: enable fulllife");
        }
    }
}