using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace TheNineSecrets.Items.Accessories.BaseSecrets
{
    /// <summary>
    /// Zhen (Array) Secret - 2 orbiting runes dealing 25 DPS each
    /// </summary>
    public class ZhenSecret : BaseSecretAccessory
    {
        public override string SecretName => "Zhen";
        public override string SecretDescription => "Summons 2 orbiting runes that deal 25 damage per second to nearby enemies";

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override void ApplySecretEffects(Player player)
        {
            player.GetModPlayer<Players.SecretPlayer>().hasZhenSecret = true;
        }

        // Dropped by Plantera
        public override void AddRecipes()
        {
            // This item drops from Plantera, no crafting recipe
        }
    }
}