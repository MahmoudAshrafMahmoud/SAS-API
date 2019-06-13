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
    public class CoursesController : ApiController
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        // GET: api/Courses
        public IEnumerable<CourseCustom> Get()
        {
            try
            {
                return unitOfWork.CourseManager.GetAllBind().Select(c => new CourseCustom { code = c.code, crs_AName = c.crs_AName, crs_Name = c.crs_Name, levelid = c.levelID.Value, staffId = c.staffId });
            }
            catch
            {
                return null;
            }
        }

        // GET: api/Courses/5
        public CourseCustom Get(int id)
        {
            try
            {
                var crsEntity = unitOfWork.CourseManager.GetByID(id);
                CourseCustom course = new CourseCustom();
                course.code = crsEntity.code;
                course.crs_AName = crsEntity.crs_AName;
                course.crs_Name = crsEntity.crs_Name;
                course.staffId = crsEntity.staffId;
                return course;
            }
            catch
            {
                return null;
            }
        }

        // POST: api/Courses
        public bool Post(course crs)
        {
            try
            {
                var id = unitOfWork.CourseManager.MaxId(crs);
                for (int i = 0; true; i++)
                {
                    if (unitOfWork.CourseManager.GetByID(id) == null)
                    {
                        crs.code = id;
                        return unitOfWork.CourseManager.AddEntity(crs);
                    }
                    id++;
                }
            }
            catch
            {
                return false;
            }
        }

        // PUT: api/Courses/5
        public bool Put(course crs)
        {
            try
            {
                return unitOfWork.CourseManager.UpdateEntity(crs);
            }
            catch
            {
                return false;
            }
        }

        // DELETE: api/Courses/5
        public bool Delete(int id)
        {
            try
            {
                return unitOfWork.CourseManager.DeleteEntity(unitOfWork.CourseManager.GetByID(id));
            }
            catch
            {
                return false;
            }
        }

    }
}
