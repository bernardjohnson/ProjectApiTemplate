using System;
using System.ComponentModel.DataAnnotations;

namespace Template.Api.Dto
{
    public class EventoDto
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime Tempo { get; set; }
        public decimal Valor { get; set; }
        public SensorDto Sensor { get; set; }
        public Guid SensorId { get; set; }
    }
}
