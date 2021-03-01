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
        [Required(ErrorMessage = "O nome da Live é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Evento")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatório", AllowEmptyStrings = false)]
        [Display(Name = "Descrição")] 
        public string Descricao { get; set; }
        public int InstrutorId { get; set; }

        [Required(ErrorMessage = "Informe a data e horario da Live", AllowEmptyStrings = false)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = false)]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "Informe a duração da Live", AllowEmptyStrings = false)]
        [Display(Name = "Duração")] 
        public int Duracao { get; set; }


        [Required(ErrorMessage = "Somente numeros permitidos", AllowEmptyStrings = false)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Valor { get; set; }

        public virtual Instrutores Instrutor { get; set; }
        public virtual ICollection<Inscricoes> Inscricoes { get; set; }
    }
}
