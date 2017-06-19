using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Shekels.NPCs;

namespace Shekels.Projectiles
{
    class MemeArrow : ModProjectile
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            projectile.height = 10;
            projectile.width = 10;
            projectile.ranged = true;
            projectile.arrow = true;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.MaxUpdates = 2;
            aiType = 1;
        }

        public override bool? CanHitNPC(NPC target)
        {
            return !target.friendly && !target.dontTakeDamage;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            //Texture2D image = Main.projectileTexture[projectile.type];
            //SpriteEffects effects = SpriteEffects.None;
            if (projectile.ai[0] != 1.0)
            {
                projectile.rotation = (float)Math.Atan2(projectile.velocity.Y, projectile.velocity.X) + (float)Math.PI / 2f;
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 6);
            }
            //Vector2 location = new Vector2(8, 8);
            //spriteBatch.Draw(image, projectile.position - Main.screenPosition - new Vector2(-8, -8), null, projectile.GetAlpha(lightColor), projectile.rotation, location, 1f, effects, 0f);
            return true;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            target.AddBuff(mod.BuffType("MemedOn"), 300);
            int index1 = target.whoAmI;
            projectile.timeLeft = 300;
            projectile.ai[0] = 1f;
            projectile.ai[1] = (float)index1;
            projectile.velocity = Vector2.Zero;
            projectile.netUpdate = true;
            projectile.damage = 0;
        }

        public override void AI()
        {
            if (projectile.ai[0] == 1.0)
            {
                NPC target = Main.npc[(int)projectile.ai[1]];
                projectile.position = Vector2.Add(Vector2.Multiply(Vector2.Subtract(target.position, target.oldPosition), 0.5f), projectile.oldPosition);
            }
        }
    }
}
