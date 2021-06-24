using Eto.Forms;
using System;

namespace Eliza.UI.Widgets
{
    public abstract class GenericGroupBox : GroupBox
    {
        protected Type _valueType;
        protected object _value;

        public GenericGroupBox(string text) : base()
        {
            Text = text;
        }
    }
}
