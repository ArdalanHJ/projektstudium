using DeviceReg.Common.Data.Interfaces;
using DeviceReg.Common.Data.Models.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceReg.Common.Data.Models
{
    public class TextResource : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Lang { get; set; }

        public string Text { get; set; }

        public Timestamp Timestamp { get; set; }

    }
}
