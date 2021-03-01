using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GerenciadorLives.Models
{
    public partial class Inscricoes
    {
        public int InscricaoId { get; set; }
        public int LiveId { get; set; }
        public int InscritoId { get; set; }
        public bool StatusPagamento { get; set; }
       
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal ValorInscricao { get; set; }
        public DateTime DataVencimento { get; set; }


        public string FatorVencimento
        {
            get
            {
                var dataBaseBoleto = new DateTime(1997, 10, 07);//'10/07/1997');
                TimeSpan fator = DataVencimento - dataBaseBoleto;
                return "00000.00000 00000.000000 00000.000000 0 " + fator.Days + retornaNumeros(ValorInscricao.ToString()).PadLeft(10, '0');
                
            }
        }

        public virtual Inscritos Inscrito { get; set; }
        public virtual Lives Live { get; set; }

        private static string retornaNumeros(string input)
        {
            return new string(input.Where(c => char.IsDigit(c)).ToArray());
        }
    }
}
