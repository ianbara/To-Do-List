using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ToDoList.Data;
using ToDoList.Service;

namespace ToDoList.Web.Controllers
{
    public class NoteController : Controller
    {
        private INoteService _noteService;
        private IBoardService _boardService;


        public NoteController(INoteService noteService, IBoardService boardService)
        {
            _noteService = noteService;
            _boardService = boardService;
        }


        public ActionResult Index(int? id)
        {
            ViewBag.PageTitle = "Notes";
            var notes = new List<Note>();

            if (id == null)
            {
                notes = _noteService.GetAll().ToList();
            }
            else
            {
                var boardId = Convert.ToInt32(id);
                notes = _noteService.GetNotesForBoard(boardId).ToList();
            }

            return View(notes);
        }

        public ActionResult Create()
        {
            ViewBag.BoardList = new SelectList(_boardService.GetAll(), "Id", "Name");
            return View(new Note());
        }

        [HttpPost]
        public ActionResult Create(Note note)
        {
            _noteService.Create(note);

            return RedirectToAction("Index");

        }

        public ActionResult Edit(int id)
        {
            var note = _noteService.GetByID(id);

            return View(note);
        }

        [HttpPost]
        public ActionResult Edit(Note note)
        {
            _noteService.Update(note);

            return RedirectToAction("Index");
        }

        public ActionResult ToggleComplete(int id)
        {
            _noteService.ToggleComplete(id);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            _noteService.DeleteByID(id);

            return RedirectToAction("Index");
        }


        public PartialViewResult TableView()
        {
            var notes = _noteService.GetAll();
            return PartialView("_tableView", notes);
        }

        public PartialViewResult GridView()
        {
            var notes = _noteService.GetAll();
            return PartialView("_gridView", notes);
        }

        public ActionResult WeekView()
        {
            var weeklyView = _noteService.GetInitialWeekView();
            return View(weeklyView);
        }

        public PartialViewResult GetNextDay(string baseDate)
        {

            DateTime dt;

            if (DateTime.TryParse(baseDate, out dt))
            {
                var nextDay = _noteService.NextDay(dt);
                return PartialView("_dayColumn", nextDay);
            }
            else
            {
                return PartialView("_Error", "The value passed in date isn't a date value.");
            }


        }

    }
}
