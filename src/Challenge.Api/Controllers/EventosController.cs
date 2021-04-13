using AutoMapper;
using Template.Api.Dto;
using Template.Business.Interfaces;
using Template.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Template.Api.Controllers
{

    [Route("api/[controller]")]
    public class EventosController : MainController
    {
        private readonly IEventoService _eventoService;
        private readonly IEventoRepository _eventoRepository;
        private readonly IMapper _mapper;

        public EventosController(IEventoService eventoService,
                                 IEventoRepository eventoRepository,
                                 IMapper mapper,
                                 INotificador notificador) : base(notificador)
        {
            _eventoService = eventoService;
            _eventoRepository = eventoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<EventoDto>> ListarEventos()
        {
            var result = _mapper.Map<IEnumerable<EventoDto>>(await _eventoRepository.ObterEventosSensores());
            return result;
        }

        [HttpPost]
        public async Task<ActionResult<EventoInputDto>> AdicionarEvento(EventoInputDto eventoDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var sensor = _mapper.Map<Sensor>(eventoDto);
            var evento = _mapper.Map<Evento>(eventoDto);

            evento.Sensor = sensor;

            var result = await _eventoService.Adicionar(evento);

            if (!result) return CustomResponse(ModelState);

            return CustomResponse(eventoDto);
        }

        [HttpGet("relatorio")]
        public async Task<IEnumerable<RelatorioDto>> RelatorioSensores()
        {
            var result = _mapper.Map<IEnumerable<RelatorioDto>>(await _eventoRepository.ObterRelatorio());
            return result;
        }
    }
}