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
    public class BooksController : ApiController
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        // GET: api/Books
        public IEnumerable<BookCustom> Get()
        {
            try
            {
                return unitOfWork.BookManager.GetAllBind().Select(b=>new BookCustom { bookID = b.bookID,Title=b.Title,ATitle=b.ATitle,link=b.link,status=b.status });
            }
            catch 
            {
                return null;   
            }
        }

        // GET: api/Books/5
        public BookCustom Get(int id)
        {
            try
            {
                var bookEntity = unitOfWork.BookManager.GetByID(id);
                BookCustom book = new BookCustom();
                book.bookID = bookEntity.bookID;
                book.Title = bookEntity.Title;
                book.ATitle = bookEntity.ATitle;
                book.link = bookEntity.link;
                book.status = bookEntity.status;
                return book;
            }
            catch 
            {
                return null;
            }
            
        }

        // POST: api/Books
        public bool Post(book b)
        {
            try
            {
                var id = unitOfWork.BookManager.MaxId(b);
                for (int i = 0; true; i++)
                {
                    if (unitOfWork.BookManager.GetByID(id) == null)
                    {
                        b.bookID = id;
                        return unitOfWork.BookManager.AddEntity(b);
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
        public bool Put(book b)
        {
            try
            {
                return unitOfWork.BookManager.UpdateEntity(b);
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
                return unitOfWork.BookManager.DeleteEntity(unitOfWork.BookManager.GetByID(id));
            }
            catch 
            {
                return false;   
            }
        }
    }
}
