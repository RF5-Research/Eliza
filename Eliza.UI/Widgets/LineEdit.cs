using Eto.Forms;
using System;
using System.Text;

namespace Eliza.UI.Widgets
{
    class LineEdit : GenericWidget
    {
        public TextBox textBox = new TextBox();

        public LineEdit(Ref<char[]> value, string text) : base(text)
        {
            _valueType = value.Value.GetType();
            _value = value;
            Setup();
        }

        public LineEdit(Ref<string> value, string text) : base(text)
        {
            _valueType = value.Value.GetType();
            _value = value;
            Setup();
        }

        public LineEdit(string text) : base(text)
        {
            Items.Add(textBox);
        }

        public void ChangeReferenceValue(Ref<char[]> value)
        {
            if (value != null)
            {
                if (value.Value != null)
                {
                    _value = value;
                    _valueType = value.Value.GetType();
                    SetValue();
                }
            }
        }

        public void ChangeReferenceValue(Ref<string> value)
        {
            if (value != null)
            {
                if (value.Value != null)
                {
                    _value = value;
                    _valueType = value.Value.GetType();
                    SetValue();
                }
            }
        }

        private void Setup()
        {
            Items.Add(textBox);
            textBox.TextChanged += LineEdit_TextChanged;
            SetValue();
        }

        private void SetValue()
        {
            if (_valueType == typeof(char[]))
            {
                textBox.Text = Encoding.UTF8.GetString(
                    Encoding.UTF8.GetBytes(((Ref<char[]>)_value).Value)
                 );
            }
            else
            {
                textBox.Text = ((Ref<string>)_value).Value;
            }
        }

        private void LineEdit_TextChanged(object sender, EventArgs e)
        {
            if (_valueType == typeof(char[]))
            {
                // Need to check on encoding, but should be fine
                ((Ref<char[]>)_value).Value = textBox.Text.ToCharArray();
            }
            else
            {
                ((Ref<string>)_value).Value = textBox.Text;
            }
        }
    }
}
