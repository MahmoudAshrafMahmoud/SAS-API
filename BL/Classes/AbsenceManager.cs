using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BL.Classes;
using BL.Models;

namespace BL.Classes
{
    public class AbsenceManager : Repository<tbl_absence>
    {
        public AbsenceManager(SchoolDBEntities ctx) : base(ctx)
        {
        }
        public List<student> GetStudentByDate(DateTime date)
        {
            UnitOfWork uow = new UnitOfWork();
            List<student> list = new List<student>();
            var studentIDList = GetAll().Where(s => s.absenceDate == date).Select(s => s.stdId).ToList();
            foreach (var id in studentIDList)
            {
                list.Add(uow.StudentManager.GetByID(id));
            }
            return list;
        }
        public List<student> GetStudentBetweenTwoDate(DateTime startdate,DateTime endDate)
        {
            UnitOfWork uow = new UnitOfWork();
            List<student> list = new List<student>();
            var studentIDList = GetAll().Where(s => s.absenceDate >= startdate && s.absenceDate <= endDate ).Select(s => s.stdId).ToList();
            foreach (var id in studentIDList)
            {
                list.Add(uow.StudentManager.GetByID(id));
            }
            return list;
        }
    }
}
