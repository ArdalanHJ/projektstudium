using DeviceReg.Common.Data.Models;

namespace DeviceReg.WebApi.Models
{
    public class UserProfileRegistrationBindingModel
    {
        public GenderType Gender { get; set; }
        public string Prename { get; set; }
        public string Surname { get; set; }
        public LanguageType Language { get; set; }

        public string Phone { get; set; }

        public CompanyProfile CompanyProfile { get; set; }

        public string SecretQuestion { get; set; }

        public string SecretAnswer { get; set; }

        public bool TermsAccepted { get; set; }
    }

    public class UserProfileUserViewDto
    {
        public UserProfileUserViewDto()
        {

        }
        public UserProfileUserViewDto(UserProfile userProfile)
        {
            Gender = userProfile.Gender;
            Prename = userProfile.Prename;
            Surname = userProfile.Surname;
            Language = userProfile.Language;
            Phone = userProfile.Phone;
            IndustryFamilyType = userProfile.IndustryFamilyType;
            IndustryType = userProfile.IndustryType;
            CompanyName = userProfile.CompanyName;
            Street = userProfile.Street;
            StreetNumber = userProfile.StreetNumber;
            ZipCode = userProfile.ZipCode;
            City = userProfile.City;
            Country = userProfile.Country;
        }
        public int Gender { get; set; }

        public string Prename { get; set; }

        public string Surname { get; set; }

        public int Language { get; set; }

        public string Phone { get; set; }

        public int IndustryFamilyType { get; set; }

        public string IndustryType { get; set; }

        public string CompanyName { get; set; }

        public string Street { get; set; }

        public string StreetNumber { get; set; }

        public string ZipCode { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

    }
}