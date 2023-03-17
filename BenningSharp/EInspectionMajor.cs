namespace BenningSharp
{
    public enum EInspectionMajor
    {
        UNKNOWN,
        NONE,
        [Display(Name = "RPE", Description = "")]
        RPE,
        [Display(Name = "RInsu", Description = "")]
        RInsu,
        [Display(Name = "RInsu-1", Description = "")]
        RInsu1,
        [Display(Name = "RInsu-2", Description = "")]
        RInsu2,
        [Display(Name = "RInsu-3", Description = "")]
        RInsu3,
        [Display(Name = "RInsu-4", Description = "")]
        RInsu4,
        [Display(Name = "ILeak", Description = "Device leakage current")]
        ILeak,
        [Display(Name = "PLeak", Description = "Patient leakage current")]
        PLeak,
        [Display(Name = "IPLeak", Description = "Protective conductor current")]
        IPE,
        [Display(Name = "ICont.", Description = "Contact current")]
        ICont,
        [Display(Name = "Ua", Description = "Safety extra-low voltage")]
        Ua,
        [Display(Name = "Funct.", Description = "Functional test")]
        Funct,
        [Display(Description = "Protective Extra Low Voltage")]
        PELV,
        RCD,
        [Display(Name = "Cable", Description = "Cable continuity test")]
        Cable,
        EV,
        ReversePolarity
    }
}
