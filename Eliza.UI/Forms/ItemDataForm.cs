using Eliza.Model.SaveData;
using Eliza.UI.Widgets;
using Eto.Forms;

namespace Eliza.UI.Forms
{
    internal class ItemDataForm : Form
    {
        public ItemDataForm(RF5ItemData itemData)
        {
            Title = "Item Data";

            var partyData = new GroupBox()
            {
                Text = "Party Data"
            };

            var ruckSack = new ItemStorageDataGroup(itemData.Rucksack, text: "Ruck Sack");
            var itemBox = new ItemStorageDataGroup(itemData.ItemBox, text: "Item Box");
            var refrigerator = new ItemStorageDataGroup(itemData.Refrigerator, text: "Refrigerator");
            var runeRuck = new ItemStorageDataGroup(itemData.RuneRuck, text: "Rune Ruck");
            var weaponBox = new ItemStorageDataGroup(itemData.WeaponBox, text: "Weapon Box");
            var armorBox = new ItemStorageDataGroup(itemData.ArmorBox, text: "Armor Box");
            var farmToolBox = new ItemStorageDataGroup(itemData.FarmToolBox, text: "Farm Toolbox");
            var runeBox = new ItemStorageDataGroup(itemData.RuneBox, text: "Rune Box");
            var shippingBox = new ItemStorageDataGroup(itemData.ShippingBox, text: "Shipping Box");

            var vBox = new VBox();
            vBox.Items.Add(ruckSack);
            vBox.Items.Add(itemBox);
            vBox.Items.Add(refrigerator);
            vBox.Items.Add(runeRuck);
            vBox.Items.Add(weaponBox);
            vBox.Items.Add(armorBox);
            vBox.Items.Add(farmToolBox);
            vBox.Items.Add(runeBox);
            vBox.Items.Add(shippingBox);

            var fieldOnGroundItemStorage = new GroupBox()
            {
                Text = "Field On Ground Item Storage"
            };

            var scroll = new Scrollable();
            scroll.Content = vBox;

            Content = scroll;
        }
    }
}