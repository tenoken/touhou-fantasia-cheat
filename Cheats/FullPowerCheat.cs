using TouhouFantasiaCheat.Commands;
using TouhouFantasiaCheat.PInvokes;

namespace TouhouFantasiaCheat.Cheats
{
    /// <summary>
    /// Maximum power cheat.
    /// </summary>
    public class FullPowerCheat
    {
        const int FULL_POWER_VALUE = 400;
        private static nint _powerAddress;

        /// <summary>
        /// Execute the maximum shoot power cheat.
        /// </summary>
        public static void Execute()
        {
            _powerAddress = GetPowerAddress((int)CheatBase.ModuleBaseAddress);
            byte[] bytesToWrite = BitConverter.GetBytes(FULL_POWER_VALUE); ;
            WriteProcessMemoryPInvoke.WriteMemory(CheatBase.Process.Id, _powerAddress, bytesToWrite);
        }

        /// <summary>
        /// Get shoot power address.
        /// </summary>
        /// <param name="moduleBaseAddress"></param>
        /// <returns></returns>
        private static nint GetPowerAddress(int moduleBaseAddress)
        {
            return (IntPtr)CheatBase.ReadFromPointer((int)moduleBaseAddress + 0x010979DC, new[] { 0x04, 0x04, 0x50, 0x18, 0x190 }, VerboseCommand.VerboseEnabled);
        }
    }
}