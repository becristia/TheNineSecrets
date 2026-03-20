using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace TheNineSecrets.Items.Accessories.BaseSecrets
{
    /// <summary>
    /// Lie (Sequence) Secret - +13% movement speed, +100% flight time
    /// </summary>
    public class LieSecret : BaseSecretAccessory
    {
        public override string SecretName => "Lie";
        public override string SecretDescription => "Increases movement speed by 13% and flight time by 100%";

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override void ApplySecretEffects(Player player)
        {
            player.moveSpeed += 0.13f;
            player.maxRunSpeed += 0.13f;
            player.accRunSpeed = player.maxRunSpeed;
            // +100% flight time
            player.wingTimeMax = (int)(player.wingTimeMax * 2f);
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            base.UpdateAccessory(player, hideVisual);
            player.ignoreWater = true;
        }

        // Dropped by Golem
        public override void AddRecipes()
        {
            // This item drops from Golem, no crafting recipe
        }
    }
}