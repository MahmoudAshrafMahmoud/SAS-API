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
    public class AbsencesController : ApiController
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        // GET api/absence
        public IEnumerable<AbsenceCustom> Get()
        {
            try
            {
                return unitOfWork.AbsenceManager.GetAllBind().Select(x => new AbsenceCustom { absenceDate = x.absenceDate, status = x.status,id=x.id });
            }
            catch
            {
                return null;   
            }
        }

        // GET api/absence/5
        public AbsenceCustom Get(int id)
        {
            try
            {
                var entity = unitOfWork.AbsenceManager.GetByID(id);
                AbsenceCustom abs = new AbsenceCustom();
                abs.id = entity.id;
                abs.status = entity.status;
                abs.absenceDate = entity.absenceDate;
                return abs;
            }
            catch 
            {
                return null;
            }
        }

        // POST api/absence
        public bool Post(tbl_absence abs)
        {
            try
            {
                var id = unitOfWork.AbsenceManager.MaxId(abs);
                for (int i = 0; true; i++)
                {
                    if (unitOfWork.AbsenceManager.GetByID(id) == null)
                    {
                        abs.id = id;
                        return unitOfWork.AbsenceManager.AddEntity(abs);
                    }
                    id++;
                }
            }
            catch 
            {
                return false;
            }
        }

        // PUT api/absence/5
        public bool Put(tbl_absence abs)
        {
            try
            {
                return unitOfWork.AbsenceManager.UpdateEntity(abs);
            }
            catch 
            {
                return false;
            }
        }

        // DELETE api/absence/5
        public bool Delete(int id)
        {
            try
            {
                unitOfWork.AbsenceManager.delete(a => a.stdId == id);
                unitOfWork.StdLevelManager.delete(a => a.stdId == id);
                unitOfWork.StdCrsManager.delete(a => a.stdId == id);
                return unitOfWork.StudentManager.DeleteEntity(unitOfWork.StudentManager.GetByID(id));
            }
            catch 
            {
                return false;   
            }
        }

    }
}
