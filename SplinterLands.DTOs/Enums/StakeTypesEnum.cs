using System.ComponentModel;

namespace SplinterLands.DTOs.Enums
{
    public enum StakeTypesEnum
    {
        [Description("STK-LND-WKR")]
        Worker,
        [Description("STK-LND-PCR")]
        PowerCore,
        [Description("STK-LND-RUNI")]
        Runi,
        [Description("STK-LND-TOT")]
        Totem,
        [Description("STK-LND-TTL")]
        Title
    }
}
