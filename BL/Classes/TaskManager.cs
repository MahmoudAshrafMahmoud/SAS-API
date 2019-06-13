using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BL.Classes
{
    public class TaskManager : Repository<tbl_Task>
    {
        public TaskManager(SchoolDBEntities ctx) : base(ctx)
        {
        }
    }
}
