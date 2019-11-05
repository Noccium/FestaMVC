using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace FestaMVC.Models
{
    public class LoginModel
    {
        [Required(
            AllowEmptyStrings = false,
            ErrorMessage = "O nome é obrigatório!")]
        [Display(Name = "Login")]
        public string campoNome { get; set; }

        [Required(
            AllowEmptyStrings = false,
            ErrorMessage = "A senha é obrigatória!")]
        [Display(Name = "Senha")]
        public string campoSenha { get; set; }
    }
}