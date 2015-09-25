
namespace ClickCounter.Hooks
{
    using System;

    public delegate void ClickEventHandler(object sender, EventArgs e);

    internal delegate int LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);

    public class MouseHook
    {
        public event ClickEventHandler Click;

        protected void OnClick(EventArgs e)
        {
            if (Click != null)
            {
                Click(this, e);
            }
        }
    }
}
