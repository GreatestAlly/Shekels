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
    class CardOfBabylon : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Card of Babylon");
            Tooltip.SetDefault("Stuff happens.");
        }

        public override void SetDefaults()
        {
            item.damage = 50;
            item.crit = 4;
            item.thrown = true;
            item.useTime = 10;
            item.width = 16;
            item.height = 20;
            item.maxStack = 1;
            item.useAnimation = 14;
            item.useStyle = 4;
            item.noMelee = true;
            item.knockBack = 2f;
            item.value = Item.sellPrice(20, 0, 0, 0);
            item.rare = 5;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("GoldenCard");
            item.shootSpeed = 15;
            item.consumable = false;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            float distance = 500;
            bool target = false;
            NPC targetNPC;
            List<int> possibleTargets = new List<int>();
            for (int k = 0; k < 200; k++)
            {
                if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5)
                {
                    Vector2 newMove = Main.npc[k].Center - player.position;
                    float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
                    if (distanceTo < distance)
                    {
                        target = true;
                        possibleTargets.Add(k);
                    }
                }
            }
            if (target)
            {
                targetNPC = Main.npc[possibleTargets[Main.rand.Next(possibleTargets.Count)]];
                float offset = (Main.rand.NextFloat() - 0.5f) * (float)Math.PI * 2f;
                position = targetNPC.Center - new Vector2((float)Math.Cos(offset) * 150f, (float)Math.Sin(offset) * 150f);
                speedX = (float)Math.Cos(offset) * 15f;
                speedY = (float)Math.Sin(offset) * 15f;
            }
            return target;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "MDInstructions");
            recipe.AddIngredient(null, "MDSpades");
            recipe.AddIngredient(null, "MDHearts");
            recipe.AddIngredient(null, "MDClubs");
            recipe.AddIngredient(null, "MDDiamonds");
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
