using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace InsatiableStorage.Projectiles.Kuishi
{
    public class KuishiProjectile : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Kuishi Projectile");
        }

        public override void SetDefaults()
        {
            projectile.CloneDefaults(ProjectileID.FlyingPiggyBank);
        }

    }
}