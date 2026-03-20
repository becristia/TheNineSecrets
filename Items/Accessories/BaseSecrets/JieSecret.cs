using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace TheNineSecrets.Items.Accessories.BaseSecrets
{
    /// <summary>
    /// Jie (All) Secret - +5% critical strike chance, +8% drop rates
    /// </summary>
    public class JieSecret : BaseSecretAccessory
    {
        public override string SecretName => "Jie";
        public override string SecretDescription => "Increases critical strike chance by 5% and item drop rates by 8%";

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override void ApplySecretEffects(Player player)
        {
            player.GetCritChance(DamageClass.Generic) += 5f;
            // Drop rate bonus handled in GlobalNPC
        }

        public override void AddRecipes()
        {
            // Pre-Hardmode recipe - early game accessible
            CreateRecipe()
                .AddIngredient(ItemID.LuckyHorseshoe, 1)
                .AddIngredient(ItemID.GoldBar, 10)
                .AddIngredient(ItemID.Amber, 5)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }
}