using System;
using System.Threading.Tasks;
using Template.Business.Interfaces;
using Template.Business.Models;
using Template.Business.Models.Validations;

namespace Template.Business.Services
{
    public class SensorService : BaseService, ISensorService
    {
        private readonly ISensorRepository _sensorRepository;
        public SensorService(ISensorRepository sensorRepository,
                             INotificador notificador) : base(notificador)
        {
            _sensorRepository = sensorRepository;
        }

        public async Task<bool> Adicionar(Sensor sensor)
        {
            if (!ExecutarValidacao(new SensorValidation(), sensor)) return false;

            await _sensorRepository.Adicionar(sensor);

            return true;
        }

        public async Task<bool> Atualizar(Sensor sensor)
        {
            if (!ExecutarValidacao(new SensorValidation(), sensor)) return false;

            await _sensorRepository.Atualizar(sensor);

            return true;
        }

        public async Task<bool> Remover(Guid id)
        {
            await _sensorRepository.Remover(id);

            return true;
        }

        public void Dispose()
        {
            _sensorRepository?.Dispose();
        }
    }
}
