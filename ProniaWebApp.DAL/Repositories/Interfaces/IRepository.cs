using ProniaWebApp.Core.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProniaWebApp.DAL.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseAuditableEntity
    {
        // CRUD Operations
        Task<T> CreateAsync(T entity);
        Task<IQueryable<T>> ReadAllAsync(
            Expression<Func<T, bool>>? expression = null,
            Expression<Func<T, object>>? orderExpression = null,
            bool isDescending = false,
            params string[] includes
            );
        Task<T> ReadIdAsync(
            Expression<Func<T, bool>>? checkExpression = null,  
            int Id = 0, 
            params string[] entityIncludes
            );
        Task<T> UpdateAsync(T entity);
        Task<T> DeleteAsync(int Id);

        // Model Operations
        Task<int> SaveChangeAsync();
    }
}
