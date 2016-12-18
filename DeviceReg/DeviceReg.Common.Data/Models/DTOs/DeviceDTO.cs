using DeviceReg.Common.Data.Models.ComplexTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeviceReg.WebApi.Models.DTOs
{
    public class DeviceDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Serialnumber { get; set; }

        public bool RegularMaintenance { get; set; }

        public string UserId { get; set; }

        public int TypeOfDeviceId { get; set; }

        public int MediumId { get; set; }

        public IEnumerable<LabelDTO> Labels { get; set; }

        public Timestamp Timestamp { get; set; }
    }
}