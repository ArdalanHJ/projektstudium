using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DeviceReg.Common.Data.Models;
using System.Data.Entity;

namespace DeviceReg.Repositories
{
    public class TextResourceRepository : IdentityRepositoryBase<TextResource>
    {
        public TextResourceRepository(DbSet<TextResource> dbSet) : base(dbSet)
        {

        }
        public TextResource GetByName(string name, string lang)
        {
            return DbSet.FirstOrDefault(t => t.Name == name && t.Lang == lang);
        }
    }
}

