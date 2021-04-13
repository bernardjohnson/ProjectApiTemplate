using AutoMapper;
using Template.Api.Dto;
using Template.Business.Interfaces;
using Template.Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Template.Api.Controllers
{
    [Route("api/[controller]")]
    public class SensoresController : MainController
    {
        private readonly ISensorRepository _sensorRepository;
        private readonly ISensorService _sensorService;
        private readonly IMapper _mapper;
        public SensoresController(ISensorRepository sensorRepository,
                                ISensorService sensorService,
                                IMapper mapper,
                                INotificador notificador) : base(notificador)
        {
            _sensorRepository = sensorRepository;
            _sensorService = sensorService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<SensorDto>> ListarSensores()
        {
            var result = _mapper.Map<IEnumerable<SensorDto>>(await _sensorRepository.ObterTodos());

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<SensorDto>> Adicionar(SensorDto sensorDto)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _sensorService.Adicionar(_mapper.Map<Sensor>(sensorDto));

            return CustomResponse(sensorDto);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<SensorDto>> Atualizar(Guid id, SensorDto sensorDto)
        {
            if (id != sensorDto.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(sensorDto);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _sensorService.Atualizar(_mapper.Map<Sensor>(sensorDto));

            return CustomResponse(sensorDto);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<SensorDto>> Excluir(Guid id)
        {
            var sensor = await _sensorRepository.ObterPorId(id);

            if (sensor == null) return NotFound();

            await _sensorService.Remover(id);

            return CustomResponse(sensor);
        }
    }
}
