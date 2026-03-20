using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace TheNineSecrets.Items.Accessories.BaseSecrets
{
    /// <summary>
    /// Lin (Approach) Secret - +10% defense, survive fatal blow with 1 HP (60s cooldown)
    /// </summary>
    public class LinSecret : BaseSecretAccessory
    {
        public override string SecretName => "Lin";
        public override string SecretDescription => "Increases defense by 10% and grants a chance to survive fatal damage (60 second cooldown)";

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
        }

        public override void ApplySecretEffects(Player player)
        {
            player.statDefense += (int)(player.statDefense * 0.1f); // +10% defense
            player.GetModPlayer<Players.SecretPlayer>().hasLinSecret = true;
        }

        public override void AddRecipes()
        {
            // Pre-Hardmode recipe - available after Skeletron
            CreateRecipe()
                .AddIngredient(ItemID.CobaltShield, 1)
                .AddIngredient(ItemID.ObsidianShield, 1)
                .AddIngredient(ItemID.IronBar, 15)
                .AddTile(TileID.TinkerersWorkbench)
                .Register();
        }
    }
}