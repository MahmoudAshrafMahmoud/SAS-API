using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class StdCrsCustom
    {
        public int id { get; set; }
        public Nullable<int> stdId { get; set; }
        public Nullable<int> CrsId { get; set; }
        public Nullable<int> grade { get; set; }
        public string CrsName { get; set; }
        public string CrsAName { get; set; }
        
         
    }
}
