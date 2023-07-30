using TouhouFantasiaCheat.Commands;
using TouhouFantasiaCheat.PInvokes;

namespace TouhouFantasiaCheat.Cheats
{
    /// <summary>
    /// Infinite spell cards cheat.
    /// </summary>
    public static class FullSpellCheat
    {
        const Byte FULL_SPELL_VALUE = 0x08;
        private static nint _spellCardAddress;

        /// <summary>
        /// Execute the infinite spell card cheat.
        /// </summary>
        public static void Execute()
        {
            _spellCardAddress = GetSpellAddress((int)CheatBase.ModuleBaseAddress);
            WriteProcessMemoryPInvoke.WriteMemory(CheatBase.Process.Id, _spellCardAddress, FULL_SPELL_VALUE);
        }

        /// <summary>
        /// Get spell cards counter address.
        /// </summary>
        /// <param name="moduleBaseAddress">Base addres of module</param>
        /// <returns>A int pointer of player life memory addres</returns>
        private static nint GetSpellAddress(int moduleBaseAddress)
        {
            return (IntPtr)CheatBase.ReadFromPointer((int)moduleBaseAddress + 0x01094D74, new[] { 0x30, 0x08, 0x54, 0x21C, 0xC, 0x10, 0x188 }, VerboseCommand.VerboseEnabled);
        }
    }
}