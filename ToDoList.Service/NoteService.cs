using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Data;
using ToDoList.Data.Infrastructure;

namespace ToDoList.Service
{
    /*
     * 
     * Service layer
     * All of our business logic will be created in a service layer, because the controllers should not contain any logic. 
     * This is so all our logic can be in one place and that the same logic can be unit tested with mocked data.
     * 
     */

    public class NoteService : INoteService
    {
        private IUnitOfWork _uow;
        private IRepository<Note> _Note;

        public NoteService(IUnitOfWork uow)
        {
            _uow = uow;
            _Note = _uow.GetRepository<Note>();
        }

        public IEnumerable<Note> GetAll()
        {
            return _Note.GetAll();
        }

        public Note GetByID(int id)
        {
            try
            {
                return _Note.GetAll().Where(s => s.Id == id).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw new Exception("Failure getting note", ex);
            }
        }

        public void Create(Note note)
        {
            _Note.Add(note);
            _uow.Save();
        }

        public void Update(Note note)
        {
            _Note.Update(note);
            _uow.Save();
        }

        public void DeleteByID(int id)
        {
            try
            {
                Note model = _Note.GetAll().Where(s => s.Id == id).SingleOrDefault();
                _Note.Delete(model);
                _uow.Save();
            }
            catch (Exception ex)
            {
                throw new Exception("Failure deleting note", ex);
            }
        }


        public void ToggleComplete(int id)
        {
            try
            {
                Note model = _Note.GetAll().Where(s => s.Id == id).SingleOrDefault();
                model.Completed = !model.Completed;
                _Note.Update(model);
                _uow.Save();
            }
            catch (Exception ex)
            {
                throw new Exception("Failure completing note", ex);
            }
        }


        public DayColumn NextDay(DateTime baseDay)
        {
            return new DayColumn() { DataDate = baseDay.AddDays(1) };
        }

        public List<DayColumn> GetInitialWeekView()
        {
            var weekView = new List<DayColumn>
            {
                new DayColumn() {DataDate = DateTime.Now.AddDays(-2)},
                new DayColumn() {DataDate = DateTime.Now.AddDays(-1)},
                new DayColumn() {DataDate = DateTime.Now},
                new DayColumn() {DataDate = DateTime.Now.AddDays(1)},
                new DayColumn() {DataDate = DateTime.Now.AddDays(2)}
            };

            return weekView;
        }

    }

    public class DayColumn
    {
        public DayColumn()
        {
            Notes = new List<Note>();
        }

        public DateTime DataDate { get; set; }
        public string Day { get { return DataDate.DayOfWeek.ToString(); } }

        public string Date { get
        {
            return string.Format("{0} {1}, {2}", DataDate.Month, DataDate.Day, DataDate.Year);
        }}

        public List<Note> Notes { get; set; }
    }
}
