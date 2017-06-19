using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shekels.Items
{
    class CorruptionLockBox : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Corruption Lock Box");
            Tooltip.SetDefault("Right click to open."
                + "Requires a Corruption Key.");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            item.rare = 7;
            item.width = 32;
            item.height = 22;
            item.value = 2000000;
        }

        public override bool CanRightClick()
        {
            return Main.player[Main.myPlayer].HasItem(ItemID.CorruptionKey);
        }

        public override void RightClick(Player player)
        {
            if (NPC.downedPlantBoss)
            {
                if (player.HasItem(ItemID.CorruptionKey) && NPC.downedPlantBoss)
                {
                    player.inventory[player.FindItem(ItemID.CorruptionKey)].stack -= 1;
                    player.QuickSpawnItem(ItemID.ScourgeoftheCorruptor);
                }
            }
        }
    }
}
