namespace DeviceReg.WebApi.Models
{
    public class UserProfileModel
    {
        public GenderType Gender { get; set; }
        public string Prename { get; set; }
        public string Surname { get; set; }
        public LanguageType Language { get; set; }

        public string Phone { get; set; }

        public CompanyProfile Company { get; set; }

        public string SecretQuestion { get; set; }

        public string SecretAnswer { get; set; }

        public bool TermsAccepted { get; set; }
    }
}