using Template.Business.Models;
using System;
using System.Threading.Tasks;

namespace Template.Business.Interfaces
{
    public interface IEventoService : IDisposable
    {
        Task<bool> Adicionar(Evento evento);
    }
}
