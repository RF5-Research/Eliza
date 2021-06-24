using Eto.Forms;

namespace Eliza.UI.Widgets
{
    public class CheckBox : GenericWidget
    {
        private Eto.Forms.CheckBox checkBox = new Eto.Forms.CheckBox();
        public CheckBox(Ref<bool> value, string text) : base(text)
        {
            _value = value;
            Items.Add(checkBox);
            checkBox.CheckedChanged += CheckBox_CheckedChanged;

            checkBox.Checked = value.Value;
        }

        private void CheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            ((Ref<bool>)_value).Value = (bool)checkBox.Checked;
        }
    }
}
