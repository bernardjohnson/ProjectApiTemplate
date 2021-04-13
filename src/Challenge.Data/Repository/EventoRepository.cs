using Template.Business.Interfaces;
using Template.Business.Models;
using Template.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Template.Data.Repository
{
    public class EventoRepository : Repository<Evento>, IEventoRepository
    {
        public EventoRepository(TemplateDbContext dbContext) : base(dbContext)
        {

        }
        

        public async Task<IEnumerable<Evento>> ObterEventosSensores()
        {
            return await Db.Eventos.AsNoTracking()
                .Include(c => c.Sensor).ToListAsync();
        }

        public async Task<IEnumerable<Relatorio>> ObterRelatorio()
        {
            var result = Db.Eventos
                .Join(Db.Sensores, cr => cr.SensorId, bn => bn.Id, (cr, bn) => new { cr, bn })
                .GroupBy(x => new { x.bn.Nome, x.bn.Regiao, x.bn.Pais })
                .Select(g => new Relatorio()
                {
                    Pais = g.Key.Pais,
                    Regiao = g.Key.Regiao,
                    Sensor = g.Key.Nome,
                    Total = g.Count()
                }).ToListAsync();
            return await result;
        }
    }
}
