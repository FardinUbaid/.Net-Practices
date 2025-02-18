using EMS.DTOs;
using EMS.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EMS.Controllers
{
    public class ParticipantController : Controller
    {
        EMSEntities db = new EMSEntities();

        public static Participant Convert(ParticipantDTO ev)
        {
            return new Participant()
            {
                PId = ev.PId,
                Name = ev.Name,
                Contact = ev.Contact,
                EventId = ev.PId
            };
        }
        public static ParticipantDTO Convert(Participant ev)
        {
            return new ParticipantDTO()
            {
                PId = ev.PId,
                Name = ev.Name,
                Contact = ev.Contact,
                EventId = ev.PId
            };
        }
        public List<ParticipantDTO> Convert(List<Participant> ev)
        {
            var list = new List<ParticipantDTO>();
            foreach (var e in ev)
            {
                list.Add(Convert(e));
            }
            return list;
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View(new ParticipantDTO());
        }
        [HttpPost]
        public ActionResult Create(ParticipantDTO dto)
        {

            if (ModelState.IsValid)
            {

                var data = Convert(dto);
                db.Participants.Add(data);
                db.SaveChanges();

                return RedirectToAction("List");
            }
            return View(dto);

        }
        public ActionResult List()
        {
            var data = db.Participants.ToList();

            return View(Convert(data));
        }
        [HttpGet]
        public ActionResult Update(int PId)
        {
            var data = db.Participants.Find(PId);
            if (data == null)
            {
                return HttpNotFound();
            }
            var e = Convert(data);
            return View(e);
        }
        [HttpPost]
        public ActionResult Update(ParticipantDTO ev)
        {
            if (ModelState.IsValid)
            {

                var data = db.Participants.Find(ev.PId);

                if (data == null)
                {
                    TempData["Msg"] = "Event Not Found!";
                    return RedirectToAction("Update");
                }
                data.EventId = ev.PId;
                data.Name = ev.Name;
                data.Contact = ev.Contact;

                db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(ev);
        }
        [HttpGet]
        public ActionResult Delete(int Pid)
        {

            var data = db.Participants.Find(Pid);
            if (data == null)
            {
                return HttpNotFound();
            }
            return View(data);
        }
        [HttpPost]
        public ActionResult Delete(int PId, string dec)
        {
            if (dec.Equals("Yes"))
            {
                var data = db.Participants.Find(PId);
                if (data != null)
                {
                    db.Participants.Remove(data);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("List");
        }
        public ActionResult SearchByEvent(int eventId)
        {
            
            var participants = db.Participants
                                 .Where(p => p.EventId == eventId)
                                 .ToList();

            
            var participantDTOs = Convert(participants);

            
            if (!participantDTOs.Any())
            {
                TempData["Msg"] = "No participants found for the specified event.";
            }

            return View(participantDTOs);
        }

    }
}