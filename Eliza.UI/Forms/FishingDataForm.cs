using Eliza.Model.SaveData;
using Eliza.UI.Helpers;
using Eliza.UI.Widgets;
using Eto.Forms;
using System;

namespace Eliza.UI.Forms
{
    internal class FishingDataForm : Form
    {
        public FishingDataForm(RF5FishingData fishingData)
        {
            Title = "Fishing Data";

            var fishRecord = new GroupBox()
            {
                Text = "Fish Record"
            };

            {
                var fishRecordList = new ListBox();
                var fishRecordHBox = new HBox();
                var fishRecordData = new VBox();

                for (int i = 0; i < fishingData.FishRecord.Count; i++)
                {
                    fishRecordList.Items.Add($"Fish {i}");
                }

                var id = new SpinBox("ID");
                var min = new SpinBox("Min");
                var max = new SpinBox("Max");
                var stamp = new SpinBox("Stamp");

                fishRecordList.SelectedIndexChanged += (object sender, EventArgs e) =>
                {
                    id.ChangeReferenceValue(
                        new Ref<int>(() => fishingData.FishRecord[fishRecordList.SelectedIndex].Id, v => { fishingData.FishRecord[fishRecordList.SelectedIndex].Id = v; })
                    );
                    min.ChangeReferenceValue(
                        new Ref<int>(() => fishingData.FishRecord[fishRecordList.SelectedIndex].Min, v => { fishingData.FishRecord[fishRecordList.SelectedIndex].Min = v; })
                    );
                    max.ChangeReferenceValue(
                        new Ref<int>(() => fishingData.FishRecord[fishRecordList.SelectedIndex].Max, v => { fishingData.FishRecord[fishRecordList.SelectedIndex].Max = v; })
                    );
                    stamp.ChangeReferenceValue(
                        new Ref<int>(() => fishingData.FishRecord[fishRecordList.SelectedIndex].Stamp, v => { fishingData.FishRecord[fishRecordList.SelectedIndex].Stamp = v; })
                    );
                };

                fishRecordData.Items.Add(id);
                fishRecordData.Items.Add(min);
                fishRecordData.Items.Add(max);
                fishRecordData.Items.Add(stamp);

                fishRecordHBox.Items.Add(fishRecordList);
                fishRecordHBox.Items.Add(fishRecordData);

                fishRecord.Content = fishRecordHBox;
            }

            var vBox = new VBox();
            vBox.Items.Add(fishRecord);
            var scroll = new Scrollable();
            scroll.Content = vBox;

            Content = scroll;
        }
    }
}