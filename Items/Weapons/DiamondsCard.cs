using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shekels.Items.Weapons
{
    class DiamondsCard : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Seven of Diamonds");
            Tooltip.SetDefault("Some say that the pattern makes it fly faster.");
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
            item.value = Item.sellPrice(0, 0, 0, 5);
            item.rare = 2;
            item.autoReuse = true;
            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType("DiamondsCardProjectile");
            item.shootSpeed = 12;
            item.consumable = true;
            projOnSwing = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "BlankCard", 100);
            recipe.AddIngredient(ItemID.RedPaint, 1);
            recipe.AddTile(TileID.WorkBenches);
            recipe.SetResult(this, 100);
            recipe.AddRecipe();
        }
    }
}
