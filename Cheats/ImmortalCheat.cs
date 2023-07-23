using TouhouFantasiaCheat.PInvokes;

namespace TouhouFantasiaCheat.Cheats
{
    /// <summary>
    /// Immortal player cheat.
    /// </summary>
    public static class ImmortalCheat
    {
        const uint IMMORTAL_BYTES_VALUE = 0xFFFFFFFF;

        /// <summary>
        /// Execute immortal player cheat.
        /// </summary>
        public static void Execute()
        {
            byte[] bytesToWrite = BitConverter.GetBytes(IMMORTAL_BYTES_VALUE); ;
            WriteProcessMemoryPInvoke.WriteMemory(CheatBase.Process.Id, CheatBase.GodModeAddress, bytesToWrite);
        }
    }
}