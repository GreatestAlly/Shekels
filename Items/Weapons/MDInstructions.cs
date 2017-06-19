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
    class MDInstructions : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Magic Deck of Playing Cards");
            Tooltip.SetDefault("The be all, end all of playing cards."
                + "\nCrashing this game, with no survivors!");
        }

        public override void SetDefaults()
        {
            item.damage = 10;
            item.crit = 11;
            item.thrown = true;
            item.useTime = 9;
            item.width = 20;
            item.height = 24;
            item.maxStack = 1;
            item.noUseGraphic = true;
            item.useAnimation = 14;
            item.useStyle = 1;
            item.noMelee = true;
            item.knockBack = 2f;
            item.value = Item.sellPrice(5, 0, 0, 0);
            item.rare = 5;
            item.autoReuse = true;
            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType("InstructionsCardHoming");
            item.shootSpeed = 14;
            item.consumable = false;
            projOnSwing = true;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float angle = (float)Math.PI / 6f;
            float offset;
            for (int i = 0; i < 4; i++)
            {
                offset = (Main.rand.NextFloat() - 0.5f) * angle;
                switch (Main.rand.Next(4))
                {
                    case 0:
                        type = mod.ProjectileType("HeartsCardHoming");
                        break;
                    case 1:
                        type = mod.ProjectileType("ClubsCardHoming");
                        break;
                    case 2:
                        type = mod.ProjectileType("DiamondsCardHoming");
                        break;
                    default:
                        type = mod.ProjectileType("SpadesCardHoming");
                        break;
                }
                Projectile.NewProjectile(position, new Vector2(speedX, speedY).RotatedBy(offset), type, damage, knockBack, player.whoAmI);
            }
            return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "MDSpades");
            recipe.AddIngredient(null, "MDHearts");
            recipe.AddIngredient(null, "MDClubs");
            recipe.AddIngredient(null, "MDDiamonds");
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
