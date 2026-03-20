using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace TheNineSecrets.Items.Accessories.Combined
{
    /// <summary>
    /// Jie + Qian Combined Secret - Perfect Strike
    /// +10% crit, +10% crit damage, bullet time 3.5s duration, 90s cooldown
    /// </summary>
    public class JieQianSecret : BaseSecrets.BaseSecretAccessory
    {
        public override string SecretName => "JieQian";
        public override string SecretDescription => "Increases critical chance by 10%, critical damage by 10%. Bullet time duration increased to 3.5s (90s cooldown)";
        public override int Tier => 2;

        public override void ApplySecretEffects(Player player)
        {
            player.GetCritChance(DamageClass.Generic) += 10f;
            player.GetModPlayer<Players.SecretPlayer>().hasJieQianSecret = true;
            player.GetModPlayer<Players.SecretPlayer>().hasQianSecret = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<BaseSecrets.JieSecret>()
                .AddIngredient<BaseSecrets.QianSecret>()
                .AddIngredient<Crafting.SecretCore>(2)
                .AddTile<Tiles.SecretForgeTile>()
                .Register();
        }
    }
}