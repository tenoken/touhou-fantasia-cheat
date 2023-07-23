using TouhouFantasiaCheat.PInvokes;

namespace TouhouFantasiaCheat.Cheats
{
    /// <summary>
    /// Infinite spell cards cheat.
    /// </summary>
    public static class FullSpellCheat
    {
        const Byte FULL_SPELL_VALUE = 0x08;
        /// <summary>
        /// Execute the infinite spell card cheat.
        /// </summary>
        public static void Execute()
        {
            WriteProcessMemoryPInvoke.WriteMemory(CheatBase.Process.Id, CheatBase.SpellAddress, FULL_SPELL_VALUE);
        }
    }
}