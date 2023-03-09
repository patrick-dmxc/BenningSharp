using System.Data.SQLite;

namespace BenningSharp.Entity
{
    public readonly struct Device
    {
        public const string COLUMN_INDEX = "Geraete_Index";
        public const string COLUMN_ID = "Geraete_ID";
        public const string COLUMN_DESIGNATION = "Geraete_Bezeichnung";
        public const string COLUMN_SERIAL_NUMBER = "Geraete_SN";
        public const string COLUMN_TYPE = "Geraete_Typ";
        public const string COLUMN_MODELL = "Geraete_Modell";
        public const string COLUMN_REMARK = "Geraete_Bemerkung";
        public const string COLUMN_DEPARTMENT = "Geraete_Abteilung";
        public const string COLUMN_MANUFACTURER = "Geraete_Hersteller";
        public const string COLUMN_RATED_POWER = "Geraete_Nennleistung";
        public const string COLUMN_CHANGE_DATE = "Aenderungsdatum";
        public const string COLUMN_INSPECTION_DATE = "Geraete_Pruefdatum";
        public const string COLUMN_NEXT_INSPECTION_DATE = "Geraete_Datum_Naechste_Pruefung";
        public const string COLUMN_INSPECTION_INTERVAL = "Geraete_Pruefintervall";
        public const string COLUMN_VDE = "Geraete_VDE";
        public const string COLUMN_CLASS = "Geraete_SK";
        public const string COLUMN_LINE_LENGTH = "Geraete_Leitungslaenge";
        public const string COLUMN_NUMBER_OF_CONDUCTORS = "Geraete_Anz_Leiter";
        public const string COLUMN_CONDUCTOR_CROSS_SECTION = "Geraete_Leitungsquerschnitt";
        public const string COLUMN_OUTPUT_VOLTAGE = "Geraete_U_Ausgang";
        public const string COLUMN_OUT_OF_ORDER = "AusserBetrieb";
        public const string COLUMN_PRIVATE_PURCHASE = "Geraete_Private_Anschaffung";

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
        public readonly double LineLength = 0;
        public readonly double NumberOfConductors = 0;
        public readonly double ConductorCrossSection = 0;
        public readonly double OutputVoltage = 0;
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
                        case COLUMN_INDEX:
                            Index = (long)value;
                            break;
                        case COLUMN_ID:
                            ID = (string)value;
                            break;
                        case "Geraete_Kunden_Index":
                            CustomerIndex = (long)value;
                            break;
                        case COLUMN_DESIGNATION:
                            Designation = (string)value;
                            break;
                        case COLUMN_REMARK:
                            Remark = (string)value;
                            break;
                        case COLUMN_DEPARTMENT:
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
                        case COLUMN_INSPECTION_DATE:
                            InspectionDate = (DateTime)value;
                            break;
                        case COLUMN_NEXT_INSPECTION_DATE:
                            NextInspectionDate = (DateTime)value;
                            break;
                        case COLUMN_INSPECTION_INTERVAL:
                            InspectionInterval = (int)value;
                            break;
                        case COLUMN_RATED_POWER:
                            RatedPower = (double)value;
                            break;
                        case COLUMN_SERIAL_NUMBER:
                            SerialNumber = (string)value;
                            break;
                        case COLUMN_MANUFACTURER:
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
                        case COLUMN_CHANGE_DATE:
                            ChangeDate = (DateTime)value;
                            break;
                        case COLUMN_VDE:
                            VDE = (int)value;
                            break;
                        case COLUMN_CLASS:
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
                        case COLUMN_LINE_LENGTH:
                            LineLength = (double)value;
                            break;
                        case COLUMN_NUMBER_OF_CONDUCTORS:
                            NumberOfConductors = (double)value;
                            break;
                        case COLUMN_CONDUCTOR_CROSS_SECTION:
                            ConductorCrossSection = (double)value;
                            break;
                        case COLUMN_OUTPUT_VOLTAGE:
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
                        case COLUMN_OUT_OF_ORDER:
                            OutOfOrder = (bool)value;
                            break;
                        case COLUMN_TYPE:
                            Type = (string)value;
                            break;
                        case COLUMN_MODELL:
                            Modell = (string)value;
                            break;
                        case COLUMN_PRIVATE_PURCHASE:
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
