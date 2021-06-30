using Eliza.Model.SaveData;
using Eliza.UI.Helpers;
using Eliza.UI.Widgets;
using Eto.Forms;
using System;

namespace Eliza.UI.Forms
{
    internal class BattleDataForm : Form
    {
        delegate void ListUpdateDelegate();

        public BattleDataForm(RF5BattleData battleData)
        {
            Title = "Battle Data";

            var partyData = new GroupBox()
            {
                Text = "Party Data"
            };

            {
                var partyDataList = new ListBox();
                var partyDataHBox = new HBox();
                var partyDataData = new VBox();

                for (int i = 0; i < battleData.PartyDatas.Length; i++)
                {
                    partyDataList.Items.Add($"Member {i}");
                }

                var partyNo = new SpinBox("Party Number");
                var partyType = new SpinBox("Party Type");
                var actorId = new SpinBox("Actor ID");
                var dataId = new SpinBox("Data ID");

                var statusData = new GroupBox()
                {
                    Text = "Status Data"
                };

                ListUpdateDelegate statusDataUpdate = delegate () { };

                {
                    var statusDataVBox = new VBox();

                    var monsterDataID = new SpinBox("Monster Data ID");
                    var partnerMovementOrder = new SpinBox("Partner Movement Order");

                    statusDataUpdate = delegate ()
                    {
                        monsterDataID.Enabled = false;
                        partnerMovementOrder.Enabled = false;
                        if (battleData.PartyDatas[partyDataList.SelectedIndex].StatusData != null)
                        {
                            monsterDataID.Enabled = true;
                            partnerMovementOrder.Enabled = true;

                            monsterDataID.ChangeReferenceValue(
                                new Ref<int>(() => battleData.PartyDatas[partyDataList.SelectedIndex].StatusData.MonsterDataID, v => { battleData.PartyDatas[partyDataList.SelectedIndex].StatusData.MonsterDataID = v; })
                            );
                            partnerMovementOrder.ChangeReferenceValue(
                                new Ref<int>(() => battleData.PartyDatas[partyDataList.SelectedIndex].StatusData.PartnerMovementOrderType, v => { battleData.PartyDatas[partyDataList.SelectedIndex].StatusData.PartnerMovementOrderType = v; })
                            );
                        }
                    };

                    statusDataVBox.Items.Add(monsterDataID);
                    statusDataVBox.Items.Add(partnerMovementOrder);

                    statusData.Content = statusDataVBox;
                }

                var partyOutTime = new SpinBox("Party Out Time");

                partyDataList.SelectedIndexChanged += (object sender, EventArgs e) =>
                {
                    partyNo.ChangeReferenceValue(
                        new Ref<int>(() => battleData.PartyDatas[partyDataList.SelectedIndex].PartyNo, v => { battleData.PartyDatas[partyDataList.SelectedIndex].PartyNo = v; })
                    );
                    partyType.ChangeReferenceValue(
                        new Ref<int>(() => battleData.PartyDatas[partyDataList.SelectedIndex].PartyType, v => { battleData.PartyDatas[partyDataList.SelectedIndex].PartyType = v; })
                    );
                    actorId.ChangeReferenceValue(
                        new Ref<int>(() => battleData.PartyDatas[partyDataList.SelectedIndex].ActorId, v => { battleData.PartyDatas[partyDataList.SelectedIndex].ActorId = v; })
                    );
                    dataId.ChangeReferenceValue(
                        new Ref<uint>(() => battleData.PartyDatas[partyDataList.SelectedIndex].DataID, v => { battleData.PartyDatas[partyDataList.SelectedIndex].DataID = v; })
                    );
                    statusDataUpdate();
                    partyOutTime.ChangeReferenceValue(
                        new Ref<int>(() => battleData.PartyDatas[partyDataList.SelectedIndex].PartyOutTime, v => { battleData.PartyDatas[partyDataList.SelectedIndex].PartyOutTime = v; })
                    );
                };

                partyDataData.Items.Add(partyNo);
                partyDataData.Items.Add(partyType);
                partyDataData.Items.Add(actorId);
                partyDataData.Items.Add(dataId);
                partyDataData.Items.Add(statusData);
                partyDataData.Items.Add(partyOutTime);

                partyDataHBox.Items.Add(partyDataList);
                partyDataHBox.Items.Add(partyDataData);

                partyData.Content = partyDataHBox;
            }

            var vBox = new VBox();
            vBox.Items.Add(partyData);
            var scroll = new Scrollable();
            scroll.Content = vBox;

            Content = scroll;
        }
    }
}