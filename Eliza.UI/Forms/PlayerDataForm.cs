using Eliza.Model.SaveData;
using Eliza.UI.Helpers;
using Eliza.UI.Widgets;
using Eto.Drawing;
using Eto.Forms;
using System;
using System.Text;

namespace Eliza.UI.Forms
{
    internal class PlayerDataForm : Form
    {
        public PlayerDataForm(RF5PlayerData playerData)
        {
            Title = "Player Data";

            var vBox = new VBox();

            var playerGold = new SpinBox(new Ref<int>(() => playerData.PlayerGold, v => { playerData.PlayerGold = v; }), "Gold");
            var playerName = new LineEdit(new Ref<string>(() => playerData.PlayerName, v => { playerData.PlayerName = v; }), "Name");
            playerName.textBox.TextChanging += (object sender, TextChangingEventArgs e) =>
            {
                var oldLength = Encoding.Unicode.GetBytes(e.OldText).Length;
                var newLength = Encoding.Unicode.GetBytes(e.NewText).Length;

                if (oldLength >= 32 && newLength >= 32)
                {
                    if (oldLength < newLength)
                    {
                        e.Cancel = true;
                    }
                }
                else if (oldLength < 32 && newLength > 32)
                {
                    playerName.textBox.TextColor = Color.FromRgb(0xFF0000);
                    playerName.textBox.ToolTip = "Warning: You have too many characters!";
                }
                else if (oldLength <= 32 && newLength <= 32)
                {
                    playerName.textBox.TextColor = Color.FromRgb(0x000000);
                    playerName.textBox.ToolTip = null;
                }
            };

            var isPlayerMale = new Widgets.CheckBox(new Ref<bool>(() => playerData.IsPlayerMale, v => { playerData.IsPlayerMale = v; }), "Male");
            var isPlayerModelMale = new Widgets.CheckBox(new Ref<bool>(() => playerData.IsPlayerModelMale, v => { playerData.IsPlayerModelMale = v; }), "Male Model");
            var variationNo = new SpinBox(new Ref<int>(() => playerData.VariationNo, v => { playerData.VariationNo = v; }), "Variation Number");
            var playerBirthday = new SpinBox(new Ref<int>(() => playerData.PlayerBirthday, v => { playerData.PlayerBirthday = v; }), "Birthday");
            var marriedNPCID = new SpinBox(new Ref<int>(() => playerData.MarriedNPCID, v => { playerData.MarriedNPCID = v; }), "Married NPC ID");
            var seedPoint = new SpinBox(new Ref<int>(() => playerData.SeedPoint, v => { playerData.SeedPoint = v; }), "Seed Point");
            var policeRank = new SpinBox(new Ref<int>(() => playerData.PoliceRank, v => { playerData.PoliceRank = v; }), "Police Rank");
            var stone = new SpinBox(new Ref<int>(() => playerData.Stone, v => { playerData.Stone = v; }), "Stone");
            var lumber = new SpinBox(new Ref<int>(() => playerData.Lumber, v => { playerData.Lumber = v; }), "Lumber");
            var compost = new SpinBox(new Ref<int>(() => playerData.Compost, v => { playerData.Compost = v; }), "Compost");
            var esa = new SpinBox(new Ref<int>(() => playerData.Esa, v => { playerData.Esa = v; }), "Esa");
            var dailyRecipePan_Bakery = new SpinBox(new Ref<int>(() => playerData.DailyRecipePan_Bakery, v => { playerData.DailyRecipePan_Bakery = v; }), "Daily Recipe Pan Bakery");
            var dailyRecipePan_Restaurant = new SpinBox(new Ref<int>(() => playerData.DailyRecipePan_Restaurant, v => { playerData.DailyRecipePan_Restaurant = v; }), "Daily Recipe Pan Restaurant");
            var bathroomBlocked = new SpinBox(new Ref<int>(() => playerData.BathroomBlocked, v => { playerData.BathroomBlocked = v; }), "Bathroom Blocked");

            //SkillData
            var skillData = new GroupBox()
            {
                Text = "Skill Data"
            };

            {
                var skillDataHBox = new HBox();
                var skillDataList = new ListBox();
                var skillDataData = new VBox();

                var expSpinBox = new SpinBox("Exp");
                var levelSpinBox = new SpinBox("Level");

                var dict = Helpers.Json.Load("Resources/Data/SkillData.json");

                for (int i = 0; i < playerData.SkillDatas.Length; i++)
                {
                    skillDataList.Items.Add((string)dict["Skill"][i]["English"]);
                }

                skillDataList.SelectedIndexChanged += (object sender, EventArgs e) =>
                {
                    expSpinBox.ChangeReferenceValue(new Ref<int>(() => playerData.SkillDatas[skillDataList.SelectedIndex].Exp, v => { playerData.SkillDatas[skillDataList.SelectedIndex].Exp = v; }));
                    levelSpinBox.ChangeReferenceValue(new Ref<int>(() => playerData.SkillDatas[skillDataList.SelectedIndex].Level, v => { playerData.SkillDatas[skillDataList.SelectedIndex].Level = v; }));
                };

                StackLayoutItem[] skillDataDataItems =
                {
                    expSpinBox,
                    levelSpinBox
                };

                foreach (var item in skillDataDataItems)
                {
                    skillDataData.Items.Add(item);
                }

                StackLayoutItem[] skillDataHBoxItems =
                {
                    skillDataList,
                    skillDataData
                };

                foreach (var item in skillDataHBoxItems)
                {
                    skillDataHBox.Items.Add(item);
                }

                skillData.Content = skillDataHBox;
            }

            var dualSmithActor = new SpinBox(new Ref<int>(() => playerData.DualSmithActor, v => { playerData.DualSmithActor = v; }), "Dual Smith Actor");
            var dualCookActor = new SpinBox(new Ref<int>(() => playerData.DualCookActor, v => { playerData.DualCookActor = v; }), "Dual Cook Actor");
            var dualFishingActor = new SpinBox(new Ref<int>(() => playerData.DualFishingActor, v => { playerData.DualFishingActor = v; }), "Dual Fishing Actor");

            StackLayoutItem[] vBoxItems =
            {
                playerGold,
                playerName,
                isPlayerMale,
                isPlayerModelMale,
                variationNo,
                playerBirthday,
                marriedNPCID,
                seedPoint,
                policeRank,
                stone,
                lumber,
                compost,
                esa,
                dailyRecipePan_Bakery,
                dailyRecipePan_Restaurant,
                bathroomBlocked,
                skillData,
                dualSmithActor,
                dualCookActor,
                dualFishingActor
            };

            foreach (var item in vBoxItems)
            {
                vBox.Items.Add(item);
            }

            var scroll = new Scrollable();
            scroll.Content = vBox;
            Content = scroll;
        }
    }
}