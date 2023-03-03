namespace BenningSharp
{
    public static class Tools
    {
        public static EInspectionMajor KeyToEInspectionMajor(string key)
        {
            key = key.Replace("Ergebnisse_", "");            
            var split = key.Split('_');
            key = split.FirstOrDefault() ?? string.Empty;

            if (key.Equals("GW"))
                key = split[2];

            switch (key.ToLowerInvariant())
            {
                case "rsl":
                    return EInspectionMajor.RPE;
                case "riso":
                    return EInspectionMajor.RInsu;
                case "riso1":
                    return EInspectionMajor.RInsu1;
                case "riso2":
                    return EInspectionMajor.RInsu2;
                case "riso3":
                    return EInspectionMajor.RInsu3;
                case "riso4":
                    return EInspectionMajor.RInsu4;
                case "iabl":
                    return EInspectionMajor.ILeak;
                case "ipabl":
                case "pabl":
                    return EInspectionMajor.IPE;
                case "iber":
                case "ib":
                    return EInspectionMajor.ICont;
                case "u":
                case "ua":
                    return EInspectionMajor.Ua;
                case "rcd":
                case "prcd":
                    return EInspectionMajor.RCD;
                case "km":
                case "kabel":
                    return EInspectionMajor.Cable;
                case "fm":
                case "funkt":
                    return EInspectionMajor.Funct;
                case "ev":
                    return EInspectionMajor.EV;
                case "pelv":
                    return EInspectionMajor.PELV;

                case "umpolung":
                    return EInspectionMajor.ReversePolarity;

                case "gw":
                    return EInspectionMajor.NONE;
            }

            return EInspectionMajor.UNKNOWN;
        }
        public static EInspectionMiddle KeyToEInspectionMiddle(string key)
        {
            if (key.StartsWith("UA_gw_")|| key.StartsWith("GW_"))
                return EInspectionMiddle.NONE;

            if (key.Contains("_leit_"))
                return EInspectionMiddle.Conductor;
            if (key.Contains("_anz_"))
                return EInspectionMiddle.NONE;
            if (key.Contains("_test_"))
                return EInspectionMiddle.Test;
            if (key.Contains("_status"))
                return EInspectionMiddle.Status;
            if (key.Contains("_uvers"))
                return EInspectionMiddle.Conductor;
            if (key.Contains("_u_ber"))
                return EInspectionMiddle.U_Contact;
            if (key.Contains("_r_leit"))
                return EInspectionMiddle.R_Conductor;

            if (key.Contains("_ul_n"))
                return EInspectionMiddle.U_L_N;
            if (key.Contains("_ul_pe"))
                return EInspectionMiddle.U_L_PE;
            if (key.Contains("_un_pe"))
                return EInspectionMiddle.U_N_PE;

            if (key.Equals("Ergebnisse_GW_Testzeit_EV"))
                return EInspectionMiddle.NONE;

            key = key.Replace("Ergebnisse_", "");
            var split = key.Split('_');

            if (split.LastOrDefault()?.ToLowerInvariant()?.StartsWith("reserve") ?? false)
                return EInspectionMiddle.NONE;

            if (split.Length > 2)
                key = split[2];
            else if (split.Length == 2)
                return EInspectionMiddle.NONE;

            switch (key.ToLowerInvariant())
            {
                case "riso":
                    return EInspectionMiddle.R_Insulation;
                case "uiso":
                    return EInspectionMiddle.U_Insulation;
                case "iiso":
                    return EInspectionMiddle.I_Insulation;
                case "iabl":
                    return EInspectionMiddle.I_Leak;
                case "pabl":
                    return EInspectionMiddle.P_Leak;
                case "upelv":
                    return EInspectionMiddle.U_PELV;
                case "ipelv":
                    return EInspectionMiddle.I_PELV;
                case "usl":
                    return EInspectionMiddle.U_PE;
                case "isl":
                case "ifehler":
                case "ipabl":
                    return EInspectionMiddle.I_PE;
                case "rsl":
                case "rslx":
                    return EInspectionMiddle.R_PE;
                case "rleitung":
                    return EInspectionMiddle.R_Conductor;
                case "uleitung":
                    return EInspectionMiddle.U_Conductor;
                case "ileitung":
                    return EInspectionMiddle.I_Conductor;
                case "ufunkt":
                    return EInspectionMiddle.U_Func;
                case "ifunkt":
                    return EInspectionMiddle.I_Func;
                case "pfunkt":
                    return EInspectionMiddle.P_Func;
                case "upe":
                    return EInspectionMiddle.U_PE;
                case "uber":
                    return EInspectionMiddle.U_Contact;
                case "irms":
                    return EInspectionMiddle.I_RMS;
                case "iausl":
                    return EInspectionMiddle.I_Tripping;
                case "tausl":
                    return EInspectionMiddle.T_Tripping;
                case "imax":
                    return EInspectionMiddle.I_Max;
                case "ib":
                    return EInspectionMiddle.I_Contact;
                case "schw":
                    return EInspectionMiddle.Welding;
                case "u":
                    return EInspectionMiddle.U;
                case "i":
                    return EInspectionMiddle.I;
                case "r":
                    return EInspectionMiddle.R;
                case "p":
                    return EInspectionMiddle.P;
                case "s":
                    return EInspectionMiddle.S;

                case "sk1":
                    return EInspectionMiddle.CLASS1;
                case "sk2":
                    return EInspectionMiddle.CLASS2;
                case "sk3":
                    return EInspectionMiddle.CLASS3;
            }
            return EInspectionMiddle.UNKNOWN;
        }
        public static EInspectionMinor KeyToEInspectionMinor(string key)
        {
            if (key.Contains("_u_ber") || key.Contains("_r_leit") || key.Contains("_anz_"))
                return EInspectionMinor.NONE;

            if (key.StartsWith("UA_gw_"))
                key = key.Replace("UA_gw_", "UA_gw_DUMMY_");

                key = key.Replace("Ergebnisse_", "");
            key = key.Replace("1_2I", "1/2I");

            var split = key.Split('_');
            if (split.LastOrDefault()?.ToLowerInvariant()?.StartsWith("reserve") ?? false)
                return EInspectionMinor.RESERVE;

            if (split.Length > 3)
                key = split[3];
            else
                return EInspectionMinor.NONE;

            EInspectionMinor result = EInspectionMinor.NONE;
            foreach (string k in split.Skip(3))
                result |= _keyToEInspectionMinor(k);

            return result;
        }
        private static EInspectionMinor _keyToEInspectionMinor(string key)
        {
            switch (key.ToLowerInvariant())
            {
                case "pos":
                    return EInspectionMinor.Positive;
                case "neg":
                    return EInspectionMinor.Negative;
                case "ac":
                    return EInspectionMinor.AC;
                case "dc":
                    return EInspectionMinor.DC;
                case "prim":
                    return EInspectionMinor.Primary;
                case "sek":
                    return EInspectionMinor.Secondary;
                case "koerp":
                    return EInspectionMinor.Housing;
                case "rms":
                    return EInspectionMinor.RMS;
                case "schw":
                    return EInspectionMinor.Welding;
                case "pe":
                    return EInspectionMinor.PE;
                case "laenge":
                    return EInspectionMinor.Length;
                case "quersch":
                    return EInspectionMinor.CrossSection;
                case "l1":
                    return EInspectionMinor.L1;
                case "l2":
                    return EInspectionMinor.L2;
                case "l3":
                    return EInspectionMinor.L3;
                case "l":
                    return EInspectionMinor.L;
                case "n":
                    return EInspectionMinor.N;
                case "p":
                    return EInspectionMinor.P;
                case "u":
                case "u0":
                    return EInspectionMinor.U;
                case "1i":
                    return EInspectionMinor._1I;
                case "5i":
                    return EInspectionMinor._5I;
                case "1/2i":
                    return EInspectionMinor._1_2I;
                case "peak":
                    return EInspectionMinor.Peak;
                case "701":
                    return EInspectionMinor.VDE_701;
                case "751":
                    return EInspectionMinor.VDE_751;
                case "544":
                    return EInspectionMinor.VDE_544;
                case "b":
                    return EInspectionMinor.B;
                case "bf":
                    return EInspectionMinor.BF;
                case "cf":
                    return EInspectionMinor.CF;
                case "ausg":
                    return EInspectionMinor.Supplied;

                case "upeak":
                    return EInspectionMinor.U | EInspectionMinor.Peak;
            }
            return EInspectionMinor.NONE;
        }
        public static EValueType KeyToEValueType(string key)
        {
            key = key.Replace("Ergebnisse_", "");
            var split = key.Split('_');

            if (split.LastOrDefault()?.ToLowerInvariant()?.StartsWith("reserve") ?? false)
                return EValueType.NONE;

            if (split.Length == 2)
                key = split[0];
            else if (split.Length > 2)
                key = split[1];

            switch (key.ToLowerInvariant())
            {
                case "gw":
                    return EValueType.Limit;
                case "mw":
                    return EValueType.Measurement;
                case "zeit":
                case "testzeit":
                    return EValueType.Time;
                case "leit":
                case "anz":
                case "test":
                case "status":
                case "laenge":
                case "count":
                case "km":
                case "rcd":
                case "ev":
                    return EValueType.NONE;
            }
            return EValueType.UNKNOWN;
        }
    }
}