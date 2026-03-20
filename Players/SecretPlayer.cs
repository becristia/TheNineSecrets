using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System;

namespace TheNineSecrets.Players
{
    public class SecretPlayer : ModPlayer
    {
        // Track which secret is currently equipped
        public int equippedSecretType = -1;

        // Zhen (Array) Secret - Rune orbiting
        public bool hasZhenSecret = false;
        public int runeTimer = 0;

        // Qian (Front) Secret - Bullet time
        public bool hasQianSecret = false;
        public bool bulletTimeActive = false;
        public int bulletTimeCooldown = 0;
        public const int BulletTimeDuration = 150; // 2.5 seconds
        public const int BulletTimeCooldownMax = 7200; // 120 seconds
        private int bulletTimeTimer = 0;

        // Lin (Approach) Secret - Death save
        public bool hasLinSecret = false;
        public bool deathSaveAvailable = true;
        public int linCooldown = 0;
        public const int LinCooldownMax = 3600; // 60 seconds

        // Xing (Walk) Secret - Dodge and speed
        public bool hasXingSecret = false;
        public bool dodgeAvailable = true;
        public int dodgeCooldown = 0;
        public const int DodgeCooldownMax = 600; // 10 seconds
        public bool hasDodgeSpeedBoost = false;
        public int dodgeSpeedTimer = 0;

        // Combined secrets tracking
        public bool hasDouBingSecret = false;
        public bool hasZheLinSecret = false;
        public bool hasJieQianSecret = false;
        public bool hasXingLieSecret = false;
        public bool hasZhenJieSecret = false;

        // Tier 3 secrets
        public bool hasZhanShengSecret = false;
        public bool hasShunYingSecret = false;
        public bool hasShouHuSecret = false;

        // Ultimate
        public bool hasNineSecretsUltimate = false;

        public override void ResetEffects()
        {
            hasZhenSecret = false;
            hasQianSecret = false;
            hasLinSecret = false;
            hasXingSecret = false;

            hasDouBingSecret = false;
            hasZheLinSecret = false;
            hasJieQianSecret = false;
            hasXingLieSecret = false;
            hasZhenJieSecret = false;

            hasZhanShengSecret = false;
            hasShunYingSecret = false;
            hasShouHuSecret = false;

            hasNineSecretsUltimate = false;

            equippedSecretType = -1;
        }

        public override void PostUpdateEquips()
        {
            // Handle cooldowns
            if (bulletTimeCooldown > 0)
                bulletTimeCooldown--;

            if (linCooldown > 0)
                linCooldown--;

            if (dodgeCooldown > 0)
                dodgeCooldown--;

            // Reset death save when cooldown expires
            if (linCooldown == 0)
                deathSaveAvailable = true;

            // Reset dodge when cooldown expires
            if (dodgeCooldown == 0)
                dodgeAvailable = true;

            // Handle dodge speed boost timer
            if (hasDodgeSpeedBoost)
            {
                dodgeSpeedTimer--;
                if (dodgeSpeedTimer <= 0)
                {
                    hasDodgeSpeedBoost = false;
                }
            }

            // Handle bullet time activation (double tap down)
            if (hasQianSecret && bulletTimeCooldown == 0 && !bulletTimeActive)
            {
                if (Player.controlDown && Player.releaseDown)
                {
                    ActivateBulletTime();
                }
            }

            // Handle bullet time duration
            if (bulletTimeActive)
            {
                bulletTimeTimer--;
                if (bulletTimeTimer <= 0)
                {
                    DeactivateBulletTime();
                }
            }

            // Zhen Secret - Rune orbiting damage
            if (hasZhenSecret)
            {
                runeTimer++;
                // Spawn rune projectiles periodically
                if (runeTimer % 60 == 0 && Main.myPlayer == Player.whoAmI)
                {
                    SpawnRuneProjectile();
                }
            }
        }

        private void ActivateBulletTime()
        {
            bulletTimeActive = true;
            bulletTimeTimer = BulletTimeDuration;
            bulletTimeCooldown = BulletTimeCooldownMax;
        }

        private void DeactivateBulletTime()
        {
            bulletTimeActive = false;
        }

        private void SpawnRuneProjectile()
        {
            int damage = 25;
            if (hasZhenJieSecret)
                damage = 40;
            if (hasNineSecretsUltimate)
                damage = 75;

            float angle = runeTimer * 0.1f;
            Vector2 offset = new Vector2((float)Math.Cos(angle) * 100, (float)Math.Sin(angle) * 100);

            Projectile.NewProjectile(
                Player.GetSource_Accessory(null),
                Player.Center + offset,
                Vector2.Zero,
                ModContent.ProjectileType<Projectiles.SecretRune>(),
                damage,
                2f,
                Player.whoAmI
            );
        }

        // Death save is handled in PostHurt by checking if player would die
        public override void PostHurt(Player.HurtInfo info)
        {
            // Lin Secret - Death save (check if we just took fatal damage)
            if ((hasLinSecret || hasZheLinSecret || hasShouHuSecret || hasNineSecretsUltimate) && deathSaveAvailable)
            {
                // If player died but has death save available, restore them
                if (Player.statLife <= 0)
                {
                    Player.statLife = 1;
                    deathSaveAvailable = false;
                    linCooldown = LinCooldownMax;
                    Player.AddBuff(ModContent.BuffType<Buffs.LinCooldownBuff>(), LinCooldownMax);
                }
            }
        }

        public override void ModifyHurt(ref Player.HurtModifiers modifiers)
        {
            // Xing Secret - Dodge chance
            if ((hasXingSecret || hasXingLieSecret || hasShunYingSecret || hasNineSecretsUltimate) && dodgeAvailable)
            {
                float dodgeChance = 0.10f; // 10% base
                if (hasNineSecretsUltimate)
                    dodgeChance = 0.18f;

                if (Main.rand.NextFloat() < dodgeChance)
                {
                    modifiers.FinalDamage *= 0;
                    dodgeAvailable = false;
                    dodgeCooldown = DodgeCooldownMax;
                    hasDodgeSpeedBoost = true;
                    dodgeSpeedTimer = 180; // 3 seconds of speed boost
                    Player.AddBuff(ModContent.BuffType<Buffs.XingSpeedBuff>(), 180);
                }
            }
        }

        public override void PostUpdateRunSpeeds()
        {
            // Lie Secret - Movement speed bonus
            if (hasXingLieSecret || hasShunYingSecret || hasNineSecretsUltimate)
            {
                Player.maxRunSpeed *= 1.13f;
                Player.runAcceleration *= 1.13f;
            }

            // Xing Secret dodge speed boost
            if (hasDodgeSpeedBoost)
            {
                Player.maxRunSpeed *= 1.5f;
                Player.runAcceleration *= 1.5f;
            }
        }

        public override void UpdateBadLifeRegen()
        {
            // Zhe Secret - Extra regeneration when hurt
            if ((hasZheLinSecret || hasShouHuSecret || hasNineSecretsUltimate) && Player.statLife < Player.statLifeMax2)
            {
                Player.lifeRegen += 3; // Extra 3 HP/s when hurt
            }
        }

        // Extra strike chance for Dou/Bing secrets
        public override void ModifyHitNPC(NPC target, ref NPC.HitModifiers modifiers)
        {
            float extraStrikeChance = 0f;
            if (hasDouBingSecret || hasZhanShengSecret || hasNineSecretsUltimate)
            {
                extraStrikeChance = 0.05f; // 5% base
                if (hasZhanShengSecret)
                    extraStrikeChance = 0.08f;
                if (hasNineSecretsUltimate)
                    extraStrikeChance = 0.10f;
            }
            else if (Player.GetModPlayer<SecretPlayer>().equippedSecretType == ModContent.ItemType<Items.Accessories.BaseSecrets.DouSecret>())
            {
                extraStrikeChance = 0.03f; // 3% for base Dou
            }

            if (Main.rand.NextFloat() < extraStrikeChance)
            {
                modifiers.SourceDamage *= 1.5f;
            }
        }

        // Critical damage bonus for Qian/Jie secrets
        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref NPC.HitModifiers modifiers)
        {
            ApplyCritDamageBonus(ref modifiers);
        }

        private void ApplyCritDamageBonus(ref NPC.HitModifiers modifiers)
        {
            float critDamageBonus = 0f;
            if (hasJieQianSecret || hasShunYingSecret || hasNineSecretsUltimate)
            {
                critDamageBonus = 0.10f;
                if (hasShunYingSecret)
                    critDamageBonus = 0.13f;
                if (hasNineSecretsUltimate)
                    critDamageBonus = 0.25f;
            }
            else if (hasQianSecret)
            {
                critDamageBonus = 0.05f;
            }

            if (critDamageBonus > 0)
            {
                modifiers.CritDamage += critDamageBonus;
            }
        }
    }
}