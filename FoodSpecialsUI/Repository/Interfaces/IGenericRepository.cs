using FoodSpecialsUI.Repository;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Web;

namespace FoodSpecialsUI.Repository
{
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// Get all rows of the object
        /// </summary>
        /// <returns>Iqueryable of all objects</returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// Get the object by id
        /// </summary>
        /// <param name="id">Id of the object</param>
        /// <returns>An object</returns>
        T GetByID(object id);

        /// <summary>
        /// Insert object into database
        /// </summary>
        /// <param name="entity">the object to insert</param>
        void Insert(T entity);

        /// <summary>
        /// Delete the object from the database
        /// </summary>
        /// <param name="id">Id of the object to delete</param>
        void Delete(int id);

        /// <summary>
        /// Update the object in the database
        /// </summary>
        /// <param name="entity">The object to update</param>
        void Update(T entity);
    }
}