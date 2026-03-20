using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace TheNineSecrets.Items.Accessories.BaseSecrets
{
    /// <summary>
    /// Xing (Walk) Secret - +10% dodge chance, +50% movement speed after dodge
    /// </summary>
    public class XingSecret : BaseSecretAccessory
    {
        public override string SecretName => "Xing";
        public override string SecretDescription => "Grants 10% chance to dodge attacks. Successful dodges grant 50% movement speed for 3 seconds.";

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override void ApplySecretEffects(Player player)
        {
            player.GetModPlayer<Players.SecretPlayer>().hasXingSecret = true;
        }

        // Dropped by Golem
        public override void AddRecipes()
        {
            // This item drops from Golem, no crafting recipe
        }
    }
}