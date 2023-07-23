using System.ComponentModel;

namespace TouhouFantasiaCheat.Cheats.Enums
{
    /// <summary>
    /// Available cheats types.
    /// </summary>
    public enum CheatEnum
    {
        [Description("fulllife")]
        FullLife,
        [Description("fullspell")]
        FullSpell,
        [Description("fullpower")]
        FullPower,
        [Description("immortal")]
        Immortal
    }
}