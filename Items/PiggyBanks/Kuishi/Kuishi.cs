using InsatiableStorage.Projectiles.Kuishi;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InsatiableStorage.Items.PiggyBanks.Kuishi
{
    public class Kuishi : ModItem
    {
        public override void SetStaticDefaults()
        {
            Tooltip.SetDefault("Kuishi is adorable, isn't he?");
        }
        
        public override void SetDefaults()
        {
            item.CloneDefaults(ItemID.MoneyTrough);

            item.shoot = ModContent.ProjectileType<KuishiProjectile>();
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
            if (player.whoAmI == Main.myPlayer && player.itemTime == 0)
            {
                int projectileID = Projectile.NewProjectile(player.position.X, player.position.Y, 1, 1, ModContent.ProjectileType<KuishiProjectile>(), 0, 0f, player.whoAmI, 0f, 0f);   
                return true;
            }

            return base.UseItem(player);
        }
    }
}
