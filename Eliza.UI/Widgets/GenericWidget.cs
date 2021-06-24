using Eto.Forms;
using System;

namespace Eliza.UI.Widgets
{
    public abstract class GenericWidget : StackLayout
    {
        protected Type _valueType;
        protected object _value;
        protected Label Label = new Label();

        public GenericWidget(string text) : base()
        {
            Orientation = Orientation.Horizontal;
            Items.Add(Label);
            Label.Text = text;
            Label.Width = 200;
        }
    }
}
