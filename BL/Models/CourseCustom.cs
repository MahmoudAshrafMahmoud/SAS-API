using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class CourseCustom
    {
        public int code { get; set; }
        public string crs_Name { get; set; }
        public string crs_AName { get; set; }
        public string staffname { get; set; }
        public int levelid { get; set; }

        public Nullable<int> staffId { get; set; }

    }
}
