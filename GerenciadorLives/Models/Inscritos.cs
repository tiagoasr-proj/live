﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace GerenciadorLives.Models
{
    public partial class Inscritos
    {
        public Inscritos()
        {
            Inscricoes = new HashSet<Inscricoes>();
        }

        public int InscritoId { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Instagram { get; set; }
        public DateTime DataNascimento { get; set; }

        public virtual ICollection<Inscricoes> Inscricoes { get; set; }
    }
}
