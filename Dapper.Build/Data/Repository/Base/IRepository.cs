using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Dapper.Build.Models.Base;

namespace Dapper.Build.Data.Repository.Base
{
    public interface IRepository<T> where T: Entity
    {
        Task<T> ById (string id);
        Task<T> By (Expression<Func<T, bool>> predicate);
        Task<bool> Delete (T entity);
        Task<bool> Reverse (T entity);
        Task Insert (T entity);
        Task<IEnumerable<T>> List ();
        Task<IEnumerable<T>> ListBy (Expression<Func<T, bool>> predicate);
        Task<bool> Update (T entity);
        Task ExecuteAsync (string query);
        Task<dynamic> QueryAsync(string query );
    }
}