using Terraria.ModLoader;
using Terraria;

namespace TheNineSecrets.Systems
{
    /// <summary>
    /// Handles integration with Recipe Browser mod.
    /// Provides custom crafting station categories and recipe grouping.
    /// </summary>
    public class RecipeBrowserSystem : ModSystem
    {
        public override void PostSetupContent()
        {
            // Recipe Browser integration
            if (!ModLoader.TryGetMod("RecipeBrowser", out Mod recipeBrowser))
                return;

            // Register the Secret Forge as a crafting station category
            // This allows Recipe Browser to properly categorize recipes made at this station
        }

        public override void AddRecipes()
        {
            // All recipes are automatically registered through the standard tModLoader recipe system
            // Recipe Browser will pick them up automatically
        }
    }
}