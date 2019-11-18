using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Dapper.Build.Models.Base;
using Dommel;

namespace Dapper.Build.Data.Repository.Base {
    public class Repository<T> : IRepository<T> where T : Entity {

        private DapperContext _db;

        public Repository (DapperContext db) {
            _db = db;
        }

        public async Task<T> ById (string id) {
            return await _db.Connection.GetAsync<T> (id);
        }

        public async Task<T> By (Expression<Func<T, bool>> predicate) {
            return await _db.Connection.FirstOrDefaultAsync (predicate);
        }

        public async Task<bool> Delete (T entity) {
            return await _db.Connection.DeleteAsync (entity);
        }

        public async Task<bool> Reverse (T entity) {
            entity.IsDeleted = !entity.IsDeleted;
            entity.UpdatedAt = DateTimeOffset.Now;
            return await _db.Connection.UpdateAsync (entity);
        }

        public async Task Insert (T entity) {
            await _db.Connection.InsertAsync (entity);
        }

        public async Task<IEnumerable<T>> List () {
            return await _db.Connection.GetAllAsync<T> ();
        }

        public async Task<IEnumerable<T>> ListBy (Expression<Func<T, bool>> predicate) {
            return await _db.Connection.SelectAsync (predicate);
        }

        public async Task<bool> Update (T entity) {
            entity.UpdatedAt = DateTimeOffset.Now;
            return await _db.Connection.UpdateAsync (entity);
        }

        public async Task ExecuteAsync (string query) {
            await _db.Connection.ExecuteAsync (query);
        }

        public async Task<dynamic> QueryAsync (string query) {
            return await _db.Connection.QueryAsync (query);
        }
    }
}