using System.Runtime.InteropServices;

namespace TouhouFantasiaCheat.PInvokes
{
    public class WriteProcessMemoryPInvoke
    {
        // Import the WriteProcessMemory function from the Windows API
        [DllImport("kernel32.dll")]
        public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out IntPtr lpNumberOfBytesWritten);

        const uint PROCESS_VM_WRITE = 0x0020;
        const uint PROCESS_VM_OPERATION = 0x0008;

        /// <summary>
        /// Write in process memomory.
        /// </summary>
        /// <param name="processId">ID of Proccess</param>
        /// <param name="address">Memory addres which will be written</param>
        /// <param name="byteValue">Value in byte to write</param>
        internal static void WriteMemory(int processId, nint address, byte byteValue)
        {
            // The data to write to the process
            byte[] buffer = new byte[] { byteValue };

            // Open the process with the specified access
            IntPtr processHandle = OpenProcessPInvoke.OpenProcess(PROCESS_VM_WRITE | PROCESS_VM_OPERATION, false, processId);

            // Write the data to the process's memory
            IntPtr bytesWritten;
            WriteProcessMemory(processHandle, address, buffer, (uint)buffer.Length, out bytesWritten);

            // Check if the write was successful
            if (bytesWritten.ToInt32() == buffer.Length)
            {

            }
            else
            {
                Console.WriteLine($"Write failed on following memory address: {address:X}");
            }
        }

        /// <summary>
        /// Write in process memomory.
        /// </summary>
        /// <param name="processId">ID of Proccess</param>
        /// <param name="address">Memory addres which will be written</param>
        /// <param name="bytes">Byte array to write</param>
        internal static void WriteMemory(int processId, nint address, byte[] bytes)
        {
            // The data to write to the process
            byte[] buffer = bytes;

            // Open the process with the specified access
            IntPtr processHandle = OpenProcessPInvoke.OpenProcess(PROCESS_VM_WRITE | PROCESS_VM_OPERATION, false, processId);

            // Write the data to the process's memory
            IntPtr bytesWritten;
            WriteProcessMemory(processHandle, address, buffer, (uint)buffer.Length, out bytesWritten);

            // Check if the write was successful
            if (bytesWritten.ToInt32() == buffer.Length)
            {

            }
            else
            {
                Console.WriteLine($"Write failed on following memory address: {address:X}");
            }
        }
    }
}