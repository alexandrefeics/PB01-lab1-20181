using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppPB01Lab1_AlexandreA.Models
{
    public class Cliente
    {
       //Primary Key
        public int ClienteId { get; set; }

        [Required(ErrorMessage ="Nome obrigatorio")]
        public string nome { get; set; }

        [Required(ErrorMessage ="CPF obrigatorio")]
        public string CPF { get; set; }

        [Required(ErrorMessage ="E-mail obrigatorio")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Data de Cadastro é obrigatorio")]
        public DateTime DataCadastro { get; set; }

    }
}
