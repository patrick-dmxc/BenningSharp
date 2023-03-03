using System.ComponentModel.DataAnnotations;

namespace BenningSharp
{
    [Flags]
    public enum EInspectionMinor
    {
        UNKNOWN=-1,
        NONE=0,
        RESERVE=-2,
        Positive=1,
        Negative=2,
        AC=4,
        DC=8,
        Primary = 16,
        Secondary = 32,
        Housing = 64,
        RMS = 128,
        Welding = 256,
        PE = 512,
        Length = 1024,
        L1 = 2048,
        L2 = 8096,
        L3 = 16192,
        L = 32384,
        N = 64768,
        P = 129536,
        U = 259072,
        [Display(Name = "1xI nominal")]
        _1I = 518144,
        [Display(Name = "5xI nominal")]
        _5I = 1036288,
        [Display(Name = "½xI nominal")]
        _1_2I = 2072576,
        Peak = 4145152,
        [Display(Name = "VDE 701")]
        VDE_701 = 8290304,
        [Display(Name = "VDE 751")]
        VDE_751 = 16580608,
        [Display(Name = "VDE 544")]
        VDE_544 = 33161216,
        [Display(Name = "VDE 751 B")]
        B = 66322432,
        [Display(Name = "VDE 751 BF")]
        BF = 132644864,
        [Display(Name = "VDE 751 CF")]
        CF = 265289728,
        CrossSection = 530579456,
        Supplied = 1061158912,
    }
}
