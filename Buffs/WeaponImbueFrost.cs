using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shekels.Buffs
{
    class WeaponImbueFrost : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Weapon Imbue Frost");
            Description.SetDefault("Melee attacks cause frostburn.");
            Main.buffNoSave[Type] = true;
        }
    }
}
