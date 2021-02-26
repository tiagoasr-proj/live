using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GerenciadorLives.Models
{
    public partial class Lives
    {
        public Lives()
        {
            Inscricoes = new HashSet<Inscricoes>();
        }

        public int LiveId { get; set; }

        [Display(Name = "Evento")]
        public string Nome { get; set; }
        
        [Display(Name = "Descrição")] 
        public string Descricao { get; set; }
        public int InstrutorId { get; set; }
        public DateTime Data { get; set; }

        [Display(Name = "Duração")] 
        public int Duracao { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Valor { get; set; }

        public virtual Instrutores Instrutor { get; set; }
        public virtual ICollection<Inscricoes> Inscricoes { get; set; }
    }
}
