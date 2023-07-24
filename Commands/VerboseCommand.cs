using TouhouFantasiaCheat.Cheats;

namespace TouhouFantasiaCheat.Commands
{
    /// <summary>
    /// Enables details about the running commands.
    /// </summary>
    public static class VerboseCommand
    {
        public static bool VerboseEnabled = false;
        /// <summary>
        /// Indicate whether the command will show detailed output. 
        /// </summary>
        public static void Execute()
        {
            VerboseEnabled = true;
            CheatBase.SetVerbose();
        }
    }
}