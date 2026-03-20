using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace TheNineSecrets.Items.Accessories.BaseSecrets
{
    /// <summary>
    /// Bing (Soldier) Secret - +5% damage, +25% knockback
    /// </summary>
    public class BingSecret : BaseSecretAccessory
    {
        public override string SecretName => "Bing";
        public override string SecretDescription => "Increases all damage by 5% and knockback by 25%";

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override void ApplySecretEffects(Player player)
        {
            player.GetDamage(DamageClass.Generic) += 0.05f;
            player.GetKnockback(DamageClass.Generic) += 0.25f;
        }

        // Dropped by mechanical bosses
        public override void AddRecipes()
        {
            // This item drops from bosses, no crafting recipe
        }
    }
}