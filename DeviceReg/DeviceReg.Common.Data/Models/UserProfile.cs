using DeviceReg.Common.Data.Interfaces;
using DeviceReg.Common.Data.Models.ComplexTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceReg.Common.Data.Models
{
    public class UserProfile : IEntity
    {
        public UserProfile()
        {
            this.Timestamp = new Timestamp();
        }

        public int Id { get; set; }

        [Key]
        [ForeignKey("User")]
        public int UserID { get; set; }

        public virtual User User { get; set; }

        public String Salutation { get; set; }

        public String FirstName { get; set; }

        public String SecondName { get; set; }

        public String Language { get; set; }

        public String Phonenumber { get; set; }

        public String CompanyName { get; set; }

        public String CompanyAddress { get; set; }

        public String BusinessCategory { get; set; }

        public String BusinessType { get; set; }

        public Timestamp Timestamp { get; set; }
    }
}
