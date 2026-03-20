using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace TheNineSecrets.Items.Accessories.Combined
{
    /// <summary>
    /// Dou + Bing Combined Secret - War Strike
    /// +13% melee damage, 5% extra strike chance, +25% knockback
    /// </summary>
    public class DouBingSecret : BaseSecrets.BaseSecretAccessory
    {
        public override string SecretName => "DouBing";
        public override string SecretDescription => "Increases melee damage by 13%, grants 5% chance for extra strike, and increases knockback by 25%";
        public override int Tier => 2;

        public override void ApplySecretEffects(Player player)
        {
            player.GetDamage(DamageClass.Melee) += 0.13f;
            player.GetKnockback(DamageClass.Generic) += 0.25f;
            player.GetModPlayer<Players.SecretPlayer>().hasDouBingSecret = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<BaseSecrets.DouSecret>()
                .AddIngredient<BaseSecrets.BingSecret>()
                .AddIngredient<Crafting.SecretCore>(2)
                .AddTile<Tiles.SecretForgeTile>()
                .Register();
        }
    }
}