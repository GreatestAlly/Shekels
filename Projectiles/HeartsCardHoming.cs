using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace Shekels.Projectiles
{
    class HeartsCardHoming : ModProjectile
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            projectile.height = 16;
            projectile.width = 16;
            projectile.timeLeft = 300;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.tileCollide = false;
            aiType = 1;
            ProjectileID.Sets.Homing[projectile.type] = true;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D image = Main.projectileTexture[projectile.type];
            SpriteEffects effects = SpriteEffects.None;
            projectile.rotation = (float)Math.Atan2(projectile.velocity.X, projectile.velocity.Y) * -1;
            Vector2 location = new Vector2(8, 0);
            spriteBatch.Draw(image, projectile.position - Main.screenPosition - new Vector2(-8, -8), null, projectile.GetAlpha(lightColor), projectile.rotation, location, 1f, effects, 0f);
            return false;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            base.OnHitNPC(target, damage, knockback, crit);
            Main.player[projectile.owner].HealEffect(1);
            Player player = Main.player[projectile.owner];
            float offset;
            for (int k = 3; k < 8 + player.extraAccessorySlots; k++)
            {
                if (player.armor[k].type == mod.ItemType("Sleeve") && crit && Main.rand.Next(4) != 0)
                {
                    offset = (Main.rand.NextFloat() - 0.5f) * (float)Math.PI * 2f;
                    Projectile.NewProjectile(target.position.X, target.position.Y, (float)Math.Cos(offset) * 14f, (float)Math.Sin(offset) * 14f, projectile.type, projectile.damage, 1f, projectile.owner);
                }
            }
        }

        public override void AI()
        {
            if (projectile.localAI[0] == 0f)
            {
                AdjustMagnitude(ref projectile.velocity);
                projectile.localAI[0] = 1f;
            }
            Vector2 move = Vector2.Zero;
            float distance = 1200f;
            bool target = false;
            for (int k = 0; k < 200; k++)
            {
                if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && !Main.npc[k].friendly && Main.npc[k].lifeMax > 5)
                {
                    Vector2 newMove = Main.npc[k].Center - projectile.Center;
                    float distanceTo = (float)Math.Sqrt(newMove.X * newMove.X + newMove.Y * newMove.Y);
                    if (distanceTo < distance)
                    {
                        move = newMove;
                        distance = distanceTo;
                        target = true;
                    }
                }
            }
            if (target)
            {
                AdjustMagnitude(ref move);
                projectile.velocity = (10 * projectile.velocity + move) / 11f;
                AdjustMagnitude(ref projectile.velocity);
            }
        }

        private void AdjustMagnitude(ref Vector2 vector)
        {
            float magnitude = (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
            if (magnitude > 9f)
            {
                vector *= 9f / magnitude;
            }
        }
    }
}
