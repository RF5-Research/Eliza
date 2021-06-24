using MessagePack;

namespace Eliza.Model.MonsterHut
{
    [MessagePackObject]
    public class FriendMonsterIDAndHouseID : KeyAndValue<int, uint> { }
}