using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shekels.Items.Armor
{
    class Torcher : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Torcher");
            Tooltip.SetDefault("Places torches around you" 
                + "\nAlleviates the excruciating pain of having to place torches down.");
        }

        public override void SetDefaults()
        {
            item.accessory = true;
            item.width = 30;
            item.height = 30;
            item.value = 50000;
            item.rare = 1;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            int topX = (int)(player.Center.X / 16f) - 5;
            int topY = (int)(player.Center.Y / 16f) - 5;
            bool torchable = false;
            Tile temp;
            if (!player.HasItem(ItemID.Torch))
            {
                return;
            }
            for (int i = 0; i < 5 * 2; i++)
            {
                for (int j = 0; j < 5 * 2; j++)
                {
                    temp = Main.tile[topX + i, topY + j];
                    if ((temp.collisionType == 0 || temp.type == TileID.Plants || temp.type == TileID.LongMoss) && temp.liquid == 0)
                    {
                        if (temp.wall != 0)
                            torchable = true;
                        if ((Main.tile[topX + i - 1, topY + j].collisionType == 1 && Main.tile[topX + i - 1, topY + j].type != 10) || Main.tile[topX + i - 1, topY + j].type == 124)
                            torchable = true;
                        if ((Main.tile[topX + i + 1, topY + j].collisionType == 1 && Main.tile[topX + i + 1, topY + j].type != 10) || Main.tile[topX + i + 1, topY + j].type == 124)
                            torchable = true;
                        if (Main.tile[topX + i, topY + j + 1].collisionType == 1)
                            torchable = true;
                        for (int k = -7; k <= 7; k++)
                            for (int l = -7; l <= 7; l++)
                                if (Main.tile[topX + i + k, topY + j + l].type == 4)
                                    torchable = false;
                        if (torchable)
                        {
                            player.inventory[player.FindItem(ItemID.Torch)].stack -= 1;
                            WorldGen.KillTile(topX + i, topY + j, false, false, false);
                            if (!Main.tile[topX + i, topY + j].active() && Main.netMode == 1)
                            {
                                Terraria.Localization.NetworkText text = Terraria.Localization.NetworkText.FromLiteral("");
                                NetMessage.SendData(17, -1, -1, text, 0, (float)(topX + i), (float)(topY + j), 0f, 0, 0, 0);
                            }
                            WorldGen.PlaceTile(topX + i, topY + j, 4);
                            torchable = false;
                            return;
                        }
                    }
                }
            }
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Torch, 99);
            recipe.AddIngredient(ItemID.IronBar, 10);
            recipe.AddIngredient(ItemID.Chain, 3);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Torch, 99);
            recipe.AddIngredient(ItemID.LeadBar, 10);
            recipe.AddIngredient(ItemID.Chain, 3);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
