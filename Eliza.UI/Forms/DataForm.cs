using Eliza.Model.SaveData;
using Eliza.UI.Widgets;
using Eto.Forms;
using System;
using System.Collections.Specialized;

namespace Eliza.UI.Forms
{
    public class DataForm : Form
    {
        private Model.SaveData.SaveData _saveData;

        public DataForm(Model.SaveData.SaveData save)
        {
            _saveData = save;

            Title = "Data";

            var data = save.saveData;
            var stackLayout = new VBox()
            {
                HorizontalContentAlignment = HorizontalAlignment.Center,
            };

            var saveFlagButton = new Button()
            {
                Text = "Save Flag"
            };

            saveFlagButton.Click += SaveFlagButton_Click;

            var worldDataButton = new Button()
            {
                Text = "World Data"
            };

            worldDataButton.Click += WorldDataButton_Click;

            var playerDataButton = new Button()
            {
                Text = "Player Data"
            };

            playerDataButton.Click += PlayerDataButton_Click;

            var eventDataButton = new Button()
            {
                Text = "Event Data"
            };

            eventDataButton.Click += EventDataButton_Click;

            var npcDataButton = new Button()
            {
                Text = "NPC Data"
            };

            npcDataButton.Click += NpcDataButton_Click;

            var fishingDataButton = new Button()
            {
                Text = "Fishing Data"
            };

            fishingDataButton.Click += FishingDataButton_Click;

            var stampDataButton = new Button()
            {
                Text = "Stamp Data"
            };

            stampDataButton.Click += StampDataButton_Click;

            var furnitureDataButton = new Button()
            {
                Text = "Furniture Data"
            };

            furnitureDataButton.Click += FurnitureDataButton_Click;

            var battleDataButton = new Button()
            {
                Text = "Battle Data"
            };

            battleDataButton.Click += BattleDataButton_Click;

            var itemDataButton = new Button()
            {
                Text = "Item Data"
            };

            itemDataButton.Click += ItemDataButton_Click;

            var supportMonsterDataButton = new Button()
            {
                Text = "Support Monster Data"
            };

            supportMonsterDataButton.Click += SupportMonsterDataButton_Click;

            var farmDataButton = new Button()
            {
                Text = "Increase Soil Stats"
            };

            farmDataButton.Click += FarmDataButton_Click;

            var statusDataButton = new Button()
            {
                Text = "Max Monster Friendship"
            };

            statusDataButton.Click += StatusDataButton_Click;

            var orderDataButton = new Button()
            {
                Text = "Order Data"
            };

            orderDataButton.Click += OrderDataButton_Click;

            var makingDataButton = new Button()
            {
                Text = "Making Data"
            };

            makingDataButton.Click += MakingDataButton_Click;

            var policeBatchDataButton = new Button()
            {
                Text = "Police Batch Data"
            };

            policeBatchDataButton.Click += PoliceBatchDataButton_Click;

            var itemFlagDataButton = new Button()
            {
                Text = "Item Flag Data"
            };

            itemFlagDataButton.Click += ItemFlagDataButton_Click;

            var buildDataButton = new Button()
            {
                Text = "Build Data"
            };

            buildDataButton.Click += BuildDataButton_Click;

            var shippingDataButton = new Button()
            {
                Text = "Shipping Data"
            };

            shippingDataButton.Click += ShippingDataButton_Click;

            var lPocketDataButton = new Button()
            {
                Text = "LPocket Data"
            };

            lPocketDataButton.Click += LPocketDataButton_Click;

            var nameDataButton = new Button()
            {
                Text = "Name Data"
            };

            nameDataButton.Click += NameDataButton_Click;

            StackLayoutItem[] stackLayoutItems =
            {
                    saveFlagButton,
                    worldDataButton,
                    playerDataButton,
                    eventDataButton,
                    npcDataButton,
                    fishingDataButton,
                    stampDataButton,
                    furnitureDataButton,
                    battleDataButton,
                    itemDataButton,
                    supportMonsterDataButton,
                    farmDataButton,
                    statusDataButton,
                    orderDataButton,
                    makingDataButton,
                    policeBatchDataButton,
                    itemFlagDataButton,
                    buildDataButton,
                    shippingDataButton,
                    lPocketDataButton,
                    nameDataButton
                };
            foreach (var item in stackLayoutItems)
            {
                stackLayout.Items.Add(item);
            }

            Content = stackLayout;
        }

        private void SaveFlagButton_Click(object sender, EventArgs e)
        {
            var saveFlagForm = new SaveFlagForm(_saveData.saveData.saveFlag);
            saveFlagForm.Show();
        }

        private void WorldDataButton_Click(object sender, EventArgs e)
        {
            var worldDataForm = new WorldDataForm(_saveData.saveData.worldData);
            worldDataForm.Show();
        }

        private void PlayerDataButton_Click(object sender, EventArgs e)
        {
            var playerDataForm = new PlayerDataForm(_saveData.saveData.playerData);
            playerDataForm.Show();
        }

        private void EventDataButton_Click(object sender, EventArgs e)
        {
            var eventDataForm = new EventDataForm(_saveData.saveData.eventData);
            eventDataForm.Show();
        }

        private void NpcDataButton_Click(object sender, EventArgs e)
        {
            var npcDataForm = new NPCDataForm(_saveData.saveData.npcData);
            npcDataForm.Show();
        }

        private void FishingDataButton_Click(object sender, EventArgs e)
        {
            var fishingDataForm = new FishingDataForm(_saveData.saveData.fishingData);
            fishingDataForm.Show();
        }

        private void StampDataButton_Click(object sender, EventArgs e)
        {
            var stampDataForm = new StampDataForm(_saveData.saveData.stampData);
            stampDataForm.Show();
        }

        private void FurnitureDataButton_Click(object sender, EventArgs e)
        {
            var furnitureDataForm = new FurnitureDataForm(_saveData.saveData.furnitureData);
            furnitureDataForm.Show();
        }

        private void BattleDataButton_Click(object sender, EventArgs e)
        {
            var battleDataForm = new BattleDataForm(_saveData.saveData.battleData);
            battleDataForm.Show();
        }

        private void ItemDataButton_Click(object sender, EventArgs e)
        {
            var itemDataForm = new ItemDataForm(_saveData.saveData.itemData);
            itemDataForm.Show();
        }

        private void ShippingDataButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void NameDataButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void LPocketDataButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BuildDataButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ItemFlagDataButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void PoliceBatchDataButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void MakingDataButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OrderDataButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void StatusDataButton_Click(object sender, EventArgs e)
        {
            this.MaxMonsterFriendship(_saveData.saveData.statusData);
        }

        private void FarmDataButton_Click(object sender, EventArgs e)
        {
            this.MaxSoilStats(_saveData.saveData.farmData);
        }

        private void SupportMonsterDataButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Maxes out the friendship values of all monsters in your barn.
        /// </summary>
        /// <param name="statusData">The current Statusdata from the save file.</param>
        private void MaxMonsterFriendship(RF5StatusData statusData)
        {
            foreach (var monster in statusData.FriendMonsterStatusDatas)
            {
                monster.LovePoint = 255;
            }
        }

        /// <summary>
        /// Kind of maxes out the soil stats. 
        /// Soil stats are stored in four BitVector32 structures. Each structure contains 4 soil values a 8-bytes.
        /// Variables labeled with 'Boost' are the ones the player can influence with items like greenifier.
        /// Variables labeled with 'Lvl' are the experience points of the soil that increase with harvesting. Once they overflow they increase the base values.
        /// Variables labeled with "base" are the base values of the soil.
        /// Other variables kind of influence the other stats in a weird way.
        /// This method only changes Boost and Lvl stats and ignores the others.
        /// </summary>
        /// <param name="farmData">The current farm data from the save file</param>
        private void MaxSoilStats(RF5FarmData farmData)
        {
            foreach (var soil in farmData.Soil)
            {
                
                BitVector32 soil0 = new BitVector32((int)soil.SI0.data);
                BitVector32.Section soil0_1 = BitVector32.CreateSection(255);
                BitVector32.Section growthBoost = BitVector32.CreateSection(255, soil0_1);
                BitVector32.Section soil0_3 = BitVector32.CreateSection(255, growthBoost);
                BitVector32.Section qualityBoost = BitVector32.CreateSection(255, soil0_3);

                // Kind of influences growthBoost and sizeBoost. Won't be changed.
                //soil0[soil0_1] = 0;
                // Kind of influences a lot. Won't be changed.
                //soil0[soil0_3] = 192;
                
                // Growth Boost. In-game maximum is 5.
                soil0[growthBoost] = 5;
                // Quality boost. In-game maximum is 127.
                soil0[qualityBoost] = 127;

                soil.SI0.data = (uint)soil0.Data;

                
                BitVector32 soil1 = new BitVector32((int)soil.SI1.data);
                BitVector32.Section sizeMulit = BitVector32.CreateSection(255);
                BitVector32.Section defenseBoost = BitVector32.CreateSection(255, sizeMulit);
                BitVector32.Section healthBoost = BitVector32.CreateSection(255, defenseBoost);
                BitVector32.Section sizeBoost = BitVector32.CreateSection(255, healthBoost);

                // This and sizeBoost influence each other. Won't change this one.
                //soil1[sizeMulit] = 255;

                // Defense maxes out at 253. Kind of resets sizeBoost when set to a higher value.
                soil1[defenseBoost] = 253;
                soil1[healthBoost] = 255;
                // Max value is 126. Greater value reduces in-game value.
                soil1[sizeBoost] = 126;

                soil.SI1.data = (uint)soil1.Data;


                BitVector32 soil2 = new BitVector32((int)soil.SI2.data);
                BitVector32.Section numberBase = BitVector32.CreateSection(255);
                BitVector32.Section sizeBase = BitVector32.CreateSection(255, numberBase);
                BitVector32.Section qualityBase = BitVector32.CreateSection(255, sizeBase);
                BitVector32.Section speedLvl = BitVector32.CreateSection(255, qualityBase);

                // Won't touch base values.
                //soil2[numberBase] = 0;
                //soil2[sizeBase] = 0;
                //soil2[qualityBase] = 0;
                soil2[speedLvl] = 255;

                soil.SI2.data = (uint)soil2.Data;

                           
                BitVector32 soil3 = new BitVector32(0);
                BitVector32.Section numberLvl = BitVector32.CreateSection(255);
                BitVector32.Section qualityLvl = BitVector32.CreateSection(255, numberLvl);
                BitVector32.Section sizeLvl = BitVector32.CreateSection(255, qualityLvl);
                BitVector32.Section speedBase = BitVector32.CreateSection(255, sizeLvl);

                // Max out soil experience points.
                soil3[numberLvl] = 255;
                soil3[qualityLvl] = 255;
                soil3[sizeLvl] = 255;

                // Won't touch base values.
                //soil3[speedBase] = 0;

                soil.SI3.data = (uint)soil3.Data;
            }
        }


    }
}
