using EmployerPortal.API.IRepository;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using System;
using EmployerPortal.API.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using EmployerPortal.API.Models;
using X.PagedList;

namespace EmployerPortal.API.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

        private readonly DatabaseContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(DatabaseContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>(); // Get the DbSet Table of Generic T from the Database _context
        }

      



        public async Task Delete(int Id)
        {
            // get the entity
            var entity = await _dbSet.FindAsync(Id);
             _dbSet.Remove(entity);

        }

        public void DeleteRange(IEnumerable<T> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public async Task<T> Get(Expression<Func<T, bool>> expression = null, List<string> includes = null)
        {
            IQueryable<T> query = _dbSet;

            // check if a request to include a foreign key table is passed
            if (includes != null)
            {
                foreach (var includeProperty in includes)
                {
                    query = query.Include(includeProperty);
                }
            }
                //add no tracking to increase efficieny
                // pass the exression which is the where clause to make it dynamic
                // eg q => q.Id == 3
                return await query.AsNoTracking().FirstOrDefaultAsync(expression);

        }

        public async Task<IList<T>> GetAll(Expression<Func<T, bool>> expression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, List<string> includes = null)
        {
            IQueryable<T> query = _dbSet;
            // check if an expression was passed i.e Where clause
            if(expression != null)
            {
                query = query.Where(expression);
            }


            // check if a request to include a foreign key table is passed
            if (includes != null)
            {
                foreach (var includeProperty in includes)
                {
                    query = query.Include(includeProperty);
                }
            }

            // if the order by was requested from the param
            if (orderBy != null)
            {
                query = orderBy(query);
            }
            //add no tracking to increase efficieny
            // pass the exression which is the where clause to make it dynamic
            // eg q => q.Id == 3
            return await query.AsNoTracking().ToListAsync();

        }





        public async Task<IPagedList<T>> GetAll(RequestParams requestParams ,List<string> includes = null  )
        {
            IQueryable<T> query = _dbSet;
            
            // check if a request to include a foreign key table is passed
            if (includes != null)
            {
                foreach (var includeProperty in includes)
                {
                    query = query.Include(includeProperty);
                }
            }

          // query.Skip(requestParams.PageSize); this is to manually do the paging but with IPagedList then it handle it
            //add no tracking to increase efficieny
            // pass the exression which is the where clause to make it dynamic
            // eg q => q.Id == 3
            return await query.AsNoTracking().ToPagedListAsync(requestParams.PageNumber, requestParams.PageSize);

        }




        public  async Task Insert(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task InsertRange(IEnumerable<T> entities)
        {
           await _dbSet.AddRangeAsync(entities);
        }

        public void Update(T entity)
        {
           _dbSet.Attach(entity); // track and find the entity and tract the modification status
            _context.Entry(entity).State = EntityState.Modified; // this will know if it was motified and update automatically


           
        }
    }
}
