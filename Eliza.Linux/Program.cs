using Eliza.Forms;
using Eto.Forms;
using System;

namespace Eliza.Linux
{
    class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            new Application(Eto.Platforms.Gtk).Run(new MainForm());
        }
    }
}
