using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ViewModelEx.Models;
using ViewModelEx.Services;

namespace ViewModelEx.Controllers
{
    public class PositionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private readonly IPositionService _positionService = new PositionService();


        // GET: Position
        public ActionResult Index()
        {
            return View(_positionService.GetAll());
        }

        // GET: Position/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PositionViewModel position = _positionService.FindById(id.Value);
            if (position == null)
            {
                return HttpNotFound();
            }
            return View(position);
        }

        // GET: Position/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Position/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PositionId,Title")] PositionViewModel position)
        {
            if (ModelState.IsValid)
            {
                _positionService.Create(position);
                return RedirectToAction("Index");
            }

            return View(position);
        }

        // GET: Position/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PositionViewModel position = _positionService.FindById(id.Value);
            if (position == null)
            {
                return HttpNotFound();
            }
            return View(position);
        }

        // POST: Position/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PositionId,Title")] PositionViewModel position)
        {
            if (ModelState.IsValid)
            {
                _positionService.Save(position);
                return RedirectToAction("Index");
            }
            return View(position);
        }

        // GET: Position/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PositionViewModel position = _positionService.FindById(id.Value);
            if (position == null)
            {
                return HttpNotFound();
            }
            return View(position);
        }

        // POST: Position/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _positionService.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _positionService.Dispose();  
            }
            base.Dispose(disposing);
        }
    }
}
