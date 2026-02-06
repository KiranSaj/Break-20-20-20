using System;
using System.Windows.Forms;

namespace Break_20_20_20;

static class Program
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new frmBreakSlide());
    }
}
