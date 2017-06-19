using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.Utilities;

namespace Shekels.Items.Weapons
{
    class Gate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Archer Card");
            Tooltip.SetDefault("Stuff happens.");
        }

        public override void SetDefaults()
        {
            item.damage = 50;
            item.crit = 4;
            item.ranged = true;
            item.useTime = 5;
            item.width = 16;
            item.height = 20;
            item.maxStack = 1;
            item.UseSound = SoundID.Item7;
            item.useAnimation = item.useTime;
            item.useStyle = 3;
            item.noUseGraphic = true;
            item.noMelee = true;
            item.knockBack = 2f;
            item.value = Item.sellPrice(20, 0, 0, 0);
            item.rare = 5;
            item.autoReuse = true;
            item.shoot = mod.ProjectileType("GateProjectile");
            item.shootSpeed = 1.5f;
            item.consumable = false;
            item.mana = 4;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
        {
            position = position + Main.rand.NextVector2Circular(30, 30) + Main.rand.NextVector2CircularEdge(60, 60);
            int swordType = getSwordType();
            Projectile.NewProjectile(position, new Vector2(speedX, speedY), item.shoot, damage, knockBack, player.whoAmI, swordType);
            return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.FragmentVortex, 9);
            recipe.AddIngredient(ItemID.FragmentSolar, 9);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }

        public int getSwordType()
        {
            WeightedRandom<int> swords = new WeightedRandom<int>();

            swords.Add(ItemID.CopperShortsword);
            swords.Add(ItemID.TinShortsword);
            swords.Add(ItemID.WoodenSword);
            swords.Add(ItemID.BorealWoodSword);
            swords.Add(ItemID.CopperBroadsword);
            swords.Add(ItemID.IronShortsword);
            swords.Add(ItemID.PalmWoodSword);
            swords.Add(ItemID.RichMahoganySword);
            swords.Add(ItemID.CactusSword);
            swords.Add(ItemID.LeadShortsword);
            swords.Add(ItemID.SilverShortsword);
            swords.Add(ItemID.TinShortsword);
            swords.Add(ItemID.EbonwoodSword);
            swords.Add(ItemID.IronBroadsword);
            swords.Add(ItemID.ShadewoodSword);
            swords.Add(ItemID.TungstenShortsword);
            swords.Add(ItemID.GoldShortsword);
            swords.Add(ItemID.LeadBroadsword);
            swords.Add(ItemID.SilverBroadsword);
            swords.Add(ItemID.TungstenBroadsword);
            swords.Add(ItemID.ZombieArm);
            swords.Add(ItemID.GoldBroadsword);
            swords.Add(ItemID.PlatinumShortsword);
            swords.Add(ItemID.AntlionClaw);
            swords.Add(ItemID.StylistKilLaKillScissorsIWish);
            swords.Add(ItemID.PlatinumBroadsword);
            swords.Add(ItemID.BoneSword);
            swords.Add(ItemID.CandyCaneSword);
            swords.Add(ItemID.Katana);
            swords.Add(ItemID.IceBlade);
            swords.Add(ItemID.LightsBane);
            swords.Add(ItemID.Muramasa);
            swords.Add(ItemID.Arkhalis);
            swords.Add(ItemID.DyeTradersScimitar);
            swords.Add(ItemID.BluePhaseblade);
            swords.Add(ItemID.GreenPhaseblade);
            swords.Add(ItemID.PurplePhaseblade);
            swords.Add(ItemID.RedPhaseblade);
            swords.Add(ItemID.WhitePhaseblade);
            swords.Add(ItemID.YellowPhaseblade);
            swords.Add(ItemID.BloodButcherer);
            swords.Add(ItemID.Starfury);
            swords.Add(ItemID.EnchantedSword);
            swords.Add(ItemID.PurpleClubberfish);
            swords.Add(ItemID.BeeKeeper);
            swords.Add(ItemID.FalconBlade);
            swords.Add(ItemID.BladeofGrass);
            swords.Add(ItemID.FieryGreatsword);
            swords.Add(ItemID.BluePhasesaber);
            swords.Add(ItemID.GreenPhasesaber);
            swords.Add(ItemID.PurplePhasesaber);
            swords.Add(ItemID.RedPhasesaber);
            swords.Add(ItemID.WhitePhasesaber);
            swords.Add(ItemID.YellowPhasesaber);
            swords.Add(ItemID.NightsEdge);

            swords.Add(ItemID.PearlwoodSword);
            swords.Add(ItemID.TaxCollectorsStickOfDoom);
            swords.Add(ItemID.SlapHand);
            swords.Add(ItemID.BreakerBlade);
            swords.Add(ItemID.CobaltSword);
            swords.Add(ItemID.PalladiumSword);
            swords.Add(ItemID.MythrilSword);
            swords.Add(ItemID.OrichalcumSword);
            swords.Add(ItemID.ChlorophyteSaber);
            swords.Add(ItemID.Cutlass);
            swords.Add(ItemID.Frostbrand);
            swords.Add(ItemID.AdamantiteSword);
            swords.Add(ItemID.Seedler);
            swords.Add(ItemID.BeamSword);
            swords.Add(ItemID.TitaniumSword);
            swords.Add(ItemID.Bladetongue);
            swords.Add(ItemID.Excalibur);

            swords.Add(ItemID.Spear);
            swords.Add(ItemID.Trident);
            swords.Add(ItemID.TheRottedFork);
            swords.Add(ItemID.Swordfish);
            swords.Add(ItemID.DarkLance);
            swords.Add(ItemID.CobaltNaginata);
            swords.Add(ItemID.PalladiumPike);
            swords.Add(ItemID.MythrilHalberd);
            swords.Add(ItemID.OrichalcumHalberd);
            swords.Add(ItemID.AdamantiteGlaive);
            swords.Add(ItemID.TitaniumTrident);
            swords.Add(ItemID.Gungnir);
            swords.Add(ItemID.ChlorophytePartisan);
            swords.Add(ItemID.MushroomSpear);
            swords.Add(ItemID.ObsidianSwordfish);
            swords.Add(ItemID.NorthPole);

            swords.Add(ItemID.ScourgeoftheCorruptor);
            swords.Add(ItemID.DayBreak);

            swords.Add(ItemID.SkyFracture);

            swords.Add(ItemID.WarAxeoftheNight);
            swords.Add(ItemID.BloodLustCluster);
            swords.Add(ItemID.FleshGrinder);
            swords.Add(ItemID.TheBreaker);

            swords.Add(ItemID.Hammush);
            swords.Add(ItemID.CobaltWaraxe);
     
            return swords.Get();
        }
    }
}
