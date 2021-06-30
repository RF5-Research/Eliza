using Eliza.Forms;
using Eto.Forms;
using System;

namespace Eliza.Windows
{
    class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            new Application(Eto.Platforms.WinForms).Run(new MainForm());
        }
    }
}
