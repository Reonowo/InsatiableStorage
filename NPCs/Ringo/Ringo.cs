using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace InsatiableStorage.NPCs
{
    [AutoloadHead]
    public class Ringo : ModNPC
    {
        public override string Texture => "InsatiableStorage/NPCs/Ringo/Ringo";
        public override string[] AltTextures => new[] { "InsatiableStorage/NPCs/Ringo/Ringo_Alt_1" };

        public override bool Autoload(ref string name)
        {
            name = "Ringo";
            return true;
        }

        public override void SetStaticDefaults()
        {
            // DisplayName automatically assigned from .lang files, but the (un) commented line below is the normal approach.
            DisplayName.SetDefault("Apple");

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
            npc.damage = 1;
            npc.defense = 666;
            npc.lifeMax = 25565;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 1f;
            animationType = NPCID.Guide;
        }

        public override string GetChat()
        {
            //int partyGirl = NPC.FindFirstNPC(NPCID.PartyGirl);
            //if (partyGirl >= 0 && Main.rand.NextBool(4))
            //{
            //    return "Can you please tell " + Main.npc[partyGirl].GivenName + " to stop decorating my house with colors?";
            //}

            switch (Main.rand.Next(10))
            {
                case 0:
                    return "Hello there.";
                case 1:
                    return "I'm like a candywrapper, protecting my sweet insides, only to be thrown away after someone gets to it.";
                case 2:
                    {
                        return "Don't you think it's hot today?";
                        // Main.npcChatCornerItem shows a single item in the corner, like the Angler Quest chat.
                        //Main.npcChatCornerItem = ItemID.HiveBackpack;
                        //return $"Hey, if you find a [i:{ItemID.HiveBackpack}], I can upgrade it for you.";
                    }
                case 4:
                    return "Is it hot in here or is that just you?";
                case 5:
                    return "Me? Bipolar? You're delusional.";
                case 6:
                    return "I'm emotionally stable.";
                case 7:
                    return $"I think you're {(Main.clientPlayer.Male ? "handsome" : "cute")}.";
                case 8:
                    return "You look fat";
                default:
                    return "What? You think I'm too edgy? I'll stab you.";
            }
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = Language.GetTextValue("LegacyInterface.28");
            button2 = "";
            if (Main.LocalPlayer.HasItem(ItemID.HiveBackpack))
                button = "Upgrade " + Lang.GetItemNameValue(ItemID.HiveBackpack);
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            if (firstButton)
            {
                // We want 3 different functionalities for chat buttons, so we use HasItem to change button 1 between a shop and upgrade action.
                if (Main.LocalPlayer.HasItem(ItemID.HiveBackpack))
                {
                    Main.PlaySound(SoundID.Item37); // Reforge/Anvil sound
                    Main.npcChatText = $"I upgraded your {Lang.GetItemNameValue(ItemID.WaspGun)} to a {Lang.GetItemNameValue(ItemID.WaspGun)}";
                    int hiveBackpackItemIndex = Main.LocalPlayer.FindItem(ItemID.HiveBackpack);
                    Main.LocalPlayer.inventory[hiveBackpackItemIndex].TurnToAir();
                    Main.LocalPlayer.QuickSpawnItem(ItemID.WaspGun);
                    return;
                }
                shop = true;
            }
            else
            {
                // If the 2nd button is pressed, open the inventory...
                Main.playerInventory = true;
                // remove the chat window...
                Main.npcChatText = "";
                // and start an instance of our UIState.
                //ModContent.GetInstance<ExampleMod>().ExamplePersonUserInterface.SetState(new UI.ExamplePersonUI());
                // Note that even though we remove the chat window, Main.LocalPlayer.talkNPC will still be set correctly and we are still technically chatting with the npc.
            }
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            shop.item[nextSlot].SetDefaults(ItemID.HealingPotion);
            nextSlot++;
            shop.item[nextSlot].SetDefaults(ItemID.ManaPotion);
        }

        public override string TownNPCName()
        {
            return "Ringo";
        }
    }
}
