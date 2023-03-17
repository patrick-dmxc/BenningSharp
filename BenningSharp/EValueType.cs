namespace BenningSharp
{
    public enum EValueType
    {
        UNKNOWN,
        NONE,
        [Display(Name = "Limit")]
        Limit,
        [Display(Name = "Measurement")]
        Measurement,
        [Display(Name = "Time")]
        Time
    }
}
