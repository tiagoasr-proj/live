using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public bool Pago { get; set; }

        [StringLength(14)] 
        public string Boleto { get; set; }

        public virtual Inscritos Inscrito { get; set; }
        public virtual Lives Live { get; set; }


        public string LinhaBoleto
        {
            get
            {
               
                char preenche = '0';
                var dataBaseBoleto = new DateTime(1997,10,07) ;//'10/07/1997');
                TimeSpan travelTime = Live.Data - dataBaseBoleto;
                return travelTime.Days + GetNumbers(Live.Valor.ToString().PadLeft(10,preenche));
                //intValue.ToString("D8")
            }
        }

        private static string GetNumbers(string input)
        {
            return new string(input.Where(c => char.IsDigit(c)).ToArray());
        }
    }
}
