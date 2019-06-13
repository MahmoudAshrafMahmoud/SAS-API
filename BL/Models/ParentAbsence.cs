using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class ParentAbsence
    {

        public int id { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public Nullable<System.DateTime> absenceDate { get; set; }

    }
}
