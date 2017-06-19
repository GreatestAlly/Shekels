using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Shekels.Items
{
    class UBW : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Unlimited Bait Works");
            Tooltip.SetDefault("I am the bone of my bait.");
        }

        public override void SetDefaults()
        {
            item.value = 50000;
            item.consumable = false;
            item.rare = 3;
            item.maxStack = 1;
            item.width = 12;
            item.height = 12;
            item.bait = 15;
            item.stack = 1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Bone, 99);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
