using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace TheNineSecrets.Items.Accessories.Tier3
{
    /// <summary>
    /// ShouHu (Guardian) - Tier 3 Combined Secret
    /// Combines Lin + Zhen + Jie
    /// +15% defense, death save (30s cooldown), 6 orbiting runes (50 DPS), +15% crit, +25% drops
    /// </summary>
    public class ShouHuSecret : BaseSecrets.BaseSecretAccessory
    {
        public override string SecretName => "ShouHu";
        public override string SecretDescription => "The Guardian: +15% defense, death save (30s cooldown), 6 orbiting runes (50 damage), +15% crit, +25% drop rates";
        public override int Tier => 3;

        public override void ApplySecretEffects(Player player)
        {
            player.statDefense += (int)(player.statDefense * 0.15f); // +15% defense
            player.GetCritChance(DamageClass.Generic) += 15f;
            player.lifeRegen += 3;
            player.GetModPlayer<Players.SecretPlayer>().hasShouHuSecret = true;
            player.GetModPlayer<Players.SecretPlayer>().hasLinSecret = true;
            player.GetModPlayer<Players.SecretPlayer>().hasZhenSecret = true;
            player.GetModPlayer<Players.SecretPlayer>().hasZhenJieSecret = true;
            player.GetModPlayer<Players.SecretPlayer>().hasZheLinSecret = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<Combined.ZhenJieSecret>()
                .AddIngredient<BaseSecrets.LinSecret>()
                .AddIngredient<Crafting.HighSecretCore>(2)
                .AddTile<Tiles.SecretForgeTile>()
                .Register();
        }
    }
}