using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace TheNineSecrets.Buffs
{
    /// <summary>
    /// Cooldown buff for Lin Secret (death save).
    /// Duration: 60 seconds.
    /// </summary>
    public class LinCooldownBuff : SecretCooldownBuff
    {
        public override string CooldownName => "Lin Cooldown";
        public override string CooldownDescription => "Death save ability is on cooldown";

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();
            BuffID.Sets.NurseCannotRemoveDebuff[Type] = true;
        }
    }
}