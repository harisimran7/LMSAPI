using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LMSData.Model;

namespace LMSData
{
    public interface IRepository<T> : IDisposable where T : EntityBase
    {
        IQueryable<T> Table { get; }

        /// <summary>
        /// Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
        /// </summary>
        IQueryable<T> TableNoTracking { get; }

        Task<T> Get(int ID);
        Task<IEnumerable<T>> Get();

        Task Insert(T entity);
        //void Delete(int ID);
        Task Delete(T entity);
        Task Delete(IEnumerable<T> entities);
        Task Update(T entity);
        Task<int> Save();
        
    }
}
