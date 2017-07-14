using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace TicketTrackerRepo
{
    /// <summary>
    /// Defines the IGenericDataRepository type.
    /// </summary>
    /// <typeparam name="T">The parent type.</typeparam>
    /// <typeparam name="TU">The child type.</typeparam>
    public interface ITicketTrackerRepo<T, TU>
        where T : class where TU : class
    {
        /// <summary>
        /// Gets a list of all records in a table.
        /// </summary>
        /// <param name="navigationProperties">Any associated tables to bring back.</param>
        /// <returns>A list off all records of the instantied type.</returns>
        IList<TU> GetAll(params Expression<Func<T, object>>[] navigationProperties);

        /// <summary>
        /// Gets a list of records in a table based on filter.
        /// </summary>
        /// <param name="where">The filtering expression.</param>
        /// <param name="navigationProperties">The associated tales to bring back.</param>
        /// <returns>A list of the filtered records of the instantiated type.</returns>
        IList<TU> GetList(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties);

        /// <summary>
        /// Gets a single record in a table.
        /// </summary>
        /// <param name="where">The filter to isolate the desired record.</param>
        /// <param name="navigationProperties">The associated tables to bring back.</param>
        /// <returns>A singleton of the instantiated type.</returns>
        TU GetSingle(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties);

        /// <summary>
        /// Adds item(s) to the instantiated entity type (table)
        /// </summary>
        /// <param name="items">Array of instantiated entities to add.</param>
        void Add(params TU[] items);

        /// <summary>
        /// Updates an item(s) in the instantiated entity type (table)
        /// </summary>
        /// <param name="items">Array of instantiated entities to add.</param>
        void Update(params TU[] items);

        /// <summary>
        /// Removes item(s) from the instantiated entity type (table)
        /// </summary>
        /// <param name="items">Array of instantiated entities to remove.</param>
        void Remove(params TU[] items);

        /// <summary>
        /// Adds item(s) to the instantiated entity type (table) and returns them back with the created identity fields.
        /// </summary>
        /// <param name="items">Array of instantiated entities to add.</param>
        /// <returns>List of the instantiated entities with created identity fields.</returns>
        IList<TU> AddWithReturnId(params TU[] items);
    }
}
