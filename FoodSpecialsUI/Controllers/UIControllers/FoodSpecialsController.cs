using System;
using System.Web.Mvc;
using FoodSpecialsUI.Services;
using FoodSpecialsUI.ViewModels;
using FoodSpecialsUI.Constants;

namespace FoodSpecialsUI.Controllers
{
    [Authorize(Roles = AuthConstants.Admin)]
    public class FoodSpecialsController : Controller
    {
        //private Lazy<IDailyFoodSpecialService> lazyDailyFoodSpecialService;

        //public FoodSpecialsController(Lazy<IDailyFoodSpecialService> lazyDailyFoodSpecialService)
        //{
        //    this.lazyDailyFoodSpecialService = lazyDailyFoodSpecialService;
        //}

        //// GET: FoodSpecials
        //public ActionResult Index()
        //{
        //    return View(lazyDailyFoodSpecialService.Value.MakeIndexViewModel());
        //}

        //// GET: FoodSpecials/Create
        //public ActionResult Create()
        //{
        //    return View(new DailyFoodSpecialViewModel());
        //}

        //// POST: FoodSpecials/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(DailyFoodSpecialViewModel dailyFoodSpecialViewModel)
        //{
        //    lazyDailyFoodSpecialService.Value.InsertDailyFoodSpecial(dailyFoodSpecialViewModel);
        //    return RedirectToAction("Index");
        //}

        //// GET: FoodSpecials/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View(lazyDailyFoodSpecialService.Value.MakeUpdateDailyFoodSpecialViewModel(id));
        //}

        //// POST: FoodSpecials/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public JsonResult Edit(DailyFoodSpecialViewModel dailyFoodSpecialViewModel)
        //{
        //    lazyDailyFoodSpecialService.Value.UpdateDailyFoodSpecial(dailyFoodSpecialViewModel);
        //    return new JsonResult();
        //}

        //// GET: FoodSpecials/Delete/5
        //public PartialViewResult Delete(int id)
        //{
        //    var viewModel = lazyDailyFoodSpecialService.Value.MakeDeleteDailyFoodSpecialModalViewModel(id);
        //    return PartialView("_Delete", viewModel);
        //}

        //// POST: FoodSpecials/Delete/5
        //[HttpPost]
        //public JsonResult DeleteConfirmed(int entityId)
        //{
        //    lazyDailyFoodSpecialService.Value.DeleteDailyFoodSpecial(entityId);
        //    return new JsonResult();            
        //}

        //public ActionResult GetRestaurantNamesJson(string query)
        //{
        //    return lazyDailyFoodSpecialService.Value.GetRestaurantNamesJson(query);
        //}

        //public JsonResult GetRestaurantNames(string location, string term = null)
        //{
        //    return JsonConvert.SerializeObject(lazyFoodSpecialUIService.Value.GetRestaurantNames(location, term).ToList());
        //}
    }
}
