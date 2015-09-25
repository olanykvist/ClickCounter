
namespace ClickCounter.WinClient
{
    using ClickCounter.Hooks;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;

    public partial class MainForm : Form
    {
        private MouseHook mouseHook;

        public MainForm()
        {
            InitializeComponent();

            mouseHook.Click += mouseHook_Click;
        }

        void mouseHook_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
