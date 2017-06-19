using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shekels.Items
{
    class HallowLockBox : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hallowed Lock Box");
            Tooltip.SetDefault("Right click to open"
                + "\nRequires a Hallowed Key.");
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
            return Main.player[Main.myPlayer].HasItem(ItemID.HallowedKey);
        }

        public override void RightClick(Player player)
        {
            if (NPC.downedPlantBoss)
            {
                if (player.HasItem(ItemID.HallowedKey) && NPC.downedPlantBoss)
                {
                    player.inventory[player.FindItem(ItemID.HallowedKey)].stack -= 1;
                    player.QuickSpawnItem(ItemID.RainbowGun);
                }
            }
        }
    }
}
