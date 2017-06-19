using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shekels.Items
{
    class CrimsonLockBox : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crimson Lock Box");
            Tooltip.SetDefault("Right click to open"
                + "\nRequires a Crimson Key.");
        }

        public override void SetDefaults()
        {
            item.rare = 7;
            item.width = 32;
            item.height = 22;
            item.value = 2000000;
        }

        public override bool CanRightClick()
        {
            return Main.player[Main.myPlayer].HasItem(ItemID.CrimsonKey);
        }

        public override void RightClick(Player player)
        {
            if (NPC.downedPlantBoss)
            {
                if (player.HasItem(ItemID.CrimsonKey) && NPC.downedPlantBoss)
                {
                    player.inventory[player.FindItem(ItemID.CrimsonKey)].stack -= 1;
                    player.QuickSpawnItem(ItemID.VampireKnives);
                }
            }
        }
    }
}
