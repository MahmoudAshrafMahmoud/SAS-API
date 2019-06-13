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
using System.IO;
using System.Web;
using System.Web.Mail;
using System.Net.Mail;

namespace FinalProject.Controllers
{
    public class StuffsController : ApiController
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        // GET api/staff
        public IEnumerable<StuffCustom> Get()
        {
            try
            {

                return unitOfWork.StuffManger.GetAllBind().Select(x => new StuffCustom { id = x.id, fname = x.fname, lname = x.lname, Afname = x.Afname, Alname = x.Alname, email = x.email, pass = x.pass, phone = x.phone, DOB = x.DOB, JoinDate = x.JoinDate, FiredDate = x.FiredDate, Img = x.Img, status = x.status, RoleId = x.RoleId });
            }
            catch
            {
                return null;
            }
        }

        // GET api/staff/5
        public StuffCustom Get(int id)
        {
            try
            {
                var entity = unitOfWork.StuffManger.GetByID(id);
                StuffCustom staff = new StuffCustom();
                staff.id = entity.id;
                staff.fname = entity.fname;
                staff.lname = entity.lname;
                staff.Afname = entity.Afname;
                staff.Alname = entity.Alname;
                staff.email = entity.email;
                staff.pass = entity.pass;
                staff.phone = entity.phone;
                staff.DOB = entity.DOB;
                staff.JoinDate = entity.JoinDate;
                staff.FiredDate = entity.FiredDate;
                staff.Img = entity.Img;
                staff.RoleId = entity.RoleId;
                return staff;

            }
            catch
            {

                return null;
            }
        }

        // POST api/staff
        public bool Post(staff s)
        {
            try
            {
                var id = unitOfWork.StuffManger.MaxId(s);
                for (int i = 0; true; i++)
                {
                    if (unitOfWork.StuffManger.GetByID(id) == null)
                    {
                        s.id = id;
                        return unitOfWork.StuffManger.AddEntity(s);
                    }
                    id++;
                }

            }
            catch
            {
                return false;
            }
        }

        // PUT api/staff
        public bool Put(staff s)
        {
            try
            {
                return unitOfWork.StuffManger.UpdateEntity(s);
            }
            catch
            {
                return false;
            }
        }

        // DELETE api/staff/5
        public bool Delete(int id)
        {
            try
            {
                unitOfWork.NewsManager.delete(a => a.adminId == id);
                return unitOfWork.StuffManger.DeleteEntity(unitOfWork.StuffManger.GetByID(id));
            }
            catch
            {
                return false;
            }
        }
        public StuffCustom getStuff(string email, string password)
        {
            try
            {
                return unitOfWork.StuffManger.CheckAuth(email, password);
            }
            catch
            {
                return null;
            }
        }
        
    }
}
