namespace BenningSharp
{
    public enum EInspectionMiddle
    {
        UNKNOWN,
        NONE,
        Test,
        [Display(Name = "R Insulation")]
        R_Insulation,
        [Display(Name = "U Insulation")]
        U_Insulation,
        [Display(Name = "I Insulation")]
        I_Insulation,
        [Display(Name = "I Leak", Description = "Device leakage current")]
        I_Leak,
        [Display(Name = "P Leak", Description = "Patient leakage current")]
        P_Leak,
        [Display(Name = "IP Leak")]
        IPE,
        [Display(Name = "U PELV")]
        U_PELV,
        [Display(Name = "I PELV")]
        I_PELV,
        [Display(Name = "U PE", Description = "Protective conductor voltage")]
        U_PE,
        [Display(Name = "I PE", Description = "Protective conductor current")]
        I_PE,
        [Display(Name = "R PE", Description = "Protective conductor resistance")]
        R_PE,
        [Display(Name = "R Conductor")]
        R_Conductor,
        [Display(Name = "U Conductor")]
        U_Conductor,
        [Display(Name = "I Conductor")]
        I_Conductor,
        [Display(Name = "U Functional")]
        U_Func,
        [Display(Name = "I Functional")]
        I_Func,
        [Display(Name = "P Functional")]
        P_Func,
        [Display(Name = "U Contact", Description = "Contact voltage [V]")]
        U_Contact,
        [Display(Name = "I Contact", Description = "Contact current [mA]")]
        I_Contact,
        [Display(Name = "U Supplied", Description = "Supplied mains voltage [V]")]
        U_Supplied,
        [Display(Name = "I RMS")]
        I_RMS,
        [Display(Name = "I Tripping", Description = "Tripping current [mA] (at 0° and 180°))")]
        I_Tripping,
        [Display(Name = "T Tripping", Description = "Tripping time [ms]")]
        T_Tripping,
        [Display(Name = "U L-PE")]
        U_L_PE,
        [Display(Name = "U L-N")]
        U_L_N,
        [Display(Name = "U N-PE")]
        U_N_PE,
        [Display(Description = "Maximum current [mA]")]
        I_Max,
        Welding,
        [Display(Description = "Voltage [V]")]
        U,
        [Display(Description = "Current [mA]")]
        I,
        [Display(Description = "Resistance [Ω]")]
        R,
        [Display(Description = "Power [W]")]
        P,
        [Display(Description = "Apparent power [VA]")]
        S,
        Conductor,
        Status,
        [Display(Name = "CLASS I")]
        CLASS1,
        [Display(Name = "CLASS II")]
        CLASS2,
        [Display(Name = "CLASS III")]
        CLASS3,
    }
}
