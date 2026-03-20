using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent.ItemDropRules;

namespace TheNineSecrets.NPCs
{
    /// <summary>
    /// Global NPC handler for secret drops and boss scaling.
    /// Handles boss drops, drop rate bonuses, and boss difficulty enhancement.
    /// </summary>
    public class GlobalSecretDrop : GlobalNPC
    {
        public override void SetDefaults(NPC npc)
        {
            // Boss difficulty enhancement
            if (npc.boss)
            {
                // Increase boss life by 20%
                npc.lifeMax = (int)(npc.lifeMax * 1.2f);

                // Increase boss damage by 15%
                npc.damage = (int)(npc.damage * 1.15f);
            }
        }

        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            // === Pre-Hardmode Boss Drops ===

            // Dou Secret - Skeletron (Pre-Hardmode)
            if (npc.type == NPCID.SkeletronHead)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Accessories.BaseSecrets.DouSecret>(), 1)); // 100% chance
            }

            // Zhe Secret - Queen Bee (Pre-Hardmode)
            if (npc.type == NPCID.QueenBee)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Accessories.BaseSecrets.ZheSecret>(), 1)); // 100% chance
            }

            // Lin Secret - Deerclops (Pre-Hardmode)
            if (npc.type == NPCID.Deerclops)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Accessories.BaseSecrets.LinSecret>(), 1)); // 100% chance
            }

            // Jie Secret - King Slime (Pre-Hardmode)
            if (npc.type == NPCID.KingSlime)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Accessories.BaseSecrets.JieSecret>(), 1)); // 100% chance
            }

            // === Hardmode Boss Drops ===

            // Bing Secret - Mechanical Bosses
            if (npc.type == NPCID.TheDestroyer || npc.type == NPCID.SkeletronPrime || npc.type == NPCID.Retinazer || npc.type == NPCID.Spazmatism)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Accessories.BaseSecrets.BingSecret>(), 1)); // 100% chance
            }

            // Zhen Secret - Plantera
            if (npc.type == NPCID.Plantera)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Accessories.BaseSecrets.ZhenSecret>(), 1)); // 100% chance
            }

            // Lie Secret - Golem
            if (npc.type == NPCID.Golem)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Accessories.BaseSecrets.LieSecret>(), 1)); // 100% chance
            }

            // Xing Secret - Duke Fishron
            if (npc.type == NPCID.DukeFishron)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Accessories.BaseSecrets.XingSecret>(), 1)); // 100% chance
            }

            // Qian Secret - Martian Saucer
            if (npc.type == NPCID.MartianSaucer)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Accessories.BaseSecrets.QianSecret>(), 1)); // 100% chance
            }

            // Qian Secret also from Solar Eclipse Mothron
            if (npc.type == NPCID.Mothron || npc.type == NPCID.MothronSpawn)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Items.Accessories.BaseSecrets.QianSecret>(), 1)); // 100% chance
            }

            // Secret Forge recipe unlock - Plantera drops Lihzahrd related items
            if (npc.type == NPCID.Plantera)
            {
                npcLoot.Add(ItemDropRule.Common(ItemID.LihzahrdBrick, 1, 50, 100));
            }
        }

        public override void OnKill(NPC npc)
        {
            // Handle drop rate bonus for Jie Secret
            Player player = Main.player[npc.lastInteraction];
            if (player.active && !player.dead)
            {
                var modPlayer = player.GetModPlayer<Players.SecretPlayer>();
                if (modPlayer.hasNineSecretsUltimate)
                {
                    // Ultimate grants 50% more drops - handled separately
                    // This is a placeholder for additional drop logic if needed
                }
            }
        }
    }
}