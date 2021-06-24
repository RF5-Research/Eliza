using Eto.Forms;

namespace Eliza.UI.Widgets
{
    public class VBox : StackLayout
    {
        public VBox() : base()
        {
            Orientation = Orientation.Vertical;
            Padding = 5;
            Spacing = 5;
        }
    }
}
