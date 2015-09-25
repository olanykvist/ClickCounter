﻿
namespace ClickCounter.Hooks
{
    using System;
    using System.Runtime.InteropServices;

    internal static class Win32
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern HookHandle SetWindowsHookEx(int idHook, LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);
    }
}
