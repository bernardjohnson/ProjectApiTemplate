using Template.Business.Interfaces;
using Template.Business.Models;
using Template.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Template.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly TemplateDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(TemplateDbContext dbContext)
        {
            Db = dbContext;
            DbSet = dbContext.Set<TEntity>();
        }

        public async Task Adicionar(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await DbSet.ToListAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }
    }
}
