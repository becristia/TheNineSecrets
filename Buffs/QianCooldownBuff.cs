using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace TheNineSecrets.Buffs
{
    /// <summary>
    /// Cooldown buff for Qian Secret (bullet time).
    /// Duration: 120 seconds.
    /// </summary>
    public class QianCooldownBuff : SecretCooldownBuff
    {
        public override string CooldownName => "Qian Cooldown";
        public override string CooldownDescription => "Bullet time ability is on cooldown";

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
        }
    }
}