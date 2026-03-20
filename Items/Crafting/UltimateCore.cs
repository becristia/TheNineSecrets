using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace TheNineSecrets.Items.Crafting
{
    /// <summary>
    /// Ultimate Core - Crafting material for Tier 4 ultimate secret.
    /// </summary>
    public class UltimateCore : ModItem
    {
        public override void SetStaticDefaults()
        {
            ItemID.Sets.ItemNoGravity[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.maxStack = 99;
            Item.rare = ItemRarityID.Cyan;
            Item.value = Item.sellPrice(gold: 15);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<HighSecretCore>(3)
                .AddIngredient(ItemID.LunarBar, 10)
                .AddIngredient(ItemID.FragmentSolar, 5)
                .AddIngredient(ItemID.FragmentVortex, 5)
                .AddIngredient(ItemID.FragmentNebula, 5)
                .AddIngredient(ItemID.FragmentStardust, 5)
                .AddTile<Tiles.SecretForgeTile>()
                .Register();
        }
    }
}