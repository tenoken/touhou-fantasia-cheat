using System.Diagnostics;
using TouhouFantasiaCheat.PInvokes;

namespace TouhouFantasiaCheat.Cheats
{
    /// <summary>
    /// Base class which have the main function to write and read memory address.
    /// </summary>
    internal static class CheatBase
    {
        public static Process Process { get; private set; }
        public static IntPtr PlayerAddress { get; private set; }
        public static IntPtr SpellAddress { get; private set; }
        public static IntPtr PowerAddress { get; private set; }
        public static IntPtr GodModeAddress { get; private set; }

        /// <summary>
        /// Main method that loads all the addresses to be used in cheats.
        /// </summary>
        internal static void Load()
        {
            try
            {

                Process = Process.GetProcessesByName("TouhouFantasia")[0];

                var moduleBaseAddress = GetModuleBaseAddress(Process, "UnityPlayer.dll");
                PlayerAddress = GetPlayerLifeAddress((int)moduleBaseAddress);
                SpellAddress = GetSpellAddress((int)moduleBaseAddress);
                PowerAddress = GetPowerAddress((int)moduleBaseAddress);
                GodModeAddress = GetGodModeAddress((int)moduleBaseAddress);
                ReadPointer((int)GodModeAddress);
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Get player life counter address.
        /// </summary>
        /// <param name="moduleBaseAddress">Base addres of module</param>
        /// <returns>A int pointer of player life memory address</returns>
        private static IntPtr GetPlayerLifeAddress(int moduleBaseAddress)
        {
            return (IntPtr)ReadFromPointer((int)moduleBaseAddress + 0x01094D74, new[] { 0x30, 0x08, 0x54, 0x21C, 0xC, 0x10, 0x184 });
        }

        /// <summary>
        /// Get spell cards counter address.
        /// </summary>
        /// <param name="moduleBaseAddress">Base addres of module</param>
        /// <returns>A int pointer of player life memory addres</returns>
        private static nint GetSpellAddress(int moduleBaseAddress)
        {
            return (IntPtr)ReadFromPointer((int)moduleBaseAddress + 0x01094D74, new[] { 0x30, 0x08, 0x54, 0x21C, 0xC, 0x10, 0x188 });
        }

        /// <summary>
        /// Get shoot power address.
        /// </summary>
        /// <param name="moduleBaseAddress"></param>
        /// <returns></returns>
        private static nint GetPowerAddress(int moduleBaseAddress)
        {
            return (IntPtr)ReadFromPointer((int)moduleBaseAddress + 0x010979DC, new[] { 0x04, 0x04, 0x50, 0x18, 0x190 });
        }

        /// <summary>
        /// Get "God Mode" address.
        /// </summary>
        /// <param name="moduleBaseAddress"></param>
        /// <returns></returns>
        private static nint GetGodModeAddress(int moduleBaseAddress)
        {
            return (IntPtr)ReadFromPointer((int)moduleBaseAddress + 0x01091924, new[] { 0x0, 0x208, 0x54, 0x21C, 0xC, 0x10, 0x1E8 });
        }

        /// <summary>
        /// Get base addres of a module.
        /// </summary>
        /// <param name="process">Process that has modules</param>
        /// <param name="moduleName">Name of module to be searched</param>
        /// <returns>A pointer to the base addres of the module or zero if it could be not found</returns>
        public static IntPtr GetModuleBaseAddress(Process process, string moduleName)
        {
            IntPtr address = IntPtr.Zero;

            foreach (ProcessModule module in process.Modules)
            {
                if (module.ModuleName == moduleName)
                {
                    address = module.BaseAddress;
                    break;
                }
            }
            return address;
        }

        /// <summary>
        /// Get the address by base address of a module and offesets calculation.
        /// </summary>
        /// <param name="address">Base addres of a module</param>
        /// <param name="offsets">Offset array to be addesd</param>
        /// <returns>A int32 value</returns>
        public static int ReadFromPointer(int address, int[] offsets)
        {
            //Console.WriteLine("----------");
            //Console.WriteLine("Address: " + address);
            int ptr = ReadPointer(address);
            int realAddress = 0;
            //Console.WriteLine($"Pointer returned as int: {ptr}, hex: {ptr:X}");
            for (var i = 0; i < offsets.Length; ++i)
            {
                //Console.WriteLine($"Adding offset: {offsets[i]:X} to Pointer: {ptr:X}");
                realAddress = ptr + offsets[i];
                ptr = ReadPointer(ptr + offsets[i]);
                //Console.WriteLine($"Pointer returned as int: {ptr}, hex: {ptr:X}");
            }
            //Console.WriteLine($"Final address: {realAddress:X}");
            //Console.WriteLine("----------");
            return realAddress;
        }

        /// <summary>
        /// Get value from address by base address of a module and offesets calculation.
        /// </summary>
        /// <param name="address">Base addres of a module</param>
        /// <param name="offsets">Offset array to be addesd</param>
        /// <returns>A int32 value</returns>
        public static int ReadValueFromPointer(int address, int[] offsets)
        {
            //Console.WriteLine("----------");
            //Console.WriteLine("Address: " + address);
            int ptr = ReadPointer(address);
            //Console.WriteLine($"Pointer returned as int: {ptr}, hex: {ptr:X}");
            for (var i = 0; i < offsets.Length; ++i)
            {
                //Console.WriteLine($"Adding offset: {offsets[i]:X} to Pointer: {ptr:X}");
                ptr = ReadPointer(ptr + offsets[i]);
                //Console.WriteLine($"Pointer returned as int: {ptr}, hex: {ptr:X}");
            }
            //.WriteLine("----------");
            return ptr;
        }

        /// <summary>
        /// Read a memory addres by a pointer.
        /// </summary>
        /// <param name="adress">Pointer addres</param>
        /// <returns>A int32 value of memory addres read</returns>
        private static int ReadPointer(int adress)
        {
            int ptrNext;
            nint bytesRead = 0;
            byte[] _Value = new byte[4];
            ReadProcessMemoryPInvoke.ReadProcessMemory((IntPtr)Process.Handle, (IntPtr)adress, _Value, (uint)IntPtr.Size, out bytesRead);
            ptrNext = BitConverter.ToInt32(_Value, 0);
            return ptrNext;
        }
    }
}