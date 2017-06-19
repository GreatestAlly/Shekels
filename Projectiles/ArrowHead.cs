using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shekels.Projectiles
{
    class ArrowHead : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.height = 10;
            projectile.width = 10;
            projectile.ranged = true;
            projectile.arrow = true;
            projectile.friendly = true;
            aiType = 1;
        }
    }
}
