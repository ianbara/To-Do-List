using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using ToDoList.Data;
using ToDoList.Data.Models;
using ToDoList.Service;

namespace ToDoList.Web.Controllers
{
    public class BoardController : Controller
    {
        private IBoardService _service;


        public BoardController(IBoardService service)
        {
            _service = service;
        }


        public ActionResult Index()
        {
            ViewBag.PageTitle = "Boards";

            var boards = _service.GetAll();
            return View(boards);
        }

        public ActionResult BoardList(int id)
        {
            var boards = _service.GetByID(id);
            return View(boards);
        }



        public ActionResult Create()
        {
            return View(new Board());
        }

        [HttpPost]
        public ActionResult Create(Board board)
        {
            _service.Create(board);

            return RedirectToAction("Index");

        }

        public ActionResult Edit(int board)
        {
            var model = _service.GetByID(board);

            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(Board model)
        {
            _service.Update(model);

            return RedirectToAction("Index");
        }

       
        public ActionResult Delete(int id)
        {
            _service.DeleteByID(id);

            return RedirectToAction("Index");
        }



    }
}
