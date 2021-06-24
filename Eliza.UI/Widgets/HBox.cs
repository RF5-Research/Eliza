using Eto.Forms;

namespace Eliza.UI.Widgets
{
    class HBox : StackLayout
    {
        public HBox() : base()
        {
            Orientation = Orientation.Horizontal;
            Padding = 5;
            Spacing = 5;
        }
    }
}
