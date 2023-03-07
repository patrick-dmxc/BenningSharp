using System.Data.SQLite;

namespace BenningSharp.Entity
{
    public readonly struct Device
    {
        public readonly long Index = 0;
        public readonly string ID = string.Empty;
        public readonly long CustomerIndex = 0;
        public readonly string Designation = string.Empty;
        public readonly string? Remark = null;
        public readonly string? Department = null;
        public readonly string? Type = null;
        public readonly string? Modell = null;
        public readonly int? DepartmentID = null;
        public readonly long? Inspection = null;
        public readonly long? Inspection2 = null;
        public readonly long? InspectionIndex = null;
        public readonly string? InspectionName = null;
        public readonly int? InspectionOptions = null;
        public readonly DateTime? InspectionDate = null;
        public readonly DateTime? NextInspectionDate = null;
        public readonly int? InspectionInterval = null;
        public readonly double? RatedPower = null;
        public readonly string? SerialNumber = null;
        public readonly string? Manufacturer = null;
        public readonly int? ManufacturerID = null;
        public readonly long? InspectionAdmin = null;
        public readonly long? InspectionCustomer = null;
        public readonly DateTime? ChangeDate = null;
        public readonly int? VDE = null;
        public readonly int? Class = null;
        public readonly string? Questions = null;
        public readonly long? AdditionalInspections = null;
        public readonly int? VisualInspections = null;
        public readonly int? ThresholdListID = null;
        public readonly double? LineLength = null;
        public readonly double? NumberOfConductors = null;
        public readonly double? ConductorCrossSection = null;
        public readonly double? OutputVoltage = null;
        public readonly string? Building = null;

        public readonly int? TimeRPE = null;
        public readonly int? TimeRInsulation = null;
        public readonly int? TimeILeak = null;
        public readonly int? TimeIPE = null;
        public readonly int? TimeILeakOutput = null;
        public readonly int? TimeICont = null;
        public readonly int? TimeIContOutput = null;
        public readonly int? TimeFunction = null;
        public readonly int? TimePELV = null;
        public readonly int? TimeWelding = null;
        public readonly int? TimeRCD = null;
        public readonly int? TimeCable = null;
        public readonly int? TimeReversePolarity = null;
        public readonly bool OutOfOrder = false;
        public readonly bool PrivatePurchase = false;

        public readonly double? TemplateID = null;
        public readonly string? TemplateButtonColumn1 = null;
        public readonly string? TemplateButtonColumn2 = null;
        public readonly string? TemplateButtonColumn3 = null;
        public readonly string? TemplateButtonColumn4 = null;
        public readonly string? TemplateColor = null;

        public readonly long? LimitsID = null;
        public readonly bool? Individual = null;

        public Device(SQLiteDataReader dr)
        {
            for (int i = 0; i < dr.FieldCount; i++)
            {
                try
                {
                    var columnName = dr.GetName(i);
                    var value = dr.GetValue(i);
                    if (value is DBNull)
                        continue;
                    switch (columnName)
                    {
                        case "Geraete_Index":
                            Index = (long)value;
                            break;
                        case "Geraete_ID":
                            ID = (string)value;
                            break;
                        case "Geraete_Kunden_Index":
                            CustomerIndex = (long)value;
                            break;
                        case "Geraete_Bezeichnung":
                            Designation = (string)value;
                            break;
                        case "Geraete_Bemerkung":
                            Remark = (string)value;
                            break;
                        case "Geraete_Abteilung":
                            Department = (string)value;
                            break;
                        case "departmentId":
                            DepartmentID = (int)value;
                            break;
                        case "Geraete_Pruefablauf":
                            Inspection = (long)value;
                            break;
                        case "Geraete_Pruefablauf_2":
                            Inspection2 = (long)value;
                            break;
                        case "Geraete_Pruefablauf_Index":
                            InspectionIndex = (long)value;
                            break;
                        case "Geraete_Pruefablauf_Name":
                            InspectionName = (string)value;
                            break;
                        case "Geraete_Pruefoptionen":
                            InspectionOptions = (int)value;
                            break;
                        case "Geraete_Pruefdatum":
                            InspectionDate = (DateTime)value;
                            break;
                        case "Geraete_Datum_Naechste_Pruefung":
                            NextInspectionDate = (DateTime)value;
                            break;
                        case "Geraete_Pruefintervall":
                            InspectionInterval = (int)value;
                            break;
                        case "Geraete_Nennleistung":
                            RatedPower = (double)value;
                            break;
                        case "Geraete_SN":
                            SerialNumber = (string)value;
                            break;
                        case "Geraete_Hersteller":
                            Manufacturer = (string)value;
                            break;
                        case "manufacturerId":
                            ManufacturerID = (int)value;
                            break;
                        case "Geraete_Pruefablauf_Admin_Index":
                            InspectionAdmin = (long)value;
                            break;
                        case "Geraete_Pruefablauf_Customer_Index":
                            InspectionCustomer = (long)value;
                            break;
                        case "Aenderungsdatum":
                            ChangeDate = (DateTime)value;
                            break;
                        case "Geraete_VDE":
                            VDE = (int)value;
                            break;
                        case "Geraete_SK":
                            Class = (int)value;
                            break;
                        case "Geraete_Fragen":
                            Questions = (string)value;
                            break;
                        case "Geraete_Zusatz_Pruefungen":
                            AdditionalInspections = (long)value;
                            break;
                        case "Geraete_Sichtpruefung":
                            VisualInspections = (int)value;
                            break;
                        case "ThresholdListID":
                            ThresholdListID = (int)value;
                            break;
                        case "Geraete_Leitungslaenge":
                            LineLength = (double)value;
                            break;
                        case "Geraete_Anz_Leiter":
                            NumberOfConductors = (double)value;
                            break;
                        case "Geraete_Leitungsquerschnitt":
                            ConductorCrossSection = (double)value;
                            break;
                        case "Geraete_U_Ausgang":
                            OutputVoltage = (double)value;
                            break;
                        case "Gebaeude":
                            Building = (string)value;
                            break;
                        case "Geraete_Zeit_rsl":
                            TimeRPE = (int)value;
                            break;
                        case "Geraete_Zeit_riso":
                            TimeRInsulation = (int)value;
                            break;
                        case "Geraete_Zeit_iabl":
                            TimeILeak = (int)value;
                            break;
                        case "Geraete_Zeit_pabl":
                            TimeIPE = (int)value;
                            break;
                        case "Geraete_Zeit_iber":
                            TimeICont = (int)value;
                            break;
                        case "Geraete_Zeit_iberausg":
                            TimeIContOutput = (int)value;
                            break;
                        case "Geraete_Zeit_funkt":
                            TimeFunction = (int)value;
                            break;
                        case "Geraete_Zeit_pelv":
                            TimePELV = (int)value;
                            break;
                        case "Geraete_Zeit_schw":
                            TimeWelding = (int)value;
                            break;
                        case "Geraete_Zeit_prcd":
                            TimeRCD = (int)value;
                            break;
                        case "Geraete_Zeit_kabel":
                            TimeCable = (int)value;
                            break;
                        case "Geraete_Zeit_umpolung":
                            TimeReversePolarity = (int)value;
                            break;
                        case "AusserBetrieb":
                            OutOfOrder = (bool)value;
                            break;
                        case "Geraete_Typ":
                            Type = (string)value;
                            break;
                        case "Geraete_Modell":
                            Modell = (string)value;
                            break;
                        case "Geraete_Private_Anschaffung":
                            PrivatePurchase = (bool)value;
                            break;
                        case "Geraete_Vorlagen_ID":
                            TemplateID = (double)value;
                            break;
                        case "Geraete_VorlButtZeile1":
                            TemplateButtonColumn1 = (string)value;
                            break;
                        case "Geraete_VorlButtZeile2":
                            TemplateButtonColumn2 = (string)value;
                            break;
                        case "Geraete_VorlButtZeile3":
                            TemplateButtonColumn3 = (string)value;
                            break;
                        case "Geraete_VorlButtZeile4":
                            TemplateButtonColumn4 = (string)value;
                            break;
                        case "Geraete_Vorlagen_Farbe":
                            TemplateColor = (string)value;
                            break;

                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {

                }
            }
        }

        public override string ToString()
        {
            return $"ID: {ID} Designation: {Designation} SerialNumber: {SerialNumber}";
        }
    }
}
