namespace TouhouFantasiaCheat.Commands
{
    /// <summary>
    /// Print all possible commands of this tool.
    /// </summary>
    public class HelpCommand
    {
        /// <summary>
        /// Execute the command.
        /// </summary>
        public static void Execute()
        {
            PrintUsage();
        }

        private static void PrintUsage()
        {
            Console.WriteLine("Commands:");
            Console.WriteLine("disable, -d      <command>       Disable a cheat. It does nothing if the cheat to be disabled are not enabled.");
            Console.WriteLine("enable, -e       <command>       Enable a cheat.");
            Console.WriteLine("--help, -h                       Show all possible commands.");
            Console.WriteLine("--verbose, -v                    Show commands actions while they are running.");
            Console.WriteLine("exit                             Exit from program's execution.");
        }
    }
}