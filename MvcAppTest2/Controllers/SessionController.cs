using MvcAppTest2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcAppTest2.Controllers
{
    ///[Authorize()]
    public class SessionController : Controller
    {
        
        public ActionResult Details(Int32 id)
        {
            ConferenceContext context = new ConferenceContext();
            List<Session> sesions = context.Sessions.Where(s => s.SessionId == id).ToList();
            return View(sesions[0]);
        }
        // GET: Session
        public ActionResult Index()
        {
            ConferenceContext context = new ConferenceContext();
            List<Session> sesions = context.Sessions.ToList();
            return View(sesions);
        }

        public ActionResult Create()
        {
            return View();
        }

        //POST: Session/Create
        [HttpPost()]
        public ActionResult Create(Session session)
        {
            if (!ModelState.IsValid)
            {
                return View(session);
            }

            try
            {
                ConferenceContext context = new ConferenceContext();
                context.Sessions.Add(session);
                context.SaveChanges();
            }
            catch (Exception er)
            {
                ModelState.AddModelError("Error", er.Message);
                return View(session);
            }
           

            TempData["Message"] = "Created" + session.Title;
            return RedirectToAction("Index");
        }
    }
}