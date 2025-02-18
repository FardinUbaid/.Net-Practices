using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Web;
using System.Web.Mvc;
using TRP.DTO;
using TRP.EF;
using TRP.Auth;

namespace TRP.Controllers
{
    [Logged]
    public class ChannelsController : Controller
    {
        TRPEntities db = new TRPEntities();

        public static Channel Convert(ChannelDTO channel)
        {
            return new Channel()
            {   
                ChannelId = channel.ChannelId,
                ChannelName = channel.ChannelName,
                EstablishedYear = channel.EstablishedYear,
                Country = channel.Country
            };
        }
        public static ChannelDTO Convert(Channel channel)
        {
            return new ChannelDTO()
            {
                ChannelId = channel.ChannelId,
                ChannelName = channel.ChannelName,
                EstablishedYear = channel.EstablishedYear,
                Country = channel.Country
            };
        }
        public List<ChannelDTO> Convert(List<Channel> channels)
        {
            var list = new List<ChannelDTO>();
            foreach (var channel in channels)
            {
                list.Add(Convert(channel));
            }
            return list;
        }
        [HttpGet]
        public ActionResult Create() {
            
            return View(new ChannelDTO());
        
        }
        [HttpPost]
        public ActionResult Create(ChannelDTO channelDTO) {
            
            if (ModelState.IsValid) {
                
                var data = Convert(channelDTO);
                db.Channels.Add(data);
                db.SaveChanges();

                return RedirectToAction("List");
            }
            return View(channelDTO);
        }
        [AllowAnonymous]
        public ActionResult List() { 

            var data = db.Channels.ToList();

            return View(Convert(data));
        }
        [HttpGet]
        public ActionResult Update(int ChannelId) {

            var data = db.Channels.Find(ChannelId);
            if (data == null) {
                return HttpNotFound();
            }
            var channel = Convert(data);
            return View(channel);
        }
        [HttpPost]
        public ActionResult Update(ChannelDTO channelDTO) {
            if (ModelState.IsValid) { 

                var data = db.Channels.Find(channelDTO.ChannelId);

                if (data == null) {
                    TempData["Msg"] = "User Not Found!";
                    return RedirectToAction("Update");
                }
                data.ChannelId = channelDTO.ChannelId;
                data.ChannelName = channelDTO.ChannelName;
                data.EstablishedYear = channelDTO.EstablishedYear;
                data.Country = channelDTO.Country;

                db.SaveChanges();
                return RedirectToAction("List");
            }
            return View(channelDTO);
        }
        [HttpGet]
        public ActionResult Delete(int ChannelId) {

            var data = db.Channels.Find(ChannelId);
            if (data == null) {
                return HttpNotFound();
            }
            return View(data);
        }
        [HttpPost]
        public ActionResult Delete(int ChannelId,string dec)
        {
            if (dec.Equals("Yes"))
            {
                var data = db.Channels.Find(ChannelId);
                if (data != null) { 
                    db.Channels.Remove(data);
                    db.SaveChanges();
                }
            }
            return RedirectToAction("List");
        }
    }


}