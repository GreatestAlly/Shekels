using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Shekels.Items
{
    class DesertCrate : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Desert Crate");
            Tooltip.SetDefault("Right click to open.");
        }

        public override void SetDefaults()
        {
            item.consumable = true;
            item.rare = 2;
            item.maxStack = 99;
            item.width = 12;
            item.height = 12;
            item.stack = 1;
        }

        public override bool CanRightClick()
        {
            return true;
        }

        public override void RightClick(Player player)
        {
            bool flag = true;
            int item;
            int stack;
            while (flag)
            {
                if (flag && Main.rand.Next(6) == 0)
                {
                    switch (Main.rand.Next(3))
                    {
                        case 0:
                            item = ItemID.SandstorminaBottle;
                            break;
                        case 1:
                            item = ItemID.FlyingCarpet;
                            break;
                        default:
                            item = ItemID.PharaohsMask;
                            player.QuickSpawnItem(item);
                            item = ItemID.PharaohsRobe;
                            break;
                    }
                    player.QuickSpawnItem(item);
                    flag = false;
                }
                if (Main.rand.Next(4) == 0)
                {
                    item = ItemID.GoldCoin;
                    stack = Main.rand.Next(5, 13);
                    player.QuickSpawnItem(item, stack);
                    flag = false;
                }
                if (Main.rand.Next(4) == 0)
                {
                    switch (Main.rand.Next(5))
                    {
                        case 0:
                            item = ItemID.IronBar;
                            break;
                        case 1:
                            item = ItemID.SilverBar;
                            break;
                        case 2:
                            item = ItemID.GoldBar;
                            break;
                        case 3:
                            item = ItemID.LeadBar;
                            break;
                        case 4:
                            item = ItemID.TungstenBar;
                            break;
                        default:
                            item = ItemID.PlatinumBar;
                            break;
                    }
                    stack = Main.rand.Next(10, 21);
                    if (Main.hardMode && Main.rand.Next(3) != 0)
                    {
                        switch (Main.rand.Next(5))
                        {
                            case 0:
                                item = ItemID.CobaltBar;
                                break;
                            case 1:
                                item = ItemID.MythrilBar;
                                break;
                            case 2:
                                item = ItemID.AdamantiteBar;
                                break;
                            case 3:
                                item = ItemID.PalladiumBar;
                                break;
                            case 4:
                                item = ItemID.OrichalcumBar;
                                break;
                            default:
                                item = ItemID.TitaniumBar;
                                break;
                        }
                        stack -= Main.rand.Next(3);
                    }
                    player.QuickSpawnItem(item, stack);
                    flag = false;
                }
            }
            if (Main.rand.Next(4) == 0)
            {
                switch (Main.rand.Next(5))
                {
                    case 0:
                        item = ItemID.ObsidianSkinPotion;
                        break;
                    case 1:
                        item = ItemID.SpelunkerPotion;
                        break;
                    case 2:
                        item = ItemID.HunterPotion;
                        break;
                    case 3:
                        item = ItemID.GravitationPotion;
                        break;
                    case 4:
                        item = ItemID.MiningPotion;
                        break;
                    default:
                        item = ItemID.HeartreachPotion;
                        break;
                }
                stack = Main.rand.Next(2, 5);
                player.QuickSpawnItem(item, stack);
            }
            if (Main.rand.Next(2) == 0)
            {
                item = Main.rand.Next(188, 190);
                stack = Main.rand.Next(5, 18);
                player.QuickSpawnItem(item, stack);
            }
            if (Main.rand.Next(2) == 0)
            {
                item = Main.rand.Next(2675, 2677);
                stack = Main.rand.Next(2, 7);
                player.QuickSpawnItem(item, stack);
            }
        }
    }
}
