using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shekels.Projectiles
{
    class FluxArrowProjectile2 : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.UnholyArrow);
            projectile.timeLeft = 16;
            projectile.tileCollide = false;
            projectile.maxPenetrate = -1;
            aiType = 1;
        }

        /*public override bool PreAI()
        {
            return false;
        }*/
    }
}
