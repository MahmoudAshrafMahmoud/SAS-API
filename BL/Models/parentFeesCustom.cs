using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class parentFeesCustom
    {

        public int id { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public Nullable<int> levelId { get; set; }
        public Nullable<int> total { get; set; }
        public Nullable<int> paid { get; set; }

    }
}
