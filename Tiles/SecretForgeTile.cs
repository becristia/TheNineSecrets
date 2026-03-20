using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.ObjectData;
using Terraria.DataStructures;
using Microsoft.Xna.Framework;

namespace TheNineSecrets.Tiles
{
    /// <summary>
    /// Secret Forge Tile - Crafting station for combining secrets.
    /// Requires Plantera defeated to obtain the recipe.
    /// </summary>
    public class SecretForgeTile : ModTile
    {
        public override void SetStaticDefaults()
        {
            // Tile properties
            Main.tileSolidTop[Type] = false;
            Main.tileFrameImportant[Type] = true;
            Main.tileNoAttach[Type] = true;
            Main.tileTable[Type] = true;
            Main.tileLavaDeath[Type] = false;
            Main.tileWaterDeath[Type] = false;

            // Placement
            TileObjectData.newTile.CopyFrom(TileObjectData.Style3x2);
            TileObjectData.newTile.Origin = new Point16(1, 1);
            TileObjectData.newTile.CoordinateHeights = new[] { 16, 18 };
            TileObjectData.newTile.CoordinateWidth = 16;
            TileObjectData.newTile.CoordinatePadding = 2;
            TileObjectData.addTile(Type);

            // Visual - also counts as Tinkerer's Workbench and Mythril Anvil for vanilla recipes
            AdjTiles = new int[] { TileID.TinkerersWorkbench, TileID.MythrilAnvil };

            // Map
            AddMapEntry(new Color(150, 100, 200), CreateMapEntryName());
        }

        public override void NumDust(int i, int j, bool fail, ref int num)
        {
            num = fail ? 1 : 3;
        }

        public override void KillMultiTile(int i, int j, int frameX, int frameY)
        {
            Item.NewItem(new EntitySource_TileBreak(i, j), i * 16, j * 16, 48, 32, ModContent.ItemType<Items.Crafting.SecretForge>());
        }

        public override bool RightClick(int i, int j)
        {
            // Opens crafting interface automatically via AdjTiles
            return true;
        }
    }
}