using System;
using System.Collections.Generic;
using System.Linq;
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


        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }


        public ActionResult Index()
        {
            var notes = _noteService.GetAll();
            return View(notes);
        }

        public ActionResult Create()
        {
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
            return View();
        }

    }
}
