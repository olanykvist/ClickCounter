
namespace ClickCounter.Hooks
{
    using System;
    using Microsoft.Win32.SafeHandles;

    internal class HookHandle : SafeHandleZeroOrMinusOneIsInvalid
    {
        public HookHandle(bool ownsHandle)
            : base(ownsHandle)
        {
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

        }

        protected override bool ReleaseHandle()
        {
            throw new NotImplementedException();
        }
    }
}
