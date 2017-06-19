using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shekels.Items.Weapons
{
    class MDClubs : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Magic Deck of Clubs");
            Tooltip.SetDefault("Never runs out!"
                + "\nHigher knockback.");
        }

        public override void SetDefaults()
        {
            item.damage = 22;
            item.thrown = true;
            item.useTime = 7;
            item.width = 20;
            item.height = 24;
            item.maxStack = 1;
            item.noUseGraphic = true;
            item.useAnimation = 14;
            item.useStyle = 1;
            item.noMelee = true;
            item.knockBack = 4f;
            item.value = Item.sellPrice(0, 5, 0, 0);
            item.rare = 5;
            item.autoReuse = true;
            item.UseSound = SoundID.Item1;
            item.shoot = mod.ProjectileType("ClubsCardProjectile");
            item.shootSpeed = 9;
            item.consumable = false;
            projOnSwing = true;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "MDBlankCard");
            recipe.AddIngredient(ItemID.SoulofNight, 13);
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}
