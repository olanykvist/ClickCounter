
namespace ClickCounter.Hooks
{
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Text;

    public delegate void ClickEventHandler(object sender, GlobalMouseEventArgs e);
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

        protected void OnClick(GlobalMouseEventArgs e)
        {
            if (Click != null)
            {
                Click(this, e);
            }
        }

        private IntPtr MouseCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0)
            {
                if (wParam == (IntPtr)WM_LBUTTONUP || wParam == (IntPtr)WM_RBUTTONUP)
                {
                    var data = (MSLLHookStruct)Marshal.PtrToStructure(lParam, typeof(MSLLHookStruct));

                    Debug.WriteLine(data.pt.x);

                    var desktop = Win32.GetDesktopWindow();
                    //var window = Win32.ChildWindowFromPoint(desktop, data.pt);
                    var window = Win32.WindowFromPoint(data.pt);
                    var builder = new StringBuilder(255);

                    Win32.GetWindowText(window, builder, 255);

                    OnClick(new GlobalMouseEventArgs() { WindowTitle = builder.ToString() });
                }
            }

            return Win32.CallNextHookEx(IntPtr.Zero, nCode, wParam, lParam);
        }
    }
}
