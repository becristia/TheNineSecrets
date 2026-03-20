using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace TheNineSecrets.Items.Accessories.BaseSecrets
{
    /// <summary>
    /// Zhe (Person) Secret - +1 HP/s regeneration, +3 HP/s when hurt
    /// </summary>
    public class ZheSecret : BaseSecretAccessory
    {
        public override string SecretName => "Zhe";
        public override string SecretDescription => "Increases life regeneration by 1 HP/s, and an additional 3 HP/s when taking damage";

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override void ApplySecretEffects(Player player)
        {
            player.lifeRegen += 1; // 1 HP/s base regen
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            base.UpdateAccessory(player, hideVisual);

            // Extra regen when recently hurt
            if (player.statLife < player.statLifeMax2)
            {
                player.lifeRegenTime += 2;
            }
        }

        public override void AddRecipes()
        {
            // Pre-Hardmode recipe - available after Skeletron
            CreateRecipe()
                .AddIngredient(ItemID.HeartLantern, 1)
                .AddIngredient(ItemID.BandofRegeneration, 1)
                .AddIngredient(ItemID.GoldBar, 10)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }
}