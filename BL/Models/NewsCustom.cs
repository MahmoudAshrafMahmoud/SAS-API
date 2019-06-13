using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class NewsCustom
    {
        public int id { get; set; }
        public string Title { get; set; }
        public string ATitle { get; set; }
        public string Content { get; set; }
        public string AContent { get; set; }
        public DateTime? NewsDate { get; set; }
        public bool? status { get; set; }
    }
}
