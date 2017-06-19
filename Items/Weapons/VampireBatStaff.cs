using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shekels.Items.Weapons
{
    class VampireBatStaff : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vampire Bat Staff");
        }

        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.RavenStaff);
            item.buffType = mod.BuffType("VampireBat");
            item.buffTime = 18000;
            item.damage = 26;
            item.shoot = mod.ProjectileType("VampireBat");
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            position = Main.screenPosition + new Vector2(Main.mouseX, Main.mouseY);
            Projectile.NewProjectile(position.X, position.Y, 0, 0, mod.ProjectileType("VampireBat"), damage, 0, player.whoAmI);
            return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.BrokenBatWing, 1);
            recipe.AddIngredient(ItemID.HallowedBar, 12);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
