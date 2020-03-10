//using Hl7.Fhir.Model;
using LMSData.Helper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LMSData.Model;

namespace LMSData
{
    public class Repository<T> : IRepository<T> where T : EntityBase
    {
        
        private readonly ILMSDBContext _context;
        private DbSet<T> _entities;
        public virtual IQueryable<T> Table => Entities;
        public virtual IQueryable<T> TableNoTracking => Entities.AsNoTracking();

        protected virtual DbSet<T> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<T>();

                return _entities;
            }
        }

        
        public Repository(ILMSDBContext context)
        {
            this._context = context;
        }

        public virtual async Task<T> Get(int ID)
        {
            return await Entities.FindAsync(ID);
            //throw new NotImplementedException();
        }

        public virtual async Task<IEnumerable<T>> Get()
        {
            await Entities.LoadAsync();
            return Entities;
        }


        public async Task<int> GetCount()
        {
            await Entities.LoadAsync();
            return Entities.Count();
        }

        public virtual async Task Insert(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            
            try
            {
                using (var dbContextTransaction = _context.BeginTransaction())
                {
                    
                    await Entities.AddAsync(entity);

                    //_context.ExecuteSqlCommand(string.Format(@"SET IDENTITY_INSERT {0} ON", _context.GetTableName(entity.GetType())), true);
                    _context.SaveChanges();
                    //_context.ExecuteSqlCommand(string.Format(@"SET IDENTITY_INSERT {0} OFF", _context.GetTableName(entity.GetType())), true);

                    dbContextTransaction.Commit();
                }
            }
            catch (DbUpdateException exception)
            {
                throw new Exception(exception.Message, exception);
            }
        }

        public virtual async Task Update(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            try
            {
                Entities.Update(entity);
            }
            catch (DbUpdateException exception)
            {
                throw new Exception(exception.Message, exception);
            }
        }

        public virtual async Task Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            try
            {
                Entities.Remove(entity);
            }
            catch (DbUpdateException exception)
            {
                throw new Exception(exception.Message, exception);
            }
        }

        public virtual async Task Delete(IEnumerable<T> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            try
            {
                Entities.RemoveRange(entities);
            }
            catch (DbUpdateException exception)
            {
                throw new Exception(exception.Message, exception);
            }
        }

        public virtual async Task<int> Save()
        {
            int i =  _context.SaveChanges();
            return i;
            //return new Task();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            /*
            if (!this.disposed)
                if (disposing)
                    _entities.Dispose();
            */
            this.disposed = true;
        }

        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
