using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using System;

namespace TheNineSecrets.Projectiles
{
    /// <summary>
    /// Secret Rune - Orbiting projectile for Zhen Secret.
    /// Deals damage to nearby enemies while orbiting the player.
    /// </summary>
    public class SecretRune : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 4;
        }

        public override void SetDefaults()
        {
            Projectile.width = 24;
            Projectile.height = 24;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 120;
            Projectile.alpha = 50;
            Projectile.light = 0.5f;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
        }

        public override void AI()
        {
            // Orbit around the player
            Player player = Main.player[Projectile.owner];

            if (!player.active || player.dead)
            {
                Projectile.Kill();
                return;
            }

            // Calculate orbit position
            float orbitSpeed = 0.05f;
            float orbitRadius = 80f;

            Projectile.ai[0] += orbitSpeed;
            if (Projectile.ai[0] > MathHelper.TwoPi)
                Projectile.ai[0] -= MathHelper.TwoPi;

            Vector2 offset = new Vector2(
                (float)Math.Cos(Projectile.ai[0]) * orbitRadius,
                (float)Math.Sin(Projectile.ai[0]) * orbitRadius
            );

            Projectile.Center = player.Center + offset;

            // Animation
            Projectile.frameCounter++;
            if (Projectile.frameCounter >= 6)
            {
                Projectile.frameCounter = 0;
                Projectile.frame = (Projectile.frame + 1) % 4;
            }

            // Dust effect
            if (Main.rand.NextBool(5))
            {
                Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.PurpleTorch);
                dust.noGravity = true;
                dust.scale = 0.8f;
            }
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            // Add a small knockback and visual effect on hit
            for (int i = 0; i < 5; i++)
            {
                Dust dust = Dust.NewDustDirect(target.position, target.width, target.height, DustID.PurpleTorch);
                dust.noGravity = true;
                dust.velocity *= 2f;
            }
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return new Color(200, 150, 255, 200);
        }
    }
}