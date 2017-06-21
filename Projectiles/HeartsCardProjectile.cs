using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
namespace Shekels.Projectiles
{
    class HeartsCardProjectile : ModProjectile
    {
        public override void SetDefaults()
        {
            base.SetDefaults();
            projectile.height = 16;
            projectile.width = 16;
            projectile.timeLeft = 65;
            projectile.friendly = true;
            projectile.thrown = true;
            aiType = 2;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D image = Main.projectileTexture[projectile.type];
            SpriteEffects effects = SpriteEffects.None;
            if (projectile.timeLeft < 15)
            {
                projectile.alpha = 255 - projectile.timeLeft * 17;
            }
            projectile.rotation = (float)Math.Atan2(projectile.velocity.X, projectile.velocity.Y) * -1;
            Vector2 location = new Vector2(8, 0);
            spriteBatch.Draw(image, projectile.position - Main.screenPosition - new Vector2(-8, -8), null, projectile.GetAlpha(lightColor), projectile.rotation, location, 1f, effects, 0f);
            return false;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            base.OnHitNPC(target, damage, knockback, crit);
            Player player = Main.player[projectile.owner];
            if (player.lifeSteal >= 0)
            {
                int heal = (int)(damage * .05f);
                heal = Math.Max(1, heal);
                player.lifeSteal -= heal;
                player.statLife += heal;
                player.HealEffect(heal);
            }
            for (int k = 3; k < 8 + player.extraAccessorySlots; k++)
            {
                if (player.armor[k].type == mod.ItemType("Sleeve") && crit)
                {
                    Projectile.NewProjectile(target.position.X, target.position.Y, 0f, -9f, mod.ProjectileType("HeartsCardHoming"), projectile.damage, 1f, projectile.owner);
                }
            }
        }

        public override void ModifyHitNPC(NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (projectile.timeLeft < 15)
            {
                damage = damage * projectile.timeLeft / 15;
            }
            base.ModifyHitNPC(target, ref damage, ref knockback, ref crit, ref hitDirection);
        }
    }
}
