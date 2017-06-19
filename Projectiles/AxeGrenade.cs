using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shekels.Projectiles
{
    class AxeGrenade : ModProjectile
    {
        public override string Texture
        {
            get
            {
                return "Terraria/Projectile_30";
            }
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.Grenade);
            aiType = ProjectileID.Grenade;
            projectile.timeLeft = 60;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.velocity = new Vector2(0, 0);
            return false;
        }

        public override void Kill(int timeLeft)
        {
            int range = 3;
            int left = (int)(projectile.Center.X / 16f - (float)range);
            int up = (int)(projectile.Center.Y / 16f - (float)range);
            int right = (int)(projectile.Center.X / 16f + (float)range);
            int down = (int)(projectile.Center.Y / 16f + (float)range);
            if (left < 0)
                left = 0;
            if (up < 0)
                up = 0;
            if (right > Main.maxTilesX)
                right = Main.maxTilesX;
            if (down > Main.maxTilesY)
                down = Main.maxTilesY;
            for (int i = left; i <= right; i++)
            {
                for (int j = down; j >= up; j--)
                {
                    float deltaX = Math.Abs((float)i - projectile.Center.X / 16f);
                    float deltaY = Math.Abs((float)j - projectile.Center.Y / 16f);
                    double distance = Math.Sqrt((double)(deltaX * deltaX + deltaY * deltaY));
                    if (distance < (double)range)
                    {
                        if (Main.tile[i, j].type == TileID.Trees || Main.tile[i, j].type == TileID.PalmTree)
                        {
                            WorldGen.KillTile(i, j, false, false, false);
                            if (!Main.tile[i, j].active() && Main.netMode != 0)
                            {
                                Terraria.Localization.NetworkText text = Terraria.Localization.NetworkText.FromLiteral("");
                                NetMessage.SendData(17, -1, -1, text, 0, (float)i, (float)j, 0f, 0, 0, 0);
                            }
                        }
                    }
                }
            }
            base.Kill(timeLeft);
        }
    }

    class AxeGrenadeItem : ModItem
    {
        public override string Texture
        {
            get
            {
                return "Terraria/Item_168";
            }
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lumberjack's Grenade");
            Tooltip.SetDefault("Sticks to tiles."
                + "\nCuts down trees.");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.Grenade);
            item.shoot = mod.ProjectileType("AxeGrenade");
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Grenade, 50);
            recipe.AddIngredient(ItemID.CopperAxe);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 50);
            recipe.AddRecipe();
        }
    }
}
