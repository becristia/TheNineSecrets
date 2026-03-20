using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace TheNineSecrets.Items.Accessories.Ultimate
{
    /// <summary>
    /// Nine Secrets Ultimate - The Source of All Secrets
    /// Combines all 9 secrets into one ultimate accessory.
    /// Grants all benefits with enhanced values.
    /// </summary>
    public class NineSecretsUltimate : BaseSecrets.BaseSecretAccessory
    {
        public override string SecretName => "NineSecrets";
        public override string SecretDescription => "The Source of Nine Secrets: All secret powers combined with enhanced effects. The ultimate embodiment of the Nine Characters.";
        public override int Tier => 4;

        public override void ApplySecretEffects(Player player)
        {
            // Dou (Fight) - Enhanced melee
            player.GetDamage(DamageClass.Melee) += 0.25f;
            player.GetDamage(DamageClass.Generic) += 0.20f;

            // Zhe (Person) - Enhanced regen
            player.lifeRegen += 5;

            // Lin (Approach) - Enhanced defense + death save
            player.statDefense += (int)(player.statDefense * 0.25f); // +25% defense

            // Bing (Soldier) - Enhanced damage + knockback
            player.GetKnockback(DamageClass.Generic) += 0.50f;

            // Jie (All) - Enhanced crit + drops
            player.GetCritChance(DamageClass.Generic) += 20f;

            // Zhen (Array) - Enhanced runes
            // Lie (Sequence) - Enhanced speed + flight
            player.moveSpeed += 0.75f;
            player.maxRunSpeed += 0.75f;
            player.accRunSpeed = player.maxRunSpeed;
            player.wingTimeMax = (int)(player.wingTimeMax * 2f);
            player.ignoreWater = true;
            player.waterWalk = true;
            player.fireWalk = true;

            // Xing (Walk) - Enhanced dodge
            // Qian (Front) - Enhanced bullet time

            // Set all flags
            var modPlayer = player.GetModPlayer<Players.SecretPlayer>();
            modPlayer.hasNineSecretsUltimate = true;
            modPlayer.hasDouBingSecret = true;
            modPlayer.hasZheLinSecret = true;
            modPlayer.hasJieQianSecret = true;
            modPlayer.hasXingLieSecret = true;
            modPlayer.hasZhenJieSecret = true;
            modPlayer.hasZhanShengSecret = true;
            modPlayer.hasShunYingSecret = true;
            modPlayer.hasShouHuSecret = true;
            modPlayer.hasZhenSecret = true;
            modPlayer.hasQianSecret = true;
            modPlayer.hasLinSecret = true;
            modPlayer.hasXingSecret = true;
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient<Tier3.ZhanShengSecret>()
                .AddIngredient<Tier3.ShunYingSecret>()
                .AddIngredient<Tier3.ShouHuSecret>()
                .AddIngredient<Crafting.UltimateCore>()
                .AddTile<Tiles.SecretForgeTile>()
                .Register();
        }
    }
}