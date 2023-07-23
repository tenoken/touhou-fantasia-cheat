using TouhouFantasiaCheat.Commands.Interfaces;

namespace TouhouFantasiaCheat.Commands
{
    public class DisableCommand : ICommand
    {
        public void Execute(string command = null)
        {
            throw new NotImplementedException();
        }

        public void PrintUsage()
        {
            Console.WriteLine("Usage: disable <command>");
            Console.WriteLine("Example: disable fulllife");
        }
    }
}