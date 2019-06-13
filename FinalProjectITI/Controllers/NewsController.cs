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
    public class NewsController : ApiController
    {
        UnitOfWork unitOfWork = new UnitOfWork();
        // GET: api/news
        public IEnumerable<NewsCustom> Get()
        {
            try
            {
                return unitOfWork.NewsManager.GetAllBind().Select(n => new NewsCustom { id = n.id, Content = n.Content, AContent = n.AContent, ATitle = n.ATitle, NewsDate = n.NewsDate, status = n.status, Title = n.Title });
            }
            catch
            {
                return null;
            }
        }

        // GET: api/news/5
        public NewsCustom Get(int id)
        {
            try
            {
                var newsEntity = unitOfWork.NewsManager.GetByID(id);
                NewsCustom news = new NewsCustom();
                news.id = newsEntity.id;
                news.Title = newsEntity.Title;
                news.Content = newsEntity.Content;
                news.ATitle = newsEntity.ATitle;
                news.NewsDate = newsEntity.NewsDate;
                news.status = newsEntity.status;
                news.AContent = newsEntity.AContent;
                return news;
            }
            catch
            {
                return null;
            }

        }

        // POST: api/news
        public bool Post(news n)
        {
            try
            {
                var id = unitOfWork.NewsManager.MaxId(n);
                for (int i = 0; true; i++)
                {
                    if (unitOfWork.NewsManager.GetByID(id) == null)
                    {
                        n.id = id;
                        return unitOfWork.NewsManager.AddEntity(n);
                    }
                    id++;
                }
            }
            catch
            {
                return false;
            }
        }

        // PUT: api/news/5
        public bool Put(news n)
        {
            try
            {
                return unitOfWork.NewsManager.UpdateEntity(n);
            }
            catch
            {
                return false;
            }
        }

        // DELETE: api/news/5
        public bool Delete(int id)
        {
            try
            {
                return unitOfWork.NewsManager.DeleteEntity(unitOfWork.NewsManager.GetByID(id));
            }
            catch
            {
                return false;
            }
        }
    }
}
