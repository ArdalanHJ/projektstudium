using DeviceReg.Common.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeviceReg.WebApi.Models
{
    public class LabelDto
    {
        public LabelDto(Tag tag)
        {
            Id = tag.Id;
            Name = tag.Name;
            Description = tag.Description;
        }
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}