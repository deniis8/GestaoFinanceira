using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoFinanceira.Data.Dtos
{
    public class ReadLancamentoDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "O Campo DataHora é obrigatório")]
        public DateTime DataHora { get; set; }
        public double Valor { get; set; }
        [Required(ErrorMessage = "O Campo Descricao é obrigatório")]
        [StringLength(100, ErrorMessage = "O limite do campo Descricao é de 100 caracteries")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "O Campo CentroCusto é obrigatório")]
        public int CentroCusto { get; set; }
    }
}
