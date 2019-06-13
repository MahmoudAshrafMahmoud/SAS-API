using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class StdLevelCustom
    {
        public int id { get; set; }
        public Nullable<int> levelId { get; set; }
        public Nullable<int> stdId { get; set; }
        public Nullable<int> total { get; set; }
        public Nullable<int> paid { get; set; }
        public int reminder { get; set; }

    }
}
