using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Shekels.Projectiles
{
    class GateSpritePlaceholder : ModProjectile
    {
        public override void SetDefaults()
        {
            projectile.height = 10;
            projectile.width = 10;
            projectile.ranged = true;
            projectile.arrow = true;
            projectile.friendly = true;
            projectile.penetrate = -1;
            projectile.MaxUpdates = 2;
            aiType = 1;
        }
    }
}
