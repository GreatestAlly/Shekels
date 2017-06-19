using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shekels.Projectiles
{
    class GoldenCard : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.height = 16;
            projectile.width = 16;
            projectile.timeLeft = 20;
            projectile.friendly = true;
            projectile.thrown = true;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.maxPenetrate = -1;
            projectile.penetrate = -1;
            aiType = 2;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            //Texture2D image = Main.projectileTexture[projectile.type];
            //SpriteEffects effects = SpriteEffects.None;
            if (projectile.timeLeft < 5)
            {
                projectile.alpha = 255 - projectile.timeLeft * 51;
            }
            if (projectile.timeLeft > 15)
            {
                projectile.alpha = (projectile.timeLeft - 15) * 51;
            }
            projectile.rotation = (float)Math.Atan2(projectile.velocity.X, projectile.velocity.Y) * -1;
            //Vector2 location = new Vector2(8, 0);
            //spriteBatch.Draw(image, projectile.position - Main.screenPosition - new Vector2(-8, -8), null, projectile.GetAlpha(lightColor), projectile.rotation, location, 1f, effects, 0f);
            //return false;
            return true;
        }
    }
}
