using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shekels.Projectiles.Minions
{
    class VampireBat : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.Raven);
            Main.projFrames[projectile.type] = 4;
            projectile.timeLeft = 18000;
            projectile.maxPenetrate = -1;
            projectile.penetrate = -1;
        }

        public override bool PreAI()
        {
            if (Main.player[projectile.owner].FindBuffIndex(mod.BuffType("VampireBat")) <= 0)
            {
                projectile.timeLeft = 1;
            } else
            {
                projectile.timeLeft = 18000;
            }
            return base.PreAI();
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            if (projectile.frame < 0 || projectile.frame > 3)
            {
                projectile.frame = 0;
            }
            return base.PreDraw(spriteBatch, lightColor);
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[projectile.owner];
            if (player.lifeSteal >= 0 && Main.rand.Next(4) == 0)
            {
                int heal = 1;
                player.lifeSteal -= heal;
                player.statLife += heal;
                player.HealEffect(heal);
            }
            base.OnHitNPC(target, damage, knockback, crit);
        }
    }
}
