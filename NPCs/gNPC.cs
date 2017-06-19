using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections;

namespace Shekels.NPCs
{
    class gNPC : GlobalNPC
    {
        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }

        public bool Memed;

        public override void ResetEffects(NPC npc)
        {
            Memed = false;
        }

        public override void UpdateLifeRegen(NPC npc, ref int damage)
        {
            if (Memed)
            {
                if (npc.lifeRegen > 0)
                {
                    npc.lifeRegen = 0;
                }
                int arrowCount = 0;
                int ticksPerSec = 4;
                for (int index = 0; index < 1000; ++index)
                {
                    if (Main.projectile[index].active && Main.projectile[index].type == mod.ProjectileType("MemeArrow"))
                        if (((double)Main.projectile[index].ai[0] == 1.0 && (double)Main.projectile[index].ai[1] == (double)npc.whoAmI))
                            ++arrowCount;
                }
                if (arrowCount == 0)
                    arrowCount = 1;
                npc.lifeRegen = npc.lifeRegen - arrowCount * 2 * 8;
                if (damage < arrowCount * 2 / ticksPerSec)
                    damage = arrowCount * 2 / ticksPerSec;

            }
        }
    }
}
