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
    public class TasksController : ApiController
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        // GET: api/Tasks
        public IEnumerable<TaskCustom> Get()
        {
            try
            {
                return unitOfWork.TaskManager.GetAllBind().Select(t => new TaskCustom { id = t.id, taskName = t.taskName, levelId = t.levelId });
            }
            catch
            {
                return null;
            }
        }

        // GET: api/Tasks/5
        public TaskCustom Get(int id)
        {
            try
            {
                var taskEntity = unitOfWork.TaskManager.GetByID(id);
                TaskCustom task = new TaskCustom();
                task.id = taskEntity.id;
                task.taskName = taskEntity.taskName;
                task.levelId = taskEntity.levelId;
                return task;
            }
            catch
            {
                return null;
            }
        }

        // POST: api/Tasks
        public bool Post(tbl_Task task)
        {
            try
            {
                var id = unitOfWork.TaskManager.MaxId(task);
                for (int i = 0; true; i++)
                {
                    if (unitOfWork.TaskManager.GetByID(id) == null)
                    {
                        task.id = id;
                        return unitOfWork.TaskManager.AddEntity(task);
                    }
                    id++;
                }
            }
            catch
            {
                return false;
            }
        }

        // PUT: api/Tasks/5
        public bool Put(tbl_Task task)
        {
            try
            {
                return unitOfWork.TaskManager.UpdateEntity(task);
            }
            catch
            {
                return false;
            }
        }

        // DELETE: api/Tasks/5
        public bool Delete(int id)
        {
            try
            {
                return unitOfWork.TaskManager.DeleteEntity(unitOfWork.TaskManager.GetByID(id));
            }
            catch
            {
                return false;
            }
        }
        // DELETE: api/Tasks/5
        public List<TaskCustom> getLevelTasks(int levelid)
        {
            try
            {
                return unitOfWork.TaskManager.GetAll().Where(t => t.levelId == levelid).Select(t => new TaskCustom { id = t.id, taskName = t.taskName, levelId = t.levelId }).ToList();
            }
            catch
            {
                return null;
            }
        }
    }
}
