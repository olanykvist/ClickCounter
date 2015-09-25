
namespace ClickCounter.Hooks
{
    using Microsoft.Win32.SafeHandles;

    internal class HookHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        public HookHandle() : base(true)
        {
        }

        public HookHandle(bool ownsHandle) : base(ownsHandle)
        {
        }

        protected override bool ReleaseHandle()
        {
            return Win32.UnhookWindowsHookEx(handle);
        }
    }
}
