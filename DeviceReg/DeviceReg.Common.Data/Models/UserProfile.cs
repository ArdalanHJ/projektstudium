using DeviceReg.Common.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DeviceReg.Common.Data.Models.ComplexTypes;

namespace DeviceReg.Common.Data.Models
{
    public class UserProfile : IEntity
    {
        public UserProfile()
        {
            Timestamp = new Timestamp();
        }
        public int Id { get; set; }

        public string UserId { get; set; }

        public Timestamp Timestamp { get; set; }
   

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

        public string SecretQuestion { get; set; }

        public string SecretAnswer { get; set; }

        public bool TermsAccepted { get; set; }

        public User User { get; set; }

        
    }
}
