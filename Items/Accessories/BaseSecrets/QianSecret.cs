using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace TheNineSecrets.Items.Accessories.BaseSecrets
{
    /// <summary>
    /// Qian (Front) Secret - Bullet time (2.5s duration, 120s cooldown), +5% critical damage
    /// </summary>
    public class QianSecret : BaseSecretAccessory
    {
        public override string SecretName => "Qian";
        public override string SecretDescription => "Double tap DOWN to activate bullet time for 2.5 seconds (120s cooldown). Increases critical damage by 5%.";

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override void ApplySecretEffects(Player player)
        {
            player.GetModPlayer<Players.SecretPlayer>().hasQianSecret = true;
        }

        // Dropped by Martian Madness or Solar Eclipse
        public override void AddRecipes()
        {
            // This item drops from events, no crafting recipe
        }
    }
}