using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shekels.Buffs
{
    class VampireBat : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Vampire Bat");
            Description.SetDefault("The Vampire Bats will fight for you.");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }
		public override void Update(Player player, ref int buffIndex)
        {
            if (player.ownedProjectileCounts[mod.ProjectileType("VampireBat")] <= 0)
            {
                player.DelBuff(buffIndex);
                buffIndex--;
            }
            else
            {
                player.buffTime[buffIndex] = 18000;
            }
        }
    }
}
