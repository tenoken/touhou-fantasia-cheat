using System.ComponentModel;

namespace TouhouFantasiaCheat.Enums
{
    public enum OptionsEnum
    {
        [Description("--help")]
        Help,
        [Description("--all")]
        All,
        [Description("--verbose")]
        Verbose,
        [Description("enable")]
        Enable,
        [Description("disable")]
        Disable
    }
}