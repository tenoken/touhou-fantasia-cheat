using TouhouFantasiaCheat.PInvokes;

namespace TouhouFantasiaCheat.Cheats
{
    /// <summary>
    /// Infinite life cheat.
    /// </summary>
    public static class FullLifeCheat
    {
        const Byte FULL_LIFE_VALUE = 0x08;
        /// <summary>
        /// Execute the infinite life cheat.
        /// </summary>
        public static void Execute()
        {
            WriteProcessMemoryPInvoke.WriteMemory(CheatBase.Process.Id, CheatBase.PlayerAddress, FULL_LIFE_VALUE);
        }
    }
}