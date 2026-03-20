using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace TheNineSecrets.Items.Accessories.BaseSecrets
{
    /// <summary>
    /// Base class for all Nine Secret accessories.
    /// Implements the exclusive equipment system - only one secret can be equipped at a time.
    /// </summary>
    public abstract class BaseSecretAccessory : ModItem
    {
        /// <summary>
        /// The internal name used for localization and identification.
        /// </summary>
        public abstract string SecretName { get; }

        /// <summary>
        /// The tier of this secret (1 = base, 2 = combined, 3 = triple, 4 = ultimate).
        /// </summary>
        public virtual int Tier => 1;

        /// <summary>
        /// The tooltip description for this secret.
        /// </summary>
        public abstract string SecretDescription { get; }

        public override void SetStaticDefaults()
        {
            ItemID.Sets.ItemNoGravity[Item.type] = true;
        }

        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.accessory = true;
            Item.rare = GetRarityForTier();
            Item.value = GetValueForTier();
        }

        protected int GetRarityForTier()
        {
            return Tier switch
            {
                1 => ItemRarityID.LightPurple, // Tier 1 base secrets
                2 => ItemRarityID.Yellow,      // Tier 2 combined
                3 => ItemRarityID.Cyan,        // Tier 3 triple
                4 => ItemRarityID.Purple,      // Ultimate
                _ => ItemRarityID.LightPurple
            };
        }

        protected int GetValueForTier()
        {
            return Tier switch
            {
                1 => Item.sellPrice(gold: 5),
                2 => Item.sellPrice(gold: 15),
                3 => Item.sellPrice(gold: 30),
                4 => Item.sellPrice(platinum: 1),
                _ => Item.sellPrice(gold: 5)
            };
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            // Apply secret-specific effects in derived classes
            ApplySecretEffects(player);

            // Track equipped secret
            player.GetModPlayer<Players.SecretPlayer>().equippedSecretType = Item.type;
        }

        /// <summary>
        /// Apply the specific effects of this secret. Override in derived classes.
        /// </summary>
        public virtual void ApplySecretEffects(Player player)
        {
            // Override in derived classes
        }

        public override bool CanEquipAccessory(Player player, int slot, bool modded)
        {
            // Check if another secret is already equipped
            var modPlayer = player.GetModPlayer<Players.SecretPlayer>();

            // If this is the first accessory, allow
            if (modPlayer.equippedSecretType == -1)
                return true;

            // If same type is already equipped, allow (swapping)
            if (modPlayer.equippedSecretType == Item.type)
                return true;

            // Block equipping if another secret is already equipped
            return false;
        }

        public override void AddRecipes()
        {
            // Base secrets don't have recipes by default
            // Override in derived classes if needed
        }
    }
}