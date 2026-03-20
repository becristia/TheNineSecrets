using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace TheNineSecrets.Items.Crafting
{
    /// <summary>
    /// High Secret Core - Crafting material for Tier 3 triple secrets.
    /// </summary>
    public class HighSecretCore : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.ItemNoGravity[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.width = 28;
            Item.height = 28;
            Item.maxStack = 99;
            Item.rare = ItemRarityID.Yellow;
            Item.value = Item.sellPrice(gold: 5);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<SecretCore>(3)
                .AddIngredient(ItemID.ShroomiteBar, 5)
                .AddIngredient(ItemID.SpectreBar, 5)
                .AddTile<Tiles.SecretForgeTile>()
                .Register();
        }
    }
}