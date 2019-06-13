using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class TaskCustom
    {
        public int id { get; set; }
        public string taskName { get; set; }
        public Nullable<int> levelId { get; set; }
    }
}
