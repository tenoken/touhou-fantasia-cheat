using System.Runtime.InteropServices;

namespace TouhouFantasiaCheat.PInvokes
{
    public class ReadProcessMemoryPInvoke
    {
        // Import the ReadProcessMemory fucntion from the Windows API
        [DllImport("kernel32.dll")]
        public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] lpBuffer, uint nSize, out IntPtr lpNumberOfBytesRead);

        /// <summary>
        /// Read process memory.
        /// </summary>
        /// <param name="processId">ID of Proccess</param>
        /// <param name="address">Memory addres which will be written</param>
        internal static void ReadMemory(int processId, nint address)
        {
            // Allocate a buffer to hold the value that you want to read
            byte[] buffer = new byte[sizeof(int)];
            nint bytesRead = 0;
            uint PROCESS_VM_ACCESS = 0x1F0FFF;

            // Open the process with the specified access
            IntPtr processHandle = OpenProcessPInvoke.OpenProcess(PROCESS_VM_ACCESS, false, processId);

            // Read the value at the calculated memory address
            if (ReadProcessMemory(processHandle, address, buffer, (uint)buffer.Length, out bytesRead))
            {
                // Interpret the buffer as an integer
                int value = BitConverter.ToInt32(buffer, 0);
                Console.WriteLine("Value: " + value);
            }
            else
            {
                Console.WriteLine("Read failed");
            }
        }
    }
}