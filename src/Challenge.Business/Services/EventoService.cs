using Template.Business.Interfaces;
using Template.Business.Models;
using Template.Business.Models.Validations;
using System.Threading.Tasks;

namespace Template.Business.Services
{
    public class EventoService : BaseService, IEventoService
    {
        private readonly IEventoRepository _eventoRepository;
        private readonly ISensorRepository _sensorRepository;
        public EventoService(IEventoRepository eventoRepository,
                             ISensorRepository sensorRepository,
                                INotificador notificador) : base(notificador)
        {
            _eventoRepository = eventoRepository;
            _sensorRepository = sensorRepository;
        }
        public async Task<bool> Adicionar(Evento evento)
        {
            if (!ExecutarValidacao(new EventoValidation(), evento) ||
                !ExecutarValidacao(new SensorValidation(), evento.Sensor))
            {
                return false;
            }

            var sensor = _sensorRepository.Buscar(f => f.Nome == evento.Sensor.Nome &&
                                                       f.Pais == evento.Sensor.Pais &&
                                                       f.Regiao == evento.Sensor.Regiao);

            if (sensor.Result != null) 
            {
                evento.SensorId = sensor.Result.Id;
                evento.Sensor = null;
            }

            await _eventoRepository.Adicionar(evento);
            
            return true;
        }

        public void Dispose()
        {
            _eventoRepository?.Dispose();
        }
    }
}
