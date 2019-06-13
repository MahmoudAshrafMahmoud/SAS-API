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
    public class RolesController : ApiController
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        // GET: api/Roles
        public IEnumerable<RoleCustom> Get()
        {
            try
            {
                return unitOfWork.RolesManager.GetAllBind().Select(r => new RoleCustom { id = r.id, RuleName = r.RuleName, status = r.status });
            }
            catch
            {
                return null;
            }
        }

        // GET: api/Roles/5
        public RoleCustom Get(int id)
        {
            try
            {
                var roleEntity = unitOfWork.RolesManager.GetByID(id);
                RoleCustom role = new RoleCustom();
                role.id = roleEntity.id;
                role.RuleName = roleEntity.RuleName;
                role.status = roleEntity.status;
                return role;
            }
            catch
            {
                return null;
            }
        }

        // POST: api/Roles
        public bool Post(tbl_role r)
        {
            try
            {
                var id = unitOfWork.RolesManager.MaxId(r);
                for (int i = 0; true; i++)
                {
                    if (unitOfWork.RolesManager.GetByID(id) == null)
                    {
                        r.id = id;
                        return unitOfWork.RolesManager.AddEntity(r);
                    }
                    id++;
                }
            }
            catch
            {
                return false;
            }
        }

        // PUT: api/Roles/5
        public bool Put(tbl_role r)
        {
            try
            {
                return unitOfWork.RolesManager.UpdateEntity(r);
            }
            catch
            {
                return false;
            }
        }

        // DELETE: api/Roles/5
        public bool Delete(int id)
        {
            try
            {
                return unitOfWork.RolesManager.DeleteEntity(unitOfWork.RolesManager.GetByID(id));
            }
            catch
            {
                return false;
            }
        }
    }
}
