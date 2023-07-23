using TouhouFantasiaCheat.Commands.Interfaces;

namespace TouhouFantasiaCheat.Commands
{
    public class HelpCommand : ICommand
    {
        public void Execute(string command = null)
        {
            throw new NotImplementedException();
        }

        public void PrintUsage()
        {
            Console.WriteLine("Commands:");
            Console.WriteLine("disable, -d      <command>       Disable a cheat. It does nothing if the cheated to be disabled are not enabled.");
            Console.WriteLine("enable, -e       <command>       Enable a cheat.");
            Console.WriteLine("--help, -e                       Show all the possible commands.");
            Console.WriteLine("--verbose, -v                    Shows commands actions while they are running.");
        }
    }
}