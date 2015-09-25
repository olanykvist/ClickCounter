
namespace ClickCounter.Hooks
{
    using System;
    using System.Runtime.InteropServices;

    internal static class Win32
    {
        private const int WH_MOUSE_LL = 14;

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern HookHandle SetWindowsHookEx(int idHook, IntPtr lpfn);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, uint dfg);
    }
}
