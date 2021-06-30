using Eliza.Model.SaveData;
using Eliza.UI.Helpers;
using Eliza.UI.Widgets;
using Eto.Forms;
using System;

namespace Eliza.UI.Forms
{
    internal class EventDataForm : Form
    {
        delegate void ListUpdateDelegate();

        public EventDataForm(RF5EventData eventData)
        {
            Title = "Event Data";

            var scroll = new Scrollable();
            var vBox = new VBox();
            var eventSaveParameterVBox = new VBox();

            var eventSaveParameter = new GroupBox()
            {
                Text = "Event Save Parameter"
            };

            {
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
                var eventScheduleDatas = new GroupBox()
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

                    ListUpdateDelegate startTimerUpdate = delegate () { };

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

                        ListUpdateDelegate subEventStepsUpdate = delegate () { };
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

                            //MainEventStep
                            var mainEventStep = new GroupBox()
                            {
                                Text = "Main Event Step"
                            };

                            ListUpdateDelegate mainEventStepUpdate = delegate () { };
                            {
                                var mainEventStepList = new ListBox();
                                var mainEventStepHBox = new HBox();
                                var mainEventStepData = new VBox();
                                if (
                                    eventScheduleDatasList.SelectedIndex < eventData.EventSaveParameter.EventScheduleDatas.Length && eventScheduleDatasList.SelectedIndex >= 0 &&
                                    eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].NpcEventDatas != null &&
                                    npcEventDatasList.SelectedIndex < eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].NpcEventDatas.Length && npcEventDatasList.SelectedIndex >= 0 &&
                                    eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].NpcEventDatas[npcEventDatasList.SelectedIndex].SubEventSteps != null &&
                                    subEventStepsList.SelectedIndex < eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].NpcEventDatas[npcEventDatasList.SelectedIndex].SubEventSteps.Count && subEventStepsList.SelectedIndex >= 0 &&
                                    eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].NpcEventDatas[npcEventDatasList.SelectedIndex].SubEventSteps[subEventStepsList.SelectedIndex].MainEventSteps != null
                                )
                                {
                                    for (int i = 0; i < eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].NpcEventDatas[npcEventDatasList.SelectedIndex].SubEventSteps[subEventStepsList.SelectedIndex].MainEventSteps.Length; i++)
                                    {
                                        mainEventStepList.Items.Add($"Main Event Step {i}");
                                    }
                                }

                                var spinBox = new SpinBox("Event Step");
                                mainEventStepList.SelectedIndexChanged += (object sender, EventArgs e) =>
                                {
                                    spinBox.Enabled = true;
                                    spinBox.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].NpcEventDatas[npcEventDatasList.SelectedIndex].SubEventSteps[subEventStepsList.SelectedIndex].MainEventSteps[mainEventStepList.SelectedIndex], v => { eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].NpcEventDatas[npcEventDatasList.SelectedIndex].SubEventSteps[subEventStepsList.SelectedIndex].MainEventSteps[mainEventStepList.SelectedIndex] = v; }));
                                };

                                mainEventStepUpdate = delegate ()
                                {
                                    spinBox.numericStepper.Enabled = false;
                                    mainEventStepList.Items.Clear();
                                    if (
                                        eventScheduleDatasList.SelectedIndex < eventData.EventSaveParameter.EventScheduleDatas.Length && eventScheduleDatasList.SelectedIndex >= 0 &&
                                        eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].NpcEventDatas != null &&
                                        npcEventDatasList.SelectedIndex < eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].NpcEventDatas.Length && npcEventDatasList.SelectedIndex >= 0 &&
                                        eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].NpcEventDatas[npcEventDatasList.SelectedIndex].SubEventSteps != null &&
                                        subEventStepsList.SelectedIndex < eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].NpcEventDatas[npcEventDatasList.SelectedIndex].SubEventSteps.Count && subEventStepsList.SelectedIndex >= 0 &&
                                        eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].NpcEventDatas[npcEventDatasList.SelectedIndex].SubEventSteps[subEventStepsList.SelectedIndex].MainEventSteps != null
                                    )
                                    {
                                        for (int i = 0; i < eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].NpcEventDatas[npcEventDatasList.SelectedIndex].SubEventSteps[subEventStepsList.SelectedIndex].MainEventSteps.Length; i++)
                                        {
                                            mainEventStepList.Items.Add($"Main Event Step {i}");
                                        }
                                    }
                                };
                                mainEventStepData.Items.Add(spinBox);

                                mainEventStepHBox.Items.Add(mainEventStepList);
                                mainEventStepHBox.Items.Add(mainEventStepData);

                                mainEventStep.Content = mainEventStepHBox;
                            }

                            subEventStepsList.SelectedIndexChanged += (object sender, EventArgs e) =>
                            {
                                targetEventStep.Enabled = true;
                                keepEventStep.Enabled = true;

                                targetEventStep.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].NpcEventDatas[npcEventDatasList.SelectedIndex].SubEventSteps[subEventStepsList.SelectedIndex].TargetEventStep, v => { eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].NpcEventDatas[npcEventDatasList.SelectedIndex].SubEventSteps[subEventStepsList.SelectedIndex].TargetEventStep = v; }));
                                keepEventStep.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].NpcEventDatas[npcEventDatasList.SelectedIndex].SubEventSteps[subEventStepsList.SelectedIndex].KeepEventStep, v => { eventData.EventSaveParameter.EventScheduleDatas[eventScheduleDatasList.SelectedIndex].NpcEventDatas[npcEventDatasList.SelectedIndex].SubEventSteps[subEventStepsList.SelectedIndex].KeepEventStep = v; }));
                                mainEventStepUpdate();
                            };

                            subEventStepsUpdate = delegate ()
                            {
                                targetEventStep.Enabled = false;
                                keepEventStep.Enabled = false;
                                subEventStepsList.Items.Clear();
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
                                mainEventStepUpdate();
                            };

                            StackLayoutItem[] subEventStepsDataItems =
                            {
                            targetEventStep,
                            keepEventStep,
                            mainEventStep
                        };

                            foreach (var item in subEventStepsDataItems)
                            {
                                subEventStepsData.Items.Add(item);
                            }

                            subEventStepsHBox.Items.Add(subEventStepsList);
                            subEventStepsHBox.Items.Add(subEventStepsData);

                            subEventSteps.Content = subEventStepsHBox;
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
                            subEventStepsUpdate();
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
                            subEventStepsUpdate();
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
                        currentTargetEventStep,
                        subEventSteps
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

                var bythewayMenuCommandNo = new SpinBox(new Ref<int>(() => eventData.EventSaveParameter.bythewayMenuCommandNo, v => { eventData.EventSaveParameter.bythewayMenuCommandNo = v; }), "BTW Menu Command Number");
                var bythewayEventStep = new SpinBox(new Ref<int>(() => eventData.EventSaveParameter.bythewayEventStep, v => { eventData.EventSaveParameter.bythewayEventStep = v; }), "BTW Event Step");
                var is1stBytheWay = new Widgets.CheckBox(new Ref<bool>(() => eventData.EventSaveParameter.Is1stBytheWay, v => { eventData.EventSaveParameter.Is1stBytheWay = v; }), "1st BTW");
                var partnerMenuCommandNo = new SpinBox(new Ref<int>(() => eventData.EventSaveParameter.partnerMenuCommandNo, v => { eventData.EventSaveParameter.partnerMenuCommandNo = v; }), "Partner Menu Command Number");
                var partnerEventStep = new SpinBox(new Ref<int>(() => eventData.EventSaveParameter.partnerEventStep, v => { eventData.EventSaveParameter.partnerEventStep = v; }), "Partner Event Step");
                var eventValue = new SpinBox(new Ref<int>(() => eventData.EventSaveParameter.eventValue, v => { eventData.EventSaveParameter.eventValue = v; }), "Event Value");
                var useRetentionEventType = new Widgets.CheckBox(new Ref<bool>(() => eventData.EventSaveParameter.UseRetentionEventType, v => { eventData.EventSaveParameter.UseRetentionEventType = v; }), "Use Retention EventType");

                //ReservedEventStartPoints
                var reservedEventStartPoints = new GroupBox()
                {
                    Text = "Reserved Event Start Points"
                };

                {
                    var reservedEventStartPointsHBox = new HBox();
                    var reservedEventStartPointsList = new ListBox();
                    var reservedEventStartPointsData = new VBox();

                    if (eventData.EventSaveParameter.ReservedEventStartPoints != null)
                    {
                        for (int i = 0; i < eventData.EventSaveParameter.ReservedEventStartPoints.Count; i++)
                        {
                            reservedEventStartPointsList.Items.Add($"Reserved Event Start Points {i}");
                        }
                    }

                    var scriptId = new SpinBox("Script ID");
                    var eventPointId = new SpinBox("Event Point ID");
                    var reservedEventCheckType = new SpinBox("Event Check Type");
                    var eventStartDay = new SpinBox("Event Start Day");
                    var eventStartTime = new SpinBox("Event Start Time");
                    var eventEndTime = new SpinBox("Event End Time");
                    var iconType = new SpinBox("Icon Type");
                    var iconViewType = new SpinBox("Icon View Type");
                    var pointOnFlag = new SpinBox("Point On Flag");
                    var storyFlag = new SpinBox("Story Flag");
                    var deleteEventPointFlag = new SpinBox("EventFinishFlag");

                    //On
                    var on = new GroupBox()
                    {
                        Text = "On"
                    };

                    ListUpdateDelegate onUpdate = delegate () { };

                    {
                        var onHBox = new HBox();
                        var onList = new ListBox();
                        var onData = new VBox();

                        if (
                            reservedEventStartPointsList.SelectedIndex < eventData.EventSaveParameter.ReservedEventStartPoints.Count && reservedEventStartPointsList.SelectedIndex >= 0 &&
                            eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].On != null
                        )
                        {
                            for (int i = 0; i < eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].On.Length; i++)
                            {
                                onList.Items.Add($"On {i}");
                            }
                        }

                        var spinBox = new SpinBox("Data");

                        onList.SelectedIndexChanged += (object sender, EventArgs e) =>
                        {
                            spinBox.Enabled = true;
                            spinBox.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].On[onList.SelectedIndex], v => { eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].On[onList.SelectedIndex] = v; }));
                        };

                        onUpdate = delegate ()
                        {
                            spinBox.Enabled = false;
                            onList.Items.Clear();
                            if (
                                reservedEventStartPointsList.SelectedIndex < eventData.EventSaveParameter.ReservedEventStartPoints.Count && reservedEventStartPointsList.SelectedIndex >= 0 &&
                                eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].On != null
                            )
                            {
                                for (int i = 0; i < eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].On.Length; i++)
                                {
                                    onList.Items.Add($"On {i}");
                                }
                            }
                        };

                        onData.Items.Add(spinBox);

                        onHBox.Items.Add(onList);
                        onHBox.Items.Add(onData);

                        on.Content = onHBox;
                    }

                    //Off
                    var off = new GroupBox()
                    {
                        Text = "Off"
                    };

                    ListUpdateDelegate offUpdate = delegate () { };

                    {
                        var offHBox = new HBox();
                        var offList = new ListBox();
                        var offData = new VBox();

                        if (
                            reservedEventStartPointsList.SelectedIndex < eventData.EventSaveParameter.ReservedEventStartPoints.Count && reservedEventStartPointsList.SelectedIndex >= 0 &&
                            eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].Off != null
                        )
                        {
                            for (int i = 0; i < eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].Off.Length; i++)
                            {
                                offList.Items.Add($"Off {i}");
                            }
                        }

                        var spinBox = new SpinBox("Data");

                        offList.SelectedIndexChanged += (object sender, EventArgs e) =>
                        {
                            spinBox.Enabled = true;
                            spinBox.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].Off[offList.SelectedIndex], v => { eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].Off[offList.SelectedIndex] = v; }));
                        };

                        offUpdate = delegate ()
                        {
                            spinBox.Enabled = false;
                            offList.Items.Clear();
                            if (
                                reservedEventStartPointsList.SelectedIndex < eventData.EventSaveParameter.ReservedEventStartPoints.Count && reservedEventStartPointsList.SelectedIndex >= 0 &&
                                eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].Off != null
                            )
                            {
                                for (int i = 0; i < eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].Off.Length; i++)
                                {
                                    offList.Items.Add($"Off {i}");
                                }
                            }
                        };

                        offData.Items.Add(spinBox);

                        offHBox.Items.Add(offList);
                        offHBox.Items.Add(offData);

                        off.Content = offHBox;
                    }

                    //NPC Off
                    var npcOff = new GroupBox()
                    {
                        Text = "NPC Off"
                    };

                    ListUpdateDelegate npcOffUpdate = delegate () { };

                    {
                        var npcOffHBox = new HBox();
                        var npcOffList = new ListBox();
                        var npcOffData = new VBox();

                        if (
                            reservedEventStartPointsList.SelectedIndex < eventData.EventSaveParameter.ReservedEventStartPoints.Count && reservedEventStartPointsList.SelectedIndex >= 0 &&
                            eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].NpcOff != null
                        )
                        {
                            for (int i = 0; i < eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].NpcOff.Length; i++)
                            {
                                npcOffList.Items.Add($"NPC Off {i}");
                            }
                        }

                        var spinBox = new SpinBox("Data");

                        npcOffList.SelectedIndexChanged += (object sender, EventArgs e) =>
                        {
                            spinBox.Enabled = true;
                            spinBox.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].NpcOff[npcOffList.SelectedIndex], v => { eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].NpcOff[npcOffList.SelectedIndex] = v; }));
                        };

                        npcOffUpdate = delegate ()
                        {
                            spinBox.Enabled = false;
                            npcOffList.Items.Clear();
                            if (
                                reservedEventStartPointsList.SelectedIndex < eventData.EventSaveParameter.ReservedEventStartPoints.Count && reservedEventStartPointsList.SelectedIndex >= 0 &&
                                eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].NpcOff != null
                            )
                            {
                                for (int i = 0; i < eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].NpcOff.Length; i++)
                                {
                                    npcOffList.Items.Add($"NPC Off {i}");
                                }
                            }
                        };

                        npcOffData.Items.Add(spinBox);

                        npcOffHBox.Items.Add(npcOffList);
                        npcOffHBox.Items.Add(npcOffData);

                        npcOff.Content = npcOffHBox;
                    }

                    //NPC On
                    var npcOn = new GroupBox()
                    {
                        Text = "NPC On"
                    };

                    ListUpdateDelegate npcOnUpdate = delegate () { };

                    {
                        var npcOnHBox = new HBox();
                        var npcOnList = new ListBox();
                        var npcOnData = new VBox();

                        if (
                            reservedEventStartPointsList.SelectedIndex < eventData.EventSaveParameter.ReservedEventStartPoints.Count && reservedEventStartPointsList.SelectedIndex >= 0 &&
                            eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].NpcOn != null
                        )
                        {
                            for (int i = 0; i < eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].NpcOn.Length; i++)
                            {
                                npcOnList.Items.Add($"NPC On {i}");
                            }
                        }

                        var spinBox = new SpinBox("Data");

                        npcOnList.SelectedIndexChanged += (object sender, EventArgs e) =>
                        {
                            spinBox.Enabled = true;
                            spinBox.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].NpcOn[npcOnList.SelectedIndex], v => { eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].NpcOn[npcOnList.SelectedIndex] = v; }));
                        };

                        npcOnUpdate = delegate ()
                        {
                            spinBox.Enabled = false;
                            npcOnList.Items.Clear();
                            if (
                                reservedEventStartPointsList.SelectedIndex < eventData.EventSaveParameter.ReservedEventStartPoints.Count && reservedEventStartPointsList.SelectedIndex >= 0 &&
                                eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].NpcOn != null
                            )
                            {
                                for (int i = 0; i < eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].NpcOn.Length; i++)
                                {
                                    npcOnList.Items.Add($"NPC On {i}");
                                }
                            }
                        };

                        npcOnData.Items.Add(spinBox);

                        npcOnHBox.Items.Add(npcOnList);
                        npcOnHBox.Items.Add(npcOnData);

                        npcOn.Content = npcOnHBox;
                    }

                    //Flag On
                    var flagOn = new GroupBox()
                    {
                        Text = "Flag On"
                    };

                    ListUpdateDelegate flagOnUpdate = delegate () { };

                    {
                        var flagOnHBox = new HBox();
                        var flagOnList = new ListBox();
                        var flagOnData = new VBox();

                        if (
                            reservedEventStartPointsList.SelectedIndex < eventData.EventSaveParameter.ReservedEventStartPoints.Count && reservedEventStartPointsList.SelectedIndex >= 0 &&
                            eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].FlagOn != null
                        )
                        {
                            for (int i = 0; i < eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].FlagOn.Length; i++)
                            {
                                flagOnList.Items.Add($"Flag On {i}");
                            }
                        }

                        var spinBox = new SpinBox("Data");

                        flagOnList.SelectedIndexChanged += (object sender, EventArgs e) =>
                        {
                            spinBox.Enabled = true;
                            spinBox.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].FlagOn[flagOnList.SelectedIndex], v => { eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].FlagOn[flagOnList.SelectedIndex] = v; }));
                        };

                        flagOnUpdate = delegate ()
                        {
                            spinBox.Enabled = false;
                            flagOnList.Items.Clear();
                            if (
                                reservedEventStartPointsList.SelectedIndex < eventData.EventSaveParameter.ReservedEventStartPoints.Count && reservedEventStartPointsList.SelectedIndex >= 0 &&
                                eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].FlagOn != null
                            )
                            {
                                for (int i = 0; i < eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].FlagOn.Length; i++)
                                {
                                    flagOnList.Items.Add($"Flag On {i}");
                                }
                            }
                        };

                        flagOnData.Items.Add(spinBox);

                        flagOnHBox.Items.Add(flagOnList);
                        flagOnHBox.Items.Add(flagOnData);

                        flagOn.Content = flagOnHBox;
                    }

                    //Flag Off
                    var flagOff = new GroupBox()
                    {
                        Text = "Flag Off"
                    };

                    ListUpdateDelegate flagOffUpdate = delegate () { };

                    {
                        var flagOffHBox = new HBox();
                        var flagOffList = new ListBox();
                        var flagOffData = new VBox();

                        if (
                            reservedEventStartPointsList.SelectedIndex < eventData.EventSaveParameter.ReservedEventStartPoints.Count && reservedEventStartPointsList.SelectedIndex >= 0 &&
                            eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].FlagOff != null
                        )
                        {
                            for (int i = 0; i < eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].FlagOff.Length; i++)
                            {
                                flagOffList.Items.Add($"Flag Off {i}");
                            }
                        }

                        var spinBox = new SpinBox("Data");

                        flagOffList.SelectedIndexChanged += (object sender, EventArgs e) =>
                        {
                            spinBox.Enabled = true;
                            spinBox.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].FlagOff[flagOffList.SelectedIndex], v => { eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].FlagOff[flagOffList.SelectedIndex] = v; }));
                        };

                        flagOffUpdate = delegate ()
                        {
                            spinBox.Enabled = false;
                            flagOffList.Items.Clear();
                            if (
                                reservedEventStartPointsList.SelectedIndex < eventData.EventSaveParameter.ReservedEventStartPoints.Count && reservedEventStartPointsList.SelectedIndex >= 0 &&
                                eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].FlagOff != null
                            )
                            {
                                for (int i = 0; i < eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].FlagOff.Length; i++)
                                {
                                    flagOffList.Items.Add($"Flag Off {i}");
                                }
                            }
                        };

                        flagOffData.Items.Add(spinBox);

                        flagOffHBox.Items.Add(flagOffList);
                        flagOffHBox.Items.Add(flagOffData);

                        flagOff.Content = flagOffHBox;
                    }

                    var pointActive = new Widgets.CheckBox("Point Active");
                    var sceneId = new SpinBox("SceneId");
                    var posX = new SpinBox("Pos X");
                    var posY = new SpinBox("Pos Y");
                    var posZ = new SpinBox("Pos Z");

                    reservedEventStartPointsList.SelectedIndexChanged += (object sender, EventArgs e) =>
                    {
                        scriptId.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].ScriptId, v => { eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].ScriptId = v; }));
                        eventPointId.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].EventPointId, v => { eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].EventPointId = v; }));
                        reservedEventCheckType.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].eventCheckType, v => { eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].eventCheckType = v; }));
                        eventStartDay.ChangeReferenceValue(new Ref<long>(() => eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].EventStartDay, v => { eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].EventStartDay = v; }));
                        eventStartTime.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].EventStartTime, v => { eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].EventStartTime = v; }));
                        eventEndTime.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].EventEndTime, v => { eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].EventEndTime = v; }));
                        iconType.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].IconType, v => { eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].IconType = v; }));
                        iconViewType.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].IconViewType, v => { eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].IconViewType = v; }));
                        pointOnFlag.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].PointOnFlag, v => { eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].PointOnFlag = v; }));
                        storyFlag.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].StoryFlag, v => { eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].StoryFlag = v; }));
                        deleteEventPointFlag.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].DeleteEventPointFlag, v => { eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].DeleteEventPointFlag = v; }));
                        onUpdate();
                        offUpdate();
                        npcOnUpdate();
                        npcOffUpdate();
                        flagOnUpdate();
                        flagOffUpdate();
                        pointActive.ChangeReferenceValue(new Ref<bool>(() => eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].PointActive, v => { eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].PointActive = v; }));
                        posX.ChangeReferenceValue(new Ref<float>(() => eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].PosX, v => { eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].PosX = v; }));
                        posY.ChangeReferenceValue(new Ref<float>(() => eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].PosY, v => { eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].PosY = v; }));
                        posZ.ChangeReferenceValue(new Ref<float>(() => eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].PosZ, v => { eventData.EventSaveParameter.ReservedEventStartPoints[reservedEventStartPointsList.SelectedIndex].PosZ = v; }));

                    };

                    StackLayoutItem[] reservedEventStartPointsDataItems =
                    {
                        scriptId,
                        eventPointId,
                        reservedEventCheckType,
                        eventStartDay,
                        eventStartTime,
                        eventEndTime,
                        iconType,
                        iconViewType,
                        pointOnFlag,
                        storyFlag,
                        deleteEventPointFlag,
                        on,
                        off,
                        npcOn,
                        npcOff,
                        flagOn,
                        flagOff,
                        pointActive,
                        posX,
                        posY,
                        posZ
                    };

                    foreach (var item in reservedEventStartPointsDataItems)
                    {
                        reservedEventStartPointsData.Items.Add(item);
                    }

                    StackLayoutItem[] reservedEventStartPointsHBoxItems =
                    {
                        reservedEventStartPointsList,
                        reservedEventStartPointsData
                    };

                    foreach (var item in reservedEventStartPointsHBoxItems)
                    {
                        reservedEventStartPointsHBox.Items.Add(item);
                    }

                    reservedEventStartPoints.Content = reservedEventStartPointsHBox;
                }

                var nowPlace = new SpinBox(new Ref<int>(() => eventData.EventSaveParameter.NowPlace, v => { eventData.EventSaveParameter.NowPlace = v; }), "Now Place");
                var flagTalkIndex = new SpinBox(new Ref<int>(() => eventData.EventSaveParameter.FlagTalkIndex, v => { eventData.EventSaveParameter.FlagTalkIndex = v; }), "Flag Talk Index");
                var isSleepScriptCalled = new Widgets.CheckBox(new Ref<bool>(() => eventData.EventSaveParameter.IsSleepScriptCalled, v => { eventData.EventSaveParameter.IsSleepScriptCalled = v; }), "Sleep Script Called");
                var isWakeUpReserve = new Widgets.CheckBox(new Ref<bool>(() => eventData.EventSaveParameter.IsWakeUpReserve, v => { eventData.EventSaveParameter.IsWakeUpReserve = v; }), "Wake Up Reserve");

                //EventCheckTypeFlag
                var eventCheckTypeFlag = new GroupBox()
                {
                    Text = "Event Check Type Flag"
                };

                {
                    var eventCheckTypeFlagHBox = new HBox();
                    var eventCheckTypeFlagList = new ListBox();
                    var eventCheckTypeFlagData = new VBox();

                    if (eventData.EventSaveParameter.EventCheckTypeFlag != null)
                    {
                        for (int i = 0; i < eventData.EventSaveParameter.EventCheckTypeFlag.Length; i++)
                        {
                            eventCheckTypeFlagList.Items.Add($"Event Check Type Flag {i}");
                        }
                    }

                    var checkBox = new Widgets.CheckBox();

                    eventCheckTypeFlagList.SelectedIndexChanged += (object sender, EventArgs e) =>
                    {
                        checkBox.ChangeReferenceValue(new Ref<bool>(() => eventData.EventSaveParameter.EventCheckTypeFlag[eventCheckTypeFlagList.SelectedIndex], v => { eventData.EventSaveParameter.EventCheckTypeFlag[eventCheckTypeFlagList.SelectedIndex] = v; }));
                    };

                    eventCheckTypeFlagData.Items.Add(checkBox);

                    eventCheckTypeFlagHBox.Items.Add(eventCheckTypeFlagList);
                    eventCheckTypeFlagHBox.Items.Add(eventCheckTypeFlagData);

                    eventCheckTypeFlag.Content = eventCheckTypeFlagHBox;
                }

                //EventCheckType
                var eventCheckType = new GroupBox()
                {
                    Text = "Event Check Type"
                };

                {
                    var eventCheckTypeHBox = new HBox();
                    var eventCheckTypeList = new ListBox();
                    var eventCheckTypeData = new VBox();

                    if (eventData.EventSaveParameter.EventCheckType != null)
                    {
                        for (int i = 0; i < eventData.EventSaveParameter.EventCheckType.Length; i++)
                        {
                            eventCheckTypeList.Items.Add($"Event Check Type {i}");
                        }
                    }

                    var spinBox = new Widgets.SpinBox();

                    eventCheckTypeList.SelectedIndexChanged += (object sender, EventArgs e) =>
                    {
                        spinBox.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.EventCheckType[eventCheckTypeList.SelectedIndex], v => { eventData.EventSaveParameter.EventCheckType[eventCheckTypeList.SelectedIndex] = v; }));
                    };

                    eventCheckTypeData.Items.Add(spinBox);

                    eventCheckTypeHBox.Items.Add(eventCheckTypeList);
                    eventCheckTypeHBox.Items.Add(eventCheckTypeData);

                    eventCheckType.Content = eventCheckTypeHBox;
                }

                //TODO EventCheckID
                var eventCheckIds = new GroupBox()
                {
                    Text = "Event Check IDs"
                };

                {
                    var eventCheckIdsHBox = new HBox();
                    var eventCheckIdsList = new ListBox();
                    var eventCheckIdsData = new VBox();

                    if (eventData.EventSaveParameter.EventCheckIds != null)
                    {
                        for (int i = 0; i < eventData.EventSaveParameter.EventCheckIds.Count; i++)
                        {
                            eventCheckIdsList.Items.Add($"Event Check ID {i}");
                        }
                    }

                    var checkTriggerType = new SpinBox("Check Trigger Type");
                    var checkTriggerId = new SpinBox("Check Trigger ID");
                    var checkScriptName = new LineEdit("Check Script Name");
                    var checkEnemyName = new LineEdit("Check Enemy Name");

                    eventCheckIdsList.SelectedIndexChanged += (object sender, EventArgs e) =>
                    {
                        checkTriggerType.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.EventCheckIds[eventCheckIdsList.SelectedIndex].CheckTriggerType, v => { eventData.EventSaveParameter.EventCheckIds[eventCheckIdsList.SelectedIndex].CheckTriggerType = v; }));
                        checkTriggerId.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.EventCheckIds[eventCheckIdsList.SelectedIndex].CheckTriggerId, v => { eventData.EventSaveParameter.EventCheckIds[eventCheckIdsList.SelectedIndex].CheckTriggerId = v; }));
                        checkScriptName.ChangeReferenceValue(new Ref<string>(() => eventData.EventSaveParameter.EventCheckIds[eventCheckIdsList.SelectedIndex].CheckScriptName, v => { eventData.EventSaveParameter.EventCheckIds[eventCheckIdsList.SelectedIndex].CheckScriptName = v; }));
                        checkEnemyName.ChangeReferenceValue(new Ref<string>(() => eventData.EventSaveParameter.EventCheckIds[eventCheckIdsList.SelectedIndex].CheckEnemyName, v => { eventData.EventSaveParameter.EventCheckIds[eventCheckIdsList.SelectedIndex].CheckEnemyName = v; }));
                    };

                    StackLayoutItem[] eventCheckIdsDataItems =
                    {
                        checkTriggerType,
                        checkTriggerId,
                        checkScriptName,
                        checkEnemyName
                    };

                    foreach (var item in eventCheckIdsDataItems)
                    {
                        eventCheckIdsData.Items.Add(item);
                    }

                    eventCheckIdsHBox.Items.Add(eventCheckIdsList);
                    eventCheckIdsHBox.Items.Add(eventCheckIdsData);

                    eventCheckIds.Content = eventCheckIdsHBox;
                }

                var nowType = new SpinBox(new Ref<int>(() => eventData.EventSaveParameter.NowType, v => { eventData.EventSaveParameter.NowType = v; }), "Now Type");

                //LastYearFesVictoryNpcId
                var lastYearFesVictoryNpcId = new GroupBox()
                {
                    Text = "Last Year Fes Victory Npc ID"
                };

                {
                    var lastYearFesVictoryNpcIdHBox = new HBox();
                    var lastYearFesVictoryNpcIdList = new ListBox();
                    var lastYearFesVictoryNpcIdData = new VBox();

                    if (eventData.EventSaveParameter.LastYearFesVictoryNpcId != null)
                    {
                        for (int i = 0; i < eventData.EventSaveParameter.LastYearFesVictoryNpcId.Length; i++)
                        {
                            lastYearFesVictoryNpcIdList.Items.Add($"Last Year Fes Victory Npc ID {i}");
                        }
                    }

                    var spinBox = new Widgets.SpinBox();

                    lastYearFesVictoryNpcIdList.SelectedIndexChanged += (object sender, EventArgs e) =>
                    {
                        spinBox.ChangeReferenceValue(new Ref<int>(() => eventData.EventSaveParameter.LastYearFesVictoryNpcId[lastYearFesVictoryNpcIdList.SelectedIndex], v => { eventData.EventSaveParameter.LastYearFesVictoryNpcId[lastYearFesVictoryNpcIdList.SelectedIndex] = v; }));
                    };

                    lastYearFesVictoryNpcIdData.Items.Add(spinBox);

                    lastYearFesVictoryNpcIdHBox.Items.Add(lastYearFesVictoryNpcIdList);
                    lastYearFesVictoryNpcIdHBox.Items.Add(lastYearFesVictoryNpcIdData);

                    lastYearFesVictoryNpcId.Content = lastYearFesVictoryNpcIdHBox;
                }

                var SP4CharaOn = new Widgets.CheckBox(new Ref<bool>(() => eventData.EventSaveParameter.SP4CharaOn, v => { eventData.EventSaveParameter.SP4CharaOn = v; }), "SP4 Character On");


                StackLayoutItem[] eventSaveParameterVBoxItems =
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
                    eventScheduleDatas,
                    reservedEventStartPoints,
                    nowPlace,
                    flagTalkIndex,
                    isSleepScriptCalled,
                    isWakeUpReserve,
                    eventCheckTypeFlag,
                    eventCheckType,
                    eventCheckIds,
                    nowType,
                    lastYearFesVictoryNpcId,
                    SP4CharaOn
                };

                foreach (var item in eventSaveParameterVBoxItems)
                {
                    eventSaveParameterVBox.Items.Add(item);
                }
                eventSaveParameter.Content = eventSaveParameterVBox;
            }

            //SaveFlag
            var saveFlag = new SaveFlagStorageGroup(eventData.SaveFlag, "Save Flag");

            var subEventSaveDatas = new GroupBox()
            {
                Text = "Sub Event Save Datas"
            };

            {
                var subEventSaveDatasVBox = new VBox();

                var progressingSubEventID = new SpinBox(new Ref<int>(() => eventData.SubEventSaveDatas.ProgressingSubEventID, v => { eventData.SubEventSaveDatas.ProgressingSubEventID = v; }), "Progressing Sub Event ID");
                subEventSaveDatasVBox.Items.Add(progressingSubEventID);

                subEventSaveDatas.Content = subEventSaveDatasVBox;
            }

            var mainScenarioStep = new SpinBox(new Ref<int>(() => eventData.MainScenarioStep, v => { eventData.MainScenarioStep = v; }), "Main Scenario Step");

            //PresentSendActorList
            var presentSendActorList = new GroupBox()
            {
                Text = "Present Send Actor"
            };

            {
                var presentSendActorListList = new ListBox();
                var presentSendActorListHBox = new HBox();
                var presentSendActorListData = new VBox();

                for (int i = 0; i < eventData.PresentSendActorList.Length; i++)
                {
                    presentSendActorListList.Items.Add($"Present Send Actor {i}");
                }

                var spinBox = new SpinBox();

                presentSendActorListList.SelectedIndexChanged += (object sender, EventArgs e) =>
                {
                    spinBox.ChangeReferenceValue(new Ref<int>(() => eventData.PresentSendActorList[presentSendActorListList.SelectedIndex], v => { eventData.PresentSendActorList[presentSendActorListList.SelectedIndex] = v; }));
                };

                presentSendActorListData.Items.Add(spinBox);

                presentSendActorListHBox.Items.Add(presentSendActorListList);
                presentSendActorListHBox.Items.Add(presentSendActorListData);

                presentSendActorList.Content = presentSendActorListHBox;
            }

            //PresentReceiveActorList
            var presentRecvActorList = new GroupBox()
            {
                Text = "Present Receive Actor"
            };

            {
                var presentRecvActorListList = new ListBox();
                var presentRecvActorListHBox = new HBox();
                var presentRecvActorListData = new VBox();

                for (int i = 0; i < eventData.PresentSendActorList.Length; i++)
                {
                    presentRecvActorListList.Items.Add($"Present Receive Actor {i}");
                }

                var spinBox = new SpinBox();

                presentRecvActorListList.SelectedIndexChanged += (object sender, EventArgs e) =>
                {
                    spinBox.ChangeReferenceValue(new Ref<int>(() => eventData.PresentRecvActorList[presentRecvActorListList.SelectedIndex], v => { eventData.PresentRecvActorList[presentRecvActorListList.SelectedIndex] = v; }));
                };

                presentRecvActorListData.Items.Add(spinBox);

                presentRecvActorListHBox.Items.Add(presentRecvActorListList);
                presentRecvActorListHBox.Items.Add(presentRecvActorListData);

                presentRecvActorList.Content = presentRecvActorListHBox;
            }

            var isStartFishing = new Widgets.CheckBox(new Ref<bool>(() => eventData.IsStartFishing, v => { eventData.IsStartFishing = v; }), "Is Start Fishing");

            //FesJoinActorList
            var fesJoinActorList = new GroupBox()
            {
                Text = "Fes Join Actor"
            };

            {
                var fesJoinActorListList = new ListBox();
                var fesJoinActorListHBox = new HBox();
                var fesJoinActorListData = new VBox();

                for (int i = 0; i < eventData.PresentSendActorList.Length; i++)
                {
                    fesJoinActorListList.Items.Add($"Fes Join Actor {i}");
                }

                var spinBox = new SpinBox();

                fesJoinActorListList.SelectedIndexChanged += (object sender, EventArgs e) =>
                {
                    spinBox.ChangeReferenceValue(new Ref<int>(() => eventData.FesJoinActorList[fesJoinActorListList.SelectedIndex], v => { eventData.FesJoinActorList[fesJoinActorListList.SelectedIndex] = v; }));
                };

                fesJoinActorListData.Items.Add(spinBox);

                fesJoinActorListHBox.Items.Add(fesJoinActorListList);
                fesJoinActorListHBox.Items.Add(fesJoinActorListData);

                fesJoinActorList.Content = fesJoinActorListHBox;
            }

            //FesVisitorActorList
            var fesVisitorActorList = new GroupBox()
            {
                Text = "Fes Visitor Actor"
            };

            {
                var fesVisitorActorListList = new ListBox();
                var fesVisitorActorListHBox = new HBox();
                var fesVisitorActorListData = new VBox();

                for (int i = 0; i < eventData.PresentSendActorList.Length; i++)
                {
                    fesVisitorActorListList.Items.Add($"Fes Join Actor {i}");
                }

                var spinBox = new SpinBox();

                fesVisitorActorListList.SelectedIndexChanged += (object sender, EventArgs e) =>
                {
                    spinBox.ChangeReferenceValue(new Ref<int>(() => eventData.FesJoinActorList[fesVisitorActorListList.SelectedIndex], v => { eventData.FesJoinActorList[fesVisitorActorListList.SelectedIndex] = v; }));
                };

                fesVisitorActorListData.Items.Add(spinBox);

                fesVisitorActorListHBox.Items.Add(fesVisitorActorListList);
                fesVisitorActorListHBox.Items.Add(fesVisitorActorListData);

                fesVisitorActorList.Content = fesVisitorActorListHBox;
            }

            //FesNpcScoreList
            var fesNpcScoreList = new GroupBox()
            {
                Text = "Fes NPC Score"
            };

            {
                var fesNpcScoreListList = new ListBox();
                var fesNpcScoreListHBox = new HBox();
                var fesNpcScoreListData = new VBox();

                for (int i = 0; i < eventData.FesNpcScoreList.Length; i++)
                {
                    fesNpcScoreListList.Items.Add($"Fes NPC Score {i}");
                }

                var npcId = new SpinBox("NPC ID");
                var score = new SpinBox("Score");

                fesNpcScoreListList.SelectedIndexChanged += (object sender, EventArgs e) =>
                {
                    npcId.ChangeReferenceValue(new Ref<int>(() => eventData.FesNpcScoreList[fesNpcScoreListList.SelectedIndex].npcId, v => { eventData.FesNpcScoreList[fesNpcScoreListList.SelectedIndex].npcId = v; }));
                    score.ChangeReferenceValue(new Ref<int>(() => eventData.FesNpcScoreList[fesNpcScoreListList.SelectedIndex].score, v => { eventData.FesNpcScoreList[fesNpcScoreListList.SelectedIndex].score = v; }));
                };

                fesNpcScoreListData.Items.Add(npcId);
                fesNpcScoreListData.Items.Add(score);

                fesNpcScoreListHBox.Items.Add(fesNpcScoreListList);
                fesNpcScoreListHBox.Items.Add(fesNpcScoreListData);

                fesNpcScoreList.Content = fesNpcScoreListHBox;
            }

            var isCalcFesId = new  SpinBox(new Ref<int>(() => eventData.IsCalcFesId, v => { eventData.IsCalcFesId = v; }), "Is Calc Fes ID");
            var victoryCandidateNpcId = new SpinBox(new Ref<int>(() => eventData.VictoryCandidateNpcId, v => { eventData.VictoryCandidateNpcId = v; }), "Victory Candidate NPC ID");
            var judgeChildId = new SpinBox(new Ref<int>(() => eventData.JudgeChildId, v => { eventData.JudgeChildId = v; }), "Judge Child ID");

            var fishTypeList = new GroupBox()
            {
                Text = "Fish Type"
            };

            {
                var fishTypeListList = new ListBox();
                var fishTypeListHBox = new HBox();
                var fishTypeListData = new VBox();

                for (int i = 0; i < eventData.FishTypeList.Length; i++)
                {
                    fishTypeListList.Items.Add($"Fish Type {i}");
                }

                var spinBox = new SpinBox();

                fishTypeListList.SelectedIndexChanged += (object sender, EventArgs e) =>
                {
                    spinBox.ChangeReferenceValue(new Ref<int>(() => eventData.FishTypeList[fishTypeListList.SelectedIndex], v => { eventData.FishTypeList[fishTypeListList.SelectedIndex] = v; }));
                };

                fishTypeListData.Items.Add(spinBox);

                fishTypeListHBox.Items.Add(fishTypeListList);
                fishTypeListHBox.Items.Add(fishTypeListData);

                fishTypeList.Content = fishTypeListHBox;
            }

            StackLayoutItem[] vBoxItems =
            {
                eventSaveParameter,
                saveFlag,
                subEventSaveDatas,
                mainScenarioStep,
                presentSendActorList,
                presentRecvActorList,
                isStartFishing,
                fesJoinActorList,
                fesVisitorActorList,
                fesNpcScoreList,
                isCalcFesId,
                victoryCandidateNpcId,
                judgeChildId,
                fishTypeList
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