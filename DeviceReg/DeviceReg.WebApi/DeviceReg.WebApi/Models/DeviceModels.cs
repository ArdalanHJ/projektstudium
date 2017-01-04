using DeviceReg.Common.Data.Models;
using DeviceReg.Common.Data.Models.ComplexTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DeviceReg.WebApi.Models
{
    public class DeviceModel
    {
        public string Name { get; set; }

        [RegularExpression("^^([1-9]|[BCDJN])([0-9]|[BCDJN])([1-9]|[BCDJN])([1-9]|[AB])([0-9]|[A-K])([0-9]{4})$", ErrorMessage = "Invalid serial number.")]
        public string SerialNumber { get; set; }

        public string Description { get; set; }

        public Boolean RegularMaintenance { get; set; }

        public int TypeOfDeviceId { get; set; }

        public int MediumId { get; set; }

        public bool IsValid()
        {
            return true;
        }
    }

    public class DeviceDto
    {
        public DeviceDto(Device device)
        {
            Id = device.Id;
            Name = device.Name;
            Description = device.Description;
            Serialnumber = device.Serialnumber;
            RegularMaintenance = device.RegularMaintenance;
            UserId = device.UserId;
            TypeOfDeviceId = device.TypeOfDeviceId;
            MediumId = device.MediumId;
            Labels = device.Tags.Select(l => new LabelDto(l));
            Timestamp = device.Timestamp;
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Serialnumber { get; set; }

        public bool RegularMaintenance { get; set; }

        public string UserId { get; set; }

        public int TypeOfDeviceId { get; set; }

        public int MediumId { get; set; }

        public IEnumerable<LabelDto> Labels { get; set; }

        public Timestamp Timestamp { get; set; }
    }
}