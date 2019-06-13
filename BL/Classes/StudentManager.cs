using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BL.Models;
using BL;
using BL.Classes;
namespace BL.Classes
{
    public class StudentManager : Repository<student>
    {
        public StudentManager(SchoolDBEntities ctx) : base(ctx)
        {
        }
        public List<StudentCustom> GetStudentByLevel(int levelID)
        {
            return GetAll().Where(s=>s.levelId==levelID).Select(x=>new StudentCustom { id = x.id, fname = x.fname, lname = x.lname, Afname = x.Afname, Alname = x.Alname, email = x.email, pass = x.pass, phone = x.phone, DOB = (DateTime)x.DOB, JoinDate = (DateTime)x.JoinDate, FiredDate = (DateTime)x.FiredDate, Img = x.Img, status = x.status, ParentID = x.ParentID }).ToList();
        }
        public StudentCustom CheckAuth(string email, string pass)
        {

            var role = GetAllBind().Where(u => u.email == email && u.pass == pass).Select(x => new StudentCustom { id = x.id, fname = x.fname, lname = x.lname, Afname = x.Afname, Alname = x.Alname, email = x.email, pass = x.pass, phone = x.phone, DOB = (DateTime)x.DOB, JoinDate = (DateTime)x.JoinDate, FiredDate = (DateTime)x.FiredDate, Img = x.Img, status = x.status, ParentID = x.ParentID,roleID=x.roleID }).FirstOrDefault(); 
            if (role != null)
                return role;
            return null;

        }

    }
}
