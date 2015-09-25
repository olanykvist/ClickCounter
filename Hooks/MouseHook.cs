
namespace ClickCounter.Hooks
{
    using System;

    public delegate void ClickEventHandler(object sender, EventArgs e);
    public delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);

    public class MouseHook
    {
        private const int WH_MOUSE_LL = 14;
        private const int WM_LBUTTONUP = 0x0202;
        private const int WM_RBUTTONUP = 0x0205;

        public event ClickEventHandler Click;

        private LowLevelMouseProc callback;
        private HookHandle handle;

        public MouseHook()
        {
            callback = new LowLevelMouseProc(MouseCallback);
            handle = Win32.SetWindowsHookEx(WH_MOUSE_LL, callback, IntPtr.Zero, 0);
        }

        protected void OnClick(EventArgs e)
        {
            if (Click != null)
            {
                Click(this, e);
            }
        }

        private IntPtr MouseCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (wParam == (IntPtr)WM_LBUTTONUP || wParam == (IntPtr)WM_RBUTTONUP)
            {
                OnClick(EventArgs.Empty);
            }

            return Win32.CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
        }
    }
}
