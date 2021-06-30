using Eliza.UI.Helpers;
using Eto.Forms;

namespace Eliza.UI.Widgets
{
    public class RewardItemDataGroup : VBox
    {
        private Model.Field.RewardItemData _rewardItemData;

        private SpinBox itemId;
        private SpinBox amount;
        private SpinBox level;

        public RewardItemDataGroup(Model.Field.RewardItemData rewardItemData)
        {
            _rewardItemData = rewardItemData;

            itemId = new SpinBox(new Ref<int>(() => _rewardItemData.ItemID, v => { _rewardItemData.ItemID = v; }), "Item ID");
            amount = new SpinBox(new Ref<int>(() => _rewardItemData.Amount, v => { _rewardItemData.Amount = v; }), "Amount");
            level = new SpinBox(new Ref<int>(() => _rewardItemData.Level, v => { _rewardItemData.Level = v; }), "Level");

            StackLayoutItem[] vBoxItems =
            {
                itemId,
                amount,
                level
            };

            foreach (var item in vBoxItems)
            {
                Items.Add(item);
            }
        }

        public RewardItemDataGroup()
        {
            var vBox = new VBox();

            itemId = new SpinBox("Item ID");
            amount = new SpinBox("Amount");
            level = new SpinBox("Level");

            StackLayoutItem[] vBoxItems =
            {
                itemId,
                amount,
                level
            };

            foreach (var item in vBoxItems)
            {
                Items.Add(item);
            }
        }

        public void ChangeReferenceValue(Model.Field.RewardItemData rewardItemData)
        {
            _rewardItemData = rewardItemData;
            itemId.ChangeReferenceValue(new Ref<int>(() => _rewardItemData.ItemID, v => { _rewardItemData.ItemID = v; }));
            amount.ChangeReferenceValue(new Ref<int>(() => _rewardItemData.Amount, v => { _rewardItemData.Amount = v; }));
            level.ChangeReferenceValue(new Ref<int>(() => _rewardItemData.Level, v => { _rewardItemData.Level = v; }));
        }
    }
}
