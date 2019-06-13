using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class BookCustom
    {
        public int bookID { get; set; }
        public string Title { get; set; }
        public string ATitle { get; set; }
        public bool? status { get; set; }
        public string link { get; set; }
    }
}
