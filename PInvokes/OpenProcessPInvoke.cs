using System.Runtime.InteropServices;

namespace TouhouFantasiaCheat.PInvokes
{
    public static class OpenProcessPInvoke
    {
        // Import the OpenProcess function from the Windows API
        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, int dwProcessId);
    }
}