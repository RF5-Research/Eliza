using Eliza.Model.SaveData;
using Eliza.UI.Helpers;
using Eliza.UI.Widgets;
using Eto.Forms;
using System;

namespace Eliza.UI.Forms
{
    internal class FurnitureDataForm : Form
    {
        public FurnitureDataForm(RF5FurnitureData furnitureData)
        {
            Title = "Furniture Data";

            var unk1 = new SpinBox(
                new Ref<int>(() => furnitureData.Unk1, v => { furnitureData.Unk1 = v; }),
                "Unk 1"
            );
            var unk2 = new SpinBox(
                new Ref<int>(() => furnitureData.Unk2, v => { furnitureData.Unk2 = v; }),
                "Unk 2"
            );

            var furnitureSaveData = new GroupBox()
            {
                Text = "Furniture Save Data"
            };

            {
                var furnitureSaveDataList = new ListBox();
                var furnitureSaveDataHBox = new HBox();
                var furnitureSaveDataData = new VBox();

                for (int i = 0; i < furnitureData.FurnitureSaveData.Count; i++)
                {
                    furnitureSaveDataList.Items.Add($"Furniture {i}");
                }

                var pos = new Vector3Group("Pos");
                var rot = new QuaternionGroup("Rot");
                var sceneId = new SpinBox("Scene ID");
                var id = new SpinBox("ID");
                var uniqueId = new LineEdit("Unique ID");
                var point = new SpinBox("Point");
                var hp = new SpinBox("HP");
                var have = new Widgets.CheckBox("Have");

                furnitureSaveDataList.SelectedIndexChanged += (object sender, EventArgs e) =>
                {
                    pos.ChangeReferenceValue(
                        new Ref<float>(() => furnitureData.FurnitureSaveData[furnitureSaveDataList.SelectedIndex].Pos.X, v => { furnitureData.FurnitureSaveData[furnitureSaveDataList.SelectedIndex].Pos.X = v; }),
                        new Ref<float>(() => furnitureData.FurnitureSaveData[furnitureSaveDataList.SelectedIndex].Pos.Y, v => { furnitureData.FurnitureSaveData[furnitureSaveDataList.SelectedIndex].Pos.Y = v; }),
                        new Ref<float>(() => furnitureData.FurnitureSaveData[furnitureSaveDataList.SelectedIndex].Pos.Z, v => { furnitureData.FurnitureSaveData[furnitureSaveDataList.SelectedIndex].Pos.Z = v; })
                    );
                    rot.ChangeReferenceValue(
                        new Ref<float>(() => furnitureData.FurnitureSaveData[furnitureSaveDataList.SelectedIndex].Rot.W, v => { furnitureData.FurnitureSaveData[furnitureSaveDataList.SelectedIndex].Rot.W = v; }),
                        new Ref<float>(() => furnitureData.FurnitureSaveData[furnitureSaveDataList.SelectedIndex].Rot.X, v => { furnitureData.FurnitureSaveData[furnitureSaveDataList.SelectedIndex].Rot.X = v; }),
                        new Ref<float>(() => furnitureData.FurnitureSaveData[furnitureSaveDataList.SelectedIndex].Rot.Y, v => { furnitureData.FurnitureSaveData[furnitureSaveDataList.SelectedIndex].Rot.Y = v; }),
                        new Ref<float>(() => furnitureData.FurnitureSaveData[furnitureSaveDataList.SelectedIndex].Rot.Z, v => { furnitureData.FurnitureSaveData[furnitureSaveDataList.SelectedIndex].Rot.Z = v; })
                    );
                    sceneId.ChangeReferenceValue(
                        new Ref<int>(() => furnitureData.FurnitureSaveData[furnitureSaveDataList.SelectedIndex].SceneId, v => { furnitureData.FurnitureSaveData[furnitureSaveDataList.SelectedIndex].SceneId = v; })
                    );
                    id.ChangeReferenceValue(
                        new Ref<int>(() => furnitureData.FurnitureSaveData[furnitureSaveDataList.SelectedIndex].Id, v => { furnitureData.FurnitureSaveData[furnitureSaveDataList.SelectedIndex].Id = v; })
                    );
                    uniqueId.ChangeReferenceValue(
                        new Ref<string>(() => furnitureData.FurnitureSaveData[furnitureSaveDataList.SelectedIndex].UniqueId, v => { furnitureData.FurnitureSaveData[furnitureSaveDataList.SelectedIndex].UniqueId = v; })
                    );
                    point.ChangeReferenceValue(
                        new Ref<int>(() => furnitureData.FurnitureSaveData[furnitureSaveDataList.SelectedIndex].Point, v => { furnitureData.FurnitureSaveData[furnitureSaveDataList.SelectedIndex].Point = v; })
                    );
                    hp.ChangeReferenceValue(
                        new Ref<int>(() => furnitureData.FurnitureSaveData[furnitureSaveDataList.SelectedIndex].Hp, v => { furnitureData.FurnitureSaveData[furnitureSaveDataList.SelectedIndex].Hp = v; })
                    );
                    have.ChangeReferenceValue(
                        new Ref<bool>(() => furnitureData.FurnitureSaveData[furnitureSaveDataList.SelectedIndex].Have, v => { furnitureData.FurnitureSaveData[furnitureSaveDataList.SelectedIndex].Have = v; })
                    );
                };

                StackLayoutItem[] furnitureSaveDataDataItems =
                {
                    pos,
                    rot,
                    sceneId,
                    id,
                    uniqueId,
                    point,
                    hp,
                    have
                };

                foreach (var item in furnitureSaveDataDataItems)
                {
                    furnitureSaveDataData.Items.Add(item);
                }

                furnitureSaveDataHBox.Items.Add(furnitureSaveDataList);
                furnitureSaveDataHBox.Items.Add(furnitureSaveDataData);

                furnitureSaveData.Content = furnitureSaveDataHBox;
            }

            var vBox = new VBox();

            vBox.Items.Add(unk1);
            vBox.Items.Add(unk2);
            vBox.Items.Add(furnitureSaveData);

            var scroll = new Scrollable();
            scroll.Content = vBox;

            Content = scroll;
        }
    }
}