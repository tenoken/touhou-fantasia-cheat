using TouhouFantasiaCheat.Cheats;
using TouhouFantasiaCheat.Cheats.Enums;
using TouhouFantasiaCheat.Helpers;

namespace TouhouFantasiaCheat.Commands
{
    /// <summary>
    /// Command to disable cheats.
    /// </summary>
    public static class DisableCommand
    {
        /// <summary>
        /// Disable the cheat if it is running.
        /// </summary>
        /// <param name="command"></param>
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

        /// <summary>
        /// Verify whether inputed command is valid.
        /// </summary>
        /// <param name="command"></param>
        /// <returns>True if the command is valid or false if is not</returns>
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