using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BL.Models;
namespace BL.Classes
{
    public class StuffManger : Repository<staff>
    {
        public StuffManger(SchoolDBEntities ctx) : base(ctx)
        {
        }
        public StuffCustom CheckAuth(string email,string pass)
        {
            var role = GetAllBind().Where(u => u.email == email && u.pass == pass).Select(x => new StuffCustom { id = x.id, fname = x.fname, lname = x.lname, Afname = x.Afname, Alname = x.Alname, email = x.email, pass = x.pass, phone = x.phone, DOB = x.DOB, JoinDate = x.JoinDate, FiredDate = x.FiredDate, Img = x.Img, status = x.status, RoleId = x.RoleId }).FirstOrDefault();
            if (role != null)
                return role;
            return null;

        }

    }
}
