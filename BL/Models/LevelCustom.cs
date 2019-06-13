using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class LevelCustom
    {
        public int id { get; set; }
        public string levelName { get; set; }
        public string levelAName { get; set; }
        public int? fees { get; set; }
        public string scheduleFile { get; set; }
    }
}
