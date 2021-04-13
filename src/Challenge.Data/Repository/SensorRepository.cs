using Template.Business.Interfaces;
using Template.Business.Models;
using Template.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Template.Data.Repository
{
    public class SensorRepository : Repository<Sensor>, ISensorRepository
    {
        public SensorRepository(TemplateDbContext dbContext) : base(dbContext)
        {

        }

        public virtual async Task<Sensor> ObterPorId(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task Atualizar(Sensor entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public async Task<Sensor> Buscar(Expression<Func<Sensor, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).FirstOrDefaultAsync();
        }

        public virtual async Task Remover(Guid id)
        {
            DbSet.Remove(new Sensor { Id = id });
            await SaveChanges();
        }

        
    }
}
