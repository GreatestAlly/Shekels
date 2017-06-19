using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shekels
{
    class ShekelsPlayer : ModPlayer
    {

        public bool[] cards;

        public override void Initialize()
        {
            cards = new bool[8];
            for (int i = 0; i < 8; i++)
            {
                cards[i] = false;
            }
            base.Initialize();
        }

        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            if (this.player.FindBuffIndex(mod.BuffType("WeaponImbueFrost")) > 1 && item.melee)
            {
                if (Main.expertMode)
                {
                    target.AddBuff(BuffID.Frostburn, 120 + Main.rand.Next(840));
                }
                else
                {
                    target.AddBuff(BuffID.Frostburn, 60 + Main.rand.Next(420));
                }
            }
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            if (this.player.FindBuffIndex(mod.BuffType("WeaponImbueFrost")) > 1 && proj.melee)
            {
                if (Main.expertMode)
                {
                    target.AddBuff(BuffID.Frostburn, 120 + Main.rand.Next(840));
                }
                else
                {
                    target.AddBuff(BuffID.Frostburn, 60 + Main.rand.Next(420));
                }
            }
        }

        public override void MeleeEffects(Item item, Rectangle hitbox)
        {
            if (this.player.FindBuffIndex(mod.BuffType("WeaponImbueFrost")) > 1 && item.melee)
            {
                int dust = Dust.NewDust(hitbox.Location.ToVector2(), hitbox.Width, hitbox.Height, 230);
                Main.dust[dust].noGravity = true;
            }
        }

        public override void CatchFish(Item fishingRod, Item bait, int power, int liquidType, int poolSize, int worldLayer, int questFish, ref int caughtType, ref bool junk)
        {
            if (liquidType != 0)
            {
                return;
            }
            if (caughtType != 2334 && caughtType != 2335)
            {
                return;
            }
            if (player.ZoneCorrupt || player.ZoneCrimson || player.ZoneDungeon || player.ZoneHoly || player.ZoneJungle)
            {
                return;
            }
            if (player.ZoneSnow)
            {
                int chance = 150 * 7 / power;
                if (chance < 4)
                {
                    chance = 4;
                }
                if (Main.rand.Next(chance) == 0)
                {
                    caughtType = mod.ItemType("IceCrate");
                }
            }
            else if (worldLayer <= 1 && (player.position.X < 380 || player.position.X > Main.maxTilesX - 380) && poolSize > 1000)
            {
                int chance = 150 * 7 / power;
                if (chance < 4)
                {
                    chance = 4;
                }
                if (Main.rand.Next(chance) == 0)
                {
                    caughtType = mod.ItemType("OceanCrate");
                }
            }
            else if (player.ZoneDesert)
            {
                int chance = 150 * 7 / power;
                if (chance < 4)
                {
                    chance = 4;
                }
                if (Main.rand.Next(chance) == 0)
                {
                    caughtType = mod.ItemType("DesertCrate");
                }
            }
        }
    }
}
