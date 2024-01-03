using Microsoft.EntityFrameworkCore;
using ProniaWebApp.Core.Entities.Common;
using ProniaWebApp.DAL.Context;
using ProniaWebApp.DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProniaWebApp.DAL.Repositories.Implementations
{
    public class Repository<T> : IRepository<T> where T : BaseAuditableEntity, new()
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _table;

        public Repository(AppDbContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public async Task<T> CreateAsync(T entity)
        {
            await _table.AddAsync(entity);

            return entity;
        }

        

        public async Task<IQueryable<T>> ReadAllAsync(
            Expression<Func<T, bool>>? expression = null,
            Expression<Func<T, object>>? orderExpression = null, 
            bool isDescending = false, 
            params string[] includes)
        {
            IQueryable<T> query = _table;

            if(expression is not null) 
            {
                query = query.Where(expression);
            }
            if(orderExpression is not null)
            {
                query = isDescending ? query.OrderByDescending(orderExpression) : query.OrderBy(orderExpression);
            }
            if(includes is not null)
            {
                foreach(var include in includes)
                {
                    query.Include(include);
                }
            }

            return query.Where(x => !x.IsDeleted);

        }

        public async Task<T> ReadIdAsync(
            Expression<Func<T, bool>>? checkExpression = null,
            int Id = 0, params string[] entityIncludes)
        {
            IQueryable<T> query = _table; 

            if(entityIncludes is not null)
            {
                foreach (var include in entityIncludes)
                {
                    query.Include(include);
                }
            }

            if (checkExpression is not null)
            {
                return await query.Where(checkExpression).AsNoTracking().FirstOrDefaultAsync();
            }

            return await query.AsNoTracking().FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _table.Update(entity);

            return entity;
        }
        public async Task<T> DeleteAsync(int Id)
        {
            (await _table.FindAsync(Id)).IsDeleted = true;

            return await _table.FindAsync(Id);
        }

        public async Task<int> SaveChangeAsync()
        {
            var result = await _context.SaveChangesAsync();

            return result;
        }
    }
}
