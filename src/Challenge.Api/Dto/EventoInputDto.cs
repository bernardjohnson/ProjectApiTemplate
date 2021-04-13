using System;
using System.ComponentModel.DataAnnotations;

namespace Template.Api.Dto
{
    public class EventoInputDto
    {
        [Key]
        public Guid Id { get; set; }
        [Range(0, 255486129307, ErrorMessage = "Valor máximo do timestamp permitido é 255486129307")]
        public long TimeStamp { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Tag { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [MaxLength(50, ErrorMessage = "O Valor máximo permitido é de {0} caracteres")]
        public string Valor { get; set; }
    }
}
