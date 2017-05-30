using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linx.Domain.Mapping.EntityViewModel
{
    public class UsersViewModel
    {
        [Required(ErrorMessage = "Campo obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "UserName", Prompt = "Insira seu usuario cadastrado...")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Campo obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Password", Prompt = "Insira sua senha")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
