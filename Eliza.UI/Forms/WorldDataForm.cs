using Eliza.UI.Helpers;
using Eliza.UI.Widgets;
using Eto.Forms;
using System;

namespace Eliza.UI.Forms
{
    internal class WorldDataForm : Form
    {
        public WorldDataForm(Model.SaveData.RF5WorldData worldData)
        {
            Title = "World Data";

            var scroll = new Scrollable();
            var stackLayout = new VBox();

            var difficultyValue = new SpinBox(new Ref<byte>(() => worldData.DifficultyValue, v => { worldData.DifficultyValue = v; }), "Difficulty");
            var scenarioStoppedTine = new SpinBox(new Ref<int>(() => worldData.ScenarioStoppedTime, v => { worldData.ScenarioStoppedTime = v; }), "Scenario Stopped Time");
            var mapId = new SpinBox(new Ref<int>(() => worldData.MapId, v => { worldData.MapId = v; }), "Map ID");

            var position = new Vector3Group(
                new Ref<float>(() => worldData.Position.X, v => { worldData.Position.X = v; }),
                new Ref<float>(() => worldData.Position.Y, v => { worldData.Position.Y = v; }),
                new Ref<float>(() => worldData.Position.Z, v => { worldData.Position.Z = v; }),
                "Position"
            );
            var rotationEuler = new Vector3Group(
                new Ref<float>(() => worldData.RotationEuler.X, v => { worldData.RotationEuler.X = v; }),
                new Ref<float>(() => worldData.RotationEuler.Y, v => { worldData.RotationEuler.Y = v; }),
                new Ref<float>(() => worldData.RotationEuler.Z, v => { worldData.RotationEuler.Z = v; }),
                "Rotation Euler"
            );

            var inGameTimeElapsedTime = new SpinBox(new Ref<int>(() => worldData.InGameTimeElapsedTime, v => { worldData.InGameTimeElapsedTime = v; }), "Elapsed Time");

            //WeatherData
            var weatherData = new GroupBox() 
            { 
                Text = "Weather Data"
            };

            {
                var weatherDataStackLayout = new VBox();

                var weatherId = new SpinBox(new Ref<byte>(() => worldData.WeatherData.WeatherId, v => { worldData.WeatherData.WeatherId = v; }), "Weather ID");
                var weatherDayId = new SpinBox(new Ref<byte>(() => worldData.WeatherData.WeatherDayId, v => { worldData.WeatherData.WeatherDayId = v; }), "Weather Day ID");
                var todayRate = new SpinBox(new Ref<byte>(() => worldData.WeatherData.TodayRate, v => { worldData.WeatherData.TodayRate = v; }), "Today Rate");
                var typhoonDayCount = new SpinBox(new Ref<byte>(() => worldData.WeatherData.TyphoonDayCount, v => { worldData.WeatherData.TyphoonDayCount = v; }), "Typhoon Day Count");
                var runeyDayCount = new SpinBox(new Ref<byte>(() => worldData.WeatherData.RuneyDayCount, v => { worldData.WeatherData.RuneyDayCount = v; }), "Runey Day Count");
                var meteorShowerDayCount = new SpinBox(new Ref<byte>(() => worldData.WeatherData.MeteorShowerDayCount, v => { worldData.WeatherData.MeteorShowerDayCount = v; }), "Meteor Shower Day Count");
                var nextWeatherDayId = new SpinBox(new Ref<byte>(() => worldData.WeatherData.NextWeatherDayId, v => { worldData.WeatherData.NextWeatherDayId = v; }), "Next Weather Day ID");

                StackLayoutItem[] weatherDataStackLayoutItems =
                {
                    weatherId,
                    weatherDayId,
                    todayRate,
                    typhoonDayCount,
                    runeyDayCount,
                    meteorShowerDayCount,
                    nextWeatherDayId
                };

                foreach (var item in weatherDataStackLayoutItems)
                {
                    weatherDataStackLayout.Items.Add(item);

                }

                weatherData.Content = weatherDataStackLayout;
            }

            var shopRandSeedFix = new SpinBox(new Ref<uint>(() => worldData.ShopRandSeedFix, v => { worldData.ShopRandSeedFix = v; }), "Shop Seed Fix");
            var shopRandSeed = new SpinBox(new Ref<uint>(() => worldData.ShopRandSeed, v => { worldData.ShopRandSeed = v; }), "Shop Seed");
            var shopSeedGenerateDay = new SpinBox(new Ref<int>(() => worldData.ShopSeedGenerateDay, v => { worldData.ShopSeedGenerateDay = v; }), "Shop Seed Generate Day");
            var lastShippingDay = new SpinBox(new Ref<int>(() => worldData.LastShippingDay, v => { worldData.LastShippingDay = v; }), "Last Shipping Day");
            var lastPlaceId = new SpinBox(new Ref<int>(() => worldData.LastPlaceId, v => { worldData.LastPlaceId = v; }), "Last Place ID");
            var lastSleepTime = new SpinBox(new Ref<int>(() => worldData.LastSleepTime, v => { worldData.LastSleepTime = v; }), "Last Sleep Time");

            //MiningPointSaveData
            var miningPointSaveData = new GroupBox()
            {
                Text = "Mining Point"
            };

            {
                var miningPointStackLayout = new HBox();
                var miningPointDataStackLayout = new VBox();

                var miningPointList = new ListBox();

                for (int i = 0; i < worldData.MiningPointSaveDatas.Length; i++)
                {
                    miningPointList.Items.Add($"Mining Point {i}");
                }

                var farmId = new SpinBox("Farm ID");
                var Uid = new SpinBox("UID");
                var miningPointPosition = new Vector3Group("Position");
                var cropId = new SpinBox("Crop ID");
                var mineTypeId = new SpinBox("Mine Type ID");
                var itemId = new SpinBox("Item ID");
                var hp = new SpinBox("HP");


                miningPointList.SelectedIndexChanged += (object sender, EventArgs e) =>
                {
                    farmId.ChangeReferenceValue(new Ref<int>(() => worldData.MiningPointSaveDatas[miningPointList.SelectedIndex].FarmID, v => { worldData.MiningPointSaveDatas[miningPointList.SelectedIndex].FarmID = v; }));
                    Uid.ChangeReferenceValue(new Ref<int>(() => worldData.MiningPointSaveDatas[miningPointList.SelectedIndex].Uid, v => { worldData.MiningPointSaveDatas[miningPointList.SelectedIndex].Uid = v; }));
                    miningPointPosition.ChangeReferenceValue(
                        new Ref<float>(() => worldData.MiningPointSaveDatas[miningPointList.SelectedIndex].Position.X, v => { worldData.MiningPointSaveDatas[miningPointList.SelectedIndex].Position.X = v; }),
                        new Ref<float>(() => worldData.MiningPointSaveDatas[miningPointList.SelectedIndex].Position.Y, v => { worldData.MiningPointSaveDatas[miningPointList.SelectedIndex].Position.Y = v; }),
                        new Ref<float>(() => worldData.MiningPointSaveDatas[miningPointList.SelectedIndex].Position.Z, v => { worldData.MiningPointSaveDatas[miningPointList.SelectedIndex].Position.Z = v; })
                    );
                    cropId.ChangeReferenceValue(new Ref<int>(() => worldData.MiningPointSaveDatas[miningPointList.SelectedIndex].CropID, v => { worldData.MiningPointSaveDatas[miningPointList.SelectedIndex].CropID = v; }));
                    mineTypeId.ChangeReferenceValue(new Ref<int>(() => worldData.MiningPointSaveDatas[miningPointList.SelectedIndex].mineTypeID, v => { worldData.MiningPointSaveDatas[miningPointList.SelectedIndex].mineTypeID = v; }));
                    itemId.ChangeReferenceValue(new Ref<int>(() => worldData.MiningPointSaveDatas[miningPointList.SelectedIndex].ItemID, v => { worldData.MiningPointSaveDatas[miningPointList.SelectedIndex].ItemID = v; }));
                    hp.ChangeReferenceValue(new Ref<int>(() => worldData.MiningPointSaveDatas[miningPointList.SelectedIndex].HP, v => { worldData.MiningPointSaveDatas[miningPointList.SelectedIndex].HP = v; }));
                };

                StackLayoutItem[] miningPointDataStackLayoutItems =
                {
                    farmId,
                    Uid,
                    miningPointPosition,
                    cropId,
                    mineTypeId,
                    itemId,
                    hp
                };

                foreach (var item in miningPointDataStackLayoutItems)
                {
                    miningPointDataStackLayout.Items.Add(item);
                }

                StackLayoutItem[] miningPointStackLayoutItems =
                {
                    miningPointList,
                    miningPointDataStackLayout
                };

                foreach (var item in miningPointStackLayoutItems)
                {
                    miningPointStackLayout.Items.Add(item);
                }

                miningPointSaveData.Content = miningPointStackLayout;
            }

            //RewardBoxSaveData
            var rewardBoxSaveData = new GroupBox()
            {
                Text = "Reward Box"
            };

            {
                var rewardBoxSaveDataVBox = new VBox();

                //OrderRewardItemData
                var orderRewardItemData = new GroupBox()
                {
                    Text = "Order Reward"
                };

                {
                    var orderRewardItemDataHBox = new HBox();
                    var orderRewardItemDataList = new ListBox();

                    for (int i = 0; i < worldData.RewardBoxSaveData.OrderRewardItemData.Length; i++)
                    {
                        orderRewardItemDataList.Items.Add($"Order Reward {i}");
                    }

                    var orderRewardItemDataGroup = new RewardItemDataGroup();
                    orderRewardItemDataList.SelectedIndexChanged += (object sender, EventArgs e) =>
                    {
                        orderRewardItemDataGroup.ChangeReferenceValue(worldData.RewardBoxSaveData.OrderRewardItemData[orderRewardItemDataList.SelectedIndex]);
                    };

                    StackLayoutItem[] orderRewardItemDataHBoxItems =
                    {
                        orderRewardItemDataList,
                        orderRewardItemDataGroup
                    };

                    foreach (var item in orderRewardItemDataHBoxItems)
                    {
                        orderRewardItemDataHBox.Items.Add(item);
                    }

                    orderRewardItemData.Content = orderRewardItemDataHBox;
                }
                
                //OrderRewardRecipeData
                var orderRewardRecipeData = new GroupBox()
                {
                    Text = "Order Reward Recipe"
                };

                {
                    var orderRewardRecipeDataHBox = new HBox();
                    var orderRewardRecipeDataList = new ListBox();
                    var orderRewardRecipeDataData = new VBox();

                    for (int i = 0; i < worldData.RewardBoxSaveData.OrderRewardRecipeData.Length; i++)
                    {
                        orderRewardRecipeDataList.Items.Add($"Order Reward Recipe {i}");
                    }

                    var orderRewardRecipeDataSpinBox = new SpinBox("Order Reward Recipe");
                    orderRewardRecipeDataList.SelectedIndexChanged += (object sender, EventArgs e) =>
                    {
                        orderRewardRecipeDataSpinBox.ChangeReferenceValue(new Ref<int>(() => worldData.RewardBoxSaveData.OrderRewardRecipeData[orderRewardRecipeDataList.SelectedIndex], v => { worldData.RewardBoxSaveData.OrderRewardRecipeData[orderRewardRecipeDataList.SelectedIndex] = v; }));
                    };

                    StackLayoutItem[] orderRewardRecipeDataDataItems =
                    {
                        orderRewardRecipeDataSpinBox
                    };

                    foreach (var item in orderRewardRecipeDataDataItems)
                    {
                        orderRewardRecipeDataData.Items.Add(item);
                    }

                    StackLayoutItem[] orderRewardRecipeDataHBoxItems =
                    {
                        orderRewardRecipeDataList,
                        orderRewardRecipeDataData
                    };

                    foreach (var item in orderRewardRecipeDataHBoxItems)
                    {
                        orderRewardRecipeDataHBox.Items.Add(item);
                    }

                    orderRewardRecipeData.Content = orderRewardRecipeDataHBox;
                }

                var orderRewardGold = new SpinBox(new Ref<int>(() => worldData.RewardBoxSaveData.OrderRewardGold, v => { worldData.RewardBoxSaveData.OrderRewardGold = v; }), "Order Reward Gold");

                //WantedRewardItemData
                var wantedRewardItemData = new GroupBox()
                {
                    Text = "Wanted Reward"
                };

                {
                    var wantedRewardItemDataHBox = new HBox();
                    var wantedRewardItemDataList = new ListBox();

                    for (int i = 0; i < worldData.RewardBoxSaveData.WantedRewardItemData.Length; i++)
                    {
                        wantedRewardItemDataList.Items.Add($"Wanted Reward Recipe {i}");
                    }

                    var wantedRewardItemDataGroup = new RewardItemDataGroup();

                    wantedRewardItemDataList.SelectedIndexChanged += (object sender, EventArgs e) =>
                    {
                        wantedRewardItemDataGroup.ChangeReferenceValue(worldData.RewardBoxSaveData.WantedRewardItemData[wantedRewardItemDataList.SelectedIndex]);
                    };

                    StackLayoutItem[] wantedRewardItemDataHBoxItems =
                    {
                        wantedRewardItemDataList,
                        wantedRewardItemDataGroup
                    };

                    foreach (var item in wantedRewardItemDataHBoxItems)
                    {
                        wantedRewardItemDataHBox.Items.Add(item);
                    }

                    wantedRewardItemData.Content = wantedRewardItemDataHBox;
                }

                //FestivalRewardItemData
                var festivalRewardItemData = new GroupBox()
                {
                    Text = "Festival Reward"
                };

                {
                    var festivalRewardItemDataHBox = new HBox();
                    var festivalRewardItemDataList = new ListBox();

                    for (int i = 0; i < worldData.RewardBoxSaveData.FestivalRewardItemData.Length; i++)
                    {
                        festivalRewardItemDataList.Items.Add($"Festival Reward Recipe {i}");
                    }

                    var festivalRewardItemDataGroup = new RewardItemDataGroup();

                    festivalRewardItemDataList.SelectedIndexChanged += (object sender, EventArgs e) =>
                    {
                        festivalRewardItemDataGroup.ChangeReferenceValue(worldData.RewardBoxSaveData.FestivalRewardItemData[festivalRewardItemDataList.SelectedIndex]);
                    };

                    StackLayoutItem[] festivalRewardItemDataHBoxItems =
                    {
                        festivalRewardItemDataList,
                        festivalRewardItemDataGroup
                    };

                    foreach (var item in festivalRewardItemDataHBoxItems)
                    {
                        festivalRewardItemDataHBox.Items.Add(item);
                    }

                    festivalRewardItemData.Content = festivalRewardItemDataHBox;
                }

                StackLayoutItem[] rewardBoxSaveDataVBoxItems =
                {
                    orderRewardItemData,
                    orderRewardRecipeData,
                    orderRewardGold,
                    wantedRewardItemData,
                    festivalRewardItemData
                };

                foreach (var item in rewardBoxSaveDataVBoxItems)
                {
                    rewardBoxSaveDataVBox.Items.Add(item);
                }

                rewardBoxSaveData.Content = rewardBoxSaveDataVBox;
            }

            var itemSpawnFlag = new SaveFlagStorageGroup(worldData.ItemSpawnFlag, "Item Spawn Flag");
            var treasureFlag = new SaveFlagStorageGroup(worldData.TreasureFlag, "Treasure Flag");
            var gimmickFlag = new SaveFlagStorageGroup(worldData.GimmickFlag, "Gimmick Flag");
            var seedPointElapsedDay = new SpinBox(new Ref<int>(() => worldData.SeedPointElapsedDay, v => { worldData.SeedPointElapsedDay = v; }), "Seed Point Elapsed Day");
            var seedPointMonsterAddedCount = new SpinBox(new Ref<int>(() => worldData.SeedPointMonsterAddedCount, v => { worldData.SeedPointMonsterAddedCount = v; }), "Seed Point Monster Added Count");
            var seedSupportCoolTime = new SpinBox(new Ref<float>(() => worldData.SeedSupportCoolTime, v => { worldData.SeedSupportCoolTime = v; }), "Seed Point Monster Added Count");

            //MeteorPosition
            var meteorPosition = new GroupBox()
            {
                Text = "Meteor Position"
            };

            {
                var meteorPositionHBox = new HBox();
                var meteorPositionList = new ListBox();
                var meteorPositionData = new VBox();

                var meteorPositionSpinBox = new SpinBox("Meteor Position");

                for (int i = 0; i < worldData.MeteorPosition.Length; i++)
                {
                    meteorPositionList.Items.Add($"Meteor {i}");
                }

                meteorPositionList.SelectedIndexChanged += (object sender, EventArgs e) =>
                {
                    meteorPositionSpinBox.ChangeReferenceValue(new Ref<int>(() => worldData.MeteorPosition[meteorPositionList.SelectedIndex], v => { worldData.MeteorPosition[meteorPositionList.SelectedIndex] = v; }));
                };

                StackLayoutItem[] meteorPositionDataItems =
                {
                    meteorPositionSpinBox
                };

                foreach (var item in meteorPositionDataItems)
                {
                    meteorPositionData.Items.Add(item);
                }

                StackLayoutItem[] meteorPositionHBoxItems =
                {
                    meteorPositionList,
                    meteorPositionData
                };

                foreach (var item in meteorPositionHBoxItems)
                {
                    meteorPositionHBox.Items.Add(item);
                }

                meteorPosition.Content = meteorPositionHBox;

            }

            var unk1 = new SpinBox(new Ref<int>(() => worldData.unk1, v => { worldData.unk1 = v; }), "Unk 1");
            var offsetFiveYearAgo = new SpinBox(new Ref<int>(() => worldData.OffsetFiveYearAgo, v => { worldData.OffsetFiveYearAgo = v; }), "Offset Five Year Ago");
            var punchCount = new SpinBox(new Ref<int>(() => worldData.PunchCount, v => { worldData.PunchCount = v; }), "Punch Count");

            StackLayoutItem[] stackLayoutItems =
            {
                difficultyValue,
                scenarioStoppedTine,
                mapId,
                position,
                rotationEuler,
                inGameTimeElapsedTime,
                weatherData,
                shopRandSeedFix,
                shopRandSeed,
                shopSeedGenerateDay,
                lastShippingDay,
                lastPlaceId,
                lastSleepTime,
                miningPointSaveData,
                rewardBoxSaveData,
                itemSpawnFlag,
                treasureFlag,
                gimmickFlag,
                seedPointElapsedDay,
                seedPointMonsterAddedCount,
                seedSupportCoolTime,
                meteorPosition,
                unk1,
                offsetFiveYearAgo,
                punchCount
            };

            foreach (var item in stackLayoutItems)
            {
                stackLayout.Items.Add(item);
            }

            scroll.Content = stackLayout;
            Content = scroll;
        }
    }
}
