using TouhouFantasiaCheat.PInvokes;

namespace TouhouFantasiaCheat.Cheats
{
    /// <summary>
    /// Infinite life cheat.
    /// </summary>
    public static class FullLifeCheat
    {
        const Byte FULL_LIFE_VALUE = 0x08;
        private static nint _playerAddress;

        /// <summary>
        /// Execute the infinite life cheat.
        /// </summary>
        public static void Execute()
        {
            _playerAddress = GetPlayerLifeAddress((int)CheatBase.ModuleBaseAddress);
            WriteProcessMemoryPInvoke.WriteMemory(CheatBase.Process.Id, _playerAddress, FULL_LIFE_VALUE);
        }

        /// <summary>
        /// Get player life counter address.
        /// </summary>
        /// <param name="moduleBaseAddress">Base addres of module</param>
        /// <returns>A int pointer of player life memory address</returns>
        private static IntPtr GetPlayerLifeAddress(int moduleBaseAddress)
        {
            return (IntPtr)CheatBase.ReadFromPointer((int)moduleBaseAddress + 0x01094D74, new[] { 0x30, 0x08, 0x54, 0x21C, 0xC, 0x10, 0x184 });
        }
    }
}