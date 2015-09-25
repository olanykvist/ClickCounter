
namespace ClickCounter.Hooks
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;

    public delegate void ClickEventHandler(object sender, EventArgs e);

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
