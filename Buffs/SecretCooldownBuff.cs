using Terraria;
using Terraria.ModLoader;

namespace TheNineSecrets.Buffs
{
    /// <summary>
    /// Base class for secret cooldown buffs.
    /// These are debuffs that prevent reactivation of secret abilities.
    /// </summary>
    public abstract class SecretCooldownBuff : ModBuff
    {
        /// <summary>
        /// The display name key for localization.
        /// </summary>
        public abstract string CooldownName { get; }

        /// <summary>
        /// The description key for localization.
        /// </summary>
        public abstract string CooldownDescription { get; }

        public override void SetStaticDefaults()
        {
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            // Cooldown buffs are passive, just display the remaining time
        }
    }
}