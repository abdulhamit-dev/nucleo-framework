﻿using Nucleo.Data.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Nucleo.Data
{
    public interface IRepository<T, TKey> where T : class, IEntityBase<TKey>
    {
        Task<T> GetByIdAsync(TKey id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task RemoveAsync(T entity);
        Task RemoveRangeAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity);

        Task<Paginate<T>> FindWithPagingAsync(
        Expression<Func<T, bool>> predicate,
        int pageIndex=0,
        int pageSize=10,
        int from=0,
        Expression<Func<T, object>> orderBy = null,
        bool isDescending = false);

        Task<Paginate<T>> GetAllWithPagingAsync(
            int pageIndex=0,
            int pageSize=10,
            int from=0,
            Expression<Func<T, object>> orderBy = null,
            bool isDescending = false);
    }
}
