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
    public class ParentsController : ApiController
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        // GET: api/Parents
        public IEnumerable<ParentCustom> Get()
        {
            try
            {
                return unitOfWork.ParentManager.GetAllBind().Select(p=>new ParentCustom {id=p.id,Afname=p.Afname,Alname=p.Alname,DOB=p.DOB,email=p.email,fname=p.fname,Img=p.Img,lname=p.lname,pass=p.pass,phone=p.phone,status=p.status,roleID=p.roleID });
            }
            catch 
            {
                return null;
            }
        }

        // GET: api/Parents/5
        public ParentCustom Get(int id)
        {
            try
            {
                var parentEntity = unitOfWork.ParentManager.GetByID(id);
                ParentCustom parent = new ParentCustom();
                parent.id = parentEntity.id;
                parent.fname = parentEntity.fname;
                parent.lname = parentEntity.lname;
                parent.email = parentEntity.email;
                parent.pass = parentEntity.pass;
                parent.phone = parentEntity.phone;
                parent.Img = parentEntity.Img;
                parent.status = parentEntity.status;
                parent.DOB = parentEntity.DOB;
                parent.Afname = parentEntity.Afname;
                parent.Alname = parentEntity.Alname;
                parent.roleID = parentEntity.roleID;
                return parent;

            }
            catch 
            {
                return null;
            } 
        }

        // POST: api/Parents
        public bool Post(parent parent)
        {
            try
            {
                var id = unitOfWork.ParentManager.MaxId(parent);
                for (int i = 0; true; i++)
                {
                    if (unitOfWork.ParentManager.GetByID(id) == null)
                    {
                        parent.id = id;
                        return unitOfWork.ParentManager.AddEntity(parent);
                    }
                    id++;
                }
            }
            catch 
            {
                return false;   
            }
        }

        // PUT: api/Parents/5
        public bool Put(parent parent)
        {
            try
            {
                return unitOfWork.ParentManager.UpdateEntity(parent);
            }
            catch 
            {
                return false;   
            }
        }

        // DELETE: api/Parents/5
        public bool Delete(int id)
        {
            try
            {
                unitOfWork.StudentManager.delete(a => a.id == id);
                return unitOfWork.ParentManager.DeleteEntity(unitOfWork.ParentManager.GetByID(id));
            }
            catch 
            {
                return false;   
            }
        }
        public ParentCustom getparent(string email, string password)
        {
            try
            {
                return unitOfWork.ParentManager.CheckAuth(email, password);
            }
            catch 
            {
                return null;   
            }

        }

    }
}
