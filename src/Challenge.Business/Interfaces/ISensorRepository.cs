using Template.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Template.Business.Interfaces
{
    public interface ISensorRepository : IRepository<Sensor>
    {
        Task Atualizar(Sensor entity);
        Task Remover(Guid id);
        Task<Sensor> ObterPorId(Guid id);
        Task<Sensor> Buscar(Expression<Func<Sensor, bool>> predicate);
    }
}
