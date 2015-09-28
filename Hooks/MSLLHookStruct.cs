
namespace ClickCounter.Hooks
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    internal struct MSLLHookStruct
    {
        public Point pt;
        public uint mouseData;
        public uint flags;
        public uint time;
        IntPtr dwExtraInfo;
    }
}
