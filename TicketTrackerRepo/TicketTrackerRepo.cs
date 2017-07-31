using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace TicketTrackerRepo
{
    /// <summary>
    /// Concrete Repository that binds to interface for basic database requests
    /// </summary>
    /// <typeparam name="T">
    /// Domain Entity applied
    /// </typeparam>
    /// <typeparam name="TU">
    /// The child type
    /// </typeparam>
    public class TicketTrackerRepo<T, TU> : ITicketTrackerRepo<T, TU>
        where T : class, new()
        where TU : class, new()
    {
        /// <summary>
        /// Understand here that we want different values for this static field
        /// ReSharper disable once StaticFieldInGenericType
        /// </summary>
        internal static Type _TypeToLoad;

        /// <summary>
        /// Initializes a new instance of the <see cref="{T,TU}" /> class
        /// </summary>
        public TicketTrackerRepo()
        {
            var type = typeof(T);
            var assembly = Assembly.Load(type.Namespace);
            var namespaceToLoad = string.Format("{0}.{1}", type.Namespace, type.Namespace.Replace("EntityModel", "Entities"));
            _TypeToLoad = assembly.GetType(namespaceToLoad);

            if (!MappingConfiguration.MapsComplete)
            {
                MappingConfiguration.CreateMaps();
                MappingConfiguration.MapsComplete = true;
            }
        }

        /// <summary>
        /// Returns all records for Entity
        /// </summary>
        /// <param name="navigationProperties">Related entities to include</param>
        /// <returns>Enumerable list of entity records</returns>
        public virtual IList<TU> GetAll(params Expression<Func<T, object>>[] navigationProperties)
        {
            using (var transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
            {
                using (var context = BuildDatabaseContext())
                {
                    IQueryable<T> dbQuery = context.Set<T>();
#if DEBUG
                    context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
#endif
                    //Apply eager loading
                    dbQuery = navigationProperties.Aggregate(dbQuery,
                        (current, navigationProperty) => current.Include(navigationProperty));

                    var list = dbQuery
                        .AsNoTracking()
                        .ToList();

                    var dtos = list.Select(Mapper.Map<T, TU>).ToList();

                    transaction.Complete();

                    return dtos;
                }
            }
        }

        /// <summary>
        /// Gets a list of a type defined as <see cref="TU"/>
        /// </summary>
        /// <param name="where">The filtering logic for the query</param>
        /// <param name="navigationProperties">The associated tables to include</param>
        /// <returns>A list of the type that was instantiated</returns>
        public virtual IList<TU> GetList(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            using (var transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
            {
                using (var context = BuildDatabaseContext())
                {
                    IQueryable<T> dbQuery = context.Set<T>();

                    //Apply eager loading
                    dbQuery = navigationProperties.Aggregate(dbQuery,
                        (current, navigationProperty) => current.Include(navigationProperty));

                    var list = dbQuery
                        .AsNoTracking()
                        .Where(@where)
                        .ToList();

                    var dtos = list.Select(Mapper.Map<T, TU>).ToList();

                    transaction.Complete();

                    return dtos;
                }
            }
        }

        /// <summary>
        /// Gets a single record of a type defined as <see cref="TU"/>
        /// </summary>
        /// <param name="where">Filtering criteria</param>
        /// <param name="navigationProperties">List of associations to include</param>
        /// <returns>A single record of type <see cref="T"/></returns>
        public virtual TU GetSingle(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties)
        {
            using (var transaction = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions { IsolationLevel = IsolationLevel.ReadUncommitted }))
            {
                using (var context = BuildDatabaseContext())
                {
                    IQueryable<T> dbQuery = context.Set<T>();
#if DEBUG
                    context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
#endif
                    //Apply eager loading
                    dbQuery = navigationProperties.Aggregate(dbQuery,
                        (current, navigationProperty) => current.Include(navigationProperty));

                    T item = dbQuery
                        .AsNoTracking() //Don't track any changes for the selected item
                        .FirstOrDefault(@where);

                    if (item == null)
                    {
                        return null;
                    }

                    var dto = Mapper.Map<T, TU>(item);

                    transaction.Complete();

                    return dto;
                }
            }
        }

        /// <summary>
        /// Persists N number of DTOs of any type to database
        /// </summary>
        /// <param name="items">Params array of DTOs</param>
        public virtual void Add(params TU[] items)
        {

            using (var context = BuildDatabaseContext())
            {
                foreach (var mapped in items.Select(Mapper.Map<TU, T>))
                {
                    context.Entry(mapped).State = EntityState.Added;
                }

                try
                {
                    context.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);
                    var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", string.Join("; ", errorMessages));
                    throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                }
                catch (DbUpdateException ex)
                {
                    var entityName = ex.Entries.First().Entity.ToString();
                    var exceptionMessage = string.Empty;
                    if (ex.InnerException != null && ex.InnerException.InnerException != null)
                    {
                        // Should give you the entity name as well as the exception message
                        exceptionMessage = string.Format("Entity {0} - {1}", entityName, ex.InnerException.InnerException.Message);
                    }
                    throw new DbUpdateException(exceptionMessage, ex.InnerException);
                }
                catch (Exception ex)
                {
                    //ErrorLoggingHelper.LogError(ex);
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Persists updates of N number of DTOs of any type to database
        /// </summary>
        /// <param name="items">Params array of DTOs</param>
        public virtual void Update(params TU[] items)
        {
            using (var context = BuildDatabaseContext())
            {
                foreach (var mapped in items.Select(Mapper.Map<TU, T>))
                {
                    context.Entry(mapped).State = EntityState.Modified;
                }

                try
                {
                    context.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);
                    var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", string.Join("; ", errorMessages));
                    throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
                }
                catch (DbUpdateException ex)
                {
                    var entityName = ex.Entries.First().Entity.ToString();
                    var exceptionMessage = string.Empty;
                    if (ex.InnerException != null && ex.InnerException.InnerException != null)
                    {
                        // Should give you the entity name as well as the exception message
                        exceptionMessage = string.Format("Entity {0} - {1}", entityName, ex.InnerException.InnerException.Message);
                    }
                    throw new DbUpdateException(exceptionMessage, ex.InnerException);
                }
                catch (Exception ex)
                {
                    //ErrorLoggingHelper.LogError(ex);
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Updates selective fields in a DTO 
        /// </summary>
        /// <param name="where">Filtering condition</param>
        /// <param name="updateValue">Set of values to update</param>
        public virtual void UpdateFields(Expression<Func<T, bool>> where, Dictionary<object, object> updateValue)
        {
            using (var context = BuildDatabaseContext())
            {
                IQueryable<T> query = context.Set<T>();
#if DEBUG
                context.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
#endif
                // Gets the entity based on the filter condition
                T item = query
                    .AsNoTracking() //Don't track any changes for the selected item
                    .FirstOrDefault(@where);

                var dto = Mapper.Map<T, TU>(item);

                // updates the appropriate property with the required values
                foreach (var val in updateValue)
                {
                    var propInfo = typeof(TU).GetProperty(val.Key.ToString());
                    propInfo.SetValue(dto, val.Value);
                }

                //Maps the changed dto and saves the updates to database.
                Mapper.Map<TU, T>(dto, item);
                context.Entry<T>(item).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Removes N number of records of any DTO type from database
        /// </summary>
        /// <param name="items">Params array of DTOs</param>
        public virtual void Remove(params TU[] items)
        {
            using (var context = BuildDatabaseContext())
            {
                foreach (var mapped in items.Select(Mapper.Map<TU, T>))
                {
                    context.Entry(mapped).State = EntityState.Deleted;
                }

                context.SaveChanges();
            }
        }

        /// <summary>
        /// Gets a list of <see cref="TU"/> with Ids generated on identity columns
        /// </summary>
        /// <param name="items">Params array of DTOs to add</param>
        /// <returns>List of DTOs returned with identity field populated</returns>
        public virtual IList<TU> AddWithReturnId(params TU[] items)
        {
            using (var context = BuildDatabaseContext())
            {
                var returnDtoList = new List<TU>();

                foreach (var mapped in items.Select(Mapper.Map<TU, T>))
                {
                    context.Entry(mapped).State = EntityState.Added;
                    context.SaveChanges();
                    var dtoToAdd = Mapper.Map<T, TU>(mapped);
                    returnDtoList.Add(dtoToAdd);
                }

                return returnDtoList;
            }
        }

        /// <summary>
        /// Executes a stored procedure with optional <see cref="SqlParameter"/>s
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure to be executed</param>
        /// <param name="sqlParameters">A list of <see cref="SqlParameter"/>s to be passed to the stored procedure</param>
        /// <returns>An <see cref="IEnumerable"/> of the output parameters passed to the method</returns>
        public virtual IEnumerable<SqlParameter> ExecuteStoredProcedure(string storedProcedureName, List<SqlParameter> sqlParameters = null)
        {
            if (string.IsNullOrEmpty(storedProcedureName))
                throw new ArgumentNullException("storedProcedureName");

            StringBuilder executeSQLStatement = new StringBuilder();
            executeSQLStatement.Append("exec " + storedProcedureName);

            // If parameters were sent in, let's add to the exec statement
            int index = 1;
            if (sqlParameters != null || sqlParameters.Count > 0)
            {
                foreach (var item in sqlParameters)
                {
                    executeSQLStatement.Append(string.Format(" {0}{1}{2}",
                        item.ParameterName,
                        item.Direction == System.Data.ParameterDirection.Output ? " Output" : string.Empty,
                        index < sqlParameters.Count ? "," : string.Empty));
                    index++;
                }
            }

            using (var context = BuildDatabaseContext())
            {
                context.Database.ExecuteSqlCommand(executeSQLStatement.ToString(), sqlParameters.ToArray());
            }

            return sqlParameters.Where(s => s.Direction == System.Data.ParameterDirection.Output);
        }

        /// <summary>
        /// Dynamically instantiates a context type for the generic type model
        /// </summary>
        /// <returns>A <see cref="DbContext"/> of the proper model</returns>
        private static DbContext BuildDatabaseContext()
        {
            return (DbContext)Activator.CreateInstance(_TypeToLoad);
        }
    }
}
