using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shekels.Items.Weapons
{
    public class BlankCard : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blank Card");
            Tooltip.SetDefault("Cards with nothing written on them.");
        }

        public override void SetDefaults()
        {
            item.damage = 9;
            item.thrown = true;
            item.useTime = 10;
            item.width = 16;
            item.height = 20;
            item.maxStack = 999;
            item.noUseGraphic = true;
            item.useAnimation = 14;
            item.useStyle = 1;
            item.noMelee = true;
            item.knockBack = 1f;
            item.value = Item.sellPrice(0, 0, 0, 2);
            item.rare = 1;
            item.autoReuse = true;
            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType("BlankCardProjectile");
            item.shootSpeed = 9;
            item.consumable = true;
            projOnSwing = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Book, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 100);
            recipe.AddRecipe();
        }
    }
}