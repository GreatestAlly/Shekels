using Terraria.ID;
using Terraria.ModLoader;

namespace Shekels.Items.Weapons
{
    class FluxArrow : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flux Arrow");
            Tooltip.SetDefault("This is a modded ammo.");
        }

        public override void SetDefaults()
        {
            item.damage = 10;
            item.ranged = true;
            item.width = 10;
            item.height = 28;
            item.maxStack = 999;
            item.consumable = true;
            item.knockBack = 0f;
            item.value = 20;
            item.rare = 3;
            item.shoot = mod.ProjectileType("FluxArrowProjectile");
            item.shootSpeed = 0f;
            item.ammo = 1;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.WoodenArrow, 50);
            recipe.AddIngredient(ItemID.MartianConduitPlating, 1);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 50);
            recipe.AddRecipe();
        }
    }
}
