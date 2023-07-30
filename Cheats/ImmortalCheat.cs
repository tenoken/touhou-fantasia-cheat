using TouhouFantasiaCheat.Commands;
using TouhouFantasiaCheat.PInvokes;

namespace TouhouFantasiaCheat.Cheats
{
    /// <summary>
    /// Immortal player cheat.
    /// </summary>
    public static class ImmortalCheat
    {
        const uint IMMORTAL_BYTES_VALUE = 0xFFFFFFFF;
        private static nint _immortalAddress;

        /// <summary>
        /// Execute immortal player cheat.
        /// </summary>
        public static void Execute()
        {
            _immortalAddress = GetGodModeAddress((int)CheatBase.ModuleBaseAddress);
            byte[] bytesToWrite = BitConverter.GetBytes(IMMORTAL_BYTES_VALUE); ;
            WriteProcessMemoryPInvoke.WriteMemory(CheatBase.Process.Id, _immortalAddress, bytesToWrite);
        }

        /// <summary>
        /// Get "God Mode" address.
        /// </summary>
        /// <param name="moduleBaseAddress"></param>
        /// <returns></returns>
        private static nint GetGodModeAddress(int moduleBaseAddress)
        {
            return (IntPtr)CheatBase.ReadFromPointer((int)moduleBaseAddress + 0x01091924, new[] { 0x0, 0x208, 0x54, 0x21C, 0xC, 0x10, 0x1E8 }, VerboseCommand.VerboseEnabled);
        }
    }
}