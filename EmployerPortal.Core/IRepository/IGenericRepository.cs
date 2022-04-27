using EmployerPortal.Core.DTOs;
using EmployerPortal.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using X.PagedList;

namespace EmployerPortal.Core.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        // a global interface for all common db operations
        // T will be the table or dbset that will be passed to this class to acccess the methods

        // define Get all method to receive a lamba expression, callback function  to order and other includes join
        Task<IList<T>> GetAll(
            Expression<Func<T, bool>> expression = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            List<string> includes = null
            );



        // get all records with paging and no filtering
        Task<IPagedList<T>> GetAll(
           RequestParams requestParams, List<string> includes=null );




        // returns one record
        Task<T> Get(
            Expression<Func<T, bool>> expression = null,
            List<string> includes = null
            );


        // Insert Operation
        Task Insert(T entitiy);

        // Insert multiple record
        Task InsertRange(IEnumerable<T> entities);

        // Delete Record
        Task Delete(int Id);

        //Delete Range of records
        void DeleteRange(IEnumerable<T> entities);

        // Update an entity
        void Update(T entity);






    }
}
