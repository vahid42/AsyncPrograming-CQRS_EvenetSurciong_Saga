using WarehouseAPI.Domain.Base;

namespace WarehouseAPI.Domain.ProductAggregate
{
    public class CompanyInformation : ValueObject
    {
        public CompanyInformation(string? companyName, string? companyAddress, string? companyPhone, string? companyEmail, string? madeCountry)
        {
            CompanyName = companyName;
            CompanyAddress = companyAddress;
            CompanyPhone = companyPhone;
            CompanyEmail = companyEmail;
            MadeCountry = madeCountry;
        }

        public CompanyInformation() { }
        public string? CompanyName { get; protected set; }
        public string? CompanyAddress { get; protected set; }
        public string? CompanyPhone { get; protected set; }
        public string? CompanyEmail { get; protected set; }
        public string? MadeCountry { get; protected set; }

        public override bool Equals(object? obj)
        {
            if (obj is CompanyInformation item)
                return CompanyName == item.CompanyName && CompanyAddress == item.CompanyAddress && CompanyPhone == item.CompanyPhone && CompanyEmail == item.CompanyEmail && MadeCountry == item.MadeCountry;

            return false;
        }
        public override int GetHashCode()
        {
            return (CompanyName, CompanyAddress, CompanyPhone, CompanyEmail, MadeCountry).GetHashCode();
        }

    }
}
