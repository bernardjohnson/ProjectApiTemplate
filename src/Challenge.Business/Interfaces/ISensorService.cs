using Template.Business.Models;
using System;
using System.Threading.Tasks;

namespace Template.Business.Interfaces
{
    public interface ISensorService : IDisposable
    {
        Task<bool> Adicionar(Sensor sensor);
        Task<bool> Atualizar(Sensor sensor);
        Task<bool> Remover(Guid id);
    }
}
