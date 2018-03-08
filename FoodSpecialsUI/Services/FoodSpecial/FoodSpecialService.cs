using System;
using System.Linq;
using FoodSpecialsUI.Models;
using FoodSpecialsUI.Repository;
using System.Collections.Generic;

namespace FoodSpecialsUI.Services
{
    public class FoodSpecialService : IFoodSpecialService
    {
        #region Constructor
        private Lazy<IFoodSpecialRepository> lazyFoodSpecialRepository;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="lazyFoodSpecialRepository"></param>
        public FoodSpecialService(
            Lazy<IFoodSpecialRepository> lazyFoodSpecialRepository)
        {
            this.lazyFoodSpecialRepository = lazyFoodSpecialRepository;
        }
        #endregion

        public void Insert(FoodSpecial foodSpecial)
        {
            lazyFoodSpecialRepository.Value.Insert(foodSpecial);
        }

        public IEnumerable<FoodSpecial> GetFoodSpecialsForRestaurant(string restaurantId)
        {
            return lazyFoodSpecialRepository.Value.GetAll().Where(x => x.RestaurantId == restaurantId);
        }

        public void Delete(int id)
        {
            lazyFoodSpecialRepository.Value.Delete(id);
        }

        public void Update(FoodSpecial foodSpecial)
        {
            lazyFoodSpecialRepository.Value.Update(foodSpecial);
        }

        #region Public Methods



        #region UI Code
        /////<inheritdoc>
        //public IQueryable<FoodSpecialViewModel> MakeIndexViewModel()
        //{
        //    return lazyFoodSpecialRepository.Value.GetAll()
        //        .Select(x => MakeFoodSpecialViewModel(x));
        //}

        /////<inheritdoc>
        //public void InsertFoodSpecial(FoodSpecialViewModel foodSpecialViewModel)
        //{
        //    var foodSpecial = MakeFoodSpecialFromViewModel(foodSpecialViewModel);
        //    lazyFoodSpecialRepository.Value.Insert(foodSpecial);
        //}

        /////<inheritdoc>
        //public DailyFoodSpecialViewModel MakeUpdateFoodSpecialViewModel(int id)
        //{
        //    var dailyFoodSpecial = lazyFoodSpecialRepository.Value.GetByID(id);
        //    return MakeDailyFoodSpecialViewModelFromDailyFoodSpecial(dailyFoodSpecial);
        //}

        /////<inheritdoc>
        //public void UpdateDailyFoodSpecial(DailyFoodSpecialViewModel dailyFoodSpecialViewModel)
        //{
        //    var dailyFoodSpecial = MakeDailyFoodSpecialFromViewModel(dailyFoodSpecialViewModel);
        //    lazyFoodSpecialRepository.Value.Update(dailyFoodSpecial);
        //}

        /////<inheritdoc>
        //public DeleteModalViewModel MakeDeleteDailyFoodSpecialModalViewModel(int id)
        //{
        //    return new DeleteModalViewModel
        //    {
        //        BackgroundColor = "bg-danger",
        //        Title = Utils.GetStringValue("DeleteText") + " \"" + lazyDailyFoodSpecialRepository.Value.GetByID(id).Title + "\"",
        //        Body = Utils.GetStringValue("DeleteFoodSpecialText"),
        //        ButtonText = Utils.GetStringValue("DeleteText"),
        //        DeleteUrl = "/FoodSpecials/DeleteConfirmed?entityId=" + id
        //    };
        //}

        /////<inheritdoc>
        //public void DeleteDailyFoodSpecial(int id)
        //{
        //    lazyDailyFoodSpecialRepository.Value.Delete(id);
        //}

        ///////<inheritdoc>
        ////public JsonResult GetRestaurantNamesJson(string partialName)
        ////{
        ////    return new JsonResult
        ////    {
        ////        Data = lazyRestaurantRepository.Value.GetRestaurantsByPartialName(partialName)
        ////            .Select(x => new Autocomplete
        ////            {
        ////                //Id = x.RestaurantId,
        ////                //Name = x.RestaurantName + ", " + x.City + " " + x.State
        ////            }).ToList(),
        ////        JsonRequestBehavior = JsonRequestBehavior.AllowGet
        ////    };
        ////}

        /////<inheritdoc>
        //public IQueryable<DailyFoodSpecial> GetDailyFoodSpecialsForRestaurant(int id)
        //{
        //    return lazyDailyFoodSpecialRepository.Value.GetDailyFoodSpecialsForRestaurant(id);
        //}
        //#endregion 
        #endregion
        #endregion

        #region Private Methods

        #region UI Code
        /// <summary>
        /// Make the daily food special from the view model
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        //private DailyFoodSpecial MakeDailyFoodSpecialFromViewModel(DailyFoodSpecialViewModel viewModel)
        //{
        //    return new DailyFoodSpecial
        //    {
        //        SpecialId = viewModel.SpecialId,
        //        Title = viewModel.Title,
        //        Description = viewModel.Description,
        //        StartTime = Utils.ConvertStringToTimespan(viewModel.StartTime),
        //        EndTime = Utils.ConvertStringToTimespan(viewModel.EndTime),
        //        SundayActive = viewModel.SundayActive,
        //        MondayActive = viewModel.MondayActive,
        //        TuesdayActive = viewModel.TuesdayActive,
        //        WednesdayActive = viewModel.WednesdayActive,
        //        ThursdayActive = viewModel.ThursdayActive,
        //        FridayActive = viewModel.FridayActive,
        //        SaturdayActive = viewModel.SaturdayActive,
        //        RestaurantId = viewModel.RestaurantId
        //    };
        //}

        ///// <summary>
        ///// Make the view model from the daily food special
        ///// </summary>
        ///// <param name="dailyFoodSpecial"></param>
        ///// <returns></returns>
        //private DailyFoodSpecialViewModel MakeDailyFoodSpecialViewModelFromDailyFoodSpecial(DailyFoodSpecial dailyFoodSpecial)
        //{
        //    return new DailyFoodSpecialViewModel
        //    {
        //        SpecialId = dailyFoodSpecial.SpecialId,
        //        Title = dailyFoodSpecial.Title,
        //        Description = dailyFoodSpecial.Description,
        //        StartTime = Utils.ConvertTimespanToString(dailyFoodSpecial.StartTime),
        //        EndTime = Utils.ConvertTimespanToString(dailyFoodSpecial.EndTime),
        //        SundayActive = dailyFoodSpecial.SaturdayActive,
        //        MondayActive = dailyFoodSpecial.MondayActive,
        //        TuesdayActive = dailyFoodSpecial.TuesdayActive,
        //        WednesdayActive = dailyFoodSpecial.WednesdayActive,
        //        ThursdayActive = dailyFoodSpecial.ThursdayActive,
        //        FridayActive = dailyFoodSpecial.FridayActive,
        //        SaturdayActive = dailyFoodSpecial.SaturdayActive,
        //        RestaurantId = dailyFoodSpecial.RestaurantId,
        //        //RestaurantName = dailyFoodSpecial.Restaurant.RestaurantName
        //    };
        //}
        #endregion
        #endregion
    }
}
