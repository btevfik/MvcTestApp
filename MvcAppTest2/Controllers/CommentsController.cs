using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcAppTest2.Models;

namespace MvcAppTest2.Controllers
{
    public class CommentsController : Controller
    {
        private ConferenceContext db = new ConferenceContext();

        public PartialViewResult _GetForSession(Int32 sessionID)
        {
            ViewBag.SessionID = sessionID;
            List<Comment> comments = db.Comments.Where(c => c.SessionID == sessionID).ToList();
            return PartialView("_GetForSession", comments);
        }

        public PartialViewResult _CommentForm(Int32 sessionID)
        {
            Comment comment = new Comment { SessionID = sessionID };
            return PartialView("_CommentForm", comment);
        }

        [ValidateAntiForgeryToken()]
        public PartialViewResult _Submit(Comment comment)
        {
            db.Comments.Add(comment);
            db.SaveChanges();
            List<Comment> comments = db.Comments.Where(c => c.SessionID == comment.SessionID).ToList();
            ViewBag.SessionID = comment.SessionID;
            return PartialView("_GetForSession", comments);
        }

        // GET: Comments
        public ActionResult Index()
        {
            var comments = db.Comments.Include(c => c.Session);
            return View(comments.ToList());
        }

        // GET: Comments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // GET: Comments/Create
        public ActionResult Create()
        {
            ViewBag.SessionID = new SelectList(db.Sessions, "SessionId", "Title");
            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CommentID,Content,SessionID")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Comments.Add(comment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SessionID = new SelectList(db.Sessions, "SessionId", "Title", comment.SessionID);
            return View(comment);
        }

        // GET: Comments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            ViewBag.SessionID = new SelectList(db.Sessions, "SessionId", "Title", comment.SessionID);
            return View(comment);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CommentID,Content,SessionID")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(comment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SessionID = new SelectList(db.Sessions, "SessionId", "Title", comment.SessionID);
            return View(comment);
        }

        // GET: Comments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Comment comment = db.Comments.Find(id);
            if (comment == null)
            {
                return HttpNotFound();
            }
            return View(comment);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Comment comment = db.Comments.Find(id);
            db.Comments.Remove(comment);
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
