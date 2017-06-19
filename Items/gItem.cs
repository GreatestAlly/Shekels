using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shekels.Items
{
    class gItem : GlobalItem
    {
        public override bool UseItem(Item item, Player player)
        {
            if (player.FindBuffIndex(mod.BuffType("WeaponImbueFrost")) > 0)
            {
                if ((item.type > 1352 && item.type < 1360) || item.type == 1340)
                {
                    player.ClearBuff(mod.BuffType("WeaponImbueFrost"));
                    return true;
                }
            }
            return base.UseItem(item, player);
        }
    }
}
