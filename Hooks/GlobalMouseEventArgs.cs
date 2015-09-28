using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClickCounter.Hooks
{
    public class GlobalMouseEventArgs : EventArgs
    {
        public string WindowTitle { get; set; }
    }
}
