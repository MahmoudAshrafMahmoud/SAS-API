using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BL.Models;
namespace BL.Classes
{
    public class ParentManager : Repository<parent>
    {
        public ParentManager(SchoolDBEntities ctx) : base(ctx)
        {
        }
        public ParentCustom CheckAuth(string email, string pass)
        {

            var role = GetAllBind().Where(u => u.email == email && u.pass == pass).Select(p => new ParentCustom { id = p.id, Afname = p.Afname, Alname = p.Alname, DOB = p.DOB, email = p.email, fname = p.fname, Img = p.Img, lname = p.lname, pass = p.pass, phone = p.phone, status = p.status, roleID = p.roleID }).FirstOrDefault();
            if (role != null)
                return role;
            return null;

        }
    }

}
