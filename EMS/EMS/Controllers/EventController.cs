using EMS.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Web;
using System.Web.Mvc;
using EMS.DTOs;

namespace EMS.Controllers
{
    public class EventController : Controller
    {
        EMSEntities db = new EMSEntities();

        public static Event Convert(EventDTO ev)
        {
            return new Event()
            {
                EventId = ev.EventId,
                Name = ev.Name,
                Date = ev.Date,
                Venue = ev.Venue,
                Description = ev.Description,
            };
        }
        public static EventDTO Convert(Event ev)
        {
            return new EventDTO()
            {
                EventId = ev.EventId,
                Name = ev.Name,
                Date = ev.Date,
                Venue = ev.Venue, 
                Description = ev.Description
            };
        }
        public List<EventDTO> Convert(List<Event> ev)
        {
            var list = new List<EventDTO>();
            foreach (var e in ev)
            {
                list.Add(Convert(e));
            }
            return list;
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View(new EventDTO());
        }
        [HttpPost]
        public ActionResult Create(EventDTO dto) {
            
            if (ModelState.IsValid)
            {

                var data = Convert(dto);
                db.Events.Add(data);
                db.SaveChanges();

                return RedirectToAction("List");
            }
            return View(dto);
        
        }
        public ActionResult List()
        {
            var data = db.Events.ToList();

            return View(Convert(data));
        }
        [HttpGet]
        public ActionResult Update(int EventId)
        {
            var data = db.Events.Find(EventId);
            if (data == null)
            {
                return HttpNotFound();
            }
            var e = Convert(data);
            return View(e);
        }
        [HttpPost]
        public ActionResult Update(EventDTO ev)
        {
            if (ModelState.IsValid)
            {

                var data = db.Events.Find(ev.EventId);

                if (data == null)
                {
                    TempData["Msg"] = "Event Not Found!";
                    return RedirectToAction("Update");
                }
                data.EventId = ev.EventId;
                data.Name = ev.Name;
                data.Venue = ev.Venue;
                data.Description = ev.Description;

                db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(ev);
        }
        [HttpGet]
        public ActionResult Delete(int EventId)
        {

            var data = db.Events.Find(EventId);
            if (data == null)
            {
                return HttpNotFound();
            }
            return View(data);
        }
        [HttpPost]
        public ActionResult Delete(int EventId, string dec)
        {
            if (dec.Equals("Yes"))
            {
                var data = db.Events.Find(EventId);
                if (data != null)
                {
                    db.Events.Remove(data);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("List");
        }
    }
}