using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL;
using BL;
using BL.Classes;
using BL.Models;

namespace FinalProject.Controllers
{
    public class StudentsController : ApiController
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        // GET api/student
        public IEnumerable<StudentCustom> Get()
        {
            try
            {
                return unitOfWork.StudentManager.GetAllBind().Select(x => new StudentCustom { id = x.id, fname = x.fname, lname = x.lname, Afname = x.Afname, Alname = x.Alname, email = x.email, pass = x.pass, phone = x.phone, DOB = (DateTime)x.DOB, JoinDate = (DateTime)x.JoinDate, FiredDate = (DateTime)x.FiredDate, Img = x.Img, status = x.status, ParentID = x.ParentID, roleID = x.roleID, classRoom = x.classRoom, levelId = x.levelId });
            }
            catch
            {
                return null;
            }
        }

        // GET api/student/5
        public StudentCustom Get(int id)
        {
            try
            {
                var entity = unitOfWork.StudentManager.GetByID(id);
                StudentCustom student = new StudentCustom();
                student.id = entity.id;
                student.fname = entity.fname;
                student.lname = entity.lname;
                student.Afname = entity.Afname;
                student.Alname = entity.Alname;
                student.email = entity.email;
                student.phone = entity.phone;
                student.DOB = (DateTime)entity.DOB;
                student.JoinDate = (DateTime)entity.JoinDate;
                student.FiredDate = (DateTime)entity.FiredDate;
                student.Img = entity.Img;
                student.status = entity.status;
                student.roleID = entity.roleID;
                student.ParentID = entity.ParentID;
                student.classRoom = entity.classRoom;
                student.levelId = entity.levelId;
                return student;
            }
            catch
            {
                return null;
            }
        }

        // POST api/student
        public bool Post(student s)
        {
            try
            {
                var id = unitOfWork.StudentManager.MaxId(s);
                for (int i = 0; true; i++)
                {
                    if (unitOfWork.StudentManager.GetByID(id) == null)
                    {
                        s.id = id;
                        return unitOfWork.StudentManager.AddEntity(s);
                    }
                    id++;
                }
            }
            catch
            {
                return false;
            }
        }

        // PUT api/student/5
        public bool Put(student s)
        {
            try
            {
                return unitOfWork.StudentManager.UpdateEntity(s);
            }
            catch
            {
                return false;
            }
        }

        // DELETE api/student/5
        public bool Delete(int id)
        {
            try
            {
                var entity = unitOfWork.StudentManager.GetByID(id);
                return unitOfWork.StudentManager.DeleteEntity(entity);

            }
            catch
            {
                return false;
            }
        }
        public StudentCustom getStudent(string email, string password)
        {
            try
            {
                return unitOfWork.StudentManager.CheckAuth(email, password);
            }
            catch
            {
                return null;
            }
        }
    }
}
