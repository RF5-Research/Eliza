using Eliza.UI.Helpers;
using Eto.Forms;
using System;

namespace Eliza.UI.Widgets
{
    class SaveFlagStorageGroup : GenericGroupBox
    {
        private Model.SaveFlagStorage _saveFlag;

        public SaveFlagStorageGroup(Model.SaveFlagStorage saveFlag, string text) : base(text)
        {
            _saveFlag = saveFlag;

            var stackLayout = new VBox();

            var length = new SpinBox(new Ref<int>(() => _saveFlag.Length, v => { _saveFlag.Length = v; }), "Length");

            var dataBox = new GroupBox()
            {
                Text = "Data"
            };

            var datastackLayout = new HBox();

            var list = new ListBox();

            for (int i = 0; i < _saveFlag.Data.Length; i++)
            {
                list.Items.Add($"Flag {i}");
            }

            var data = new SpinBox("Flag");

            list.SelectedIndexChanged += List_SelectedIndexChanged;

            void List_SelectedIndexChanged(object sender, EventArgs e)
            {
                data.ChangeReferenceValue(new Ref<byte>(() => _saveFlag.Data[list.SelectedIndex], v => { _saveFlag.Data[list.SelectedIndex] = v; }));
            }

            StackLayoutItem[] datastackLayoutItems =
            {
                list,
                data
            };

            foreach (var item in datastackLayoutItems)
            {
                datastackLayout.Items.Add(item);
            }

            dataBox.Content = datastackLayout;

            StackLayoutItem[] stackLayoutItems =
            {
                length,
                dataBox
            };

            foreach (var item in stackLayoutItems)
            {
                stackLayout.Items.Add(item);
            }

            Content = stackLayout;
        }
    }
}
