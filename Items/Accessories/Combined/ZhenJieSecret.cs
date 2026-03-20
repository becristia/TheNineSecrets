using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace TheNineSecrets.Items.Accessories.Combined
{
    /// <summary>
    /// Zhen + Jie Combined Secret - Array of Fortune
    /// 4 orbiting runes (40 DPS each), +13% crit, +15% drop rates
    /// </summary>
    public class ZhenJieSecret : BaseSecrets.BaseSecretAccessory
    {
        public override string SecretName => "ZhenJie";
        public override string SecretDescription => "Summons 4 orbiting runes (40 damage each), increases critical chance by 13% and drop rates by 15%";
        public override int Tier => 2;

        public override void ApplySecretEffects(Player player)
        {
            player.GetCritChance(DamageClass.Generic) += 13f;
            player.GetModPlayer<Players.SecretPlayer>().hasZhenJieSecret = true;
            player.GetModPlayer<Players.SecretPlayer>().hasZhenSecret = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<BaseSecrets.ZhenSecret>()
                .AddIngredient<BaseSecrets.JieSecret>()
                .AddIngredient<Crafting.SecretCore>(2)
                .AddTile<Tiles.SecretForgeTile>()
                .Register();
        }
    }
}