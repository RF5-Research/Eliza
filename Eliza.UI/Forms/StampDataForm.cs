using Eliza.Model.SaveData;
using Eliza.UI.Helpers;
using Eliza.UI.Widgets;
using Eto.Forms;
using System;

namespace Eliza.UI.Forms
{
    internal class StampDataForm : Form
    {
        public StampDataForm(RF5StampData stampData)
        {
            Title = "Stamp Data";

            var stampRecordData = new GroupBox()
            {
                Text = "Stamp Record Data"
            };

            {
                var stampRecordDataList = new ListBox();
                var stampRecordDataHBox = new HBox();
                var stampRecordDataData = new VBox();

                for (int i = 0; i < stampData.StampRecordData.Length; i++)
                {
                    stampRecordDataList.Items.Add($"Stamp {i}");
                }

                var stampLevel = new SpinBox("Stamp Level");
                var maxRecord = new SpinBox("Max Record");
                var minRecord = new SpinBox("Min Record");

                stampRecordDataList.SelectedIndexChanged += (object sender, EventArgs e) =>
                {
                    stampLevel.ChangeReferenceValue(
                        new Ref<int>(() => stampData.StampRecordData[stampRecordDataList.SelectedIndex].StampLevel, v => { stampData.StampRecordData[stampRecordDataList.SelectedIndex].StampLevel = v; })
                    );
                    maxRecord.ChangeReferenceValue(
                        new Ref<float>(() => stampData.StampRecordData[stampRecordDataList.SelectedIndex].MaxRecord, v => { stampData.StampRecordData[stampRecordDataList.SelectedIndex].MaxRecord = v; })
                    );
                    minRecord.ChangeReferenceValue(
                        new Ref<float>(() => stampData.StampRecordData[stampRecordDataList.SelectedIndex].MinRecord, v => { stampData.StampRecordData[stampRecordDataList.SelectedIndex].MinRecord = v; })
                    );

                };

                stampRecordDataData.Items.Add(stampLevel);
                stampRecordDataData.Items.Add(maxRecord);
                stampRecordDataData.Items.Add(minRecord);

                stampRecordDataHBox.Items.Add(stampRecordDataList);
                stampRecordDataHBox.Items.Add(stampRecordDataData);

                stampRecordData.Content = stampRecordDataHBox;
            }

            var vBox = new VBox();
            vBox.Items.Add(stampRecordData);
            var scroll = new Scrollable();
            scroll.Content = vBox;

            Content = scroll;
        }
    }
}