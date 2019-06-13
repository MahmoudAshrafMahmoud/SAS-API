using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using DAL;
namespace BL.Classes
{
    public class RolesManager : Repository<tbl_role>
    {
        public RolesManager(SchoolDBEntities ctx) : base(ctx)
        {
        }
    }
}
