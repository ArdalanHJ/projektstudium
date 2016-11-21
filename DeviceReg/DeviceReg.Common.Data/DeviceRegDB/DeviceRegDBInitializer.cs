using DeviceReg.Common.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceReg.Common.Data.DeviceRegDB {
    //public class DeviceRegDBInitializer : DropCreateDatabaseAlways<DeviceRegDBContext> {
    public class DeviceRegDBInitializer : NullDatabaseInitializer<DeviceRegDBContext> {

    //protected override void Seed(DeviceRegDBContext context) {
    //        AddTypesOfDevice(context);
    //        AddMediums(context);

    //        base.Seed(context);
    //    }

        private void AddMediums(DeviceRegDBContext context) {
            IList<Medium> mediums = new List<Medium>() {
                new Medium() { Name = "1- Pentanol" },
                new Medium() { Name = "1- Pentanol", IsGas = true },
                new Medium() { Name = "Aceton" },
                new Medium() { Name = "Aceton", IsGas = true },
                new Medium() { Name = "Ameisensäure" },
                new Medium() { Name = "Ameisensäure", IsGas = true },
                new Medium() { Name = "Ammoniak" },
                new Medium() { Name = "Ammoniak", IsGas = true },
            };

            foreach(Medium medium in mediums) {
          //      context.Mediums.Add(medium);
            }
        }

        private void AddTypesOfDevice(DeviceRegDBContext context) {
            IList<TypeOfDevice> types = new List<TypeOfDevice>() {
                new TypeOfDevice() { Name = "Magnetischer Durchflussmesser" },
                new TypeOfDevice() { Name = "Vortex-Durchflussmesser" },
                new TypeOfDevice() { Name = "Coriolis-Masse-Durchflussmesser" },
                new TypeOfDevice() { Name = "Schwebekörper-Durchflussmesser" },
                new TypeOfDevice() { Name = "Ultraschall-Durchflussmesser" }
            };

            foreach(TypeOfDevice type in types) {
            //    context.Types.Add(type);
            }
        }
    }
}
