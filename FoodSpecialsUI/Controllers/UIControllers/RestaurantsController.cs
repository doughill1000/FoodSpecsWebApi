using System;
using System.Web.Mvc;
using FoodSpecialsUI.Services;
using FoodSpecialsUI.Constants;
using System.Data.Entity.Validation;

namespace FoodSpecialsUI.Controllers
{
    [Authorize(Roles = AuthConstants.Admin)]
    public class RestaurantsController : Controller
    {
        private Lazy<IRestaurantService> lazyRestaurantService;

        public RestaurantsController(Lazy<IRestaurantService> lazyRestaurantService)
        {
            this.lazyRestaurantService = lazyRestaurantService;
        }

        [HttpPost]
        public ActionResult AddRestaurant(string id)
        {
            try
            {
                lazyRestaurantService.Value.AddRestaurant(id);
                return Json(new { success = true });
            }
            catch (DbEntityValidationException ex)
            {
                return Json(new { success = false });
            }
        }

        //public ActionResult Index()
        //{
        //    //return View(lazyRestaurantService.Value.MakeIndexViewModel());
        //}

        //// GET: Restaurants/Create
        //public ActionResult Create()
        //{
        //    return View(new RestaurantViewModel());
        //}

        //// POST: Restaurants/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(RestaurantViewModel viewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        lazyRestaurantService.Value.CreateRestaurant(viewModel);
        //        return RedirectToAction("Index");
        //    }

        //    return View(new RestaurantViewModel());
        //}

        //// GET: Restaurants/Edit/5
        //public ActionResult Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    var viewModel = lazyRestaurantService.Value.MakeUpdateRestaurantViewModel(id.Value);

        //    return View(viewModel);
        //}

        //// POST: Restaurants/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public JsonResult Edit(RestaurantViewModel viewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //       lazyRestaurantService.Value.UpdateRestaurant(viewModel);
        //    }
        //    return new JsonResult();
        //}

        // GET: Restaurants/Delete/5
        public PartialViewResult Delete(int id)
        {
            var viewModel = lazyRestaurantService.Value.MakeDeleteRestaurantModalViewModel(id);
            return PartialView("_Delete", viewModel);
        }

        // POST: Restaurants/Delete/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public JsonResult DeleteConfirmed(int entityId)
        {
            lazyRestaurantService.Value.DeleteRestaurant(entityId);
            return new JsonResult();
        }

        /// <summary>
        /// Returns view to add restaurants.
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            return View("Add");
        }

        /// <summary>
        /// Searches Yelp Api for restaurants.
        /// </summary>
        /// <param name="term">term to search by</param>
        /// <param name="location">location to search</param>
        /// <returns>Returns Json result with list of restaurants.</returns>
        public JsonResult SearchRestaurants(string term, string location)
        {
            return new JsonResult
            {
                Data = new { Restaurants = lazyRestaurantService.Value.SearchRestaurants(term, location) },
                JsonRequestBehavior = JsonRequestBehavior.AllowGet
            };
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
