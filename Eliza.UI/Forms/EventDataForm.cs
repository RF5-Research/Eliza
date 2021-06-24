using Eliza.Model.SaveData;
using Eliza.UI.Widgets;
using Eto.Forms;
using System;

namespace Eliza.UI.Forms
{
    public class EventDataForm : Form
    {
        delegate void ListUpdateDelegate();

        public EventDataForm(RF5EventData eventData)
        {
            Title = "Event Data";

            var scroll = new Scrollable();
            var vBox = new VBox();

            var currentEventId = new SpinBox(new Ref<int>(() => eventData.EventSaveParameter.CurrentEventId, v => { eventData.EventSaveParameter.CurrentEventId = v; }), "Current Event ID");
            var currentEventStep = new SpinBox(new Ref<int>(() => eventData.EventSaveParameter.CurrentEventStep, v => { eventData.EventSaveParameter.CurrentEventStep = v; }), "Current Event Step");
            var isTalking = new Widgets.CheckBox(new Ref<bool>(() => eventData.EventSaveParameter.IsTalking, v => { eventData.EventSaveParameter.IsTalking = v; }), "Talking");
            var selectMenuGroupId = new SpinBox(new Ref<int>(() => eventData.EventSaveParameter.SelectMenuGroupId, v => { eventData.EventSaveParameter.SelectMenuGroupId = v; }), "Select Menu Group ID");
            var isSelectMenu = new Widgets.CheckBox(new Ref<bool>(() => eventData.EventSaveParameter.IsSelectMenu, v => { eventData.EventSaveParameter.IsSelectMenu = v; }), "Select Menu");
            var targetNpcId = new SpinBox(new Ref<int>(() => eventData.EventSaveParameter.TargetNpcId, v => { eventData.EventSaveParameter.TargetNpcId = v; }), "Target NPC ID");

            //OrderNpcIds
            var orderNpcIds = new GroupBox()
            {
                Text = "Order NPC IDs"
            };

            {
                var orderNpcIdsHBox = new HBox();
                var orderNpcIdsList = new ListBox();
                var orderNpcIdsData = new VBox();

                if (eventData.EventSaveParameter.OrderNpcIds != null)
                {
                    for (int i = 0; i < eventData.EventSaveParameter.OrderNpcIds.Length; i++)
                    {
                        orderNpcIdsList.Items.Add($"Order NPC ID {i}");
                    }
                }

                var orderNpcIdSpinBox = new SpinBox("NPC ID");
                orderNpcIdsList.SelectedIndexChanged += (object sender, EventArgs e) =>
                {
                    orderNpcIdSpinBox.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.OrderNpcIds[orderNpcIdsList.SelectedIndex], v => { eventData.EventSaveParameter.OrderNpcIds[orderNpcIdsList.SelectedIndex] = v; }));
                };

                StackLayoutItem[] orderNpcIdsDataItems =
                {
                    orderNpcIdSpinBox
                };

                foreach (var item in orderNpcIdsDataItems)
                {
                    orderNpcIdsData.Items.Add(item);
                }

                StackLayoutItem[] orderNpcIdsHBoxItems =
                {
                    orderNpcIdsList,
                    orderNpcIdsData
                };

                foreach (var item in orderNpcIdsHBoxItems)
                {
                    orderNpcIdsHBox.Items.Add(item);
                }

                orderNpcIds.Content = orderNpcIdsHBox;
            }

            var forceScriptName = new LineEdit(new Ref<string>(() => eventData.EventSaveParameter.ForceScriptName, v => { eventData.EventSaveParameter.ForceScriptName = v; }), "Force Script Name");
            var forceEvent = new Widgets.CheckBox(new Ref<bool>(() => eventData.EventSaveParameter.ForceEvent, v => { eventData.EventSaveParameter.ForceEvent = v; }), "Force Event");
            var orderOccuredId = new SpinBox(new Ref<int>(() => eventData.EventSaveParameter.orderOccuredId, v => { eventData.EventSaveParameter.orderOccuredId = v; }), "Order Occured ID");

            // Need to finish EventScheduleData
            //EventScheduleData
            var eventScheduleDatas  = new GroupBox()
            {
                Text = "Event Schedule Data"
            };

            {
                var eventScheduleDatasHBox = new HBox();
                var eventScheduleDatasList = new ListBox();
                eventScheduleDatasList.Width = 200;
                var eventScheduleDatasData = new VBox();

                if (eventData.EventSaveParameter.EventScheduleDatas != null)
                {
                    for (int i = 0; i < eventData.EventSaveParameter.EventScheduleDatas.Length; i++)
                    {
                        eventScheduleDatasList.Items.Add($"Event Schedule Data {i}");
                    }
                }

                var eventID = new SpinBox("Event ID");
                var eventStep = new SpinBox("Event Step");

                //StartTime
                var startTime = new GroupBox()
                {
                    Text = "Start Time"
                };

                ListUpdateDelegate startTimerUpdate = delegate() { };

                {
                    var startTimeHBox = new HBox();
                    var startTimeList = new ListBox();
                    var startTimeData = new VBox();

                    if (
                        eventScheduleDatasList.SelectedIndex < eventData.EventSaveParameter.EventScheduleDatas.Length && eventScheduleDatasList.SelectedIndex >= 0 &&
                        eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].StartTime != null
                    )
                    {
                        for (int i = 0; i < eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].StartTime.Length; i++)
                        {
                            startTimeList.Items.Add($"Start Time {i}");
                        }
                    }

                    var year = new SpinBox("Year");
                    var season = new SpinBox("Season");
                    var week = new SpinBox("Week");
                    var day = new SpinBox("Day");
                    var hour = new SpinBox("Hour");
                    var minutes = new SpinBox("Minutes");
                    var timezone = new SpinBox("Timezone");
                    var weather = new SpinBox("Weather");

                    year.numericStepper.Enabled = false;
                    season.numericStepper.Enabled = false;
                    week.numericStepper.Enabled = false;
                    day.numericStepper.Enabled = false;
                    hour.numericStepper.Enabled = false;
                    minutes.numericStepper.Enabled = false;
                    timezone.numericStepper.Enabled = false;
                    weather.numericStepper.Enabled = false;

                    startTimeList.SelectedIndexChanged += (object sender, EventArgs e) =>
                    {
                        year.numericStepper.Enabled = true;
                        season.numericStepper.Enabled = true;
                        week.numericStepper.Enabled = true;
                        day.numericStepper.Enabled = true;
                        hour.numericStepper.Enabled = true;
                        minutes.numericStepper.Enabled = true;
                        timezone.numericStepper.Enabled = true;
                        weather.numericStepper.Enabled = true;

                        year.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].StartTime[startTimeList.SelectedIndex].Year, v => { eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].StartTime[startTimeList.SelectedIndex].Year = v; }));
                        season.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].StartTime[startTimeList.SelectedIndex].Season, v => { eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].StartTime[startTimeList.SelectedIndex].Season = v; }));
                        week.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].StartTime[startTimeList.SelectedIndex].Week, v => { eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].StartTime[startTimeList.SelectedIndex].Week = v; }));
                        day.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].StartTime[startTimeList.SelectedIndex].Day, v => { eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].StartTime[startTimeList.SelectedIndex].Day = v; }));
                        hour.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].StartTime[startTimeList.SelectedIndex].Hour, v => { eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].StartTime[startTimeList.SelectedIndex].Hour = v; }));
                        minutes.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].StartTime[startTimeList.SelectedIndex].Minutes, v => { eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].StartTime[startTimeList.SelectedIndex].Minutes = v; }));
                        timezone.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].StartTime[startTimeList.SelectedIndex].TimeZone, v => { eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].StartTime[startTimeList.SelectedIndex].TimeZone = v; }));
                        weather.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].StartTime[startTimeList.SelectedIndex].Weather, v => { eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].StartTime[startTimeList.SelectedIndex].Weather = v; }));
                    };


                    startTimerUpdate = delegate ()
                    {
                        startTimeList.Items.Clear();
                        year.numericStepper.Enabled = false;
                        season.numericStepper.Enabled = false;
                        week.numericStepper.Enabled = false;
                        day.numericStepper.Enabled = false;
                        hour.numericStepper.Enabled = false;
                        minutes.numericStepper.Enabled = false;
                        timezone.numericStepper.Enabled = false;
                        weather.numericStepper.Enabled = false;

                        if (
                            eventScheduleDatasList.SelectedIndex < eventData.EventSaveParameter.EventScheduleDatas.Length && eventScheduleDatasList.SelectedIndex >= 0 &&
                            eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].StartTime != null
                        )
                        {
                            for (int i = 0; i < eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].StartTime.Length; i++)
                            {
                                startTimeList.Items.Add($"Start Time {i}");
                            }
                        }
                    };

                    StackLayoutItem[] startTimeDataItems =
                    {
                        year,
                        season,
                        week,
                        day,
                        hour,
                        minutes,
                        timezone,
                        weather
                    };

                    foreach (var item in startTimeDataItems)
                    {
                        startTimeData.Items.Add(item);
                    }

                    StackLayoutItem[] startTimeHBoxItems =
                    {
                        startTimeList,
                        startTimeData
                    };

                    foreach (var item in startTimeHBoxItems)
                    {
                        startTimeHBox.Items.Add(item);
                    }

                    startTime.Content = startTimeHBox;
                }

                //EndTime
                var endTime = new GroupBox()
                {
                    Text = "End Time"
                };

                ListUpdateDelegate endTimerUpdate = delegate () { };

                {
                    var endTimeHBox = new HBox();
                    var endTimeList = new ListBox();
                    var endTimeData = new VBox();

                    if (
                        eventScheduleDatasList.SelectedIndex < eventData.EventSaveParameter.EventScheduleDatas.Length && eventScheduleDatasList.SelectedIndex >= 0 &&
                        eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].StartTime != null
                    )
                    {
                        for (int i = 0; i < eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].StartTime.Length; i++)
                        {
                            endTimeList.Items.Add($"End Time {i}");
                        }
                    }

                    var year = new SpinBox("Year");
                    var season = new SpinBox("Season");
                    var week = new SpinBox("Week");
                    var day = new SpinBox("Day");
                    var hour = new SpinBox("Hour");
                    var minutes = new SpinBox("Minutes");
                    var timezone = new SpinBox("Timezone");
                    var weather = new SpinBox("Weather");

                    year.numericStepper.Enabled = false;
                    season.numericStepper.Enabled = false;
                    week.numericStepper.Enabled = false;
                    day.numericStepper.Enabled = false;
                    hour.numericStepper.Enabled = false;
                    minutes.numericStepper.Enabled = false;
                    timezone.numericStepper.Enabled = false;
                    weather.numericStepper.Enabled = false;

                    endTimeList.SelectedIndexChanged += (object sender, EventArgs e) =>
                    {
                        year.numericStepper.Enabled = true;
                        season.numericStepper.Enabled = true;
                        week.numericStepper.Enabled = true;
                        day.numericStepper.Enabled = true;
                        hour.numericStepper.Enabled = true;
                        minutes.numericStepper.Enabled = true;
                        timezone.numericStepper.Enabled = true;
                        weather.numericStepper.Enabled = true;

                        year.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].EndTime[endTimeList.SelectedIndex].Year, v => { eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].EndTime[endTimeList.SelectedIndex].Year = v; }));
                        season.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].EndTime[endTimeList.SelectedIndex].Season, v => { eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].EndTime[endTimeList.SelectedIndex].Season = v; }));
                        week.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].EndTime[endTimeList.SelectedIndex].Week, v => { eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].EndTime[endTimeList.SelectedIndex].Week = v; }));
                        day.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].EndTime[endTimeList.SelectedIndex].Day, v => { eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].EndTime[endTimeList.SelectedIndex].Day = v; }));
                        hour.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].EndTime[endTimeList.SelectedIndex].Hour, v => { eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].EndTime[endTimeList.SelectedIndex].Hour = v; }));
                        minutes.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].EndTime[endTimeList.SelectedIndex].Minutes, v => { eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].EndTime[endTimeList.SelectedIndex].Minutes = v; }));
                        timezone.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].EndTime[endTimeList.SelectedIndex].TimeZone, v => { eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].EndTime[endTimeList.SelectedIndex].TimeZone = v; }));
                        weather.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].EndTime[endTimeList.SelectedIndex].Weather, v => { eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].EndTime[endTimeList.SelectedIndex].Weather = v; }));
                    };


                    endTimerUpdate = delegate ()
                    {
                        endTimeList.Items.Clear();
                        year.numericStepper.Enabled = false;
                        season.numericStepper.Enabled = false;
                        week.numericStepper.Enabled = false;
                        day.numericStepper.Enabled = false;
                        hour.numericStepper.Enabled = false;
                        minutes.numericStepper.Enabled = false;
                        timezone.numericStepper.Enabled = false;
                        weather.numericStepper.Enabled = false;

                        if (
                            eventScheduleDatasList.SelectedIndex < eventData.EventSaveParameter.EventScheduleDatas.Length && eventScheduleDatasList.SelectedIndex >= 0 &&
                            eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].EndTime != null
                        )
                        {
                            for (int i = 0; i < eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].EndTime.Length; i++)
                            {
                                endTimeList.Items.Add($"End Time {i}");
                            }
                        }
                    };

                    StackLayoutItem[] endTimeDataItems =
                    {
                        year,
                        season,
                        week,
                        day,
                        hour,
                        minutes,
                        timezone,
                        weather
                    };

                    foreach (var item in endTimeDataItems)
                    {
                        endTimeData.Items.Add(item);
                    }

                    StackLayoutItem[] endTimeHBoxItems =
                    {
                        endTimeList,
                        endTimeData
                    };

                    foreach (var item in endTimeHBoxItems)
                    {
                        endTimeHBox.Items.Add(item);
                    }

                    endTime.Content = endTimeHBox;
                }

                var joinNpcNumMin = new SpinBox("Min Joining NPC");
                var joinNpcNumMax = new SpinBox("Max Joining NPC");


                //JoinNpcs
                var joinNpcs = new GroupBox()
                {
                    Text = "Join NPCs"
                };

                ListUpdateDelegate joinNpcsUpdate = delegate () { };

                {
                    var joinNpcsHBox = new HBox();
                    var joinNpcsList = new ListBox();
                    var joinNpcsData = new VBox();

                    if (
                        eventScheduleDatasList.SelectedIndex < eventData.EventSaveParameter.EventScheduleDatas.Length && eventScheduleDatasList.SelectedIndex >= 0 &&
                        eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].JoinNpcs != null
                    )
                    {
                        for (int i = 0; i < eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].JoinNpcs.Length; i++)
                        {
                            joinNpcsList.Items.Add($"Join NPC {i}");
                        }
                    }

                    var dataHBox = new HBox();

                    ListUpdateDelegate dataUpdate = delegate () { };
                    {
                        var dataVBox = new VBox();
                        var dataList = new ListBox();

                        if (
                            eventScheduleDatasList.SelectedIndex < eventData.EventSaveParameter.EventScheduleDatas.Length && eventScheduleDatasList.SelectedIndex >= 0 &&
                            eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].JoinNpcs != null &&
                            joinNpcsList.SelectedIndex < eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].JoinNpcs.Length && joinNpcsList.SelectedIndex >= 0 &&
                            eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].JoinNpcs[joinNpcsList.SelectedIndex].datas != null
                        )
                        {
                            for (int i = 0; i < eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].JoinNpcs[joinNpcsList.SelectedIndex].datas.Length; i++)
                            {
                                dataList.Items.Add($"Data {i}");
                            }
                        }

                        var data = new SpinBox("Data");

                        dataList.SelectedIndexChanged += (object sender, EventArgs e) =>
                        {
                            data.Enabled = true;
                            data.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].JoinNpcs[joinNpcsList.SelectedIndex].datas[dataList.SelectedIndex], v => { eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].JoinNpcs[joinNpcsList.SelectedIndex].datas[dataList.SelectedIndex] = v; }));
                        };

                        dataUpdate = delegate ()
                        {
                            dataList.Items.Clear();
                            data.Enabled = false;
                            if (
                                eventScheduleDatasList.SelectedIndex < eventData.EventSaveParameter.EventScheduleDatas.Length && eventScheduleDatasList.SelectedIndex >= 0 &&
                                eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].JoinNpcs != null &&
                                joinNpcsList.SelectedIndex < eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].JoinNpcs.Length && joinNpcsList.SelectedIndex >= 0 &&
                                eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].JoinNpcs[joinNpcsList.SelectedIndex].datas != null
                            )
                            {
                                for (int i = 0; i < eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].JoinNpcs[joinNpcsList.SelectedIndex].datas.Length; i++)
                                {
                                    dataList.Items.Add($"Data {i}");
                                }
                            }
                        };

                        dataVBox.Items.Add(data);

                        dataHBox.Items.Add(dataList);
                        dataHBox.Items.Add(dataVBox);
                    }

                    joinNpcsList.SelectedIndexChanged += (object sender, EventArgs e) =>
                    {
                        dataUpdate();
                    };

                    joinNpcsUpdate = delegate ()
                    {
                        joinNpcsList.Items.Clear();
                        if (
                            eventScheduleDatasList.SelectedIndex < eventData.EventSaveParameter.EventScheduleDatas.Length && eventScheduleDatasList.SelectedIndex >= 0 &&
                            eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].JoinNpcs != null
                        )
                        {
                            for (int i = 0; i < eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].JoinNpcs.Length; i++)
                            {
                                joinNpcsList.Items.Add($"Join NPC {i}");
                            }
                        }
                        dataUpdate();
                    };

                    joinNpcsData.Items.Add(dataHBox);

                    joinNpcsHBox.Items.Add(joinNpcsList);
                    joinNpcsHBox.Items.Add(joinNpcsData);

                    joinNpcs.Content = joinNpcsHBox;
                }

                //JoinRateNpcs
                var joinRateNpcs = new GroupBox()
                {
                    Text = "Join Rate NPCs"
                };

                ListUpdateDelegate joinRateNpcsUpdate = delegate () { };

                {
                    var joinRateNpcsHBox = new HBox();
                    var joinRateNpcsList = new ListBox();
                    var joinRateNpcsData = new VBox();

                    if (
                        eventScheduleDatasList.SelectedIndex < eventData.EventSaveParameter.EventScheduleDatas.Length && eventScheduleDatasList.SelectedIndex >= 0 &&
                        eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].JoinRateNpcs != null
                    )
                    {
                        for (int i = 0; i < eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].JoinRateNpcs.Length; i++)
                        {
                            joinRateNpcsList.Items.Add($"Join NPC {i}");
                        }
                    }

                    var dataHBox = new HBox();

                    ListUpdateDelegate dataUpdate = delegate () { };
                    {
                        var dataVBox = new VBox();
                        var dataList = new ListBox();

                        if (
                            eventScheduleDatasList.SelectedIndex < eventData.EventSaveParameter.EventScheduleDatas.Length && eventScheduleDatasList.SelectedIndex >= 0 &&
                            eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].JoinRateNpcs != null &&
                            joinRateNpcsList.SelectedIndex < eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].JoinRateNpcs.Length && joinRateNpcsList.SelectedIndex >= 0 &&
                            eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].JoinRateNpcs[joinRateNpcsList.SelectedIndex].datas != null
                        )
                        {
                            for (int i = 0; i < eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].JoinRateNpcs[joinRateNpcsList.SelectedIndex].datas.Length; i++)
                            {
                                dataList.Items.Add($"Data {i}");
                            }
                        }

                        var data = new SpinBox("Data");

                        dataList.SelectedIndexChanged += (object sender, EventArgs e) =>
                        {
                            data.Enabled = true;
                            data.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].JoinRateNpcs[joinRateNpcsList.SelectedIndex].datas[dataList.SelectedIndex], v => { eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].JoinRateNpcs[joinRateNpcsList.SelectedIndex].datas[dataList.SelectedIndex] = v; }));
                        };

                        dataUpdate = delegate ()
                        {
                            dataList.Items.Clear();
                            data.Enabled = false;
                            if (
                                eventScheduleDatasList.SelectedIndex < eventData.EventSaveParameter.EventScheduleDatas.Length && eventScheduleDatasList.SelectedIndex >= 0 &&
                                eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].JoinRateNpcs != null &&
                                joinRateNpcsList.SelectedIndex < eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].JoinRateNpcs.Length && joinRateNpcsList.SelectedIndex >= 0 &&
                                eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].JoinRateNpcs[joinRateNpcsList.SelectedIndex].datas != null
                            )
                            {
                                for (int i = 0; i < eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].JoinRateNpcs[joinRateNpcsList.SelectedIndex].datas.Length; i++)
                                {
                                    dataList.Items.Add($"Data {i}");
                                }
                            }
                        };

                        dataVBox.Items.Add(data);

                        dataHBox.Items.Add(dataList);
                        dataHBox.Items.Add(dataVBox);
                    }

                    joinRateNpcsList.SelectedIndexChanged += (object sender, EventArgs e) =>
                    {
                        dataUpdate();
                    };

                    joinRateNpcsUpdate = delegate ()
                    {
                        joinRateNpcsList.Items.Clear();
                        if (
                            eventScheduleDatasList.SelectedIndex < eventData.EventSaveParameter.EventScheduleDatas.Length && eventScheduleDatasList.SelectedIndex >= 0 &&
                            eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].JoinRateNpcs != null
                        )
                        {
                            for (int i = 0; i < eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].JoinRateNpcs.Length; i++)
                            {
                                joinRateNpcsList.Items.Add($"Join Rate NPC {i}");
                            }
                        }
                        dataUpdate();
                    };

                    joinRateNpcsData.Items.Add(dataHBox);

                    joinRateNpcsHBox.Items.Add(joinRateNpcsList);
                    joinRateNpcsHBox.Items.Add(joinRateNpcsData);

                    joinRateNpcs.Content = joinRateNpcsHBox;
                }

                //DecideJoinNpcsData
                var decideJoinNpcsData = new GroupBox()
                {
                    Text = "Decide Join NPCs"
                };

                ListUpdateDelegate decideJoinNpcsDataUpdate = delegate () { };

                {
                    var decideJoinNpcsDataHBox = new HBox();
                    var decideJoinNpcsDataList = new ListBox();
                    var decideJoinNpcsDataData = new VBox();

                    if (
                        eventScheduleDatasList.SelectedIndex < eventData.EventSaveParameter.EventScheduleDatas.Length && eventScheduleDatasList.SelectedIndex >= 0 &&
                        eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].JoinRateNpcs != null
                        )
                    {
                        for (int i = 0; i < eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].DecideJoinNpcs.Count; i++)
                        {
                            decideJoinNpcsDataList.Items.Add($"Decide Join NPCs {i}");
                        }
                    }

                    var decideJoinNpcsDataSpinBox = new SpinBox("Decide Join NPCs");
                    decideJoinNpcsDataList.SelectedIndexChanged += (object sender, EventArgs e) =>
                    {
                        decideJoinNpcsDataSpinBox.Enabled = true;
                        decideJoinNpcsDataSpinBox.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].DecideJoinNpcs[decideJoinNpcsDataList.SelectedIndex], v => { eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].DecideJoinNpcs[decideJoinNpcsDataList.SelectedIndex] = v; }));
                    };

                    decideJoinNpcsDataUpdate = delegate ()
                    {
                        decideJoinNpcsDataList.Items.Clear();
                        decideJoinNpcsDataSpinBox.Enabled = false;
                        if (
                            eventScheduleDatasList.SelectedIndex < eventData.EventSaveParameter.EventScheduleDatas.Length && eventScheduleDatasList.SelectedIndex >= 0 &&
                            eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].JoinRateNpcs != null
                        )
                        {
                            for (int i = 0; i < eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].DecideJoinNpcs.Count; i++)
                            {
                                decideJoinNpcsDataList.Items.Add($"Decide Join NPCs {i}");
                            }
                        }
                    };
                    StackLayoutItem[] decideJoinNpcsDataDataItems =
                    {
                        decideJoinNpcsDataSpinBox
                    };

                    foreach (var item in decideJoinNpcsDataDataItems)
                    {
                        decideJoinNpcsDataData.Items.Add(item);
                    }

                    StackLayoutItem[] decideJoinNpcsDataHBoxItems =
                    {
                        decideJoinNpcsDataList,
                        decideJoinNpcsDataData
                    };

                    foreach (var item in decideJoinNpcsDataHBoxItems)
                    {
                        decideJoinNpcsDataHBox.Items.Add(item);
                    }

                    decideJoinNpcsData.Content = decideJoinNpcsDataHBox;
                }

                //NpcScoreResultsData
                var npcScoreResultsData = new GroupBox()
                {
                    Text = "NPC Score Results"
                };

                ListUpdateDelegate npcScoreResultsDataUpdate = delegate () { };

                {
                    var npcScoreResultsDataHBox = new HBox();
                    var npcScoreResultsDataList = new ListBox();
                    var npcScoreResultsDataData = new VBox();

                    if (
                            eventScheduleDatasList.SelectedIndex < eventData.EventSaveParameter.EventScheduleDatas.Length && eventScheduleDatasList.SelectedIndex >= 0 &&
                            eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].JoinRateNpcs != null
                        )
                    {
                        for (int i = 0; i < eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].NpcScoreResults.Count; i++)
                        {
                            npcScoreResultsDataList.Items.Add($"NPC Score Results {i}");
                        }
                    }

                    var npcScoreResultsDataSpinBox = new SpinBox("NPC Score Results");
                    npcScoreResultsDataList.SelectedIndexChanged += (object sender, EventArgs e) =>
                    {
                        npcScoreResultsDataSpinBox.Enabled = true;
                        npcScoreResultsDataSpinBox.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].NpcScoreResults[npcScoreResultsDataList.SelectedIndex], v => { eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].NpcScoreResults[npcScoreResultsDataList.SelectedIndex] = v; }));
                    };

                    npcScoreResultsDataUpdate = delegate ()
                    {
                        npcScoreResultsDataList.Items.Clear();
                        npcScoreResultsDataSpinBox.Enabled = false;
                        if (
                            eventScheduleDatasList.SelectedIndex < eventData.EventSaveParameter.EventScheduleDatas.Length && eventScheduleDatasList.SelectedIndex >= 0 &&
                            eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].JoinRateNpcs != null
                        )
                        {
                            for (int i = 0; i < eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].NpcScoreResults.Count; i++)
                            {
                                npcScoreResultsDataList.Items.Add($"NPC Score Results {i}");
                            }
                        }
                    };
                    StackLayoutItem[] npcScoreResultsDataDataItems =
                    {
                        npcScoreResultsDataSpinBox
                    };

                    foreach (var item in npcScoreResultsDataDataItems)
                    {
                        npcScoreResultsDataData.Items.Add(item);
                    }

                    StackLayoutItem[] npcScoreResultsDataHBoxItems =
                    {
                        npcScoreResultsDataList,
                        npcScoreResultsDataData
                    };

                    foreach (var item in npcScoreResultsDataHBoxItems)
                    {
                        npcScoreResultsDataHBox.Items.Add(item);
                    }

                    npcScoreResultsData.Content = npcScoreResultsDataHBox;
                }

                //NpcEventDatas
                var npcEventDatas = new GroupBox()
                {
                    Text = "NPC Event Datas"
                };

                ListUpdateDelegate npcEventDatasUpdate = delegate () { };

                {
                    var npcEventDatasHBox = new HBox();
                    var npcEventDatasList = new ListBox();
                    var npcEventDatasData = new VBox();

                    if (
                        eventScheduleDatasList.SelectedIndex < eventData.EventSaveParameter.EventScheduleDatas.Length && eventScheduleDatasList.SelectedIndex >= 0 &&
                        eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].StartTime != null
                    )
                    {
                        for (int i = 0; i < eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].NpcEventDatas.Length; i++)
                        {
                            npcEventDatasList.Items.Add($"NPC Event Data {i}");
                        }
                    }

                    var eventId = new SpinBox("Event ID");
                    var eventState = new SpinBox("Event State");
                    var orderId = new SpinBox("Order ID");
                    var currentStep = new SpinBox("Current Step");
                    var currentReservedStep = new SpinBox("Current Reserved Step");
                    var nextStep = new SpinBox("Next Step");
                    var currentNpcEventType = new SpinBox("Current NPC Event Type");
                    var currentNpcEventPath = new LineEdit("Current NPC Event Path");
                    var currentTargetEventStep = new SpinBox("Current NPC Event Step");

                    //SubEventSteps
                    var subEventSteps = new GroupBox()
                    {
                        Text = "Sub Event Steps"
                    };

                    {
                        var subEventStepsHBox = new HBox();
                        var subEventStepsList = new ListBox();
                        var subEventStepsData = new VBox();

                        if (
                            eventScheduleDatasList.SelectedIndex < eventData.EventSaveParameter.EventScheduleDatas.Length && eventScheduleDatasList.SelectedIndex >= 0 &&
                            eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].NpcEventDatas != null &&
                            npcEventDatasList.SelectedIndex < eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].NpcEventDatas.Length && npcEventDatasList.SelectedIndex >= 0 &&
                            eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].NpcEventDatas[npcEventDatasList.SelectedIndex].SubEventSteps != null
                            )
                        {
                            for (int i = 0; i < eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].NpcEventDatas[npcEventDatasList.SelectedIndex].SubEventSteps.Count; i++)
                            {
                                subEventStepsList.Items.Add($"Sub Event Step {i}");
                            }
                        }

                        var targetEventStep = new SpinBox("Target Event Step");
                        var keepEventStep = new SpinBox("Keep Event Step");
                        //var mainEventStep = new SpinBox("Main Event Step");

                        //mainEventStep.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].NpcEventDatas[npcEventDatasList.SelectedIndex].SubEventSteps[subEventStepsList.SelectedIndex].MainEventSteps, v => { eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].NpcEventDatas[npcEventDatasList.SelectedIndex].SubEventSteps[subEventStepsList.SelectedIndex].MainEventSteps = v; }));


                        subEventStepsList.SelectedIndexChanged += (object sender, EventArgs e) =>
                        {
                            targetEventStep.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].NpcEventDatas[npcEventDatasList.SelectedIndex].SubEventSteps[subEventStepsList.SelectedIndex].TargetEventStep, v => { eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].NpcEventDatas[npcEventDatasList.SelectedIndex].SubEventSteps[subEventStepsList.SelectedIndex].TargetEventStep = v; }));
                            keepEventStep.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].NpcEventDatas[npcEventDatasList.SelectedIndex].SubEventSteps[subEventStepsList.SelectedIndex].KeepEventStep, v => { eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].NpcEventDatas[npcEventDatasList.SelectedIndex].SubEventSteps[subEventStepsList.SelectedIndex].KeepEventStep = v; }));

                        };
                    }

                    npcEventDatasList.SelectedIndexChanged += (object sender, EventArgs e) =>
                    {
                        eventId.numericStepper.Enabled = true;
                        eventState.numericStepper.Enabled = true;
                        orderId.numericStepper.Enabled = true;
                        currentStep.numericStepper.Enabled = true;
                        currentReservedStep.numericStepper.Enabled = true;
                        nextStep.numericStepper.Enabled = true;
                        currentNpcEventType.numericStepper.Enabled = true;
                        currentNpcEventPath.textBox.Enabled = true;
                        currentTargetEventStep.numericStepper.Enabled = true;

                        eventId.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].NpcEventDatas[npcEventDatasList.SelectedIndex].EventId, v => { eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].NpcEventDatas[npcEventDatasList.SelectedIndex].EventId = v; }));
                        eventState.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].NpcEventDatas[npcEventDatasList.SelectedIndex].EventState, v => { eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].NpcEventDatas[npcEventDatasList.SelectedIndex].EventState = v; }));
                        orderId.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].NpcEventDatas[npcEventDatasList.SelectedIndex].OrderId, v => { eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].NpcEventDatas[npcEventDatasList.SelectedIndex].OrderId = v; }));
                        currentStep.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].NpcEventDatas[npcEventDatasList.SelectedIndex].CurrentStep, v => { eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].NpcEventDatas[npcEventDatasList.SelectedIndex].CurrentStep = v; }));
                        currentReservedStep.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].NpcEventDatas[npcEventDatasList.SelectedIndex].CurrentReservedStep, v => { eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].NpcEventDatas[npcEventDatasList.SelectedIndex].CurrentReservedStep = v; }));
                        nextStep.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].NpcEventDatas[npcEventDatasList.SelectedIndex].NextStep, v => { eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].NpcEventDatas[npcEventDatasList.SelectedIndex].NextStep = v; }));
                        currentNpcEventType.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].NpcEventDatas[npcEventDatasList.SelectedIndex].CurrentNpcEventType, v => { eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].NpcEventDatas[npcEventDatasList.SelectedIndex].CurrentNpcEventType = v; }));
                        currentNpcEventPath.ChangeReferenceValue(new Ref<string>(() => eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].NpcEventDatas[npcEventDatasList.SelectedIndex].CurrentNpcEventPath, v => { eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].NpcEventDatas[npcEventDatasList.SelectedIndex].CurrentNpcEventPath = v; }));
                        currentTargetEventStep.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].NpcEventDatas[npcEventDatasList.SelectedIndex].CurrentTargetEventStep, v => { eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].NpcEventDatas[npcEventDatasList.SelectedIndex].CurrentTargetEventStep = v; }));
                    };

                    npcEventDatasUpdate = delegate ()
                    {
                        npcEventDatasList.Items.Clear();
                        eventId.numericStepper.Enabled = false;
                        eventState.numericStepper.Enabled = false;
                        orderId.numericStepper.Enabled = false;
                        currentStep.numericStepper.Enabled = false;
                        currentReservedStep.numericStepper.Enabled = false;
                        nextStep.numericStepper.Enabled = false;
                        currentNpcEventType.numericStepper.Enabled = false;
                        currentNpcEventPath.textBox.Enabled = false;
                        currentTargetEventStep.numericStepper.Enabled = false;

                        if (
                            eventScheduleDatasList.SelectedIndex < eventData.EventSaveParameter.EventScheduleDatas.Length && eventScheduleDatasList.SelectedIndex >= 0 &&
                            eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].NpcEventDatas != null
                        )
                        {
                            for (int i = 0; i < eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].NpcEventDatas.Length; i++)
                            {
                                npcEventDatasList.Items.Add($"NPC Event Data {i}");
                            }
                        }
                    };

                    StackLayoutItem[] npcEventDatasDataItems =
                    {
                        eventId,
                        eventState,
                        orderId,
                        currentStep,
                        currentReservedStep,
                        nextStep,
                        currentNpcEventType,
                        currentNpcEventPath,
                        currentTargetEventStep
                    };

                    foreach (var item in npcEventDatasDataItems)
                    {
                        npcEventDatasData.Items.Add(item);
                    }

                    StackLayoutItem[] npcEventDatasHBoxItems =
                    {
                        npcEventDatasList,
                        npcEventDatasData
                    };

                    foreach (var item in npcEventDatasHBoxItems)
                    {
                        npcEventDatasHBox.Items.Add(item);
                    }

                    npcEventDatas.Content = npcEventDatasHBox;
                }

                eventScheduleDatasList.SelectedIndexChanged += (object sender, EventArgs e) =>
                {
                    eventID.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].EventId, v => { eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].EventId = v; }));
                    eventStep.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].EventStep, v => { eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].EventStep = v; }));
                    startTimerUpdate();
                    endTimerUpdate();
                    joinNpcNumMin.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].JoinNpcNumMin, v => { eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].JoinNpcNumMin = v; }));
                    joinNpcNumMax.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].JoinNpcNumMax, v => { eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].JoinNpcNumMax = v; }));
                    joinNpcsUpdate();
                    joinRateNpcsUpdate();
                    decideJoinNpcsDataUpdate();
                    npcScoreResultsDataUpdate();
                    npcEventDatasUpdate();
                };

                StackLayoutItem[] eventScheduleDatasDataItems =
                {
                    eventID,
                    eventStep,
                    startTime,
                    endTime,
                    joinNpcNumMin,
                    joinNpcNumMax,
                    joinNpcs,
                    joinRateNpcs,
                    decideJoinNpcsData,
                    npcScoreResultsData,
                    npcEventDatas
                };

                foreach (var item in eventScheduleDatasDataItems)
                {
                    eventScheduleDatasData.Items.Add(item);
                }

                StackLayoutItem[] eventScheduleDatasHBoxItems =
                {
                    eventScheduleDatasList,
                    eventScheduleDatasData
                };

                foreach (var item in eventScheduleDatasHBoxItems)
                {
                    eventScheduleDatasHBox.Items.Add(item);
                }

                eventScheduleDatas.Content = eventScheduleDatasHBox;
            }

            StackLayoutItem[] vBoxItems =
            {
                currentEventId,
                currentEventStep,
                isTalking,
                selectMenuGroupId,
                isSelectMenu,
                targetNpcId,
                orderNpcIds,
                forceScriptName,
                forceEvent,
                eventScheduleDatas
            };

            foreach (var item in vBoxItems)
            {
                vBox.Items.Add(item);
            }

            scroll.Content = vBox;
            Content = scroll;
        }
    }
}