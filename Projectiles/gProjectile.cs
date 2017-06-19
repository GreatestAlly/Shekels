using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shekels.Projectiles
{
    class gProjectile : GlobalProjectile
    {
        public override void PostDraw(Projectile projectile, SpriteBatch spriteBatch, Color lightColor)
        {
            if (projectile.melee && Main.player[projectile.owner].FindBuffIndex(mod.BuffType("WeaponImbueFrost")) >= 0)
            {
                int dust = Dust.NewDust(projectile.position, projectile.width, projectile.height, 230);
                Main.dust[dust].noGravity = true;
            }
        }

        public override bool PreDraw(Projectile projectile, SpriteBatch spriteBatch, Color lightColor)
        {
            // for debug purposes
            /*
            int x = (int)((projectile.position.X - Main.screenPosition.X));
            int y = (int)((projectile.position.Y - Main.screenPosition.Y));
            Rectangle r = new Rectangle(x, y, projectile.width, projectile.height);
            Texture2D image = Main.projectileTexture[mod.ProjectileType("BlankCardHoming")];
            spriteBatch.Draw(image, r, lightColor);
            */
            return base.PreDraw(projectile, spriteBatch, lightColor);
        }
    }
}
