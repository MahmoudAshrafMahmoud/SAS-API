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
    public class LevelsController : ApiController
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        // GET api/level
        public IEnumerable<LevelCustom> Get()
        {
            try
            {
                return unitOfWork.LevelManager.GetAllBind().Select(x => new LevelCustom { id = x.id, levelAName = x.levelAName, levelName = x.levelName, fees = x.fees, scheduleFile = x.scheduleFile });

            }
            catch
            {
                return null;
            }
        }

        // GET api/level/5
        public LevelCustom Get(int id)
        {
            try
            {
                var entity = unitOfWork.LevelManager.GetByID(id);
                LevelCustom level = new LevelCustom();
                level.id = entity.id;
                level.levelAName = entity.levelAName;
                level.levelName = entity.levelName;
                level.scheduleFile = entity.scheduleFile;
                level.fees = entity.fees;
                return level;
            }
            catch
            {
                return null;
            }
        }

        // POST api/level
        public bool Post(ClassLevel l)
        {
            try
            {
                var id = unitOfWork.LevelManager.MaxId(l);
                for (int i = 0; true; i++)
                {
                    if (unitOfWork.LevelManager.GetByID(id) == null)
                    {
                        l.id = id;
                        return unitOfWork.LevelManager.AddEntity(l);
                    }
                    id++;
                }
            }
            catch
            {
                return false;
            }
        }

        // PUT api/level/5
        public bool Put(ClassLevel l)
        {
            try
            {
                return unitOfWork.LevelManager.UpdateEntity(l);
            }
            catch
            {
                return false;
            }
        }

        // DELETE api/level/5
        public bool Delete(int id)
        {
            try
            {
                var entity = unitOfWork.LevelManager.GetByID(id);
                return unitOfWork.LevelManager.DeleteEntity(entity);
            }
            catch
            {
                return false;
            }
        }
    }
}
