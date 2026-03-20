using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace TheNineSecrets.Items.Crafting
{
    /// <summary>
    /// Secret Forge - The crafting station item for combining secrets.
    /// </summary>
    public class SecretForge : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 44;
            Item.height = 32;
            Item.maxStack = 99;
            Item.useTurn = true;
            Item.autoReuse = true;
            Item.useAnimation = 15;
            Item.useTime = 10;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.consumable = true;
            Item.value = Item.sellPrice(gold: 10);
            Item.rare = ItemRarityID.Yellow;
            Item.createTile = ModContent.TileType<Tiles.SecretForgeTile>();
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.MythrilAnvil) // Mythril Anvil as base
                .AddIngredient<SecretCore>(5)
                .AddIngredient(ItemID.LihzahrdBrick, 50)
                .AddTile(TileID.MythrilAnvil)
                .Register();
        }
    }
}