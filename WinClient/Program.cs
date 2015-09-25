
namespace ClickCounter.WinClient
{
    using System;
    using System.Windows.Forms;

    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (var app = new TrayApplication())
            {
                app.Display();
                Application.Run();
            }
        }
    }
}
