using TouhouFantasiaCheat.Commands.Interfaces;

namespace TouhouFantasiaCheat.Commands
{
    public class VerboseCommand : ICommand
    {
        public void Execute(string command = null)
        {
            throw new NotImplementedException();
        }

        public void PrintUsage()
        {
            Console.WriteLine("--verbose, -v            Shows commands actions while they are running");
        }
    }
}