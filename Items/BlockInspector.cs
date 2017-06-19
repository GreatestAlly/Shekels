using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shekels.Items
{
    class BlockInspector : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("BlockInspector");
            Tooltip.SetDefault("Shows info about blocks.");
        }

        public override void SetDefaults()
        {
            item.value = 50000;
            item.useStyle = 1;
            item.useAnimation = 20;
            item.useTime = 20;
            item.rare = 1;
            item.width = 26;
            item.height = 28;
            item.noMelee = true;
            item.stack = 1;
        }

        public override bool UseItem(Player player)
        {
            Main.NewText("testing");
            Tile t = Main.tile[((int)Main.screenPosition.X + Main.mouseX) / 16, ((int)Main.screenPosition.Y + Main.mouseY) / 16];
            Main.NewText("Block type: " + t.blockType());
            Main.NewText("Collision: " + t.collisionType);
            Main.NewText("type: " + t.type);
            Main.NewText("Wall: " + t.wall);
            Main.NewText("Liquid: " + t.liquid);
            Main.NewText("S Header:" + t.sTileHeader);
            Main.NewText("Header:" + t.bTileHeader);
            Main.NewText("Header 2:" + t.bTileHeader2);
            Main.NewText("Header 3:" + t.bTileHeader3);
            return true;
        }

        public override bool AltFunctionUse(Player player)
        {
            Tile t = Main.tile[((int)Main.screenPosition.X + Main.mouseX) / 16, ((int)Main.screenPosition.Y + Main.mouseY) / 16];
            t.ClearEverything();
            return true;
        }

        public override void AddRecipes()
        {
            /*ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.DirtBlock, 1);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();*/
        }
    }
}
