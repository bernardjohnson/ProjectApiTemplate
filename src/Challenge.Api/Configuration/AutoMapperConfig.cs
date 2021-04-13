using AutoMapper;
using Template.Api.Dto;
using Template.Business.Models;

namespace Template.Api.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<EventoInputDto, Evento>()
                .ForMember(a => a.Tempo, opt => opt.MapFrom(src => src.TimeStamp.UnixToDateTime()))
                .ForMember(a => a.Valor, opt => opt.MapFrom(src => src.Valor));

            CreateMap<EventoInputDto, Sensor>()
                .ForMember(a => a.Nome, opt => opt.MapFrom(src => src.Tag.Sensor()))
                .ForMember(a => a.Pais, opt => opt.MapFrom(src => src.Tag.Pais()))
                .ForMember(a => a.Regiao, opt => opt.MapFrom(src => src.Tag.Regiao()));

            CreateMap<Relatorio, RelatorioDto>().ReverseMap();
            CreateMap<EventoDto, Evento>().ReverseMap();
            CreateMap<SensorDto, Sensor>().ReverseMap();

        }
    }
}
