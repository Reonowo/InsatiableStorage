using System;
using System.Collections.Generic;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;

namespace InsatiableStorage.Items
{
	public abstract class BaseBag : ModItem
	{
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Kuishi is adorable, isn't he?");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.maxStack = 1;
            item.value = 100;
            item.consumable = false;
            item.useStyle = ItemUseStyleID.SwingThrow;
            item.rare = ItemRarityID.LightPurple;
        }

        public override bool CanUseItem(Player player)
        {
            return true;
        }

        public override bool UseItem(Player player)
        {

            if (player.whoAmI == Main.myPlayer)
            {
                
                return true;
            }

            return base.UseItem(player);
        }
    }
}