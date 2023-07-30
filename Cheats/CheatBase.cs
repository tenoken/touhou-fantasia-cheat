using System.Diagnostics;
using TouhouFantasiaCheat.PInvokes;

namespace TouhouFantasiaCheat.Cheats
{
    /// <summary>
    /// Base class which have the main function to write and read memory address.
    /// </summary>
    internal class CheatBase
    {
        /// <summary>
        /// Touhou Fantasia running proccess.
        /// </summary>
        /// <value></value>
        public static Process Process { get; private set; }
        /// <summary>
        /// Module base address of Touhou Fantasia.
        /// </summary>
        /// <value></value>
        public static nint ModuleBaseAddress { get; private set; }

        /// <summary>
        /// Main method that loads module base address.
        /// </summary>
        internal static void Load()
        {
            try
            {
                Process = Process.GetProcessesByName("TouhouFantasia")[0];

                if (Process is null)
                {
                    Console.WriteLine("No touhou fantasia process found. Make sure whether the game is running and try again.");
                    return;
                }

                ModuleBaseAddress = GetModuleBaseAddress(Process, "UnityPlayer.dll");
            }
            catch (System.Exception e)
            {
                Console.WriteLine($"Unhandled error: {e.Message}");
            }
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
        public static int ReadFromPointer(int address, int[] offsets, bool verbose = false)
        {
            if (verbose)
            {
                Console.WriteLine("----------");
                Console.WriteLine("Address: " + address);
            }

            int ptr = ReadPointer(address);
            int realAddress = 0;

            if (verbose)
                Console.WriteLine($"Pointer returned as int: {ptr}, hex: {ptr:X}");

            for (var i = 0; i < offsets.Length; ++i)
            {
                if (verbose)
                    Console.WriteLine($"Adding offset: {offsets[i]:X} to Pointer: {ptr:X}");

                realAddress = ptr + offsets[i];
                ptr = ReadPointer(ptr + offsets[i]);

                if (verbose)
                    Console.WriteLine($"Pointer returned as int: {ptr}, hex: {ptr:X}");
            }

            if (verbose)
            {
                Console.WriteLine($"Final address: {realAddress:X}");
                Console.WriteLine("----------");
            }

            //UnsetVerbose();
            return realAddress;
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