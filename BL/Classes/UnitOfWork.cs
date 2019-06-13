using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BL.Classes
{
    public class UnitOfWork
    {
        SchoolDBEntities ctx = new SchoolDBEntities();

        public CourseManager CourseManager
        {
            get
            {
                return new CourseManager(ctx);
            }
        }
        public TaskManager TaskManager
        {
            get
            {
                return new TaskManager(ctx);
            }
        }
        public ParentManager ParentManager
        {
            get
            {
                return new ParentManager(ctx);
            }
        }
        public BookManager BookManager
        {
            get
            {
                return new BookManager(ctx);
            }
        }
        public NewsManager NewsManager
        {
            get
            {
                return new NewsManager(ctx);
            }
        }
        public RolesManager RolesManager
        {
            get { return new RolesManager(ctx); }
        }
        public AbsenceManager AbsenceManager
        {
            get { return new AbsenceManager(ctx); }
        }
        public StudentManager StudentManager
        {
            get
            {
                return new StudentManager(ctx);

            }
        }
        public StuffManger StuffManger
        {
            get { return new StuffManger(ctx); }
        }
        public LevelManager LevelManager
        {
            get { return new LevelManager(ctx); }
        }
        public StdCrsManager StdCrsManager
        {
            get {return new StdCrsManager(ctx); }
        }
        public StdLevelManager StdLevelManager
        {
            get { return new StdLevelManager(ctx); }
        }
    }
}
