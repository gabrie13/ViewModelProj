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
    public class EmployeePositionController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        private readonly IPersonPositionService _ppService = new PersonPositionService();
        private readonly IPositionService _positionService = new PositionService();
        private readonly IPersonService _personService = new PersonService();


        // GET: EmployeePosition
        public ActionResult Index()
        {
            var personPositions = db.PersonPositions.Include(p => p.Position);
            var personList = _personService.GetAll();
            var positionList = _positionService.GetAll();
            return View(_ppService.GetAll());
        }

        // GET: EmployeePosition/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonPositionViewModel personPosition = _ppService.FindById(id.Value);
            PositionViewModel position = _positionService.FindById(id.Value);
            PersonViewModel person = _personService.FindById(id.Value);
            if (personPosition == null)
            {
                return HttpNotFound();
            }
            return View(personPosition);
        }

        // GET: EmployeePosition/Create
        public ActionResult Create()
        {
            ViewBag.PositionId = new SelectList(db.Positions, "PositionId", "Title");
            return View();
        }

        // POST: EmployeePosition/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PersonPositionId,PositionId,FirstName,LastName,Phone")] PersonPosition personPosition)
        {
            if (ModelState.IsValid)
            {
                db.PersonPositions.Add(personPosition);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PositionId = new SelectList(db.Positions, "PositionId", "Title", personPosition.PositionId);
            return View(personPosition);
        }

        // GET: EmployeePosition/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonPosition personPosition = db.PersonPositions.Find(id);
            if (personPosition == null)
            {
                return HttpNotFound();
            }
            ViewBag.PositionId = new SelectList(db.Positions, "PositionId", "Title", personPosition.PositionId);
            return View(personPosition);
        }

        // POST: EmployeePosition/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PersonPositionId,PositionId,FirstName,LastName,Phone")] PersonPosition personPosition)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personPosition).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PositionId = new SelectList(db.Positions, "PositionId", "Title", personPosition.PositionId);
            return View(personPosition);
        }

        // GET: EmployeePosition/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PersonPosition personPosition = db.PersonPositions.Find(id);
            if (personPosition == null)
            {
                return HttpNotFound();
            }
            return View(personPosition);
        }

        // POST: EmployeePosition/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PersonPosition personPosition = db.PersonPositions.Find(id);
            db.PersonPositions.Remove(personPosition);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
