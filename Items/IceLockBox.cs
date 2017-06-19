using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shekels.Items
{
    class IceLockBox : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frozen Lock Box");
            Tooltip.SetDefault("Right click to open."
                + "\nRequires a Frozen Key.");
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
            return Main.player[Main.myPlayer].HasItem(ItemID.FrozenKey);
        }

        public override void RightClick(Player player)
        {
            if (NPC.downedPlantBoss)
            {
                if (player.HasItem(ItemID.FrozenKey) && NPC.downedPlantBoss)
                {
                    player.inventory[player.FindItem(ItemID.FrozenKey)].stack -= 1;
                    player.QuickSpawnItem(ItemID.StaffoftheFrostHydra);
                }
            }
        }
    }
}
