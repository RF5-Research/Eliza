using Eto.Forms;
using System.Numerics;

namespace Eliza.UI.Widgets
{
    public class Vector3Group : GenericGroupBox
    {
        private Ref<float> _x;
        private Ref<float> _y;
        private Ref<float> _z;

        private SpinBox xSpinBox;
        private SpinBox ySpinBox;
        private SpinBox zSpinBox;


        public Vector3Group(Ref<float> x, Ref<float> y, Ref<float> z, string text) : base(text)
        {
            _x = x;
            _y = y;
            _z = z;

            var itemStackLayout = new VBox();

            xSpinBox = new SpinBox(new Ref<float>(() => _x.Value, v => { _x.Value = v; }), "X");
            ySpinBox = new SpinBox(new Ref<float>(() => _y.Value, v => { _y.Value = v; }), "Y");
            zSpinBox = new SpinBox(new Ref<float>(() => _z.Value, v => { _z.Value = v; }), "Z");

            StackLayoutItem[] itemStackLayoutItems =
            {
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

        public Vector3Group(string text) : base(text)
        {
            var itemStackLayout = new VBox();

            xSpinBox = new SpinBox("X");
            ySpinBox = new SpinBox("Y");
            zSpinBox = new SpinBox("Z");

            StackLayoutItem[] itemStackLayoutItems =
            {
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

        public void ChangeReferenceValue(Ref<float> x, Ref<float> y, Ref<float> z)
        {
            _x = x;
            _y = y;
            _z = z;

            xSpinBox.ChangeReferenceValue(new Ref<float>(() => _x.Value, v => { _x.Value = v; }));
            ySpinBox.ChangeReferenceValue(new Ref<float>(() => _y.Value, v => { _y.Value = v; }));
            zSpinBox.ChangeReferenceValue(new Ref<float>(() => _z.Value, v => { _z.Value = v; }));
        }
    }
}
