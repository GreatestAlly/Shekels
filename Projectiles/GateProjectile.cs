using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shekels.Projectiles
{
    class GateProjectile : ModProjectile
    {
        public override string Texture
        {
            get
            {
                return "Terraria/Item_3507";
            }
        }

        public override void SetDefaults()
        {
            projectile.height = 10;
            projectile.width = 10;
            projectile.timeLeft = 300;
            projectile.friendly = true;
            projectile.ranged = true;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            aiType = 2;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            projectile.velocity = Vector2.Multiply(projectile.velocity, 0.0f);
            return false;
        }

        public override bool PreAI()
        {
            return base.PreAI();
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            float initialSpeed = 1.5f;
            if (projectile.velocity.Length() > 1)
            {
                projectile.rotation = (float)Math.Atan2(projectile.velocity.X, projectile.velocity.Y) * -1 + (float)Math.PI * 3f / 4;
            }
            float distance = (300f - (float)projectile.timeLeft) * initialSpeed / (float)Math.Sqrt(2) + 10;
            Texture2D image = Main.itemTexture[(int)projectile.ai[0]];
            SpriteEffects effects = SpriteEffects.None;
            Vector2 position = projectile.position - Main.screenPosition + new Vector2(projectile.width / 2, projectile.height / 2);
            Vector2 center = new Vector2(image.Width - projectile.width, projectile.height);
            if (distance < image.Width)
            {
                Rectangle r = new Rectangle(image.Width - (int)distance, 0, (int)distance, (int)distance);
                center = new Vector2((int)distance - projectile.width, projectile.height);
                Texture2D portal = Main.projectileTexture[mod.ProjectileType("GateSpritePlaceholder")];
                float centerToCenter = (distance - projectile.width / 2) * (float)Math.Sqrt(2) - 15;
                Vector2 gateCenter = projectile.Center - Main.screenPosition + new Vector2(centerToCenter, 0).RotatedBy(projectile.rotation + (float)Math.PI * 3f / 4);
                Vector2 gateSpriteCenter = new Vector2(portal.Width / 2f, portal.Height / 2f);
                spriteBatch.Draw(portal, gateCenter, null, projectile.GetAlpha(lightColor), projectile.rotation - (float)Math.PI / 4f, gateSpriteCenter, 1f, effects, 0f);
                spriteBatch.Draw(image, position, r, projectile.GetAlpha(lightColor), projectile.rotation, center, 1f, effects, 0f);
                spriteBatch.Draw(portal, gateCenter, null, projectile.GetAlpha(lightColor), projectile.rotation + (float)Math.PI * 3f / 4f, gateSpriteCenter, 1f, effects, 0f);
            }
            else
            {
                if (projectile.velocity.Length() < 2 && projectile.velocity.Length() > 1)
                {
                    projectile.velocity = Vector2.Multiply(projectile.velocity, 10f);
                    projectile.tileCollide = true;
                }
                spriteBatch.Draw(image, position, null, projectile.GetAlpha(lightColor), projectile.rotation, center, 1f, effects, 0f);
            }
            return false;
        }
    }
}
