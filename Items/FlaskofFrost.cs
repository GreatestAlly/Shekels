using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shekels.Items
{
    class FlaskofFrost : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flask of Frost");
            Tooltip.SetDefault("Melee attacks inflict enemies with frostburn");
        }

        public override void SetDefaults()
        {
            item.value = 1500;
            item.useStyle = 2;
            item.useAnimation = 17;
            item.useTime = 17;
            item.consumable = true;
            item.useTurn = true;
            item.rare = 4;
            item.maxStack = 30;
            item.width = 14;
            item.height = 24;
            item.UseSound = SoundID.Item3;
            item.buffType = mod.BuffType("WeaponImbueFrost");
            item.buffTime = 72000;
            item.stack = 1;
        }

        public override bool UseItem(Player player)
        {
            if (player.FindBuffIndex(71) > 0)
            {
                player.ClearBuff(71);
            }
            if (player.FindBuffIndex(73) > 0)
            {
                player.ClearBuff(73);
            }
            if (player.FindBuffIndex(74) > 0)
            {
                player.ClearBuff(74);
            }
            if (player.FindBuffIndex(75) > 0)
            {
                player.ClearBuff(75);
            }
            if (player.FindBuffIndex(76) > 0)
            {
                player.ClearBuff(76);
            }
            if (player.FindBuffIndex(77) > 0)
            {
                player.ClearBuff(77);
            }
            if (player.FindBuffIndex(78) > 0)
            {
                player.ClearBuff(78);
            }
            if (player.FindBuffIndex(79) > 0)
            {
                player.ClearBuff(79);
            }
            return true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BottledWater, 15);
            recipe.AddIngredient(ItemID.FrostCore, 1);
            recipe.AddTile(TileID.ImbuingStation);
            recipe.SetResult(this, 15);
            recipe.AddRecipe();
            /*recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, 1);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();*/
        }
    }
}
