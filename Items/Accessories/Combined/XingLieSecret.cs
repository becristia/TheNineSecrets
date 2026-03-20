using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace TheNineSecrets.Items.Accessories.Combined
{
    /// <summary>
    /// Xing + Lie Combined Secret - Phantom Step
    /// +13% dodge, +25% speed, +100% flight time, speed boost after dodge
    /// </summary>
    public class XingLieSecret : BaseSecrets.BaseSecretAccessory
    {
        public override string SecretName => "XingLie";
        public override string SecretDescription => "Grants 13% dodge chance, 25% movement speed, and 100% flight time. Dodging grants massive speed boost.";
        public override int Tier => 2;

        public override void ApplySecretEffects(Player player)
        {
            player.moveSpeed += 0.25f;
            player.maxRunSpeed += 0.25f;
            player.accRunSpeed = player.maxRunSpeed;
            player.wingTimeMax = (int)(player.wingTimeMax * 2f);
            player.ignoreWater = true;
            player.GetModPlayer<Players.SecretPlayer>().hasXingLieSecret = true;
            player.GetModPlayer<Players.SecretPlayer>().hasXingSecret = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<BaseSecrets.XingSecret>()
                .AddIngredient<BaseSecrets.LieSecret>()
                .AddIngredient<Crafting.SecretCore>(2)
                .AddTile<Tiles.SecretForgeTile>()
                .Register();
        }
    }
}