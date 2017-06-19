using Terraria;
using Terraria.ModLoader;
using Shekels.NPCs;

namespace Shekels.Buffs
{
    class MemedOn : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Memed On");
            Description.SetDefault("Losing life");
            Main.debuff[Type] = true;
            Main.pvpBuff[Type] = false;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = true;
        }

        public override void Update(NPC npc, ref int buffIndex)
        {
            npc.GetGlobalNPC<gNPC>(mod).Memed = true;
        }
    }
}
