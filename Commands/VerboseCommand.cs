namespace TouhouFantasiaCheat.Commands
{
    /// <summary>
    /// Enables details about the running commands.
    /// </summary>
    public class VerboseCommand
    {
        public static bool VerboseEnabled = false;
        /// <summary>
        /// Indicate whether the command will show detailed output. 
        /// </summary>
        public static void Execute()
        {
            VerboseEnabled = true;
        }

        /// <summary>
        /// Indicate whether the command will not show detailed output. 
        /// </summary>
        internal static void Disable()
        {
            VerboseEnabled = false;
        }
    }
}