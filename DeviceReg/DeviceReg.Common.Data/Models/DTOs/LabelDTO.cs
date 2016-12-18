using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DeviceReg.WebApi.Models.DTOs
{
    public class LabelDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}