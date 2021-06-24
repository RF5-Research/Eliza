using Eliza.UI.Widgets;
using Eto.Forms;
using System;

namespace Eliza.UI.Forms
{
    public class SaveFlagForm : Form
    {
        public SaveFlagForm(Model.SaveFlagStorage saveFlag)
        {
            Title = "Save Flag";

            Content = new SaveFlagStorageGroup(saveFlag, "Save Flag");
        }

    }
}
