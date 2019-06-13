using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL;
using BL.Classes;
using BL.Models;
namespace FinalProject.Controllers
{
    public class StdCrsController : ApiController
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        // GET: api/Books
        public IEnumerable<StdCrsCustom> Get()
        {
            try
            {
                return unitOfWork.StdCrsManager.GetAllBind().Select(b => new StdCrsCustom { id = b.id, CrsId = b.CrsId, stdId = b.stdId, grade = b.grade });
            }
            catch
            {
                return null;
            }
        }

        // GET: api/Books/5
        public StdCrsCustom Get(int id)
        {
            try
            {
                var stdcrs = unitOfWork.StdCrsManager.GetByID(id);
                StdCrsCustom obj = new StdCrsCustom();
                obj.id = stdcrs.id;
                obj.stdId = stdcrs.stdId;
                obj.CrsId = stdcrs.CrsId;
                obj.grade = stdcrs.grade;
                return obj;
            }
            catch
            {
                return null;
            }
        }

        // POST: api/Books
        public bool Post(std_Crs b)
        {
            try
            {
                var id = unitOfWork.StdCrsManager.MaxId(b);
                for (int i = 0; true; i++)
                {
                    if (unitOfWork.StdCrsManager.GetByID(id) == null)
                    {
                        b.id = id;
                        return unitOfWork.StdCrsManager.AddEntity(b);
                    }
                    id++;
                }
            }
            catch
            {
                return false;
            }
        }

        // PUT: api/Books/5
        public bool Put(std_Crs b)
        {
            try
            {
                return unitOfWork.StdCrsManager.UpdateEntity(b);
            }
            catch
            {
                return false;
            }
        }

        // DELETE: api/Books/5
        public bool Delete(int id)
        {
            try
            {
                return unitOfWork.StdCrsManager.DeleteEntity(unitOfWork.StdCrsManager.GetByID(id));
            }
            catch
            {
                return false;
            }
        }
        //http://localhost:31436/api/stdcrs?stdid=1
        public List<StdCrsCustom> getcourses(int stdId)
        {
            try
            {
                var myvar = (from a in unitOfWork.StdCrsManager.GetAllBind().Where(x => x.stdId == stdId)
                             join b in unitOfWork.CourseManager.GetAllBind() on a.CrsId equals b.code
                             select new StdCrsCustom
                             {
                                 CrsId = a.CrsId.Value,
                                 stdId = a.stdId,
                                 id = a.id,
                                 CrsName = b.crs_Name,
                                 CrsAName = b.crs_AName,
                                 grade = a.grade

                             }).ToList();
                return myvar;
            }
            catch
            {
                return null;
            }

        }
    }
}
