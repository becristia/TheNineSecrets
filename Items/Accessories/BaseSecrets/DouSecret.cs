using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace TheNineSecrets.Items.Accessories.BaseSecrets
{
    /// <summary>
    /// Dou (Fight) Secret - +8% melee damage, 3% chance for extra strike
    /// </summary>
    public class DouSecret : BaseSecretAccessory
    {
        public override string SecretName => "Dou";
        public override string SecretDescription => "Increases melee damage by 8% and grants 3% chance for an extra strike";

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override void ApplySecretEffects(Player player)
        {
            player.GetDamage(DamageClass.Melee) += 0.08f;
        }

        public override void AddRecipes()
        {
            // Pre-Hardmode recipe - early game accessible
            CreateRecipe()
                .AddIngredient(ItemID.Obsidian, 30)
                .AddIngredient(ItemID.HellstoneBar, 5)
                .AddIngredient(ItemID.IronBar, 10)
                .AddTile(TileID.Anvils)
                .Register();
        }
    }
}