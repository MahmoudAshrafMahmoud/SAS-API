using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BL.Classes
{
    public class LevelManager : Repository<ClassLevel>
    {
        public LevelManager(SchoolDBEntities ctx) : base(ctx)
        {
        }
    }
}
