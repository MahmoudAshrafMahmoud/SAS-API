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
    public class StdLevelController : ApiController
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        // GET: api/Books
        public IEnumerable<StdLevelCustom> Get()
        {
            try
            {
                return unitOfWork.StdLevelManager.GetAllBind().Select(b => new StdLevelCustom { id = b.id, stdId = b.stdId, levelId = b.levelId, total = b.total ?? 0, paid = b.paid ?? 0, reminder = (b.total ?? 0 - b.paid ?? 0) });
            }
            catch
            {
                return null;
            }
        }

        // GET: api/Books/5
        public StdLevelCustom Get(int id)
        {
            try
            {
                var stdLevel = unitOfWork.StdLevelManager.GetByID(id);
                StdLevelCustom obj = new StdLevelCustom();
                obj.id = stdLevel.id;
                obj.stdId = stdLevel.stdId;
                obj.levelId = stdLevel.levelId;
                obj.total = stdLevel.total ?? 0;
                obj.paid = stdLevel.paid ?? 0;
                obj.reminder = stdLevel.total ?? 0 - stdLevel.paid ?? 0;
                return obj;
            }
            catch
            {
                return null;
            }
        }

        // POST: api/Books
        public bool Post(StudentLevel b)
        {
            try
            {
                var id = unitOfWork.StdLevelManager.MaxId(b);
                for (int i = 0; true; i++)
                {
                    if (unitOfWork.StdLevelManager.GetByID(id) == null)
                    {
                        b.id = id;
                        return unitOfWork.StdLevelManager.AddEntity(b);
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
        public bool Put(StudentLevel b)
        {
            try
            {
                return unitOfWork.StdLevelManager.UpdateEntity(b);
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
                return unitOfWork.StdLevelManager.DeleteEntity(unitOfWork.StdLevelManager.GetByID(id));
            }
            catch
            {
                return false;
            }
        }
    }
}
