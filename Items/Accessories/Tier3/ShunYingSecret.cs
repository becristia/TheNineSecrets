using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace TheNineSecrets.Items.Accessories.Tier3
{
    /// <summary>
    /// ShunYing (Flash Shadow) - Tier 3 Combined Secret
    /// Combines Xing + Lie + Qian
    /// +18% dodge, +50% speed, +100% flight time, bullet time 5s (60s cooldown), +13% crit damage
    /// </summary>
    public class ShunYingSecret : BaseSecrets.BaseSecretAccessory
    {
        public override string SecretName => "ShunYing";
        public override string SecretDescription => "The Flash Shadow: 18% dodge chance, 50% movement speed, 100% flight time, bullet time 5s (60s cooldown), +13% critical damage";
        public override int Tier => 3;

        public override void ApplySecretEffects(Player player)
        {
            player.moveSpeed += 0.50f;
            player.maxRunSpeed += 0.50f;
            player.accRunSpeed = player.maxRunSpeed;
            player.wingTimeMax = (int)(player.wingTimeMax * 2f);
            player.ignoreWater = true;
            player.GetModPlayer<Players.SecretPlayer>().hasShunYingSecret = true;
            player.GetModPlayer<Players.SecretPlayer>().hasXingLieSecret = true;
            player.GetModPlayer<Players.SecretPlayer>().hasXingSecret = true;
            player.GetModPlayer<Players.SecretPlayer>().hasQianSecret = true;
            player.GetModPlayer<Players.SecretPlayer>().hasJieQianSecret = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<Combined.XingLieSecret>()
                .AddIngredient<BaseSecrets.QianSecret>()
                .AddIngredient<Crafting.HighSecretCore>(2)
                .AddTile<Tiles.SecretForgeTile>()
                .Register();
        }
    }
}