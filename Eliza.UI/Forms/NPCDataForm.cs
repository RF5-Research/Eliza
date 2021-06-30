using Eliza.Model;
using Eliza.Model.SaveData;
using Eliza.UI.Helpers;
using Eliza.UI.Widgets;
using Eto.Forms;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Eliza.UI.Forms
{
    internal class NPCDataForm : Form
    {
        delegate void ListUpdateDelegate();

        public NPCDataForm(RF5NPCData npcData)
        {
            Title = "NPC Data";

            var vBox = new VBox();

            var npcSaveParameters = new GroupBox()
            {
                Text = "NPC Save Parameters"
            };

            {
                var npcSaveParametersList = new ListBox();
                var npcSaveParametersHBox = new HBox();
                var npcSaveParametersData = new VBox();

                var dict = Helpers.Json.Load("Resources/Data/NPCID.json");

                for (int i = 0; i < npcData.NpcSaveParameters.Count; i++)
                {
                    if (i + 2 < dict["NPCID"].Count - 1)
                    {
                        npcSaveParametersList.Items.Add((string)dict["NPCID"][i + 2]["English"]);
                    }
                    else
                    {
                        npcSaveParametersList.Items.Add($"NPC {i}");
                    }
                }

                var savePosition = new Vector3Group("Save Position");
                var saveRotation = new Vector3Group("Save Rotation");
                var forceDisabled = new Widgets.CheckBox("Force Disabled");
                var isShortPlay = new Widgets.CheckBox("Short Play");
                var animationState = new SpinBox("Animation State");
                var animationSitting = new Widgets.CheckBox("Animation Sitting");
                var npcGroupId = new SpinBox("NPC Group ID");
                var currentFieldPlaceId = new SpinBox("Current Field Place ID");
                var currentLifecycleState = new SpinBox("Current Life Cycle State");
                var currentPlace = new SpinBox("CurrentPlace");
                var rotatePatternNumber = new SpinBox("Rotate Pattern Number");
                var isTalking = new Widgets.CheckBox("Talking");
                var todayTalkCount = new SpinBox("Today Talk Count");
                var nowEventId = new SpinBox("NowEventId");
                var home = new SpinBox("Home");
                var job = new SpinBox("Job");
                var isPartner = new Widgets.CheckBox("Partner");
                var isSpouses = new Widgets.CheckBox("Spouses");
                var isLover = new Widgets.CheckBox("Lover");
                var isRefused = new Widgets.CheckBox("Refused");
                var isJealousy = new Widgets.CheckBox("Jealousy");
                var isDateRefrain = new Widgets.CheckBox("Date Refrain");
                var isExclamation = new Widgets.CheckBox("Exclamation");
                var angryStep = new SpinBox("AngryStep");
                var lovePoint = new SpinBox("Love Point");
                var datingNum = new SpinBox("Dating Num");
                var presentCount = new SpinBox("Present Count");
                var nickNameToPlayerId = new SpinBox("Nickname To Player");
                var nickNameFromPlayerId = new SpinBox("Nickname From Player");
                var weddingAnniversary = new SpinBox("Wedding Anniversary");

                var presentItemTypes = new GroupBox()
                {
                    Text = "Present Item Types"
                };

                ListUpdateDelegate presentItemTypesUpdate = delegate () { };
                {
                    var presentItemTypesList = new ListBox();
                    var presentItemTypesHBox = new HBox();
                    var presentItemTypesData = new VBox();

                    if (npcSaveParametersList.SelectedIndex >= 0)
                    {
                        for (int i = 0; i < npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].PresentItemTypes.Count; i++)
                        {
                            presentItemTypesList.Items.Add($"Present Item Type {i}");
                        }
                    }

                    var spinBox = new SpinBox();

                    presentItemTypesList.SelectedIndexChanged += (object sender, EventArgs e) =>
                    {
                        spinBox.ChangeReferenceValue(
                            new Ref<int>(() => npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].PresentItemTypes[presentItemTypesList.SelectedIndex], v => { npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].PresentItemTypes[presentItemTypesList.SelectedIndex] = v; })
                        );
                    };

                    presentItemTypesUpdate = delegate ()
                    {
                        presentItemTypesList.Items.Clear();
                        if (npcSaveParametersList.SelectedIndex >= 0)
                        {
                            for (int i = 0; i < npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].PresentItemTypes.Count; i++)
                            {
                                presentItemTypesList.Items.Add($"Present Item Type {i}");
                            }
                        }
                    };

                    presentItemTypesData.Items.Add(spinBox);

                    presentItemTypesHBox.Items.Add(presentItemTypesList);
                    presentItemTypesHBox.Items.Add(presentItemTypesData);

                    presentItemTypes.Content = presentItemTypesHBox;
                }

                var isVoiceSleepPlayed = new Widgets.CheckBox("Voice Sleep Played");
                var isVoiceGreeted = new Widgets.CheckBox("Voice Greeted");

                var talkedTime = new GroupBox()
                {
                    Text = "Present Item Types"
                };

                ListUpdateDelegate talkedTimeUpdate = delegate () { };
                {
                    var talkedTimeList = new ListBox();
                    var talkedTimeHBox = new HBox();
                    var talkedTimeData = new VBox();

                    if (npcSaveParametersList.SelectedIndex >= 0)
                    {
                        for (int i = 0; i < npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].TalkedTime.Length; i++)
                        {
                            talkedTimeList.Items.Add($"Talked Time {i}");
                        }
                    }

                    var spinBox = new SpinBox();

                    talkedTimeList.SelectedIndexChanged += (object sender, EventArgs e) =>
                    {
                        spinBox.ChangeReferenceValue(
                            new Ref<long>(() => npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].TalkedTime[talkedTimeList.SelectedIndex], v => { npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].TalkedTime[talkedTimeList.SelectedIndex] = v; })
                        );
                    };

                    presentItemTypesUpdate = delegate ()
                    {
                        talkedTimeList.Items.Clear();
                        if (npcSaveParametersList.SelectedIndex >= 0)
                        {
                            for (int i = 0; i < npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].TalkedTime.Length; i++)
                            {
                                talkedTimeList.Items.Add($"Talked Time {i}");
                            }
                        }
                    };

                    talkedTimeData.Items.Add(spinBox);

                    talkedTimeHBox.Items.Add(talkedTimeList);
                    talkedTimeHBox.Items.Add(talkedTimeData);

                    talkedTime.Content = talkedTimeHBox;
                }

                var friendlyMilestoneTalk = new SpinBox("Friendly Milestone Talk");
                var chatTalkLv = new SpinBox("ChatTalkLv");
                var chatTalkCount = new SpinBox("ChatTalkCount");
                var chatTalkLotteryType = new SpinBox("ChatTalkLotteryType");
                var chatTalkLotteryID = new SpinBox("ChatTalkLotteryID");
                var homeTalkedLv = new SpinBox("Home Talked Lv");
                var modelType = new SpinBox("Model Type");
                var loveStroyState = new SpinBox("Love Story State");
                var flowerFesDateNum = new SpinBox("Flower Fes Date Num");
                var isDateReserved = new Widgets.CheckBox("Date Reserved");
                var dateDay = new SpinBox("Date Day");

                npcSaveParametersList.SelectedIndexChanged += (object sender, EventArgs e) =>
                {
                    savePosition.ChangeReferenceValue(
                        new Ref<float>(() => npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].SavePosition.x, v => { npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].SavePosition.x = v; }),
                        new Ref<float>(() => npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].SavePosition.y, v => { npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].SavePosition.y = v; }),
                        new Ref<float>(() => npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].SavePosition.z, v => { npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].SavePosition.z = v; })
                    );
                    saveRotation.ChangeReferenceValue(
                        new Ref<float>(() => npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].SaveRotation.x, v => { npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].SaveRotation.x = v; }),
                        new Ref<float>(() => npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].SaveRotation.y, v => { npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].SaveRotation.y = v; }),
                        new Ref<float>(() => npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].SaveRotation.z, v => { npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].SaveRotation.z = v; })
                    );
                    forceDisabled.ChangeReferenceValue(
                        new Ref<bool>(() => npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].forceDisabled, v => { npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].forceDisabled = v; })
                    );
                    isShortPlay.ChangeReferenceValue(
                        new Ref<bool>(() => npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].isShortPlay, v => { npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].isShortPlay = v; })
                    );
                    animationState.ChangeReferenceValue(
                        new Ref<int>(() => npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].AnimationState, v => { npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].AnimationState = v; })
                    );
                    animationSitting.ChangeReferenceValue(
                        new Ref<bool>(() => npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].AnimationSitting, v => { npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].AnimationSitting = v; })
                    );
                    npcGroupId.ChangeReferenceValue(
                        new Ref<int>(() => npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].NpcGroupId, v => { npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].NpcGroupId = v; })
                    );
                    currentFieldPlaceId.ChangeReferenceValue(
                        new Ref<int>(() => npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].CurrentFieldPlaceId, v => { npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].CurrentFieldPlaceId = v; })
                    );
                    currentLifecycleState.ChangeReferenceValue(
                        new Ref<int>(() => npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].CurrentLifecycleState, v => { npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].CurrentLifecycleState = v; })
                    );
                    currentPlace.ChangeReferenceValue(
                        new Ref<int>(() => npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].CurrentPlace, v => { npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].CurrentPlace = v; })
                    );
                    rotatePatternNumber.ChangeReferenceValue(
                        new Ref<int>(() => npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].RotatePatternNumber, v => { npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].RotatePatternNumber = v; })
                    );
                    isTalking.ChangeReferenceValue(
                        new Ref<bool>(() => npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].IsTalking, v => { npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].IsTalking = v; })
                    );
                    todayTalkCount.ChangeReferenceValue(
                        new Ref<int>(() => npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].TodayTalkCount, v => { npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].TodayTalkCount = v; })
                    );
                    nowEventId.ChangeReferenceValue(
                        new Ref<int>(() => npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].NowEventId, v => { npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].NowEventId = v; })
                    );
                    home.ChangeReferenceValue(
                        new Ref<int>(() => npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].Home, v => { npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].Home = v; })
                    );
                    job.ChangeReferenceValue(
                        new Ref<int>(() => npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].Job, v => { npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].Job = v; })
                    );
                    isPartner.ChangeReferenceValue(
                        new Ref<bool>(() => npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].IsPartner, v => { npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].IsPartner = v; })
                    );
                    isSpouses.ChangeReferenceValue(
                        new Ref<bool>(() => npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].IsSpouses, v => { npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].IsSpouses = v; })
                    );
                    isLover.ChangeReferenceValue(
                        new Ref<bool>(() => npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].IsLover, v => { npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].IsLover = v; })
                    );
                    isRefused.ChangeReferenceValue(
                        new Ref<bool>(() => npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].IsRefused, v => { npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].IsRefused = v; })
                    );
                    isJealousy.ChangeReferenceValue(
                        new Ref<bool>(() => npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].IsJealousy, v => { npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].IsJealousy = v; })
                    );
                    isDateRefrain.ChangeReferenceValue(
                        new Ref<bool>(() => npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].IsDateRefrain, v => { npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].IsDateRefrain = v; })
                    );
                    isExclamation.ChangeReferenceValue(
                        new Ref<bool>(() => npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].IsExclamation, v => { npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].IsExclamation = v; })
                    );
                    angryStep.ChangeReferenceValue(
                        new Ref<int>(() => npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].AngryStep, v => { npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].AngryStep = v; })
                    );
                    lovePoint.ChangeReferenceValue(
                        new Ref<int>(() => npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].LovePoint, v => { npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].LovePoint = v; })
                    );
                    datingNum.ChangeReferenceValue(
                        new Ref<int>(() => npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].DatingNum, v => { npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].DatingNum = v; })
                    );
                    presentCount.ChangeReferenceValue(
                        new Ref<int>(() => npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].PresentCount, v => { npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].PresentCount = v; })
                    );
                    nickNameToPlayerId.ChangeReferenceValue(
                        new Ref<int>(() => npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].NickNameToPlayerId, v => { npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].NickNameToPlayerId = v; })
                    );
                    nickNameFromPlayerId.ChangeReferenceValue(
                        new Ref<int>(() => npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].NickNameFromPlayerId, v => { npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].NickNameFromPlayerId = v; })
                    );
                    weddingAnniversary.ChangeReferenceValue(
                        new Ref<int>(() => npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].WeddingAnniversary, v => { npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].WeddingAnniversary = v; })
                    );
                    presentItemTypesUpdate();
                    isVoiceSleepPlayed.ChangeReferenceValue(
                        new Ref<bool>(() => npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].IsVoiceSleepPlayed, v => { npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].IsVoiceSleepPlayed = v; })
                    );
                    isVoiceGreeted.ChangeReferenceValue(
                        new Ref<bool>(() => npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].IsVoiceGreeted, v => { npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].IsVoiceGreeted = v; })
                    );
                    talkedTimeUpdate();
                    friendlyMilestoneTalk.ChangeReferenceValue(
                        new Ref<int>(() => npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].FriendlyMilestoneTalk, v => { npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].FriendlyMilestoneTalk = v; })
                    );
                    chatTalkLv.ChangeReferenceValue(
                        new Ref<int>(() => npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].ChatTalkLv, v => { npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].ChatTalkLv = v; })
                    );
                    chatTalkCount.ChangeReferenceValue(
                        new Ref<int>(() => npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].ChatTalkCount, v => { npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].ChatTalkCount = v; })
                    );
                    chatTalkLotteryType.ChangeReferenceValue(
                        new Ref<int>(() => npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].ChatTalkLotteryType, v => { npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].ChatTalkLotteryType = v; })
                    );
                    chatTalkLotteryID.ChangeReferenceValue(
                        new Ref<int>(() => npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].ChatTalkLotteryID, v => { npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].ChatTalkLotteryID = v; })
                    );
                    homeTalkedLv.ChangeReferenceValue(
                        new Ref<int>(() => npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].HomeTalkedLv, v => { npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].HomeTalkedLv = v; })
                    );
                    modelType.ChangeReferenceValue(
                        new Ref<int>(() => npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].ModelType, v => { npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].ModelType = v; })
                    );
                    loveStroyState.ChangeReferenceValue(
                        new Ref<int>(() => npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].LoveStroyState, v => { npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].LoveStroyState = v; })
                    );
                    flowerFesDateNum.ChangeReferenceValue(
                        new Ref<int>(() => npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].FlowerFesDateNum, v => { npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].FlowerFesDateNum = v; })
                    );
                    isDateReserved.ChangeReferenceValue(
                        new Ref<bool>(() => npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].IsDateReserved, v => { npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].IsDateReserved = v; })
                    );
                    dateDay.ChangeReferenceValue(
                        new Ref<int>(() => npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].dateDay, v => { npcData.NpcSaveParameters[npcSaveParametersList.SelectedIndex].dateDay = v; })
                    );
                };

                StackLayoutItem[] npcSaveParametersDataItems =
                {
                    savePosition,
                    saveRotation,
                    forceDisabled,
                    isShortPlay,
                    animationState,
                    animationSitting,
                    npcGroupId,
                    currentFieldPlaceId,
                    currentLifecycleState,
                    currentPlace,
                    rotatePatternNumber,
                    isTalking,
                    todayTalkCount,
                    nowEventId,
                    home,
                    job,
                    isPartner,
                    isSpouses,
                    isLover,
                    isRefused,
                    isJealousy,
                    isDateRefrain,
                    isExclamation,
                    angryStep,
                    lovePoint,
                    datingNum,
                    presentCount,
                    nickNameToPlayerId,
                    nickNameFromPlayerId,
                    weddingAnniversary,
                    presentItemTypes,
                    isVoiceSleepPlayed,
                    isVoiceGreeted,
                    talkedTime,
                    friendlyMilestoneTalk,
                    chatTalkLv,
                    chatTalkCount,
                    chatTalkLotteryType,
                    chatTalkLotteryID,
                    homeTalkedLv,
                    modelType,
                    loveStroyState,
                    flowerFesDateNum,
                    isDateReserved,
                    dateDay
                };

                foreach (var item in npcSaveParametersDataItems)
                {
                    npcSaveParametersData.Items.Add(item);
                }

                npcSaveParametersHBox.Items.Add(npcSaveParametersList);
                npcSaveParametersHBox.Items.Add(npcSaveParametersData);
                npcSaveParameters.Content = npcSaveParametersHBox;
            }

            var npcDateSaveParam = new GroupBox()
            {
                Text = "NPC Date Save Param"
            };

            {
                var npcDateSaveParamData = new VBox();

                var progressType = new SpinBox(
                    new Ref<int>(() => npcData.NpcDateSaveParam.ProgressType, v => { npcData.NpcDateSaveParam.ProgressType = v; }),
                    "Progress Type"
                );
                var dateType = new SpinBox(
                    new Ref<int>(() => npcData.NpcDateSaveParam.DateType, v => { npcData.NpcDateSaveParam.DateType = v; }),
                    "Date Type"
                );
                var dateSpotID = new SpinBox(
                    new Ref<int>(() => npcData.NpcDateSaveParam.DateSpotID, v => { npcData.NpcDateSaveParam.DateSpotID = v; }),
                    "Date Spot ID"
                );
                var npcId = new SpinBox(
                    new Ref<int>(() => npcData.NpcDateSaveParam.NpcId, v => { npcData.NpcDateSaveParam.NpcId = v; }),
                    "NPC ID"
                );
                var dateStartTime = new SpinBox(
                    new Ref<int>(() => npcData.NpcDateSaveParam.dateStartTime, v => { npcData.NpcDateSaveParam.dateStartTime = v; }),
                    "Date Start Time"
                );
                var meetingLimitTime = new SpinBox(
                    new Ref<int>(() => npcData.NpcDateSaveParam.meetingLimitTime, v => { npcData.NpcDateSaveParam.meetingLimitTime = v; }),
                    "Meeting Limit Time"
                );
                var meetingEventPointOnFlag = new SpinBox(
                    new Ref<int>(() => npcData.NpcDateSaveParam.meetingEventPointOnFlag, v => { npcData.NpcDateSaveParam.meetingEventPointOnFlag = v; }),
                    "Meeting Event Point On Flag"
                );
                var doSuppo = new Widgets.CheckBox(
                    new Ref<bool>(() => npcData.NpcDateSaveParam.doSuppo, v => { npcData.NpcDateSaveParam.doSuppo = v; }),
                    "Do Support"
                );

                StackLayoutItem[] npcDateSaveParamDataItems =
                {
                    progressType,
                    dateType,
                    dateSpotID,
                    npcId,
                    dateStartTime,
                    meetingLimitTime,
                    meetingEventPointOnFlag,
                    doSuppo
                };

                foreach (var item in npcDateSaveParamDataItems)
                {
                    npcDateSaveParamData.Items.Add(item);
                }

                npcDateSaveParam.Content = npcDateSaveParamData;
            }

            var childSaveData = new GroupBox()
            {
                Text = "Child Save Data"
            };

            {
                var childSaveDataList = new ListBox();
                var childSaveDataData = new VBox();
                var childSaveDataHBox = new HBox();

                for (int i = 0; i < npcData.ChildSaveDatas.ChildDatas.Count; i++)
                {
                    childSaveDataList.Items.Add($"Child {i}");
                }

                var name = new LineEdit("Name");
                var isMale = new Widgets.CheckBox("Male");
                var personality = new SpinBox("Personality");
                var birthday = new SpinBox("Birthday");

                childSaveDataList.SelectedIndexChanged += (object sender, EventArgs e) =>
                {
                    name.ChangeReferenceValue(
                        new Ref<string>(() => npcData.ChildSaveDatas.ChildDatas[childSaveDataList.SelectedIndex].Name, v => { npcData.ChildSaveDatas.ChildDatas[childSaveDataList.SelectedIndex].Name = v; })
                    );
                    isMale.ChangeReferenceValue(
                        new Ref<bool>(() => npcData.ChildSaveDatas.ChildDatas[childSaveDataList.SelectedIndex].IsMale, v => { npcData.ChildSaveDatas.ChildDatas[childSaveDataList.SelectedIndex].IsMale = v; })
                    );
                    personality.ChangeReferenceValue(
                        new Ref<int>(() => npcData.ChildSaveDatas.ChildDatas[childSaveDataList.SelectedIndex].Personality, v => { npcData.ChildSaveDatas.ChildDatas[childSaveDataList.SelectedIndex].Personality = v; })
                    );
                    birthday.ChangeReferenceValue(
                        new Ref<int>(() => npcData.ChildSaveDatas.ChildDatas[childSaveDataList.SelectedIndex].BirthDay, v => { npcData.ChildSaveDatas.ChildDatas[childSaveDataList.SelectedIndex].BirthDay = v; })
                    );
                };

                StackLayoutItem[] childSaveDataItems =
                {
                    name,
                    isMale,
                    personality,
                    birthday
                };

                foreach (var item in childSaveDataItems)
                {
                    childSaveDataData.Items.Add(item);
                }

                childSaveDataHBox.Items.Add(childSaveDataList);
                childSaveDataHBox.Items.Add(childSaveDataData);
                childSaveData.Content = childSaveDataHBox;
            }

            var giveBirthParams = new GroupBox()
            {
                Text = "Give Birth Params"
            };

            {
                var giveBirthParamsData = new VBox();

                var targetdays = new SpinBox(
                    new Ref<int>(() => npcData.GiveBirthParams.Targetdays, v => { npcData.GiveBirthParams.Targetdays = v; }),
                    "Target Days"
                );
                var nowType = new SpinBox(
                    new Ref<int>(() => npcData.GiveBirthParams.NowType, v => { npcData.GiveBirthParams.NowType = v; }),
                    "Now Type"
                );

                giveBirthParamsData.Items.Add(targetdays);
                giveBirthParamsData.Items.Add(nowType);

                giveBirthParams.Content = giveBirthParamsData;
            }

            var npcHatCache = new GroupBox()
            {
                Text = "NPC Hat"
            };

            {
                var npcHatCacheList = new ListBox();
                var npcHatCacheData = new VBox();
                var npcHatCacheHBox = new HBox();

                for (int i = 0; i < npcData.NpcHatCache.Count; i++)
                {
                    npcHatCacheList.Items.Add($"NPC {i}");
                }

                var npcID = new SpinBox("NPC ID");
                var itemData = new ItemStorageDataGroup();

                var key = new List<int>();
                var value = new List<ItemStorageData>();

                foreach (var item in npcData.NpcHatCache)
                {
                    key.Add(item.Key);
                    value.Add(item.Value);
                }

                npcHatCacheList.SelectedIndexChanged += (object sender, EventArgs e) =>
                {

                    npcID.ChangeReferenceValue(
                        new Ref<int>(() => key[npcHatCacheList.SelectedIndex], v => { key[npcHatCacheList.SelectedIndex] = v; })
                    );
                    itemData.ChangeReferenceValue(
                        value[npcHatCacheList.SelectedIndex]
                    );
                };

                npcHatCacheData.Items.Add(npcID);
                npcHatCacheData.Items.Add(itemData);

                npcHatCacheHBox.Items.Add(npcHatCacheList);
                npcHatCacheHBox.Items.Add(npcHatCacheData);

                npcHatCache.Content = npcHatCacheHBox;
            }

            StackLayoutItem[] vBoxItems =
            {
                npcSaveParameters,
                npcDateSaveParam,
                childSaveData,
                giveBirthParams,
                npcHatCache
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