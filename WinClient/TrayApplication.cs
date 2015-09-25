

namespace ClickCounter.WinClient
{
    using Hooks;
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.IO;

    internal class TrayApplication : IDisposable
    {
        private NotifyIcon icon;
        private ContextMenu menu;
        private MouseHook hook;
        private StreamWriter writer;

        public TrayApplication()
        {
            menu = new ContextMenu();
            menu.MenuItems.Add(new MenuItem("Exit", OnExitClick));

            icon = new NotifyIcon();
            icon.Text = "ClickCounter";
            icon.Icon = new Icon(SystemIcons.Shield, new Size(16, 16));
            icon.ContextMenu = menu;

            writer = new StreamWriter(File.Open(@"log.txt", FileMode.Append, FileAccess.Write));

            hook = new MouseHook();
            hook.Click += Hook_Click;
        }

        private void Hook_Click(object sender, EventArgs e)
        {
            var date = DateTime.Now.ToString();
            writer.WriteLine(date);
        }

        public void Display()
        {
            icon.Visible = true;
        }

        private void OnExitClick(object sender, EventArgs e)
        {
            Application.Exit();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    icon.Dispose();
                    writer.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~TrayApplication() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
