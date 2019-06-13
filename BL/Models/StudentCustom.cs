using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
    public class StudentCustom
    {
        public int id { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string Afname { get; set; }
        public string Alname { get; set; }
        public string email { get; set; }
        public string pass { get; set; }
        public string phone { get; set; }
        public DateTime DOB { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime FiredDate { get; set; }
        public byte[] Img { get; set; }
        public Nullable<bool> status { get; set; }
        public Nullable<int> ParentID { get; set; }
        public Nullable<int> classRoom { get; set; }
        public Nullable<int> roleID { get; set; }
        public Nullable<int> levelId { get; set; }

    }
}
