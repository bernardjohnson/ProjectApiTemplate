using System;

namespace Template.Business.Models
{
    public class Evento : Entity
    {
        public Guid SensorId { get; set; }
        public DateTime Tempo { get; set; }
        public decimal Valor { get; set; }
        public Sensor Sensor { get; set; }
    }
}
