using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linx.Domain.Mapping.EntityViewModel
{
    public class UserClaimsConsegViewModel
    {        

        [Key]
        public int Id { get; set; }

        public int IdUser { get; set; }

        [Required(ErrorMessage = "Campo obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "NomeCompleto", Prompt = "Insira seu Nome Completo...")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Campo obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Nome", Prompt = "Insira seu primeiro nome...")]
        public string GivenName { get; set; }

        [Required(ErrorMessage = "Campo obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "UserName", Prompt = "Insira seu usuario cadastrado...")]
        public string FamilyName { get; set; }

        [Required(ErrorMessage = "Campo obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Secret", Prompt = "Insira uma palavra que sera criptografada e sera seu token...")]
        public string Secret { get; set; }

        [Required(ErrorMessage = "Campo obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "E-mail", Prompt = "Insira seu email...")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Insira um email valido")]
        public string Email { get; set; }
           
        public bool EmailVerified { get; set; }

        public List<string> Roles { get; set; }
    }
}
