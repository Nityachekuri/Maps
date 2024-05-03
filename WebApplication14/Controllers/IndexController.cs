using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication14.Controllers
{
    public class IndexController : Controller
    {
        private DirectionEntities db = new DirectionEntities();

       
        [HttpPost]
        public ActionResult SaveDistanceDuration(string name, string origin, string destination, string distance, string duration)
        {
            try
            {
            
                Destination newDestination = new Destination
                {
                    Name = name, 
                    Source = origin,
                    Destination1 = destination,
                    Distance = distance,
                    Duration = duration
                };

                db.Destinations.Add(newDestination);
                db.SaveChanges();

                return Json(new { success = true, message = "Distance and duration saved successfully." });
            }
            catch (Exception ex)
            {

                return Json(new { success = false, message = "Failed to save distance and duration: " + ex.Message });
            }
        }

        // GET: Index
        public ActionResult Index()

        {

            return View();
        }
    }
}