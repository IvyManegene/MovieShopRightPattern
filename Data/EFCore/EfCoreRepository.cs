using Microsoft.EntityFrameworkCore;

namespace MovieShopRightPattern.Data.EFCore
{
    public  abstract class EfCoreRepository<TEntity , TContext> : IRepository<TEntity> 
        where TEntity : class,IEntity 
        where TContext : DbContext
    {
        private readonly TContext Context;
        public EfCoreRepository(TContext Context)
        {
            this.Context = Context;
        }

        public async Task<TEntity> Add(TEntity Entity)
        {
            Context.Set<TEntity>().Add(Entity);
            await Context.SaveChangesAsync();
            return Entity;
        }

        public async Task<TEntity> Delete(int id)
        {
            var Entity = await Context.Set<TEntity>().FindAsync(id);

            if (Entity == null)
            { 
                return Entity; 
            }

            Context.Set<TEntity>().Remove(Entity);
            await Context.SaveChangesAsync();

            return Entity;
        }

        public  async Task<TEntity?> Get(int id)
        {
            return await Context.Set<TEntity>().FindAsync(id);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await Context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> Update(TEntity Entity)
        {
            Context.Entry(Entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return Entity;
        }
    }
}
