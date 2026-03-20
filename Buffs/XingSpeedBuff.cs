using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace TheNineSecrets.Buffs
{
    /// <summary>
    /// Speed buff granted after successfully dodging with Xing Secret.
    /// Duration: 3 seconds.
    /// </summary>
    public class XingSpeedBuff : ModBuff
    {
        public override void SetStaticDefaults()
        {
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = false;
        }

        public override void Update(Player player, ref int buffIndex)
        {
            // Speed is handled in SecretPlayer.PostUpdateRunSpeeds
            player.moveSpeed += 1.0f; // +100% movement speed
        }
    }
}