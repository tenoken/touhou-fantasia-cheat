namespace TouhouFantasiaCheat.Commands.Interfaces
{
    public interface ICommand
    {
        public void Execute(string command = null);
        public void PrintUsage();
    }
}