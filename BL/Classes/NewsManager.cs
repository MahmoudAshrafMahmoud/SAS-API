using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL;
using DAL;
namespace BL.Classes
{
    public class NewsManager : Repository<news>
    {
        public NewsManager(SchoolDBEntities ctx) : base(ctx)
        {
        }
    }
}
