using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shekels.Projectiles
{
    class FluxArrowProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.WoodenArrowFriendly);
            aiType = 1;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            base.OnHitNPC(target, damage, knockback, crit);
            float distance = 400f;
            float offset;
            bool t = false;
            NPC target2 = target;
            for (int k = 0; k < 200; k++)
            {
                if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5)
                {
                    Vector2 newMove = Main.npc[k].Center - projectile.Center;
                    float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
                    if (distanceTo < distance)
                    {
                        distance = distanceTo;
                        t = true;
                        target2 = Main.npc[k];
                    }
                }
            }
            if (t)
            {
                offset = (Main.rand.NextFloat() - 0.5f) * (float)Math.PI * 2f;
                Projectile.NewProjectile(target2.Center.X - (float)Math.Cos(offset) * 120f, target2.Center.Y - (float)Math.Sin(offset) * 120f, (float)Math.Cos(offset) * 15f, (float)Math.Sin(offset) * 15f, mod.ProjectileType("FluxArrowProjectile2"), projectile.damage, projectile.knockBack, projectile.owner);
            }
        }
    }
}
