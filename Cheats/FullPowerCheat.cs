using TouhouFantasiaCheat.PInvokes;

namespace TouhouFantasiaCheat.Cheats
{
    /// <summary>
    /// Maximum power cheat.
    /// </summary>
    public static class FullPowerCheat
    {
        const int FULL_POWER_VALUE = 400;

        /// <summary>
        /// Execute the maximum shoot power cheat.
        /// </summary>
        public static void Execute()
        {
            byte[] bytesToWrite = BitConverter.GetBytes(FULL_POWER_VALUE); ;
            WriteProcessMemoryPInvoke.WriteMemory(CheatBase.Process.Id, CheatBase.PowerAddress, bytesToWrite);
        }
    }
}