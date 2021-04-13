using System;
using System.Collections.Generic;
using System.Text;

namespace Template.Business.Models
{
    public class Sensor : Entity
    {
        public string Nome { get; set; }
        public string Pais { get; set; }
        public string Regiao { get; set; }
        public IEnumerable<Evento> Eventos { get; set; }
    }
}
