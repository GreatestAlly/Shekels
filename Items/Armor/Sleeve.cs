using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shekels.Items.Armor
{
    class Sleeve : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Card Player's Sleeve");
            Tooltip.SetDefault("A good player always has an ace up their sleeve.");
        }

        public override void SetDefaults()
        {
            item.accessory = true;
            item.width = 30;
            item.height = 30;
            item.value = 10000;
            item.rare = 3;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BlankCard", 100);
            recipe.AddIngredient(ItemID.Silk, 10);
            recipe.AddIngredient(ItemID.GreenThread, 10);
            recipe.AddTile(TileID.Loom);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
