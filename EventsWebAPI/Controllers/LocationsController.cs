using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventsWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventsWebAPI.Controllers
{
    public class LocationsController : Controller
    {
        private readonly ApplicationDbContext context;
        public LocationsController(ApplicationDbContext context)
        {
            this.context = context;
        }

        // GET: Locations
        public IActionResult Index()
        {
            var locations = context.Locations.ToList();

            return Json(locations);
        }

        // GET: Location/Details/5
        public ActionResult Details(int id)
        {
            var location = context.Locations.SingleOrDefault(e => e.Id == id);

            return Json(location);
        }

        // GET: Location/Create
        public ActionResult Create()
        {
            return Ok();
        }

        // POST: Location/Create
        [HttpPost]
        public ActionResult Create([FromBody] Location location)
        {
            context.Locations.Add(location);
            context.SaveChanges();

            return Ok(location);
        }

        // GET: Location/Edit/5
        public ActionResult Edit(int id)
        {
            Location locationInDb = context.Locations.SingleOrDefault(e => e.Id == id);

            return Ok(locationInDb);
        }

        // POST: Location/Edit/5
        [HttpPost]
        public ActionResult Edit([FromBody] Location location)
        {
            Location locationInDb = context.Locations.SingleOrDefault(e => e.Id == location.Id);
            locationInDb.Name = location.Name;
            locationInDb.Description = location.Description;

            context.SaveChanges();

            return Ok(location);
        }

        // POST: Location/Delete/5
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var location = context.Locations.SingleOrDefault(e => e.Id == id);
            var message = "Deleted " + location.Name;
            context.Remove(location);
            return Ok(message);
        }
    }
}