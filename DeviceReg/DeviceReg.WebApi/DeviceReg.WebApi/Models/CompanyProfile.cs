namespace DeviceReg.WebApi.Models
{
    public class CompanyProfile
    {
        public IndustryFamilyType IndustryFamilyType { get; set; }
        public string IndustryType { get; set; }

        public string CompanyName { get; set; }

        public string Street { get; set; }

        public string StreetNumber { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
    }
}