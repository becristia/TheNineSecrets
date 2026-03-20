using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace TheNineSecrets.Items.Accessories.Tier3
{
    /// <summary>
    /// ZhanSheng (War Saint) - Tier 3 Combined Secret
    /// Combines Dou + Bing + Zhe
    /// +18% all damage, +15% melee damage, 8% extra strike, +38% knockback, +2 HP/s regen
    /// </summary>
    public class ZhanShengSecret : BaseSecrets.BaseSecretAccessory
    {
        public override string SecretName => "ZhanSheng";
        public override string SecretDescription => "The War Saint: +18% all damage, +15% melee damage, 8% extra strike chance, +38% knockback, +2 HP/s regeneration";
        public override int Tier => 3;

        public override void ApplySecretEffects(Player player)
        {
            player.GetDamage(DamageClass.Generic) += 0.18f;
            player.GetDamage(DamageClass.Melee) += 0.15f;
            player.GetKnockback(DamageClass.Generic) += 0.38f;
            player.lifeRegen += 2;
            player.GetModPlayer<Players.SecretPlayer>().hasZhanShengSecret = true;
            player.GetModPlayer<Players.SecretPlayer>().hasDouBingSecret = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<Combined.DouBingSecret>()
                .AddIngredient<BaseSecrets.ZheSecret>()
                .AddIngredient<Crafting.HighSecretCore>(2)
                .AddTile<Tiles.SecretForgeTile>()
                .Register();
        }
    }
}