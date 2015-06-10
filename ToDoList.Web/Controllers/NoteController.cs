using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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

            return View();

        }

    }
}
