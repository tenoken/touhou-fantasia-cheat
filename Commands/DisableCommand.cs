using TouhouFantasiaCheat.Cheats;
using TouhouFantasiaCheat.Cheats.Enums;
using TouhouFantasiaCheat.Helpers;

namespace TouhouFantasiaCheat.Commands
{
    /// <summary>
    /// Command to disable cheats.
    /// </summary>
    public class DisableCommand
    {
        /// <summary>
        /// Disable the cheat if it is running.
        /// </summary>
        /// <param name="command">Cheat to be disabled</param>
        public static void Execute(string command)
        {
            if (!IsValidCommand(command))
                PrintUsage();
        }

        private static void PrintUsage()
        {
            Console.WriteLine("Usage: disable <command>");
            Console.WriteLine("Example: disable fulllife");
        }

        private static bool IsValidCommand(string command)
        {
            try
            {
                if (string.IsNullOrEmpty(command))
                    return false;

                var cheat = EnumHelper.GetValueFromDescription<CheatEnum>(command);
                CheatManager.Stop(cheat);
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