using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BL.Models;
namespace BL.Classes
{
    public class CourseManager : Repository<course>
    {
        public CourseManager(SchoolDBEntities ctx) : base(ctx)
        {
        }
        public StuffCustom GetCourseTeacher(int crsId)
        {
            UnitOfWork uow = new UnitOfWork();
            StuffCustom stuff = new StuffCustom();
            var crs = uow.CourseManager.GetByID(crsId);
            var teacher = uow.StuffManger.GetByID(crs.staffId.Value);
            stuff.id = teacher.id;
            stuff.fname = teacher.fname;
            stuff.lname = teacher.lname;
            stuff.Afname = teacher.Afname;
            stuff.Alname = teacher.Alname;
            stuff.email = teacher.email;
            stuff.pass = teacher.pass;
            stuff.phone = teacher.phone;
            stuff.DOB = (DateTime)teacher.DOB;
            stuff.JoinDate = (DateTime)teacher.JoinDate;
            stuff.FiredDate = (DateTime)teacher.FiredDate;
            stuff.Img = teacher.Img;
            stuff.status = teacher.status;
            return stuff;
        }
    }
}
