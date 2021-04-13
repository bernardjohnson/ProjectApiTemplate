using System;
using System.ComponentModel.DataAnnotations;

namespace Template.Api.Dto
{
    public class SensorDto
    {
        [Key]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Pais { get; set; }
        public string Regiao { get; set; }
    }
}
