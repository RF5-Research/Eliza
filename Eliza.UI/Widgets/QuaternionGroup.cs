using Eliza.UI.Helpers;
using Eto.Forms;

namespace Eliza.UI.Widgets
{
    public class QuaternionGroup : GenericGroupBox
    {
        private Ref<float> _w;
        private Ref<float> _x;
        private Ref<float> _y;
        private Ref<float> _z;

        private SpinBox wSpinBox;
        private SpinBox xSpinBox;
        private SpinBox ySpinBox;
        private SpinBox zSpinBox;

        public QuaternionGroup(Ref<float> w, Ref<float> x, Ref<float> y, Ref<float> z, string text) : base(text)
        {
            _w = w;
            _x = x;
            _y = y;
            _z = z;

            var itemStackLayout = new VBox();

            wSpinBox = new SpinBox(new Ref<float>(() => _w.Value, v => { _w.Value = v; }), "W");
            xSpinBox = new SpinBox(new Ref<float>(() => _x.Value, v => { _x.Value = v; }), "X");
            ySpinBox = new SpinBox(new Ref<float>(() => _y.Value, v => { _y.Value = v; }), "Y");
            zSpinBox = new SpinBox(new Ref<float>(() => _z.Value, v => { _z.Value = v; }), "Z");

            StackLayoutItem[] itemStackLayoutItems =
            {
                    wSpinBox,
                    xSpinBox,
                    ySpinBox,
                    zSpinBox
            };

            foreach (var item in itemStackLayoutItems)
            {
                itemStackLayout.Items.Add(item);

            }

            Content = itemStackLayout;
        }

        public QuaternionGroup(string text) : base(text)
        {
            var itemStackLayout = new VBox();

            wSpinBox = new SpinBox("W");
            xSpinBox = new SpinBox("X");
            ySpinBox = new SpinBox("Y");
            zSpinBox = new SpinBox("Z");

            StackLayoutItem[] itemStackLayoutItems =
            {
                    wSpinBox,
                    xSpinBox,
                    ySpinBox,
                    zSpinBox
            };

            foreach (var item in itemStackLayoutItems)
            {
                itemStackLayout.Items.Add(item);

            }

            Content = itemStackLayout;
        }

        public void ChangeReferenceValue(Ref<float> w, Ref<float> x, Ref<float> y, Ref<float> z)
        {
            _w = w;
            _x = x;
            _y = y;
            _z = z;

            wSpinBox.ChangeReferenceValue(new Ref<float>(() => _w.Value, v => { _w.Value = v; }));
            xSpinBox.ChangeReferenceValue(new Ref<float>(() => _x.Value, v => { _x.Value = v; }));
            ySpinBox.ChangeReferenceValue(new Ref<float>(() => _y.Value, v => { _y.Value = v; }));
            zSpinBox.ChangeReferenceValue(new Ref<float>(() => _z.Value, v => { _z.Value = v; }));
        }
    }
}
