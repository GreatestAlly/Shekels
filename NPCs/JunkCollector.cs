using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shekels.NPCs
{
    public class JunkCollector : ModNPC
    {
        public override string Texture
        {
            get
            {
                return "Shekels/NPCs/JunkCollector";
            }
        }

        public override string[] AltTextures
        {
            get
            {
                return new string[] { "Shekels/NPCs/JunkCollector_Alt_1" };
            }
        }


        public override bool Autoload(ref string name)
        {
            name = "Junk Collector";
            return mod.Properties.Autoload;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Junk Collector");
            Main.npcFrameCount[npc.type] = 25;
            NPCID.Sets.ExtraFramesCount[npc.type] = 9;
            NPCID.Sets.AttackFrameCount[npc.type] = 4;
            NPCID.Sets.DangerDetectRange[npc.type] = 700;
            NPCID.Sets.AttackType[npc.type] = 0;
            NPCID.Sets.AttackTime[npc.type] = 90;
            NPCID.Sets.AttackAverageChance[npc.type] = 30;
            NPCID.Sets.HatOffsetY[npc.type] = 4;
        }

        public override void SetDefaults()
        {
            npc.townNPC = true;
            npc.friendly = true;
            npc.width = 18;
            npc.height = 40;
            npc.aiStyle = 7;
            npc.damage = 10;
            npc.defense = 15;
            npc.lifeMax = 250;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
            animationType = NPCID.Guide;
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            int num = npc.life > 0 ? 1 : 5;
            for (int k = 0; k < num; k++)
            {
                Dust.NewDust(npc.position, npc.width, npc.height, 72);
            }
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            return numTownNPCs >= 8;
         }

        public override string TownNPCName()
        {
            switch (WorldGen.genRand.Next(4))
            {
                case 0:
                    return "Isaiah";
                case 1:
                    return "Fishke";
                case 2:
                    return "Lieber";
                default:
                    return "Avram";
            }
        }

        public override string GetChat()
        {
            /*int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
            if (partyGirl >= 0 && Main.rand.Next(4) == 0)
            {
                return "Can you please tell " + Main.npc[partyGirl].displayName + " to stop decorating my house with colors?";
            }*/
            switch (Main.rand.Next(3))
            {
                case 0:
                    return "You never know when something will be useful.";
                case 1:
                    return "It's never a good idea to throw anything away.";
                default:
                    return "One man's junk is another man's treasure. Or something like that.";
            }
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Lang.inter[28].Value;
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                shop = true;
            }
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            shop.item[nextSlot].SetDefaults(ItemID.Bottle);
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.SandBlock);
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.DirtBlock);
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.StoneBlock);
            nextSlot++;
            if (NPC.downedBoss3)
            {
                shop.item[nextSlot].SetDefaults(ItemID.Book);
                nextSlot++;
            }
            if (Main.hardMode)
            {
                shop.item[nextSlot].SetDefaults(ItemID.CrimstoneBlock);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.EbonstoneBlock);
                nextSlot++;
            }
            if (NPC.downedPlantBoss)
            {
                if (Main.bloodMoon)
                {
                    shop.item[nextSlot].SetDefaults(mod.ItemType("CrimsonLockBox"));
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(mod.ItemType("CorruptionLockBox"));
                    nextSlot++;
                }
                else if (Main.player[Main.myPlayer].ZoneHoly)
                {
                    shop.item[nextSlot].SetDefaults(mod.ItemType("HallowLockBox"));
                    nextSlot++;
                }
                else if (Main.player[Main.myPlayer].ZoneJungle)
                {
                    shop.item[nextSlot].SetDefaults(mod.ItemType("JungleLockBox"));
                    nextSlot++;
                }
                else if (Main.player[Main.myPlayer].ZoneSnow)
                {
                    shop.item[nextSlot].SetDefaults(mod.ItemType("IceLockBox"));
                    nextSlot++;
                }
            }
            if (NPC.downedAncientCultist)
            {
            }
            /*if (Main.moonPhase > 0)
            {
            }*/
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 20;
            knockback = 4f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 30;
            randExtraCooldown = 30;
        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            projType = mod.ProjectileType("BlankCardProjectile");
            attackDelay = 1;
        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            multiplier = 12f;
            randomOffset = 2f;
        }
    }
}