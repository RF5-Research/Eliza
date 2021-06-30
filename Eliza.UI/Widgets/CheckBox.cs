using Eliza.UI.Helpers;

namespace Eliza.UI.Widgets
{
    public class CheckBox : GenericWidget
    {
        private Eto.Forms.CheckBox checkBox = new Eto.Forms.CheckBox();
        public CheckBox(Ref<bool> value, string text = "") : base(text)
        {
            _value = value;
            checkBox.Checked = value.Value;
            Items.Add(checkBox);
            checkBox.CheckedChanged += CheckBox_CheckedChanged;

        }

        public CheckBox(string text = "") : base(text)
        {
            Items.Add(checkBox);
            checkBox.CheckedChanged += CheckBox_CheckedChanged;
        }

        public void ChangeReferenceValue(Ref<bool> value)
        {
            _value = value;
            checkBox.Checked = value.Value;
        }
        private void CheckBox_CheckedChanged(object sender, System.EventArgs e)
        {
            ((Ref<bool>)_value).Value = (bool)checkBox.Checked;
        }
    }
}