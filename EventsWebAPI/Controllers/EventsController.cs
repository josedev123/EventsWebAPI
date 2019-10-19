using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventsWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventsWebAPI.Controllers
{
    public class EventsController : Controller
    {
        private readonly ApplicationDbContext context;

        public EventsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET: Event
        public ActionResult Index()
        {
            var locationEvents = context.Events.ToList();

            return Json(locationEvents);
        }

        // GET: Event/Details/5
        public ActionResult Details(int id)
        {
            var locationEvent = context.Events.Include("Location").SingleOrDefault(e => e.Id == id);

            return Json(locationEvent);
        }

        // GET: Event/Create
        public ActionResult Create()
        {
            return Ok();
        }

        // POST: Event/Create
        [HttpPost]
        public ActionResult Create([FromBody] Event newEvent)
        {
            var locationEvent = new Event();

            locationEvent.Name = newEvent.Name;
            locationEvent.Description = newEvent.Description;
            locationEvent.Free = newEvent.Free;
            locationEvent.LocationId = newEvent.LocationId;
            locationEvent.Date = newEvent.Date;

            context.Events.Add(locationEvent);
            context.SaveChanges();

            int eId = locationEvent.Id;

            return Ok(locationEvent);
        }

        // GET: Event/Edit/5
        public ActionResult Edit(int id)
        {
            Event locationEventInDb = context.Events.SingleOrDefault(e => e.Id == id);

            return Ok(locationEventInDb);
        }

        // POST: Event/Edit/5
        [HttpPost]
        public ActionResult Edit([FromBody] Event locationEvent)
        {
            Event locationEventInDb = context.Events.SingleOrDefault(e => e.Id == locationEvent.Id);

            locationEventInDb.Name = locationEvent.Name;
            locationEventInDb.Description = locationEvent.Description;
            locationEventInDb.Free = locationEvent.Free;
            locationEventInDb.LocationId = locationEvent.LocationId;
            locationEventInDb.Date = locationEvent.Date;

            context.SaveChanges();

            return Ok(locationEvent);
        }

        // POST: Events/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var locationEvent = context.Events.SingleOrDefault(e => e.Id == id);
            var message = "Deleted " + locationEvent.Name;
            context.Remove(locationEvent);
            return Ok(message);
        }

    }
}