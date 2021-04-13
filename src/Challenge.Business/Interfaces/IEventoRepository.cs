using Template.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Template.Business.Interfaces
{
    public interface IEventoRepository : IRepository<Evento>
    {
        Task<IEnumerable<Evento>> ObterEventosSensores();
        Task<IEnumerable<Relatorio>> ObterRelatorio();
    }

}
