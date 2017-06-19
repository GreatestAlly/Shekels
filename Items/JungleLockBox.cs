using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shekels.Items
{
    class JungleLockBox : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jungle Lock Box");
            Tooltip.SetDefault("Right click to open."
                + "\nRequires a Jungle Key.");
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
            return Main.player[Main.myPlayer].HasItem(ItemID.JungleKey);
        }

        public override void RightClick(Player player)
        {
            if (NPC.downedPlantBoss)
            {
                if (player.HasItem(ItemID.JungleKey) && NPC.downedPlantBoss)
                {
                    player.inventory[player.FindItem(ItemID.JungleKey)].stack -= 1;
                    player.QuickSpawnItem(ItemID.PiranhaGun);
                }
            }
        }
    }
}
