using DeviceReg.Common.Data.Interfaces;
using DeviceReg.Common.Data.Models.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceReg.Common.Data.Models
{
    public class Role : IEntity
    {
        public Role()
        {

        }

        public int Id { get; set; }

        public String Name { get; set; }

        public Timestamp Timestamp { get; set; }

    }
}
