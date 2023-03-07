using System.Data.SQLite;

namespace BenningSharp.Entity
{
    public readonly struct Customer
    {
        public readonly long ID = -1;
        public readonly string? Name = null;

        public readonly string? Street = null;
        public readonly string? Postcode = null;
        public readonly string? Number = null;
        public readonly string? City = null;
        public readonly string? Phonenumber = null;
        public readonly string? Faxnumber = null;
        public readonly string? Note = null;
        public readonly string? EMail = null;
        public readonly string? ContactPerson = null;
        public readonly string? ContactPersonDepartment = null;
        public readonly string? ContactPersonPhonenumber = null;
        public readonly string? ContactPersonEMail = null;
        public readonly DateTime? ModificationDate = null;

        public Customer(
            in long id,
            in string? name,
            in string? street,
            in string? postcode,
            in string? number,
            in string? city,
            in string? phonenumber,
            in string? faxnumber,
            in string? note,
            in string? eMail,
            in string? contactPerson,
            in string? contactPersonDepartment,
            in string? contactPersonPhonenumber,
            in string? contactPersonEMail,
            in DateTime? modificationDate)
        {
            this.ID = id;
            this.Name = name;
            this.Number = number;
            this.Street = street;
            this.Postcode = postcode;
            this.City = city;
            this.Phonenumber = phonenumber;
            this.Faxnumber = faxnumber;
            this.EMail = eMail;
            this.Note = note;
            this.ContactPerson = contactPerson;
            this.ContactPersonDepartment = contactPersonDepartment;
            this.ContactPersonPhonenumber = contactPersonPhonenumber;
            this.ContactPersonEMail = contactPersonEMail;
            this.ModificationDate = modificationDate;
        }
        public Customer(SQLiteDataReader dr)
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
                        case "Kunden_Index":
                            ID = (long)value;
                            break;
                        case "Kunden_Name":
                            Name = (string)value;
                            break;
                        case "Kunden_Nummer":
                            Number = (string)value;
                            break;
                        case "Kunden_Strasse":
                            Street = (string)value;
                            break;
                        case "Kunden_PLZ":
                            Postcode = (string)value;
                            break;
                        case "Kunden_Wohnort":
                            City = (string)value;
                            break;
                        case "Kunden_Rufnummer":
                            Phonenumber = (string)value;
                            break;
                        case "Kunden_Fax":
                            Faxnumber = (string)value;
                            break;
                        case "Kunden_Email":
                            EMail = (string)value;
                            break;
                        case "Kunden_Bemerkung":
                            Note = (string)value;
                            break;
                        case "Kunden_Ansprechpartner":
                            ContactPerson = (string)value;
                            break;
                        case "Ansprechpartner_Abteilung":
                            ContactPersonDepartment = (string)value;
                            break;
                        case "Ansprechpartner_Rufnummer":
                            ContactPersonPhonenumber = (string)value;
                            break;
                        case "Ansprechpartner_Email":
                            ContactPersonEMail = (string)value;
                            break;
                        case "Aenderungsdatum":
                            ModificationDate = (DateTime)value;
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
            return $"ID: {ID} Name: {Name} Number: {Number} Street: {Street} Postcode: {Postcode} City: {City} Phonenumber: {Phonenumber} Faxnumber: {Faxnumber} EMail: {EMail} Note: {Note} ContactPerson: {ContactPerson} Department: {ContactPersonDepartment} Phonenumber: {ContactPersonPhonenumber} EMail: {ContactPersonEMail} ModificationDate: {ModificationDate}";
        }
    }
}
