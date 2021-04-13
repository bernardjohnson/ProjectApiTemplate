using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Template.Api.Dto
{
    public class RegisterUserDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Password { get; set; }
        [Compare("Password", ErrorMessage = "Senhas estão diferentes")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginUserDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Email { get; set; }
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Password { get; set; }
    }
}
