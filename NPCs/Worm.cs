using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace Shekels.NPCs
{
    public abstract class Worm : ModNPC
    {
        // function that returns the NPCID, given the total length of the worm
        // and a section position. 
        public int getSectionType(int section, int length)
        {
            return 0;
        }

        public override void AI()
        {
            base.AI();
        }
    }
}
