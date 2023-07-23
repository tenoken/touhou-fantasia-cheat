using TouhouFantasiaCheat.Cheats;
using TouhouFantasiaCheat.Cheats.Enums;
using TouhouFantasiaCheat.Helpers;

namespace TouhouFantasiaCheat.Commands
{
    /// <summary>
    /// Command to enable cheats.
    /// </summary>
    public static class EnableCommand
    {
        /// <summary>
        /// Enable the cheat.
        /// </summary>
        /// <param name="command">Cheat to be executed</param>
        public static void Execute(string command)
        {
            if (!IsValidCommand(command))
                PrintUsage();
        }

        private static void PrintUsage()
        {
            Console.WriteLine("Usage: enable <command>");
            Console.WriteLine("Example: enable fulllife");
        }

        private static bool IsValidCommand(string command)
        {
            try
            {
                if (string.IsNullOrEmpty(command))
                    return false;

                var cheat = EnumHelper.GetValueFromDescription<CheatEnum>(command);
                CheatManager.Execute(cheat);
                return true;
            }
            catch (System.Exception e)
            {
                Console.WriteLine($"It was not possible to execute the following command: {command}");
                if (VerboseCommand.VerboseEnabled)
                    Console.WriteLine($"Unhandled error: {e.Message}");

                return false;
            }
        }
    }
}