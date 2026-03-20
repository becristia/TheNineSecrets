using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace TheNineSecrets.Items.Accessories.Combined
{
    /// <summary>
    /// Zhe + Lin Combined Secret - Eternal Life
    /// +3 HP/s regen, death save with 45s cooldown
    /// </summary>
    public class ZheLinSecret : BaseSecrets.BaseSecretAccessory
    {
        public override string SecretName => "ZheLin";
        public override string SecretDescription => "Increases life regeneration by 3 HP/s and grants death save ability (45s cooldown)";
        public override int Tier => 2;

        public override void ApplySecretEffects(Player player)
        {
            player.lifeRegen += 3;
            player.statDefense += (int)(player.statDefense * 0.08f); // +8% defense
            player.GetModPlayer<Players.SecretPlayer>().hasZheLinSecret = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            // Extra regen when hurt (handled in SecretPlayer)
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<BaseSecrets.ZheSecret>()
                .AddIngredient<BaseSecrets.LinSecret>()
                .AddIngredient<Crafting.SecretCore>(2)
                .AddTile<Tiles.SecretForgeTile>()
                .Register();
        }
    }
}