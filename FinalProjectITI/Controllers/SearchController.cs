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
using System.Net.Mail;
namespace FinalProject.Controllers
{
    public class SearchController : ApiController
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        public List<StudentCustom> getStudents(int id)
        {
            try
            {
                return unitOfWork.StudentManager.GetStudentByLevel(id);
            }
            catch
            {
                return null;
            }
        }
        //http://localhost:49576/api/search?d=2018/12/08
        public List<StudentCustom> getStudentsAbsence(DateTime d)
        {
            try
            {
                return unitOfWork.AbsenceManager.GetStudentByDate(d).Select(x => new StudentCustom { id = x.id, fname = x.fname, lname = x.lname, Afname = x.Afname, Alname = x.Alname, email = x.email, pass = x.pass, phone = x.phone, DOB = (DateTime)x.DOB, JoinDate = (DateTime)x.JoinDate, FiredDate = (DateTime)x.FiredDate, Img = x.Img, status = x.status, ParentID = x.ParentID }).ToList();
            }
            catch
            {
                return null;
            }
        }
        //http://localhost:49576/api/search?StartDate=2018/12/08&EndDate=2018/12/23
        public List<StudentCustom> getStudentsAbsence(DateTime StartDate, DateTime EndDate)
        {
            try
            {
                return unitOfWork.AbsenceManager.GetStudentBetweenTwoDate(StartDate, EndDate).Select(x => new StudentCustom { id = x.id, fname = x.fname, lname = x.lname, Afname = x.Afname, Alname = x.Alname, email = x.email, pass = x.pass, phone = x.phone, DOB = (DateTime)x.DOB, JoinDate = (DateTime)x.JoinDate, FiredDate = (DateTime)x.FiredDate, Img = x.Img, status = x.status, ParentID = x.ParentID }).ToList();
            }
            catch
            {
                return null;
            }
        }
        //localhost:49576/api/search?crsId=1
        public StuffCustom GetCourseInstructor(int crsId)
        {
            try
            {
                return unitOfWork.CourseManager.GetCourseTeacher(crsId);
            }
            catch
            {
                return null;
            }
        }

        //http://localhost:31436/api/search?parentID=1
        public List<ParentgradesCustom> getGrades(int parentID)
        {
            try
            {
                return
                (from a in unitOfWork.StudentManager.GetAllBind().Where(x => x.ParentID == parentID)
                 join b in unitOfWork.StdCrsManager.GetAllBind() on a.id equals b.stdId
                 join c in unitOfWork.CourseManager.GetAllBind() on b.CrsId equals c.code
                 select new ParentgradesCustom
                 {
                     id = a.id,
                     fname = a.fname,
                     lname = a.lname,
                     crs_Name = c.crs_Name,
                     grade = b.grade.Value,
                 }).ToList();
            }
            catch
            {
                return null;
            }

        }
        //http://localhost:31436/api/search?parid=1
        public List<ParentAbsence> getAbsence(int parid)
        {
            try
            {
                return
                (from a in unitOfWork.StudentManager.GetAllBind().Where(x => x.ParentID == parid)
                 join b in unitOfWork.AbsenceManager.GetAllBind() on a.id equals b.stdId
                 select new ParentAbsence
                 {
                     id = a.id,
                     fname = a.fname,
                     lname = a.lname,
                     absenceDate = b.absenceDate
                 }).ToList();
            }
            catch
            {
                return null;
            }

        }
        //http://localhost:31436/api/search?pid=1
        public List<parentFeesCustom> getFees(int pid)
        {
            try
            {
                return
               (from a in unitOfWork.StudentManager.GetAllBind().Where(x => x.ParentID == pid)
                join b in unitOfWork.StdLevelManager.GetAllBind() on a.id equals b.stdId
                select new parentFeesCustom
                {
                    id = a.id,
                    fname = a.fname,
                    lname = a.lname,
                    levelId = b.levelId,
                    total = b.total,
                    paid = b.paid
                }).ToList();
            }
            catch
            {
                return null;
            }
        }
        //http://localhost:31436/api/search?pid=1
        public List<CourseCustom> getcrs(int tid)
        {
            try
            {
                return unitOfWork.CourseManager.GetAllBind().Where(x => x.staffId == tid).Select(x => new CourseCustom { code = x.code, crs_Name = x.crs_Name, levelid = x.levelID.Value }).ToList();
            }
            catch
            {
                return null;
            }

        }
        [HttpPost]
        public void postmail(mailCustom m)
        {

            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage("projectsalary4444@gmail.com", m.email);
            mail.Subject = m.subject;
            string Body = m.content;
            mail.Body = Body;
            mail.IsBodyHtml = true;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("projectsalary4444@gmail.com", "Psalaryproject4444");
            smtp.Send(mail);
        }
    }
}
