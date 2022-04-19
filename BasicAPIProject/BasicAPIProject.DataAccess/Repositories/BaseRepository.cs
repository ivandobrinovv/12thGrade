using Microsoft.EntityFrameworkCore;
using BasicAPIProject.DataAccess.Entities;
using BasicAPIProject.DataAccess.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BasicAPIProject.DataAccess.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly PracticalAssignmentDbContext context;

        public BaseRepository(PracticalAssignmentDbContext context)
        {
            this.context = context;
        }

        public virtual async Task<ICollection<T>> GetAllAsync()
        {
            return  await context.Set<T>().ToListAsync();
        }

        public virtual async Task<ICollection<T>> GetAllAsync(Expression<Func<T, bool>> filter)
        {
            return await context.Set<T>().Where(filter).ToListAsync();
        }

        public virtual async ValueTask<T> GetByIdAsync(Guid id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public virtual async Task<Guid> CreateAsync(T entity)
        {
            var entry = context.Set<T>().Add(entity);
            await context.SaveChangesAsync();

            return entry.Entity.Id;
        }

        public virtual async Task UpdateAsync(T entity)
        {
            var dbEntity = await GetByIdAsync(entity.Id);

            if (dbEntity == null)
            {
                throw new ArgumentException($"No such {typeof(T)} with id: {entity.Id}");
            }

            context.Entry(dbEntity).CurrentValues.SetValues(entity);

            await context.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);

            if (entity == null)
            {
                throw new ArgumentException($"No such {typeof(T)} with id: {id}");
            }

            context.Remove(entity);

            await context.SaveChangesAsync();
        }
    }
}
